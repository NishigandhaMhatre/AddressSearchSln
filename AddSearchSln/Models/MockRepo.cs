using AddressSearchAlpha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddSearchSln.Models
{
    public class MockRepo : IAddressRepository
    {
        private List<AddressModel> _AddressList;
        public MockRepo()
        {
            _AddressList = new List<AddressModel>()
            {
                new AddressModel { Country = "United States of America", Id = "US"},
                new AddressModel { Country = "Uruguay", Id = "UY" },
                new AddressModel { Country = "Somalia", Id = "SO" },
                new AddressModel { Country = "Portugal", Id = "PT" },
                new AddressModel { Country = "Netherlands", Id = "NL" },
                new AddressModel { Country = "India", Id = "IN" }
            };
        }

        public AddressModel GetAddressCountry(String id)
        {
            return _AddressList.FirstOrDefault(a => a.Id == id);
        }

    }
}
