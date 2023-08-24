using FruitShopping.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FruitShopping.Areas.Admin.Models.ViewModel
{
	public class ProductDetailDTO
	{
		public ProductDetailDTO() { }
		public int ProductId { get; set; }

		public string ProductName { get; set; }

		public string ProductDescription { get; set; }

		public decimal CostPrice { get; set; }

		public decimal UnitPrice { get; set; }

		public string CategoryName { get; set; }

		public string SupplierName { get; set; }

		public string PlaceOfOriginName { get; set; }

		public string ImagePath { get; set; }
	}
}
