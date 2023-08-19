using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FruitShopping.Models
{
	[Table("Categories")]
	public class Category
	{
		public Category() { }
		
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CategoryId { get; set; }
		
		[Column(TypeName ="nvarchar")]
		[MaxLength(50)]
		public string CategoryName { get; set; }

		public virtual ICollection<Product> Products { get; set; }
    }
}
