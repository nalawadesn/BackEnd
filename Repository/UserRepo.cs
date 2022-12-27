using NPMS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;


namespace NPMS.Repository
{
    public class UserRepo: IUser
    {
            private News_Paper_Management_SystemContext _unt;

            public UserRepo(News_Paper_Management_SystemContext unt)  //Dependncy Inject
            {
                _unt = new News_Paper_Management_SystemContext();
            }
            public async Task DeleteUser(int Userid)
            {
                var obj = await _unt.Userdet.FindAsync(Userid);
                _unt.Userdet.Remove(obj);
                await _unt.SaveChangesAsync();
            }
            public async Task<IEnumerable<Userdet>> GetAllUsers()
            {
                return await _unt.Userdet.Select(i => i).ToListAsync();
            }

            public async Task<Userdet> GetUserbyemail(Userlogin userlogin)
            {
            var det = await _unt.Userdet.Where(i => i.UserEmail == userlogin.email).FirstOrDefaultAsync();
            if (det != null)
            {
                if (det.UserPassword == userlogin.password)
                {
                    return det;
                }
                return null;
            }
            return null;
        }

        public async Task<Userdet> GetUserdetbyemail(string email)
        {
            return await _unt.Userdet.Where(i => i.UserEmail == email).FirstOrDefaultAsync();
        }

        //public async Task<Userdet> GetUser(int Userid)
        //    {
        //        return await _unt.Userdet.FindAsync(Userid);
        //    }
        public async Task<Userdet> InsertUser(Userdet uobj)
            {
                _unt.Userdet.Add(uobj);
                await _unt.SaveChangesAsync();
                return uobj;
            }
            public async Task UpdateUser(Userdet uobj)
            {
                _unt.Entry(uobj).State = EntityState.Modified;
                await _unt.SaveChangesAsync();
            }
       
    } 
}
