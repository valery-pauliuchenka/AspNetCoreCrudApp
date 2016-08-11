using AspNetCoreCrudApp.DataAccess.Entities;
using AspNetCoreCrudApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreCrudApp.Web.Mappers
{
    public static class ProductMapper
    {
        public static ProductViewModel ToViewModel(Product item)
        {
            return new ProductViewModel
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CategoryId = item.CategoryId,
                IsAvailable = item.IsAvailable,
                CategoryName = item.Category.Name
            };
        }

        public static List<ProductViewModel> ToViewModel(List<Product> items)
        {
            var list = new List<ProductViewModel>();

            foreach (var item in items)
            {
                list.Add(ProductMapper.ToViewModel(item));
            }

            return list;
        }

        public static Product ToDataModel(ProductViewModel item)
        {
            return new Product
            {
                Id = item.Id,
                Name = item.Name,
                IsAvailable = item.IsAvailable,
                Price = item.Price,
                CategoryId = item.CategoryId
            };
        }

        public static List<Product> ToDataModel(List<ProductViewModel> items)
        {
            var list = new List<Product>();

            foreach (var item in items)
            {
                list.Add(ProductMapper.ToDataModel(item));
            }

            return list;
        }
    }
}
