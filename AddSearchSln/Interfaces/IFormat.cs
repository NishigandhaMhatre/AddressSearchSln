using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddSearchSln.Interfaces
{
    interface IFormat
    {
        String DisplayName { get; set; }
        String Format { get; set; }
        String Type { get; set; }

        public List<String> Value { get; set; }
    }
}
