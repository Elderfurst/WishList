using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WishList.Data.Models
{
	public class WishListRecord
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public Guid ReferenceId { get; set; }
		public int OwnerId { get; set; }
		public string Name { get; set; }
		public bool Private { get; set; }
		public IEnumerable<WishListEntry> Entries { get; set; }
	}
}
