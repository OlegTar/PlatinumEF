using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatinumEF.Entities
{
    class Person
    {
        public int Id { get; set; }
        //[Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }

        public string MiddleName { get; set; }

        [ForeignKey(nameof(Department))]
        public int CurrentDepartmentId { get; set; }
        public Department Department { get; set; }

        public Address Address { get; set; }

        public ICollection<Hobby> Hobbies { get; set; }
    }
}
