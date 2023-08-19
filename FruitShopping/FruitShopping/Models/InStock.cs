using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FruitShopping.Models
{
	[Table("InStocks")]
	public class InStock
	{
		public InStock() { }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int InStockId { get; set; }

		[ForeignKey(nameof(Product))]
		public int ProductId { get; set; }

		public DateTime UpdateTime { get; set; }

		[ForeignKey(nameof(UpDataType))]
		public int UpDataTypeId { get; set; }

		public int StockQuantity { get; set; }


	}
}
