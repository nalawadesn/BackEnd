using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NPMS.Models
{
    public partial class Adds
    {
        public Adds()
        {
            AddLists = new HashSet<AddLists>();
            Booking = new HashSet<Booking>();
        }

        public int AddId { get; set; }
        public string AddTitle { get; set; }
        public string AddContent { get; set; }
        public string AddDesc { get; set; }
        public string AddDate { get; set; }
        public string CategoryTitle { get; set; }

        public virtual Category CategoryTitleNavigation { get; set; }
        public virtual ICollection<AddLists> AddLists { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
    }
}
