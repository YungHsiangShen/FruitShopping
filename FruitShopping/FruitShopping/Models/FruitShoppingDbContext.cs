using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FruitShopping.Models
{
	public class FruitShoppingDbContext :IdentityDbContext
	{
		public FruitShoppingDbContext() { }

		public FruitShoppingDbContext(DbContextOptions<FruitShoppingDbContext> options ) : base( options ) { }

		public DbSet<Category> Categories { get; set; }
		public DbSet<Collerct> Collercts { get; set; }
		public DbSet<InStock> InStocks { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ShoppingCart> ShoppingCarts { get; set; }
		public DbSet<Supplier> Suppliers { get; set; }
		public DbSet<UpDataType> UpDataTypes { get; set; }
		public DbSet<PlaceOfOrigin> placeOfOrigins { get; set; }

		public DbSet<ProductComment> ProductComments { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				IConfigurationRoot Config = new ConfigurationBuilder()
					.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
					.AddJsonFile("appsetting.json")
					.Build();
				optionsBuilder.UseLazyLoadingProxies().UseSqlServer(Config.GetConnectionString("DefaultConnection"));
			}
		}
	}
}
