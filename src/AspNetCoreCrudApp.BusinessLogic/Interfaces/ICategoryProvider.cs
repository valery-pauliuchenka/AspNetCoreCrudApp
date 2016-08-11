using AspNetCoreCrudApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreCrudApp.BusinessLogic.Interfaces
{
    public interface ICategoryProvider
    {
        List<Category> GetAll();
        Task<List<Category>> GetAllAsync();
        Category GetById(int id);
        void Create(Category category);
        void Update(Category category);
        void Remove(Category category);
    }
}
