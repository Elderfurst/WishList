using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WishList.Data.Models;
using WishList.Data.Services.Interfaces;

namespace WishList.Data.Services
{
	public class WishListRecordService : IWishListRecordService
	{
		private ApplicationDbContext Database { get; }

		public WishListRecordService(ApplicationDbContext database)
		{
			Database = database;
		}

		public async Task<List<WishListRecord>> GetOwnedWishLists(int ownerId)
		{
			return await Database.WishLists.Where(x => x.OwnerId == ownerId).ToListAsync();
		}

		public async Task<WishListRecord> GetWishListByReferenceId(string referenceId)
		{
			var parsedGuid = Guid.Parse(referenceId);

			return await Database.WishLists.FirstOrDefaultAsync(x => x.ReferenceId == parsedGuid);
		}

		public async Task AddWishList(WishListRecord wishList)
		{
			await Database.WishLists.AddAsync(wishList);

			await Database.SaveChangesAsync();
		}

		public async Task UpdateWishList(WishListRecord wishList)
		{
			Database.WishLists.Update(wishList);

			await Database.SaveChangesAsync();
		}

		public async Task DeleteWishList(int wishListId)
		{
			var wishList = await Database.WishLists.FirstOrDefaultAsync(x => x.Id == wishListId);

			if (wishList == null)
			{
				throw new Exception("Unable to delete wish list - wish list does not exist");
			}

			Database.WishLists.Remove(wishList);

			await Database.SaveChangesAsync();
		}
	}
}
