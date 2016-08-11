using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreCrudApp.BusinessLogic.Interfaces;
using AspNetCoreCrudApp.Web.Models;
using AspNetCoreCrudApp.Web.Mappers;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreCrudApp.Web.Api
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private IProductProvider _productProvider;

        public ProductController(IProductProvider productProvider)
        {
            _productProvider = productProvider;
        }

        // GET: api/values
        [HttpGet]
        public List<ProductViewModel> Get()
        {
            var items = _productProvider.GetAll();

            return ProductMapper.ToViewModel(items);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ProductViewModel Get(int id)
        {
            var item = _productProvider.GetById(id);

            return ProductMapper.ToViewModel(item);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]ProductViewModel item)
        {
            _productProvider.Create(ProductMapper.ToDataModel(item));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put([FromBody]ProductViewModel item)
        {
            _productProvider.Update(ProductMapper.ToDataModel(item));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productProvider.Remove(ProductMapper.ToDataModel(new ProductViewModel { Id = id }));
        }
    }
}
