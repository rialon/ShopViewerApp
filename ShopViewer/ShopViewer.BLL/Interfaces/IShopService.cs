using ShopViewer.BLL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopViewer.BLL.Interfaces {

    public interface IShopService : IDisposable {
        void Create(ShopDto item);
        void Update(ShopDto item);
        void Remove(int id);
        IEnumerable<ShopDto> GetAll();
    }
}
