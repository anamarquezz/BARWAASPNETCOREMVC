using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LittlePacktBookstore.Models
{
    public class Book
    {
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage ="Title is required")]
		[Display(Name ="Book Title"), MinLength(2,ErrorMessage ="Minimum length is 2 chars")]
		public string Title { get; set; }

		public string Description { get; set; }
		public string Author { get; set; }
		public string PublishDate { get; set; }

		[DataType(DataType.Currency, ErrorMessage ="Please enter correct price.")]
		public double Price { get; set; }

		public string image { get; set; }
	}
}
