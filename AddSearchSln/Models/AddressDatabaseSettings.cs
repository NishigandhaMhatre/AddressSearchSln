using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddSearchSln.Interfaces;

namespace AddSearchSln.Models
{

    public class AddressDatabaseSettings : IAddressDatabaseSettings
    {
        public string AddressCollectionName { get; set; }
        public string AddressFormatCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }


}
