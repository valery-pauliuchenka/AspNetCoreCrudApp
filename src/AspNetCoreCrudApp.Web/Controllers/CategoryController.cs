using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreCrudApp.BusinessLogic.Interfaces;
using AspNetCoreCrudApp.Web.Models;
using AspNetCoreCrudApp.Web.Mappers;

namespace AspNetCoreCrudApp.Web.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryProvider _categoryProvider;

        public CategoryController(ICategoryProvider categoryProvider)
        {
            _categoryProvider = categoryProvider;
        }

        public IActionResult List()
        {
            var categories = _categoryProvider.GetAll();
            var viewItems = CategoryMapper.ToViewModel(categories);

            return View(viewItems);
        }

        public IActionResult Details(int id)
        {
            var item = _categoryProvider.GetById(id);
            var itemView = CategoryMapper.ToViewModel(item);

            return View(itemView);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryViewModel item)
        {
            if (ModelState.IsValid)
            {
                _categoryProvider.Create(CategoryMapper.ToDataModel(item));

                return RedirectToAction("List");
            }
            else
            {
                return View(item);
            }
        }

        public IActionResult Edit(int id)
        {
            var item = _categoryProvider.GetById(id);
            var itemView = CategoryMapper.ToViewModel(item);
            
            return View(itemView);
        }

        [HttpPost]
        public IActionResult Edit(CategoryViewModel item)
        {
            if (ModelState.IsValid)
            {
                _categoryProvider.Update(CategoryMapper.ToDataModel(item));

                return RedirectToAction("List");
            }
            else
            {
                return View(item);
            }
        }

        public IActionResult Remove(int id)
        {
            _categoryProvider.Remove(CategoryMapper.ToDataModel(new CategoryViewModel { Id = id }));

            return RedirectToAction("List");
        }
    }
}
