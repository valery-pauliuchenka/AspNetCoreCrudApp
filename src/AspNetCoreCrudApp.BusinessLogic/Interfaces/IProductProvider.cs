using AspNetCoreCrudApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreCrudApp.BusinessLogic.Interfaces
{
    public interface IProductProvider
    {
        List<Product> GetAll();
        Product GetById(int id);
        List<Product> GetByCategoryId(int categoryId);
        void Update(Product product);
        void Create(Product product);
        void Remove(Product product);
    }
}
