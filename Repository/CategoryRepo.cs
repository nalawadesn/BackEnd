using NPMS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace NPMS.Repository
{
    public class CategoryRepo : ICategory
    {
        private News_Paper_Management_SystemContext _cnt;

        public CategoryRepo(News_Paper_Management_SystemContext cnt)  //Dependncy Inject
        {
            _cnt = new News_Paper_Management_SystemContext();
        }
        public async Task DeleteCategory(int Userid)
        {
            var obj = await _cnt.Category.FindAsync(Userid);
            _cnt.Category.Remove(obj);
            await _cnt.SaveChangesAsync();
        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _cnt.Category.Select(i => i).ToListAsync();
        }
        public async Task<Category> GetCategory(int Categoryid)
        {
            return await _cnt.Category.FindAsync(Categoryid);
        }
        public async Task<Category> InsertCategory(Category cobj)
        {
            _cnt.Category.Add(cobj);
            await _cnt.SaveChangesAsync();
            return cobj;
        }
        public async Task UpdateCategory(Category cobj)
        {
            _cnt.Entry(cobj).State = EntityState.Modified;
            await _cnt.SaveChangesAsync();
        }
    }
}
