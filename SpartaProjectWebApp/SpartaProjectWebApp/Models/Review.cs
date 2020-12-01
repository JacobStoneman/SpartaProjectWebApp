using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpartaProjectWebApp.Models
{
	public class Review
	{
        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [RegularExpression(@"[+]?([0-4]*\.[0-9]+|[0-5])")]
        [Display(Name = "Rating")]
        public float Rating { get; set; }

        [StringLength(5000,MinimumLength = 3)]
        [Required]
        public string Comment { get; set; }
    }
}
