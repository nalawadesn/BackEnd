using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NPMS.Models
{
    public partial class Booking
    {
        public Booking()
        {
            Payment = new HashSet<Payment>();
        }

        public int BkId { get; set; }
        public string CategoryTitle { get; set; }
        public string AddTitle { get; set; }
        public int? UserId { get; set; }
        public string CityName { get; set; }
        public string PublicationName { get; set; }
        public string AddImg { get; set; }
        public string RowColumn { get; set; }
        public decimal? AddPrice { get; set; }

        public virtual Adds AddTitleNavigation { get; set; }
        public virtual Category CategoryTitleNavigation { get; set; }
        public virtual Userdet User { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
