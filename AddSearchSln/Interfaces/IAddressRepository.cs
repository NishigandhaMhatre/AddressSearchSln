using AddSearchSln.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddSearchSln.Interfaces
{
    interface IAddressRepository
    {
        AddressModel GetAddressCountry(String id);
        
    }
}
