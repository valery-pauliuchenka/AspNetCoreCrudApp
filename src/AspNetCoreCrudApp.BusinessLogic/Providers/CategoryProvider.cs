using AspNetCoreCrudApp.BusinessLogic.Interfaces;
using AspNetCoreCrudApp.DataAccess.Contexts;
using AspNetCoreCrudApp.DataAccess.Entities;
using AspNetCoreCrudApp.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreCrudApp.BusinessLogic.Providers
{
    public class CategoryProvider : ICategoryProvider
    {
        private IShopContext _shopContext;

        public CategoryProvider(IShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<Category> GetAll()
        {
            return _shopContext.Categories
                .ToList();
        }

        public Task<List<Category>> GetAllAsync()
        {
            return _shopContext.Categories
                .ToListAsync();
        }

        public Category GetById(int id)
        {
            return _shopContext.Categories
                .Where(c => c.Id == id)
                .SingleOrDefault();
        }

        public void Create(Category category)
        {
            _shopContext.Categories.Add(category);

            _shopContext.SaveChanges();
        }

        public void Update(Category category)
        {
            var entry = _shopContext.Entry(category);
            entry.State = EntityState.Modified;

            _shopContext.SaveChanges();
        }

        public void Remove(Category category)
        {
            var entry = _shopContext.Entry(category);
            entry.State = EntityState.Deleted;

            _shopContext.SaveChanges();
        }
    }
}
