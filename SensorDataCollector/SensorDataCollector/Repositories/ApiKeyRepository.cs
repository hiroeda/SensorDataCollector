using SensorDataCollector.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SensorDataCollector.Repositories
{
    public class ApiKeyRepository : IRepository<ApiKey>
    {
        private DbContext db;

        public ApiKeyRepository(DbContext db)
        {
            this.db = db;
        }

        public ApiKey GetOne(params object[] keyValues)
        {
            return this.db.Set<ApiKey>().Find(keyValues);
        }

        public IEnumerable<ApiKey> GetAll()
        {
            return this.db.Set<ApiKey>().AsEnumerable();
        }

        public void Add(ApiKey item)
        {
            this.db.Set<ApiKey>().Add(item);
            this.db.SaveChanges();
        }

        public void Update(ApiKey item)
        {
            this.db.SaveChanges();
        }

        public void Delete(ApiKey item)
        {
            this.db.Set<ApiKey>().Remove(item);
            this.db.SaveChanges();
        }

    }
}