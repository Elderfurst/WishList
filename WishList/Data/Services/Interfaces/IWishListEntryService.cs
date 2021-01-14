using System.Threading.Tasks;
using WishList.Data.Models;

namespace WishList.Data.Services.Interfaces
{
	public interface IWishListEntryService
	{
		Task AddWishListEntry(WishListEntry wishListEntry);
		Task UpdateWishListEntry(WishListEntry wishListEntry);
		Task UpdateMarkedOff(int wishListEntryId, bool markedOff);
		Task DeleteWishListEntry(int wishListEntryId);
	}
}
