using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AddressSearchAlpha.Models;
using AddressSearchAlpha.Services;

namespace AddressSearchAlpha.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressService addressService;

        public AddressController(AddressService _addressService)
        {
            addressService = _addressService;
        }

        [HttpGet]
        public ActionResult<List<AddressModel>> Get() =>
          addressService.Get();
    }
}
