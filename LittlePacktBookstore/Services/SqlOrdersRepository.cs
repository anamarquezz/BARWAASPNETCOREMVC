using LittlePacktBookstore.Data;
using LittlePacktBookstore.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LittlePacktBookstore.Services
{
	public class SqlOrdersRepository : IRepository<Order>
	{
		private LittlePacktBookStoreDbContex _context;
		private readonly ILogger _logger;

		public SqlOrdersRepository(LittlePacktBookStoreDbContex context, ILogger<SqlOrdersRepository> logger)
		{
			_context = context;
			_logger = logger;
		}

		public bool Add(Order item)
		{
			try
			{
				_context.Orders.Add(item);
				_context.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				_logger.LogError("Failed to add order: " + ex.Message);
				return false;
			}
		}

		public bool Delete(Order Item)
		{
			try
			{
				Order order = Get(Item.Id);
				if (order != null)
				{
					_context.Orders.Remove(order);
					_context.SaveChanges();
					return true;
				}				
			}
			catch (Exception ex)
			{
				_logger.LogError("Failed to delete order: " + ex.Message);
			}
			return false;
		}

		public bool Edit(Order item)
		{
			try
			{
				_context.Orders.Update(item);
				_context.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				_logger.LogError("Failed to update order: " + ex.Message);
				return false;
			}
		}

		public Order Get(int id)
		{
			if (_context.Orders.Count(x => x.Id == id) > 0)
			{
				return _context.Orders.FirstOrDefault(x => x.Id == id);
			}
			return null;
		}

		public IEnumerable<Order> GetAll()
		{
			return _context.Orders;
		}
	}
}
