using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WishList.Config;
using WishList.Data;
using WishList.Data.Services;
using WishList.Data.Services.Interfaces;

namespace WishList
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Build settings from each configuration section and register as singletons.
			var appSettings = Configuration.GetSection("Config").Get<AppSettings>();
			var authenticationSettings = Configuration.GetSection("Authentication").Get<AuthenticationSettings>();

			services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(appSettings.DatabaseConnectionString));

			services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

			// Register our services
			services.AddScoped<IWishListRecordService, WishListRecordService>();
			services.AddScoped<IWishListEntryService, WishListEntryService>();
			
			services.AddControllersWithViews();
			services.AddRazorPages();

			// Add our authentication providers
			services.AddAuthentication()
				.AddFacebook(facebookOptions =>
				{
					facebookOptions.AppId = authenticationSettings.Facebook.AppId;
					facebookOptions.AppSecret = authenticationSettings.Facebook.AppSecret;
					facebookOptions.AccessDeniedPath = "/Home/Error";
				})
				.AddTwitter(twitterOptions =>
				{
					twitterOptions.ConsumerKey = authenticationSettings.Twitter.ConsumerKey;
					twitterOptions.ConsumerSecret = authenticationSettings.Twitter.ConsumerSecret;
					twitterOptions.RetrieveUserDetails = true;
				});

			// Set our default policy to require authentication
			services.AddAuthorization(options =>
			{
				options.FallbackPolicy = new AuthorizationPolicyBuilder()
					.RequireAuthenticatedUser()
					.Build();
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
				endpoints.MapRazorPages();
			});
		}
	}
}
