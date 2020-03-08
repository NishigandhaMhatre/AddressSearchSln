using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AddSearchSln.Models;
using AddSearchSln.Services;

namespace AddSearchSln.Controllers
{

    [Route("api/addresses")]
    [ApiController]
    public class AddressController : Controller
    {
        private readonly AddressService addressService;

        public AddressController(AddressService _addressService)
        {
            addressService = _addressService;
        }

        [HttpGet("/format")]
        public ActionResult<List<AddressFormatModel>> GetAddressFormat()
        {
            var temp = addressService.GetAddressFormat();
            return temp;

        }

        [HttpGet("/address")]
        public ActionResult<List<AddressModel>> GetAddress()
        {
            var temp = addressService.GetAddress();
            return temp;

        }


    }
}
