using System;
using System.Collections.Generic;

namespace Library.Models
{
    public partial class Rent
    {
        public Rent()
        {
            Members = new HashSet<Members>();
        }

        public int Rentid { get; set; }
        public int? Bookid { get; set; }
        public int? Dayskept { get; set; }

        public virtual Books Book { get; set; }
        public virtual ICollection<Members> Members { get; set; }
    }
}
