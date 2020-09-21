using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LittlePacktBookstore.Models
{
    public class Carousel
    {
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage ="Image Url Required.")]
		public string ImageURL { get; set; }
		[Required(ErrorMessage ="Title is required.")]
		public string Title { get; set; }
		public string Description { get; set; }
	}
}
