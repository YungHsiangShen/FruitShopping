using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FruitShopping.Models
{
	[Table("Products")]
	public class Product
	{
		public Product() { }
		
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ProductId { get; set; }
		
		[Column(TypeName ="nvarchar")]
		[MaxLength(50)]
		public string ProductName { get; set; }
		
		[Column(TypeName = "nvarchar")]
        [MaxLength(2000)]
        public string? ProductDescription { get; set; }

		[Column(TypeName ="decimal(16,2)")]
		public decimal CostPrice { get; set; }

		[Column(TypeName = "decimal(16,2)")]
		public decimal UnitPrice { get; set; }
		
		[ForeignKey(nameof(Category))]
		public int CategoryId { get; set; }

		[ForeignKey(nameof(Supplier))]
		public int SupplierId { get; set; }
		
		[Column(TypeName = "nvarchar")]
		[MaxLength(50)]
		public string? UnitStock { get; set; }

		[ForeignKey(nameof(PlaceOfOrigin))]
        public int? PlaceOfOriginId { get; set; }

		[ForeignKey(nameof(InStock))]
		public int InStockId { get; set; }

		public string ImagePath { get; set; }

		public virtual Supplier Supplier { get; set; }

		public virtual Category Category { get; set; }

		public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }

		public virtual PlaceOfOrigin PlaceOfOrigin { get; set; }

	}
}
