using System;
using Microsoft.AspNetCore.Mvc;
using prop_central_netcore.Dto.PopularPlaces;
using prop_central_netcore.Service.Interfaces;

namespace prop_central_netcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularPlacesController
	{
		private readonly IPopularPlacesService _popularPlacesService;

        public PopularPlacesController(IPopularPlacesService popularPlacesService)
		{
			_popularPlacesService = popularPlacesService;
		}

        [HttpGet]
        [Route("GetAllPopularPlaces")]
        public async Task<List<PopularPlacesDto>> GetAllPopularPlaces()
        {
            return await _popularPlacesService.GetAllPopularPlaces();
        }

        [HttpGet]
        [Route("GetAllPlaces")]
        public async Task<PlacesDto> GetAllPlaces()
        {
            return await _popularPlacesService.GetAllPlacesAsync();
        }
    }
}

