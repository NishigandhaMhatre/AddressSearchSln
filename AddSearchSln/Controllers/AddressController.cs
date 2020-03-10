using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AddSearchSln.Models;
using AddSearchSln.Services;
using System.Web.Http.Cors;

namespace AddSearchSln.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [Route("api/addresses")]
    [ApiController]
    public class AddressController : Controller
    {
        private readonly AddressService addressService;

        public AddressController(AddressService _addressService)
        {
            addressService = _addressService;
        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpGet("/format")]
        public ActionResult<List<AddressFormatModel>> GetAddressFormat()
        {
            var temp = addressService.GetAddressFormat();
            return temp;

        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpGet("/address")]
        public ActionResult<List<AddressModel>> GetAddress()
        {
            var temp = addressService.GetAddress();
            return temp;

        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpPost("/searchAddress")]
        public ActionResult<List<AddressModel>> SearchAddress([FromBody] AddressModel addressModel)
        {
            var country = addressModel.Country;
            var addressLine1 = addressModel.AddressLine1;
            var addreessLine2 = addressModel.AddressLine2;
            var stateOrCounty = addressModel.StateOrCounty;
            var postcode = addressModel.PostCode;

            var result = addressService.SearchAddress(country, addressLine1, addreessLine2, stateOrCounty, postcode);
            return result;

        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpGet("/searchAddressFormat/{Country}")]
        public ActionResult<AddressFormatModel> SearchAddressFormat(String Country)
        {
           
            var result = addressService.SearchAddressFormat(Country);
            return result;
                
        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpPost("/addAddress")]
        public ActionResult<AddressModel> AddAddress([FromBody] AddressModel address)
        {
            return addressService.Add(address);
        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpPost("/addAddressFormat")]
        public ActionResult<AddressFormatModel> AddAddressFormat([FromBody] AddressFormatModel addressFormat)
        {
            return addressService.AddAddressFormat(addressFormat);
        }


    }
}
