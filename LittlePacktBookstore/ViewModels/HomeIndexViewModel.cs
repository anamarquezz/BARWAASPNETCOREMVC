using LittlePacktBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LittlePacktBookstore.ViewModels
{
    public class HomeIndexViewModel
    {
		public IEnumerable<Book> Books { get; set; }
		public IEnumerable<Carousel> Carousels { get; set; }
	}
}
