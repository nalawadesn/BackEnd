using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NPMS.Models
{
    public partial class Category
    {
        public Category()
        {
            AddLists = new HashSet<AddLists>();
            Adds = new HashSet<Adds>();
            Booking = new HashSet<Booking>();
        }

        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }

        public virtual ICollection<AddLists> AddLists { get; set; }
        public virtual ICollection<Adds> Adds { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
    }
}
