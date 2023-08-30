using FruitShopping.Areas.Admin.Models.ViewModel;
using FruitShopping.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Nodes;

namespace FruitShopping.Areas.Admin.Controllers.ApiController
{
    [EnableCors("AllowAny")]
	[Route("api/ProductApi/{action}")]
	[ApiController]
	public class ProductApiController : ControllerBase
	{
		private readonly FruitShoppingDbContext _db;
		private readonly IWebHostEnvironment _webhost;

		public ProductApiController(FruitShoppingDbContext context, IWebHostEnvironment webHost)
		{
			_db = context;
			_webhost = webHost;
		}

		//GET: api/ ProductApi
		[HttpGet]
		public  IEnumerable<CategoryDTO> GetCategoryOptions()
		{
			return _db.Categories.Select(c => new CategoryDTO { CategoryName = c.CategoryName } );
		}

		[HttpGet]
		public IEnumerable<SupplierDTO> GetSupplierOption()
		{
			return _db.Suppliers.Select(s => new SupplierDTO { SupplierName = s.CompanyName });
		}

		[HttpGet]
		public IEnumerable<PlaceOfOriginDTO> GetPlaceOfOriginOption()
		{
			return _db.placeOfOrigins.Select(p => new PlaceOfOriginDTO { PlaceOfOriginName = p.Name });
		}
		//POST:api/ProductApi("Filter")
		[HttpPost("FilterProduct")]
		public async Task<IEnumerable<ShowProductDTO>> FilterProduct([FromBody] ShowProductDTO pmDTO)
		{
			return _db.Products
		   .Include(p => p.Category)
		   .Include(p => p.Supplier)
		   .Where(p =>
			   p.ProductId == pmDTO.ProductId ||
			   p.ProductName.Contains(pmDTO.ProductName) ||
			   p.Category.CategoryName == pmDTO.CategoryName ||
			   p.Supplier.CompanyName == pmDTO.SupplierName ||
			   p.PlaceOfOrigin.Name == pmDTO.PlaceOfOriginName
		   //         p.CostPrice >= pmDTO.CostPrice ||
		   //p.UnitPrice >= pmDTO.UnitPrice )
		   ).Select(p => new ShowProductDTO
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
			if (id != pdDTO.ProductId)
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

		[HttpPost("ProductDetailDTO")]
		public async Task<string> CreateProduct([FromBody] ProductDetailDTO pdDTO)
		{
			if (pdDTO == null)
			{
				return "新增資料不能為空";
			}

			var category = await _db.Categories.FirstOrDefaultAsync(c => c.CategoryName == pdDTO.CategoryName);
			var supplier = await _db.Suppliers.FirstOrDefaultAsync(s => s.CompanyName == pdDTO.SupplierName);
			var placeOfOrigin = await _db.placeOfOrigins.FirstOrDefaultAsync(p => p.Name == pdDTO.PlaceOfOriginName);

			if (pdDTO.ProductName != null &&
				pdDTO.ProductDescription != null &&
				pdDTO.CostPrice > 0 &&
				pdDTO.UnitPrice == pdDTO.CostPrice * 3 &&
				pdDTO.CategoryName == category.CategoryName &&
				pdDTO.SupplierName == supplier.CompanyName &&
				pdDTO.PlaceOfOriginName == placeOfOrigin.Name)
			{
				Product pro = new Product();
				pro.ProductName = pdDTO.ProductName;
				pro.ProductDescription = pdDTO.ProductDescription;
				pro.CostPrice = pdDTO.CostPrice;
				pro.UnitPrice = pdDTO.UnitPrice;
				pro.CategoryId = category.CategoryId;
				pro.SupplierId = supplier.SupplierId;
				pro.PlaceOfOriginId = placeOfOrigin.Id;

				try
				{
					_db.Products.Add(pro);
					await _db.SaveChangesAsync();
				}
				catch (DbUpdateException ex)
				{
					return "新增產品失敗";
				}
			}
			return "新增產品成功";
		}

		[HttpDelete("{id}")]
		public async Task<string> DeleteProduct(int id)
		{
			var productId = await _db.Products.FindAsync(id);
			if (productId == null)
			{
				return "刪除商品失敗，請聯絡系統管理員";
			}
			try
			{
				_db.Products.Remove(productId);
				await _db.SaveChangesAsync();
				return "刪除商品成功";
			}
			catch (Exception)
			{
				return "刪除商品失敗，請聯絡系統管理員";
			}
		}
		private bool ProductExists(int ProductId)
		{
			return (_db.Products?.Any(p => p.ProductId == ProductId)).GetValueOrDefault();
		}
	}
}
