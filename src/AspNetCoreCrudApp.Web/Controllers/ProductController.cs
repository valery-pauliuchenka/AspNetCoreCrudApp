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
    public class ProductController : Controller
    {
        private IProductProvider _productProvider;

        public ProductController(IProductProvider productProvider)
        {
            _productProvider = productProvider;
        }

        public IActionResult List()
        {
            var items = _productProvider.GetAll();
            var viewItems = ProductMapper.ToViewModel(items);

            return View(viewItems);
        }

        public IActionResult Details(int id)
        {
            var item = _productProvider.GetById(id);
            var viewItem = ProductMapper.ToViewModel(item);

            return View(viewItem);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel item)
        {
            if (ModelState.IsValid)
            {
                _productProvider.Create(ProductMapper.ToDataModel(item));

                return RedirectToAction("List");
            }
            else
            {
                return View(item);
            }
        }

        public IActionResult Edit(int id)
        {
            var item = _productProvider.GetById(id);
            var itemView = ProductMapper.ToViewModel(item);

            return View(itemView);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel item)
        {
            if (ModelState.IsValid)
            {
                _productProvider.Update(ProductMapper.ToDataModel(item));

                return RedirectToAction("List");
            }
            else
            {
                return View(item);
            }
        }

        public IActionResult Remove(int id)
        {
            _productProvider.Remove(ProductMapper.ToDataModel(new ProductViewModel { Id = id }));

            return RedirectToAction("List");
        }
    }
}
