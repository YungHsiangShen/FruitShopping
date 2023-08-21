using FruitShopping.Areas.Admin.Models.ViewModel;
using FruitShopping.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Linq;

namespace FruitShopping.Areas.Admin.Controllers.ApiController
{
	[EnableCors("AllowAny")]
	[Route("api/ProductApi")]
	[ApiController]
	public class ProductApiController : ControllerBase
	{
		private readonly FruitShoppingDbContext _db;

		public ProductApiController(FruitShoppingDbContext context)
		{
			_db = context;
		}

		//GET: api/ ProductApi
		[HttpGet]
		public async Task<IEnumerable<ProductsManagershowDTO>> GetAllProducts()
		{
			return _db.Products
			.Include(c => c.Category)
			.Include(p => p.Supplier)
			.Select(p => new ProductsManagershowDTO
			{
				ProductId = p.ProductId,
				ProductName = p.ProductName,
				CostPrice = p.CostPrice,
				UnitPrice = p.UnitPrice,
				CategoryName = p.Category.CategoryName,
				SupplierName = p.Supplier.ContactName,
				PlaceOfOriginName = p.PlaceOfOrigin.Name
			});
		}
	}
}
