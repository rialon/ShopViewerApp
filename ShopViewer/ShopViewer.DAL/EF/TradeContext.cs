using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ShopViewer.DAL.Entities;

namespace ShopViewer.DAL.EF {

    public class TradeContext : DbContext {

        public TradeContext(string connectionString) : base(connectionString) {
        }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
