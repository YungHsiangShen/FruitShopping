using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace FruitShopping.Models
{
	public class PlaceOfOrigin
	{
		public PlaceOfOrigin() { }

		[Key]
		public int Id { get; set; }
		public string? Name { get; set; }

		public virtual ICollection<Product> Products { get; set; }
	}
}
