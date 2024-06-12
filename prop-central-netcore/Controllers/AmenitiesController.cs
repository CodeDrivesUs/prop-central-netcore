using System;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using prop_central_netcore.Service.Interfaces;
using Microsoft.AspNetCore.Cors.Infrastructure;
using prop_central_netcore.Dto.Amenities;

namespace prop_central_netcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
	{
		private readonly IAmenitiesService _amenitiesService;

        public AmenitiesController(IAmenitiesService amenitiesService)
		{
			_amenitiesService = amenitiesService;
		}

        [HttpGet]
        public async Task<List<AmenitiesDto>> GetAll()
        {
            return await _amenitiesService.GetAll();
        }
    }
}

