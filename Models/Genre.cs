using System;
using System.Collections.Generic;

namespace Library.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Books = new HashSet<Books>();
        }

        public int Gid { get; set; }
        public string Genre1 { get; set; }
        public int? Bookid { get; set; }

        public virtual Books Book { get; set; }
        public virtual ICollection<Books> Books { get; set; }
    }
}
