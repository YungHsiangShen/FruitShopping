using NuGet.Packaging.Signing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FruitShopping.Models
{
	[Table("ProductComments")]
	public class ProductComment
	{
		public ProductComment() { }
		
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ProductCommentId { get; set; }
		
		[Column(TypeName ="nvarchar")]
		[MaxLength(450)]
		public string Id { get; set; }
		
		[ForeignKey(nameof(Product))]
		public int ProductId { get; set; }
		
		[Column(TypeName ="nvarchar")]
		[MaxLength(2000)]
		public string CommentContent { get; set; }

		public DateTime Timestamp { get; set; }

		public  float Rating { get; set; }

		public virtual Product Product { get; set; }
	}
}
