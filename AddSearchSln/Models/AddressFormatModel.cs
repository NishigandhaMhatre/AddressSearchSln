using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddSearchSln.Models
{
    public class AddressFormatModel
    {
        public string id { get; set; }
        public string Country { get; set; }
        public AddressStructureToken AddressLine1 { get; set; }
        public AddressStructureToken AddressLine2 { get; set; }
        public AddressStructureToken StateOrCounty { get; set; }
        public AddressStructureToken PostCode { get; set; }
    }
}
