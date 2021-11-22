using System;
using System.Collections.Generic;

#nullable disable

namespace FromDB
{
    public partial class PersonHobby
    {
        public int HobbiesId { get; set; }
        public int PersonsId { get; set; }

        public virtual Hobby Hobbies { get; set; }
        public virtual Person Persons { get; set; }
    }
}
