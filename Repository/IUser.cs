    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using NPMS.Models;

    namespace NPMS.Repository
    {
        public interface IUser
        {
            Task<IEnumerable<Userdet>> GetAllUsers();
            Task<Userdet> GetUserbyemail(Userlogin userlogin);

            Task<Userdet> GetUserdetbyemail(string email);

            //Task<Userdet> GetUser(int Userid);
            Task<Userdet> InsertUser(Userdet uobj);
            Task UpdateUser(Userdet uobj);
            Task DeleteUser(int Userid);
        }
    }