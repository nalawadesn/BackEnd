using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NPMS.Models;

namespace NPMS.Repository
{
    public interface IAddLists
    {
        Task<IEnumerable<AddLists>> GetAllAddLists();
        Task<AddLists> GetAddlist(int Addlistid);
        Task<AddLists> InsertAddlist(AddLists lobj);
        Task UpdateAddlist(AddLists lobj);
        Task DeleteAddlist(int Addlistid);
    }
}
