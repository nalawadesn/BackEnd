using NPMS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPMS.Repository
{
    public interface IAdmin
    {
        Task<IEnumerable<Admin>> GetAllAdmins();
        Task<Admin> GetAdmin(int Adminid);
        Task<Admin> GetAdminbyemail(Adminlogin adminLogin);
        Task<Admin> InsertAdmin(Admin aobj);
        Task UpdateAdmin(Admin aobj);
        Task DeleteAdmin(int Adminid);
    }
}
