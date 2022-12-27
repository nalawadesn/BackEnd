using Microsoft.EntityFrameworkCore;
using NPMS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPMS.Repository
{
    public class AdminRepo : IAdmin
    {
            private News_Paper_Management_SystemContext _ant;

            public AdminRepo(News_Paper_Management_SystemContext ant)  //Dependncy Inject
            {
                _ant = new News_Paper_Management_SystemContext();

            }
            public async Task DeleteAdmin(int Userid)
            {
                var aobj = await _ant.Admin.FindAsync(Userid);
                _ant.Admin.Remove(aobj);
                await _ant.SaveChangesAsync();
            }
            public async Task<IEnumerable<Admin>> GetAllAdmins()
            {
                return await _ant.Admin.Select(i => i).ToListAsync();
            }

        public async Task<Admin> GetAdminbyemail(Adminlogin adminlogin)
        {
            var det = await _ant.Admin.Where(i => i.AdminEmail == adminlogin.email).FirstOrDefaultAsync();
            if (det != null)
            {
                if (det.AdminPassword == adminlogin.password)
                {
                    return det;
                }
                return null;
            }
            return null;
        }

            public async Task<Admin> GetAdmin(int Userid)
            {
                return await _ant.Admin.FindAsync(Userid);
            }
            public async Task<Admin> InsertAdmin(Admin aobj)
            {
                _ant.Admin.Add(aobj);
                await _ant.SaveChangesAsync();
                return aobj;
            }
            public async Task UpdateAdmin(Admin aobj)
            {
                _ant.Entry(aobj).State = EntityState.Modified;
                await _ant.SaveChangesAsync();
            }
    }
}
