using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NPMS.Models;

namespace NPMS.Repository
{
    public interface IAdds
    {
        Task<IEnumerable<Adds>> GetAllAdds();
        Task<Adds> GetAdd(int Addid);
        Task<Adds> InsertAdd(Adds adobj);
        Task UpdateAdd(Adds adobj);
        Task DeleteAdd(int Addid);
    }
}
