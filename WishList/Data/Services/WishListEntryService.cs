using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WishList.Data.Models;
using WishList.Data.Services.Interfaces;

namespace WishList.Data.Services
{
	public class WishListEntryService : IWishListEntryService
	{
		private ApplicationDbContext Database { get; }

		public WishListEntryService(ApplicationDbContext database)
		{
			Database = database;
		}
		public async Task AddWishListEntry(WishListEntry wishListEntry)
		{
			wishListEntry.DateAdded = DateTime.UtcNow;

			await Database.WishListEntries.AddAsync(wishListEntry);

			await Database.SaveChangesAsync();
		}

		public async Task UpdateWishListEntry(WishListEntry wishListEntry)
		{
			Database.WishListEntries.Update(wishListEntry);

			await Database.SaveChangesAsync();
		}

		public async Task UpdateMarkedOff(int wishListEntryId, bool markedOff)
		{
			var wishListEntry = await Database.WishListEntries.FirstOrDefaultAsync(x => x.Id == wishListEntryId);

			if (wishListEntry == null)
			{
				throw new Exception("Unable to update wish list entry - entry does not exist");
			}

			wishListEntry.MarkedOff = markedOff;
			wishListEntry.DateMarkedOff = DateTime.UtcNow;

			await Database.SaveChangesAsync();
		}

		public async Task DeleteWishListEntry(int wishListEntryId)
		{
			var wishListEntry = await Database.WishListEntries.FirstOrDefaultAsync(x => x.Id == wishListEntryId);

			if (wishListEntry == null)
			{
				throw new Exception("Unable to delete wish list entry - entry does not exist");
			}

			Database.Remove(wishListEntry);
		}
	}
}
