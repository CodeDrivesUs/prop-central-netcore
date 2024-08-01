using System;
using Microsoft.AspNetCore.Mvc;
using prop_central_netcore.Dto.FlatImage;
using prop_central_netcore.Dto.Flats;
using prop_central_netcore.Service.Interfaces;

namespace prop_central_netcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlatsController:ControllerBase
	{
        private readonly IFlatService _flatService;
        private readonly IFlatImageService _flatImageService;

        public FlatsController(IFlatService flatService, IFlatImageService flatImageService)
		{
            _flatService = flatService;
            _flatImageService = flatImageService;
		}

        [HttpGet]
        [Route("GetLatestFlats")]
        public async Task<List<FlatViewDto>> GetLatestFlats()
        {
            return await _flatService.GetLatestFlats();
        }

        [HttpGet]
        [Route("GetAllFlatsForPlaceName")]
        public async Task<List<FlatViewDto>> GetAllFlatsForPlaceName(string name)
        {
            return await _flatService.GetAllFlatsForPlaceName(name);
        }

        [HttpGet]
        [Route("GetFlatDetails")]
        public async Task<FlatDetailsDto> GetFlatDetails(Guid flatId)
        {
            return await _flatService.GetFlatDetails(flatId);
        }

        [HttpGet]
        [Route("GetGalleryImagesForAFlat")]
        public async Task<List<FlatImageDto>> GetGalleryImagesForAFlat(Guid flatId)
        {
            return await _flatImageService.GetGalleryImagesForAFlat(flatId);
        }

        [HttpGet]
        [Route("GetRoomAndImages")]
        public async Task<ManageRoomDto> GetRoomAndImages(Guid roomId)
        {
            //To Do: Get The FlatId using the roomId
            return await _flatService.InitializeManageRoom(roomId, new Guid());
        }

        [HttpPost]
        [Route("GetAllFlatsForFindFlats")]
        public async Task<List<FlatViewDto>> GetAllFlatsForFindFlats(SearchFlatDto model)
        {
            return await _flatService.GetAllFlatsForFindFlats(model);
        }

    }
}

