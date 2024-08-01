using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using prop_central_netcore.Dto.Flats;
using prop_central_netcore.Models;
using prop_central_netcore.Service.Interfaces;

namespace prop_central_netcore.Pages;

[Authorize]
public class StartApplicationModel : PropCentralPageModel
{
    private readonly ILogger<StartApplicationModel> _logger;
    private readonly IRoomTypeService _roomTypeService;
    private readonly IAmenitiesService _amenitiesService;

    public StartApplicationModel(ILogger<StartApplicationModel> logger, IRoomTypeService roomTypeService, IAmenitiesService amenitiesService )
    {
        _logger = logger;
        _amenitiesService = amenitiesService;
        _roomTypeService = roomTypeService;
    }
    [BindProperty]
    public CreateUpdateFlatDto  createUpdateFlat { get; set; }

    public async Task OnGetAsync()
    {
        createUpdateFlat = new CreateUpdateFlatDto
        {
            ListAmenities = await _amenitiesService.GetAll(),
            ListRoomTypes = await _roomTypeService.GetAllRoomTypes()
        };
    }
}


