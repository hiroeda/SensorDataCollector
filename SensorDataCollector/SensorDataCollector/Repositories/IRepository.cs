using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorDataCollector.Repositories
{
    interface IRepository<T>
    {
        T GetOne(params object[] keyValues);

        IEnumerable<T> GetAll();

        void Add(T item);

        void Update(T item);

        void Delete(T item);
    }
}
