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

    public class ShopService : IShopService {
        private ITradeUnitOfWork _tuow;

        public ShopService(ITradeUnitOfWork tuow) {
            this._tuow = tuow;
        }

        public void Create(ShopDto item) {
            var _shop = new Shop {
                Name = item.Name,
                Address = item.Address,
                StartTime = item.StartTime,
                EndTime = item.EndTime
            };
            this._tuow.Shops.Create(_shop);
            this._tuow.Save();
        }

        public void Update(ShopDto item) {
            if (this._tuow.Shops.Get(item.Id) == null) {
                throw new ValidationException("Shop is not found", " ");
            }
            var _shop = new Shop {
                Id = item.Id,
                Name = item.Name,
                Address = item.Address,
                StartTime = item.StartTime,
                EndTime = item.EndTime
            };
            this._tuow.Shops.Update(_shop);
            this._tuow.Save();
        }

        public void Remove(int id) {
            var _shop = this._tuow.Shops.Get(id);
            if (_shop == null) {
                throw new ValidationException("Shop is not found", " ");
            }
            this._tuow.Shops.Remove(_shop);
            this._tuow.Save();
        }

        public IEnumerable<ShopDto> GetAll() {
            var _mapper = new MapperConfiguration(cfg => cfg.CreateMap<Shop, ShopDto>()).CreateMapper();
            return _mapper.Map<IEnumerable<Shop>, List<ShopDto>>(this._tuow.Shops.GetAll());
        }

        public void Dispose() {
            this._tuow.Dispose();
        }
    }
}
