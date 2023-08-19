using Microsoft.Build.ObjectModelRemoting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing.Printing;

namespace FruitShopping.Models
{
	[Table("OrderDetails")]
	public class OrderDetail
	{
		public OrderDetail() { }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int OrderDetailId { get; set; }

		[ForeignKey(nameof(Order))]
		public int OrderId { get; set; }

		public int ProductId { get; set; }

		[Column(TypeName = "decimal(16,2)")]
		public decimal UnitPrice { get; set; }
		
		public int Quantity { get; set; }

		[Column(TypeName ="decimal(16,2)")]
		public decimal Total { get ; set; }

		public float? Discount { get; set; }

		public virtual Order Order { get; set; }
	}
}
