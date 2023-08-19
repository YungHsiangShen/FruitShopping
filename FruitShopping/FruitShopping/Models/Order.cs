using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FruitShopping.Models
{
	[Table("Orders")]
	public class Order
	{
		public Order() { }
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int OrderId { get; set; }

		[Column(TypeName ="nvarchar")]
		[MaxLength(200)]
		public string Address { get; set; }

		[ForeignKey(nameof(IdentityUser))]
		public string Id { get; set; }

		[Column(TypeName ="nvarchar")]
		[MaxLength (200)]
		public string Remark { get; set; }
		public DateTime OrderDate { get; set; }

		[Column(TypeName = "nvarchar")]
		[MaxLength(50)]
		public string PaymentMethodType { get; set; } 
		
		public virtual IdentityUser IdentityUser { get; set; }
	}
}
