using SensorDataCollector.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SensorDataCollector.Repositories
{
    public class SensorDataRepository : IRepository<SensorData>
    {
        private DbContext db;

        public SensorDataRepository(DbContext db)
        {
            this.db = db;
        }

        public SensorData GetOne(params object[] keyValues)
        {
            return this.db.Set<SensorData>().Find(keyValues);
        }

        public IEnumerable<SensorData> GetAll()
        {
            return this.db.Set<SensorData>().AsEnumerable();
        }

        public void Add(SensorData item)
        {
            this.db.Set<SensorData>().Add(item);
            this.db.SaveChanges();
        }

        public void Update(SensorData item)
        {
            this.db.SaveChanges();
        }

        public void Delete(SensorData item)
        {
            this.db.Set<SensorData>().Remove(item);
            this.db.SaveChanges();
        }

    }
}