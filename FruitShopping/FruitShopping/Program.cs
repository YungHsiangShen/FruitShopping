using FruitShopping.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FruitShopping
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
			builder.Services.AddDbContext<FruitShoppingDbContext>(options =>
				options.UseLazyLoadingProxies().UseSqlServer(connectionString));
			
			builder.Services.AddDatabaseDeveloperPageExceptionFilter();

			var MyAllowSpecifficOrigina = "AllowAny";
			builder.Services.AddCors(option =>
				option.AddPolicy(
					name: MyAllowSpecifficOrigina,
					policy =>
					policy.AllowAnyOrigin()
					.WithHeaders("*")
					.WithMethods("*")
					)
			);

			builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
				.AddEntityFrameworkStores<FruitShoppingDbContext>();
			
			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseMigrationsEndPoint();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseFileServer();

			app.UseRouting();

			app.UseCors();

			app.UseAuthorization();

			app.MapControllerRoute(
			name: "areas",
			pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");
			app.MapRazorPages();

			

			app.Run();
		}
	}
}