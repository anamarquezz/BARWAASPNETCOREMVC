using LittlePacktBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LittlePacktBookstore.ViewModels
{
    public class OrderViewModel
    {
		public Book BookToOrder { get; set; }
		public Order OrderDetails { get; set; }
	}
}
