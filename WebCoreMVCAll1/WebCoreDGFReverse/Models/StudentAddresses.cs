using System;
using System.Collections.Generic;

namespace WebCoreDGFReverse.Models
{
    public partial class StudentAddresses
    {
        public int StudentAddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public Students StudentAddress { get; set; }
    }
}
