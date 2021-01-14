using System.Collections.Generic;
using System.Threading.Tasks;
using WishList.Data.Models;

namespace WishList.Data.Services.Interfaces
{
	public interface IWishListRecordService
	{
		Task<List<WishListRecord>> GetOwnedWishLists(int ownerId);
		Task<WishListRecord> GetWishListByReferenceId(string referenceId);
		Task AddWishList(WishListRecord wishList);
		Task UpdateWishList(WishListRecord wishList);
	}
}
