using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NPMS.Models;

namespace NPMS.Repository
{
    public interface ICategory
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategory(int Categoryid);
        Task<Category> InsertCategory(Category cobj);
        Task UpdateCategory(Category cobj);
        Task DeleteCategory(int Categoryid);
    }
}
