using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using prop_central_netcore.Dto.Flats;
using prop_central_netcore.Dto.PopularPlaces;
using prop_central_netcore.Dto.RoomType;
using prop_central_netcore.Models;
using prop_central_netcore.Service.Interfaces;

namespace prop_central_netcore.Pages;

public class IndexModel : PropCentralPageModel
{
    private readonly ILogger<IndexModel> _logger;

    private readonly IRoomTypeService _roomTypeService;
    private readonly IFlatService _flatService;
    private readonly IPopularPlacesService _popularPlacesService;

    public IndexModel(ILogger<IndexModel> logger, IRoomTypeService roomTypeService, IFlatService flatService,
        IPopularPlacesService popularPlacesService)
    {
        _logger = logger;
        _roomTypeService = roomTypeService;
        _flatService = flatService;
        _popularPlacesService = popularPlacesService;
    }

    [BindProperty]
    public IndexViewModel indexViewModel  { get; set; }

    public async Task OnGetAsync()
    {

     //   var user = User.Claims.FindFirstValue(ClaimTypes.Name);
        indexViewModel = new IndexViewModel
        {
            RoomTypes = await _roomTypeService.GetAllRoomTypes(),
            LatestFlats = await _flatService.GetLatestFlats(),
            PopularPlaces = await _popularPlacesService.GetAllPopularPlaces(),
            Surbubs = _popularPlacesService.GetAllPlacesAsync().GetAwaiter().GetResult().Surbubs.Where(x => x.City.Contains("Durban")).ToList()
        };
    }

}

public class IndexViewModel
{
    public List<RoomTypeDto> RoomTypes { get; set; }
    public List<FlatViewDto> LatestFlats { get; set; }
    public List<PopularPlacesDto> PopularPlaces { get; set; }
    public List<SurbubDto> Surbubs { get; set; }
}

