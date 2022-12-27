using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NPMS.Models
{
    public partial class Userdet
    {
        public Userdet()
        {
            AddLists = new HashSet<AddLists>();
            Booking = new HashSet<Booking>();
        }

        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserName { get; set; }
        public string ContactNum { get; set; }

        public virtual ICollection<AddLists> AddLists { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
    }
}
