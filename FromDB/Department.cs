using System;
using System.Collections.Generic;

#nullable disable

namespace FromDB
{
    public partial class Department
    {
        public Department()
        {
            People = new HashSet<Person>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
