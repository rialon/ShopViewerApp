using ShopViewer.BLL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopViewer.BLL.Interfaces {

    public interface IProductService : IDisposable {
        void Create(ProductDto item);
        void Update(ProductDto item);
        void Remove(int id);
        IEnumerable<ProductDto> GetForShop(int shopId);
    }
}
