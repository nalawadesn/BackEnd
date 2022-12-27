using NPMS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace NPMS.Repository
{
    public class AddListsRepo : IAddLists
    {
        private News_Paper_Management_SystemContext _lnt;

        public AddListsRepo(News_Paper_Management_SystemContext lnt)  //Dependncy Inject
        {
            _lnt = new News_Paper_Management_SystemContext();
        }
        public async Task DeleteAddlist(int Addlistid)
        {
            var obj = await _lnt.AddLists.FindAsync(Addlistid);
            _lnt.AddLists.Remove(obj);
            await _lnt.SaveChangesAsync();
        }
        public async Task<IEnumerable<AddLists>> GetAllAddLists()
        {
            return await _lnt.AddLists.Select(i => i).ToListAsync();
        }
        public async Task<AddLists> GetAddlist(int Addlistid)
        {
            return await _lnt.AddLists.FindAsync(Addlistid);
        }
        public async Task<AddLists> InsertAddlist(AddLists lobj)
        {
            _lnt.AddLists.Add(lobj);
            await _lnt.SaveChangesAsync();
            return lobj;
        }
        public async Task UpdateAddlist(AddLists lobj)
        {
            _lnt.Entry(lobj).State = EntityState.Modified;
            await _lnt.SaveChangesAsync();
        }
    }
}
