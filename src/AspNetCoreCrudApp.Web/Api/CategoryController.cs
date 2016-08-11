using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreCrudApp.BusinessLogic.Interfaces;
using AspNetCoreCrudApp.Web.Mappers;
using AspNetCoreCrudApp.Web.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreCrudApp.Web.Api
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private ICategoryProvider _categoryProvider;

        public CategoryController(ICategoryProvider categoryProvider)
        {
            _categoryProvider = categoryProvider;
        }

        // GET: api/values
        [HttpGet]
        public List<CategoryViewModel> Get()
        {
            var categories = _categoryProvider.GetAll();

            return CategoryMapper.ToViewModel(categories);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public CategoryViewModel Get(int id)
        {
            var category = _categoryProvider.GetById(id);

            return CategoryMapper.ToViewModel(category);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]CategoryViewModel item)
        {
            _categoryProvider.Create(CategoryMapper.ToDataModel(item));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put([FromBody]CategoryViewModel item)
        {
            _categoryProvider.Update(CategoryMapper.ToDataModel(item));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _categoryProvider.Remove(CategoryMapper.ToDataModel(new CategoryViewModel { Id = id }));
        }
    }
}
