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
		private readonly IWebHostEnvironment _webhost;

		public ProductApiController(FruitShoppingDbContext context , IWebHostEnvironment webHost)
		{
			_db = context;
			_webhost = webHost;
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
			return _db.Products
		   .Include(p => p.Category)
		   .Include(p => p.Supplier)
		   .Where(p =>
			   p.ProductId == pmDTO.ProductId ||
			   p.ProductName.Contains(pmDTO.ProductName) ||
			   p.Category.CategoryName == pmDTO.CategoryName ||
			   p.Supplier.CompanyName == pmDTO.SupplierName ||
			   (p.CostPrice >= pmDTO.CostPrice) ||
			   (p.UnitPrice >= pmDTO.UnitPrice ||
			   p.PlaceOfOrigin.Name == pmDTO.PlaceOfOriginName))
		   .Select(p => new ProductsManagershowDTO
		   {
			   ProductId = p.ProductId,
			   ProductName = p.ProductName,
			   CategoryName = p.Category.CategoryName,
			   SupplierName = p.Supplier.CompanyName,
			   CostPrice = p.CostPrice,
			   UnitPrice = p.UnitPrice,
			   PlaceOfOriginName = p.PlaceOfOrigin.Name
		   });
		}

		[HttpGet("{id}")]
		public async Task<ProductDetailDTO> GetProductDetail(int id)
		{
			var productId = await _db.Products.FindAsync(id);

			if (productId == null)
			{
				return null;
			}

			ProductDetailDTO pdDTO = new ProductDetailDTO
			{
				ProductId = productId.ProductId,
				ProductName = productId.ProductName,
				ProductDescription = productId.ProductDescription,
				CostPrice = productId.CostPrice,
				UnitPrice = productId.UnitPrice,
				CategoryName = productId.Category.CategoryName,
				SupplierName = productId.Supplier.CompanyName,
				PlaceOfOriginName = productId.PlaceOfOrigin.Name,
				ImagePath = Path.Combine("\\", productId.ImagePath)
			};
			return pdDTO;
		}

		[HttpPut("ProductDetailDTO/{id}")] 
		public async Task<string> UpdateProduct(int id, ProductDetailDTO pdDTO)
		{ 
			var updateProduct = await _db.Products.FindAsync(pdDTO.ProductId);
			if (id != pdDTO.ProductId ) 
			{
				return "未找到該產品";
			}

			Product product = await _db.Products.FindAsync(id);

			product.ProductName = pdDTO.ProductName;
			product.ProductDescription = pdDTO.ProductDescription;
			product.CostPrice = pdDTO.CostPrice;
			product.UnitPrice = pdDTO.UnitPrice;
			product.Category.CategoryName = pdDTO.CategoryName;
			product.Supplier.CompanyName = pdDTO.SupplierName;
			product.PlaceOfOrigin.Name = pdDTO.PlaceOfOriginName;
			product.ImagePath = pdDTO.ImagePath;
			
			_db.Entry(product).State = EntityState.Modified;
			try
			{
				await _db.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ProductExists(id))
				{
					return "更新產品資訊失敗";
				}
				else
				{
					throw;
				} 
			}
			return "更新產品資訊成功";
		}
		private bool ProductExists(int ProductId)
		{
			return (_db.Products?.Any(p => p.ProductId == ProductId)).GetValueOrDefault();
		}
	}
}
