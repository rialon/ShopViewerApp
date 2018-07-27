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

    public class ProductRepository : IRepository<Product> {
        private TradeContext _db;

        public ProductRepository(TradeContext dbContext) {
            this._db = dbContext;
        }

        public void Create(Product item) {
            this._db.Products.Add(item);
        }

        public void Update(Product item) {
            this._db.Entry(item).State = EntityState.Modified;
        }

        public void Remove(Product item) {
            this._db.Products.Remove(item);
        }

        public Product Get(int id) {
            return this._db.Products.Find(id);
        }

        public IEnumerable<Product> GetAll() {
            return this._db.Products;
        }

        public IEnumerable<Product> Find(Func<Product, bool> predicate) {
            return this._db.Products.Where(predicate).ToList();
        }

        public void Dispose() {
            this._db.Dispose();
        }
    }
}
