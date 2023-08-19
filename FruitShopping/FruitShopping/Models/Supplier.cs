using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FruitShopping.Models
{
	[Table("Suppliers")]
	public class Supplier
	{
		public Supplier() { }
		
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int SupplierId { get; set; }
		
		[Column(TypeName ="nvarchar")]
		[MaxLength(50)]
		public string CompanyName { get; set; }
		
		[Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string ContactName { get; set; }

		[Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string ContactTitle { get; set; }

		[Column(TypeName = "nvarchar")]
        [MaxLength(200)]
        public string Address { get; set; }

		[Column(TypeName = "nvarchar")]
        [MaxLength(200)]
        public string City { get; set; }

		[Column(TypeName = "nvarchar")]
        [MaxLength(200)]
        public string Region { get; set; }

		[Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string Phone { get; set; }

		[Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string Fax { get; set; }

		[MaxLength(8)]
		public int UBN { get; set; }

		public virtual ICollection<Product> Products { get; set; }
	}
}
