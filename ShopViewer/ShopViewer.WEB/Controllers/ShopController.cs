using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ShopViewer.WEB.Models;
using ShopViewer.BLL.Interfaces;
using AutoMapper;
using ShopViewer.BLL.Dto;
using ShopViewer.BLL.Infrastructure;
using System.Web.Http.Cors;

namespace ShopViewer.WEB.Controllers {

    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class ShopController : ApiController {
        private IShopService _shopService;

        public ShopController(IShopService shopService) {
            this._shopService = shopService;
        }

        // GET: api/Shop
        public IHttpActionResult GetShops() {
            var _shopDtos = this._shopService.GetAll();
            var _mapper = new MapperConfiguration(cfg => cfg.CreateMap<ShopDto, ShopViewModel>()).CreateMapper();
            var _shops = _mapper.Map<IEnumerable<ShopDto>, List<ShopViewModel>>(_shopDtos);
            return Ok(_shops.ToList());
        }

        // POST: api/Shop
        [HttpPost]
        public IHttpActionResult CreateShop([FromBody]ShopViewModel shop) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var _shopDto = new ShopDto {
                Name = shop.Name,
                Address = shop.Address,
                StartTime = shop.StartTime,
                EndTime = shop.EndTime
            };
            this._shopService.Create(_shopDto);
            return CreatedAtRoute("DefaultApi", new { }, shop);
        }

        // PUT: api/Shop/
        [HttpPut]
        public IHttpActionResult EditShop([FromBody]ShopViewModel shop) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            try {
                var _shopDto = new ShopDto {
                    Id = shop.Id,
                    Name = shop.Name,
                    Address = shop.Address,
                    StartTime = shop.StartTime,
                    EndTime = shop.EndTime
                };
                this._shopService.Update(_shopDto);
                return Ok();
            } catch (ValidationException ex) {
                ModelState.AddModelError(ex.Property, ex.Message);
                return NotFound();
            }
        }

        // DELETE: api/Shop/5
        [HttpDelete]
        public IHttpActionResult RemoveShop(int id) {
            try {
                this._shopService.Remove(id);
                return Ok();
            } catch (ValidationException ex) {
                ModelState.AddModelError(ex.Property, ex.Message);
                return NotFound();
            }
        }
    }
}