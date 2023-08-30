using Microsoft.Build.ObjectModelRemoting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace FruitShopping.Models
{
	[Table("Users")]
	public class Users
	{
		public Users() { }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int UserId { get; set; }

		public string UserName { get; set; }

		public string Password { get; set; }

		[EmailAddress]
		public string Email { get; set; }

		public string? Salt { get; set; }

		public string? ConfirmeEmail { get; set; }

		public string? Phone { get; set; }

		public string? Gerder { get; set; }

		public string? Address { get; set; }

		public DateTime? BirthDay { get; set; }

		public int? Age { get; set; }

		public virtual ICollection<Collerct> Collercts { get; set; }
		public virtual ICollection<Order> Orders { get; set; }
		public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
	}
}
