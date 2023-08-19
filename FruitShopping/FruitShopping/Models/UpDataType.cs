using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FruitShopping.Models
{
	[Table("UpDataTypes")]
	public class UpDataType
	{
		public UpDataType() { }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int UpDataTypeId { get; set; }
	
		public string UpDataTypeName { get; set; }
	}
}
