using System;
using System.Collections.Generic;

#nullable disable

namespace FromDB
{
    public partial class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int? PersonId { get; set; }

        public virtual Person Person { get; set; }
    }
}
