using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LittlePacktBookstore.Services
{
    public interface IRepository<T>
    {
		T Get(int id);
		IEnumerable<T> GetAll();
		bool Add(T item);
		bool Delete(T Item);
		bool Edit(T item);
	}
}
