using System;
using System.Collections.Generic;

namespace Library.Models
{
    public partial class Books
    {
        public Books()
        {
            Genre = new HashSet<Genre>();
            Members = new HashSet<Members>();
            Rent = new HashSet<Rent>();
        }

        public int Bookid { get; set; }
        public string Bookname { get; set; }
        public string Author { get; set; }
        public int? Price { get; set; }
        public string Publications { get; set; }
        public int? Gid { get; set; }

        public virtual Genre G { get; set; }
        public virtual ICollection<Genre> Genre { get; set; }
        public virtual ICollection<Members> Members { get; set; }
        public virtual ICollection<Rent> Rent { get; set; }
    }
}
