using ShopViewer.DAL.EF;
using ShopViewer.DAL.Entities;
using ShopViewer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ShopViewer.DAL.Repositories {

    public class ShopRepository : IRepository<Shop> {
        private TradeContext _db;

        public ShopRepository(TradeContext dbContext) {
            this._db = dbContext;
        }

        public void Create(Shop item) {
            this._db.Shops.Add(item);
        }

        public void Update(Shop item) {
            this._db.Entry(item).State = EntityState.Modified;
        }

        public void Remove(Shop item) {
            this._db.Shops.Remove(item);
        }

        public Shop Get(int id) {
            return this._db.Shops.Find(id);
        }

        public IEnumerable<Shop> GetAll() {
            return this._db.Shops;
        }

        public IEnumerable<Shop> Find(Func<Shop, bool> predicate) {
            return this._db.Shops.Where(predicate).ToList();
        }

        public void Dispose() {
            this._db.Dispose();
        }
    }
}
