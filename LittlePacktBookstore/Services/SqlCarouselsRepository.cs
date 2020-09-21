using LittlePacktBookstore.Data;
using LittlePacktBookstore.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LittlePacktBookstore.Services
{
	public class SqlCarouselsRepository : IRepository<Carousel>
	{
		private LittlePacktBookStoreDbContex _context;
		private readonly ILogger _logger;

		public SqlCarouselsRepository(LittlePacktBookStoreDbContex context, ILogger<SqlCarouselsRepository> logger)
		{
			_context = context;
			_logger = logger;
		}

		public bool Add(Carousel item)
		{
			try
			{
				_context.Carousels.Add(item);
				_context.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				_logger.LogError("Failed to add carousel: " + ex.Message);
				return false;
			}
		}

		public bool Delete(Carousel Item)
		{
			try
			{
				Carousel book = Get(Item.Id);
				if (book != null)
				{
					_context.Carousels.Remove(Item);
					_context.SaveChanges();
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				_logger.LogError("Failed to remove carousel: " + ex.Message);
				return false;
			}
		}

		public bool Edit(Carousel item)
		{
			try
			{
				_context.Carousels.Update(item);
				_context.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				_logger.LogError("Failed to update carousel: " + ex.Message);

				return false;
			}
		}

		public Carousel Get(int id)
		{
			if (_context.Carousels.Count(x => x.Id == id) > 0)
			{
				return _context.Carousels.FirstOrDefault(x => x.Id == id);
			}
			return null;
		}

		public IEnumerable<Carousel> GetAll()
		{
			return _context.Carousels;
		}
	}
}
