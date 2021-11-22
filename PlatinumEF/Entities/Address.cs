using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatinumEF.Entities
{
    class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }

        //[Key]
        //[ForeignKey(nameof(Person))]
        public int? PersonId { get; set; }
        public Person Person { get; set; }
    }
}
