using System;

namespace WishList.Data.Models
{
	public class WishListEntry
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string BackingUrl { get; set; }
		public DateTime DateAdded { get; set; }
		public bool MarkedOff { get; set; }
		public DateTime DateMarkedOff { get; set; }
	}
}
