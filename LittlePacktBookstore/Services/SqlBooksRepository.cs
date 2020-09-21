using LittlePacktBookstore.Data;
using LittlePacktBookstore.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LittlePacktBookstore.Services
{
	public class SqlBooksRepository : IRepository<Book>
	{
		private LittlePacktBookStoreDbContex _context;
		private readonly ILogger _logger;

		public SqlBooksRepository(LittlePacktBookStoreDbContex context, ILogger<SqlBooksRepository> logger)
		{
			_context = context;
			_logger = logger;
		}

		public bool Add(Book item)
		{
			try
			{
				_context.Books.Add(item);
				_context.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				_logger.LogError("Failed to add Book item to the database: " + ex.Message);
				return false;
			}
		}

		public bool Delete(Book Item)
		{
			try
			{
				Book book = Get(Item.Id);
				if (book != null)
				{
					_context.Books.Remove(Item);
					_context.SaveChanges();
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				_logger.LogError("Unable to delete book: " + ex.Message);
				return false;
			}
		}

		public bool Edit(Book item)
		{
			try
			{
				_context.Books.Update(item);
				_context.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				_logger.LogError("Unable to save book: " + ex.Message);
			}
			return false;
		}

		public Book Get(int id)
		{
			if (_context.Books.Count(x => x.Id == id) > 0)
			{
				return _context.Books.FirstOrDefault(x => x.Id == id);
			}
			return null;
		}

		public IEnumerable<Book> GetAll()
		{
			return _context.Books;
		}
	}
}
