using AspNetCoreCrudApp.BusinessLogic.Interfaces;
using AspNetCoreCrudApp.DataAccess.Entities;
using AspNetCoreCrudApp.Web.Mappers;
using AspNetCoreCrudApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreCrudApp.Web.ViewComponents
{
    public class CategoryDropdownViewComponent : ViewComponent
    {
        private ICategoryProvider _categoryProvider;

        public CategoryDropdownViewComponent(ICategoryProvider categoryProvider)
        {
            _categoryProvider = categoryProvider;
        }

        public async Task<IViewComponentResult> InvokeAsync(string bindingProperty, int? id = null)
        {
            ViewBag.BindingProperty = bindingProperty;
            ViewBag.Id = id;

            var items = await GetItemsAsync();
            var itemsView = CategoryMapper.ToViewModel(items);

            return View(itemsView);
        }

        private Task<List<Category>> GetItemsAsync()
        {
            var items = _categoryProvider.GetAllAsync();

            return items;
        }
    }
}
