using System;
using System.Collections.Generic;

#nullable disable

namespace FromDB
{
    public partial class Hobby
    {
        public Hobby()
        {
            PersonHobbies = new HashSet<PersonHobby>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PersonHobby> PersonHobbies { get; set; }
    }
}
