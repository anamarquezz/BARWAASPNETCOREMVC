using LittlePacktBookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace LittlePacktBookstore.Data
{
    public class LittlePacktBookStoreDbContex:DbContext
    {
		public LittlePacktBookStoreDbContex(DbContextOptions options):base(options)
		{
		}
		public DbSet<Book> Books { get; set; }
		public DbSet<Carousel> Carousels { get; set; }
		public DbSet<Order> Orders { get; set; }
	}
}
