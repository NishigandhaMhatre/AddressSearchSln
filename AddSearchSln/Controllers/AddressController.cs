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
    public class AddressController : ControllerBase
    {
        private readonly AddressService addressService;

        public AddressController(AddressService _addressService)
        {
            addressService = _addressService;
        }

        [HttpGet]
        public ActionResult<List<AddressFormatModel>> Get()
        {
            var temp = addressService.Get();
            return temp;

        }
          
    }
}
