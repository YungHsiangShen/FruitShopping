using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace FruitShopping.Models
{
	[Table("Collects")]
	[PrimaryKey(nameof(CollectId),nameof(ProductId),nameof(Id))]
	public class Collerct
	{
		public Collerct() { }
		
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]			
		public int CollectId { get; set; }
				
		public int ProductId { get; set; }
		
		[ForeignKey(nameof(IdentityUser))]
		public string Id { get; set; }

		public virtual IdentityUser IdentityUser { get; set; }
	}
}
