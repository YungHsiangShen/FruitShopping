using Microsoft.Build.ObjectModelRemoting;

namespace FruitShopping.Areas.Admin.Models.ViewModel
{
    public class ProductsManagershowDTO
    {
        public ProductsManagershowDTO() { }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal CostPrice { get; set; }
        public decimal UnitPrice { get; set; }
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }
        public string PlaceOfOriginName { get; set; }
    }
}
