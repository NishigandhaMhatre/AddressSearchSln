using AddressSearchAlpha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddSearchSln.Models
{
    interface IAddressRepository
    {
        AddressModel GetAddressCountry(String id);
        
    }
}
