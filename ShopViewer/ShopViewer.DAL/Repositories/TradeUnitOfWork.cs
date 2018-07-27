using ShopViewer.DAL.EF;
using ShopViewer.DAL.Entities;
using ShopViewer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopViewer.DAL.Repositories {

    public class TradeUnitOfWork : ITradeUnitOfWork {
        private TradeContext _db;
        private bool _disposed = false;

        public IRepository<Shop> Shops {
            get;
        }
        public IRepository<Product> Products {
            get;
        }

        public TradeUnitOfWork(string connectionString) {
            this._db = new TradeContext(connectionString);
            this.Shops = new ShopRepository(this._db);
            this.Products = new ProductRepository(this._db);
        }

        public void Save() {
            this._db.SaveChanges();
        }

        private void _Dispose(bool disposing) {
            if (!this._disposed) {
                if (disposing) {
                    this._db.Dispose();
                }
                this._disposed = true;
            }
        }

        public void Dispose() {
            this._Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
