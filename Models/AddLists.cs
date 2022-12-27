using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NPMS.Models
{
    public partial class AddLists
    {
        public int AddListId { get; set; }
        public int? UserId { get; set; }
        public string AddTitle { get; set; }
        public int? CategoryId { get; set; }

        public virtual Adds AddTitleNavigation { get; set; }
        public virtual Category Category { get; set; }
        public virtual Userdet User { get; set; }
    }
}
