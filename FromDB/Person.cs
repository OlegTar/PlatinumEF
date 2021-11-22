using System;
using System.Collections.Generic;

#nullable disable

namespace FromDB
{
    public partial class Person
    {
        public Person()
        {
            PersonHobbies = new HashSet<PersonHobby>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname2 { get; set; }
        public int? Age { get; set; }
        public int CurrentDepartmentId { get; set; }
        public string MiddleName { get; set; }

        public virtual Department CurrentDepartment { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<PersonHobby> PersonHobbies { get; set; }
    }
}
