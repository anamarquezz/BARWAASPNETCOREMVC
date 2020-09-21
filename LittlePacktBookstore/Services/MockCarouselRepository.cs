using LittlePacktBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LittlePacktBookstore.Services
{
	public class MockCarouselRepository : IRepository<Carousel>
	{
		List<Carousel> _carousels;
		public MockCarouselRepository()
		{
			_carousels = new List<Carousel>();
			_carousels.Add(new Carousel()
			{
				Id = 0,
				Title = "New books",
				Description = "All brand new books in one site",
				ImageURL = "car1.jpg"
			});
			_carousels.Add(new Carousel()
			{
				Id = 1,
				Title = "Discount books",
				Description = "Discount books, get them all now. Don't wait!",
				ImageURL = "car2.jpg"
			});
			_carousels.Add(new Carousel()
			{
				Id = 3,
				Title = "Subcription",
				Description = "Subcribe now to read 1000s of books.",
				ImageURL = "car3.jpg"
			});
		}
		public bool Add(Carousel item)
		{
			try
			{
				Carousel carousel = item;
				carousel.Id = _carousels.Max(x => x.Id) + 1;
				_carousels.Add(carousel);
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}

		public bool Delete(Carousel Item)
		{
			throw new NotImplementedException();
		}

		public bool Edit(Carousel item)
		{
			throw new NotImplementedException();
		}

		public Carousel Get(int id)
		{
			return _carousels.FirstOrDefault(x => x.Id == id);
		}

		public IEnumerable<Carousel> GetAll()
		{
			return _carousels.ToList();
		}
	}
}
