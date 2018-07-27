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
using ShopViewer.BLL.Dto;
using AutoMapper;
using ShopViewer.BLL.Infrastructure;
using System.Web.Http.Cors;

namespace ShopViewer.WEB.Controllers {

    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class ProductController : ApiController {
        private IProductService _productService;

        public ProductController(IProductService produtService) {
            this._productService = produtService;
        }

        // GET: api/Product/5
        public IHttpActionResult GetForShop(int id) {
            try {
                var _productDtos = this._productService.GetForShop(id);
                var _mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDto, ProductViewModel>()).CreateMapper();
                var _products = _mapper.Map<IEnumerable<ProductDto>, List<ProductViewModel>>(_productDtos);
                return Ok(_products);
            } catch (ValidationException ex) {
                ModelState.AddModelError(ex.Property, ex.Message);
                return BadRequest(ModelState);
            }
        }

        // POST: api/Product
        [HttpPost]
        public IHttpActionResult CreateProduct([FromBody]ProductViewModel product) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var _productDto = new ProductDto {
                Name = product.Name,
                Description = product.Description,
                ShopId = product.ShopId
            };
            this._productService.Create(_productDto);
            return CreatedAtRoute("DefaultApi", new { }, product);
        }

        // PUT: api/Product
        [HttpPut]
        public IHttpActionResult EditProduct([FromBody]ProductViewModel product) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            try {
                var _productDto = new ProductDto {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    ShopId = product.ShopId
                };
                this._productService.Update(_productDto);
                return Ok();
            } catch (ValidationException ex) {
                ModelState.AddModelError(ex.Property, ex.Message);
                return NotFound();
            }
        }

        // DELETE: api/Product/5
        [HttpDelete]
        public IHttpActionResult RemoveProduct(int id) {
            try {
                this._productService.Remove(id);
                return Ok();
            } catch (ValidationException ex) {
                ModelState.AddModelError(ex.Property, ex.Message);
                return NotFound();
            }
        }
    }
}