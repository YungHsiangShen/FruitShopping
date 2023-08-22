using FruitShopping.Areas.Admin.Models.ViewModel;
using FruitShopping.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace FruitShopping.Areas.Admin.Controllers.ApiController
{
	[EnableCors("AllowAny")]
	[Route("api/ProductApi/{action}")]
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
			.Include(p => p.Category)
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

		//POST:api/ProductApi("Filter")
		[HttpPost("FilterProduct")]
		public async Task<IEnumerable<ProductsManagershowDTO>> FilterProduct([FromBody] ProductsManagershowDTO pmDTO)
		{
			var query = _db.Products
		   .Include(p => p.Category)
		   .Include(p => p.Supplier)
		   .Where(p =>
			   p.ProductId == pmDTO.ProductId ||
			   p.ProductName.Contains(pmDTO.ProductName) ||
			   p.Category.CategoryName.Contains(pmDTO.CategoryName) ||
			   p.Supplier.ContactName.Contains(pmDTO.SupplierName) ||
			   (p.CostPrice >= pmDTO.CostPrice) ||
			   (p.UnitPrice >= pmDTO.UnitPrice) ||
			   p.PlaceOfOrigin.Name.Contains(pmDTO.PlaceOfOriginName))
		   .Select(p => new ProductsManagershowDTO
			{
				ProductId = p.ProductId,
				ProductName = p.ProductName,
				CategoryName = p.Category.CategoryName,
				SupplierName = p.Supplier.ContactName,
				CostPrice = p.CostPrice,
				UnitPrice = p.UnitPrice,
				PlaceOfOriginName = p.PlaceOfOrigin.Name
			});
			return query;
		}
	}
}
