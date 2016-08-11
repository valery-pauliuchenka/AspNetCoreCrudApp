using AspNetCoreCrudApp.DataAccess.Entities;
using AspNetCoreCrudApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreCrudApp.Web.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryViewModel ToViewModel(Category item)
        {
            return new CategoryViewModel
            {
                Id = item.Id,
                Name = item.Name
            };
        }

        public static List<CategoryViewModel> ToViewModel(List<Category> items)
        {
            var list = new List<CategoryViewModel>();

            foreach (var item in items)
            {
                list.Add(CategoryMapper.ToViewModel(item));
            }

            return list;
        }

        public static Category ToDataModel(CategoryViewModel item)
        {
            return new Category
            {
                Id = item.Id,
                Name = item.Name,
            };
        }

        public static List<Category> ToDataModel(List<CategoryViewModel> items)
        {
            var list = new List<Category>();

            foreach (var item in items)
            {
                list.Add(CategoryMapper.ToDataModel(item));
            }

            return list;
        }
    }
}
