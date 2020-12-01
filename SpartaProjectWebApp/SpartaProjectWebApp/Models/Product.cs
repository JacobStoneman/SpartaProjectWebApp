using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpartaProjectWebApp.Models
{
	public class Product
	{
		public int ProductId { get; set; }
		[StringLength(60, MinimumLength = 3)]
		[Required]
		public string Name { get; set; }

		[Range(1, 100)]
		[DataType(DataType.Currency)]
		[Column(TypeName = "decimal(18, 2)")]
		public decimal Price { get; set; }

		[RegularExpression(@"(http(s)?:\/\/.)?(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)")]
		[Required]
		public string Url { get; set; }

		[RegularExpression(@"[+]?([0-4]*\.[0-9]+|[0-5])")]
		[Display(Name = "Average Rating")]
		public float AverageRating { get; set; }

		[StringLength(60, MinimumLength = 3)]
		[Required]
		public string Category { get; set; }
	}
}
