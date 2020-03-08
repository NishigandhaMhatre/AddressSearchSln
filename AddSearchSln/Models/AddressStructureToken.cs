using AddSearchSln.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddSearchSln.Models
{
    public class AddressStructureToken : IFormat
    {
        public string DisplayName { get; set; }
        public string Format { get; set; }
        public string Type { get; set; }
    }
}
