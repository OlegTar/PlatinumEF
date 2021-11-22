using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatinumEF.Entities
{
    //[Table("Deps")]
    class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //[ForeignKey("CurrentDepartmentId")]
        public ICollection<Person> Persons { get; set; }
    }
}
