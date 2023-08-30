using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace FruitShopping.Models
{
	[Table("Collects")]
	[PrimaryKey(nameof(CollectId),nameof(ProductId),nameof(UserId))]
	public class Collerct
	{
		public Collerct() { }
		
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]			
		public int CollectId { get; set; }

		[ForeignKey(nameof(Models.Users))]
		public int UserId { get; set; }

		public int ProductId { get; set; }
		
		public virtual  Users Users { get; set; }
	}
}
