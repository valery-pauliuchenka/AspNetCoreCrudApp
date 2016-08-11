using AspNetCoreCrudApp.DataAccess.Contexts;
using AspNetCoreCrudApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using AspNetCoreCrudApp.BusinessLogic.Interfaces;
using AspNetCoreCrudApp.DataAccess.Interfaces;

namespace AspNetCoreCrudApp.BusinessLogic.Providers
{
    public class ProductProvider : IProductProvider
    {
        private IShopContext _shopContext;

        public ProductProvider(IShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<Product> GetAll()
        {
            return _shopContext.Products.
                Include(p => p.Category).
                ToList();
        }

        public Product GetById(int id)
        {
            return _shopContext.Products.
                Include(p => p.Category).
                Where(p => p.Id == id).
                SingleOrDefault();
        }

        public List<Product> GetByCategoryId(int categoryId)
        {
            return _shopContext.Products
                .Include(p => p.Category)
                .Where(p => p.CategoryId == categoryId)
                .ToList();
        }

        public void Update(Product product)
        {
            var entry = _shopContext.Entry(product);
            entry.State = EntityState.Modified;

            _shopContext.SaveChanges();
        }

        public void Create(Product product)
        {
            _shopContext.Products.Add(product);

            _shopContext.SaveChanges();
        }

        public void Remove(Product product)
        {
            var entry = _shopContext.Entry(product);
            entry.State = EntityState.Deleted;

            _shopContext.SaveChanges();
        }
    }
}
