using ShopViewer.BLL.Dto;
using ShopViewer.BLL.Infrastructure;
using ShopViewer.BLL.Interfaces;
using ShopViewer.DAL.Entities;
using ShopViewer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ShopViewer.BLL.Services {

    public class ProductService : IProductService {
        private ITradeUnitOfWork _tuow;

        public ProductService(ITradeUnitOfWork tuow) {
            this._tuow = tuow;
        }

        public void Create(ProductDto item) {
            var _shop = this._tuow.Shops.Get(item.ShopId);
            if (_shop == null) {
                throw new ValidationException("Shop is not found", " ");
            }
            var _product = new Product {
                Name = item.Name,
                Description = item.Description,
                ShopId = item.ShopId
            };
            this._tuow.Products.Create(_product);
            this._tuow.Save();
        }

        public void Update(ProductDto item) {
            if (this._tuow.Products.Get(item.Id) == null) {
                throw new ValidationException("Product is not found", " ");
            }
            var _product = new Product {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                ShopId = item.ShopId
            };
            this._tuow.Products.Update(_product);
            this._tuow.Save();
        }

        public void Remove(int id) {
            var _product = this._tuow.Products.Get(id);
            if (_product == null) {
                throw new ValidationException("Product is not found", " ");
            }
            this._tuow.Products.Remove(_product);
            this._tuow.Save();
        }

        public IEnumerable<ProductDto> GetForShop(int shopId) {
            if (this._tuow.Shops.Get(shopId) == null) {
                throw new ValidationException("Shop is not found", " ");
            }
            var _mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDto>()).CreateMapper();
            return _mapper.Map<IEnumerable<Product>, List<ProductDto>>(this._tuow.Products.Find(p => p.ShopId == shopId));
        }

        public void Dispose() {
            this._tuow.Dispose();
        }
    }
}
