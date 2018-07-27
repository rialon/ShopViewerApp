using ShopViewer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopViewer.DAL.Interfaces {

    public interface ITradeUnitOfWork : IDisposable {
        IRepository<Shop> Shops { get; }
        IRepository<Product> Products { get; }
        void Save();
    }
}
