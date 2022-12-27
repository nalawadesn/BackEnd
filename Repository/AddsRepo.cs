using Microsoft.EntityFrameworkCore;
using NPMS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPMS.Repository
{
    public class AddsRepo : IAdds
    {
        private News_Paper_Management_SystemContext _adnt;

        public AddsRepo(News_Paper_Management_SystemContext adnt)  //Dependncy Inject
        {
            _adnt = new News_Paper_Management_SystemContext();
        }
        public async Task DeleteAdd(int Addid)
        {
            var adobj = await _adnt.Adds.FindAsync(Addid);
            _adnt.Adds.Remove(adobj);
            await _adnt.SaveChangesAsync();
        }
        public async Task<IEnumerable<Adds>> GetAllAdds()
        {
            return await _adnt.Adds.Select(i => i).ToListAsync();
        }
        public async Task<Adds> GetAdd(int Addid)
        {
            return await _adnt.Adds.FindAsync(Addid);
        }
        public async Task<Adds> InsertAdd(Adds adobj)
        {
            _adnt.Adds.Add(adobj);
            await _adnt.SaveChangesAsync();
            return adobj;
        }
        public async Task UpdateAdd(Adds uobj)
        {
            _adnt.Entry(uobj).State = EntityState.Modified;
            await _adnt.SaveChangesAsync();
        }

    }
}
