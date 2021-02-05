using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WishList.Data.Models;

namespace WishList.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public DbSet<WishListRecord> WishLists { get; set; }
		public DbSet<WishListEntry> WishListEntries { get; set; }
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<WishListRecord>()
				.Property(w => w.ReferenceId)
				.HasDefaultValueSql("newid()");
		}
	}
}
