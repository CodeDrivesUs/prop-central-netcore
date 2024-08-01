using System;
using Microsoft.AspNetCore.Mvc;
using prop_central_netcore.Dto.Amenities;
using prop_central_netcore.Dto.Flats;
using prop_central_netcore.Dto.RoomType;
using prop_central_netcore.Models;
using prop_central_netcore.Service.Interfaces;

namespace prop_central_netcore.Controllers
{
	public class FlatsHomeController :Controller
	{
        private readonly IFlatService _flatService;
        private readonly IFlatImageService _flatImageService;
        private readonly IRoomTypeService _roomTypeService;
        private readonly IAmenitiesService _amenitiesService;

        public FlatsHomeController(IFlatService flatService, IFlatImageService flatImageService, IRoomTypeService roomTypeService, IAmenitiesService amenitiesService)
        {
            _flatService = flatService;
            _flatImageService = flatImageService;
            _amenitiesService = amenitiesService;
            _roomTypeService = roomTypeService;
        }

        [HttpPost]
        public ActionResult GetSelectedRoomTypes(Guid[] roomtypeId)
        {
            return View(new SelectedRoomTypesDto { _roomtypeIds = PopulateRoomtypes(roomtypeId) });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult ReviewApplication(FullFlatApplicationDto fullFlatApplicationSharedModel)
        {
            fullFlatApplicationSharedModel._listamenities = PopulaAmenities(fullFlatApplicationSharedModel.Amenities);
            fullFlatApplicationSharedModel._listflatroomtypes = PopulateFlatRoomType(fullFlatApplicationSharedModel.DepositWithIds, fullFlatApplicationSharedModel.RentWithIds, fullFlatApplicationSharedModel.RoomTypes);
            return View(fullFlatApplicationSharedModel);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult SubmitApplication(FullFlatApplicationDto fullFlatApplicationSharedModel)
        {
            fullFlatApplicationSharedModel._listamenities = PopulaAmenities(fullFlatApplicationSharedModel.Amenities);
            fullFlatApplicationSharedModel._listflatroomtypes = PopulateFlatRoomType(fullFlatApplicationSharedModel.DepositWithIds, fullFlatApplicationSharedModel.RentWithIds, fullFlatApplicationSharedModel.RoomTypes);
            fullFlatApplicationSharedModel.UserId = new Guid();
            Guid flatId = _flatService.AddFlatApplication(fullFlatApplicationSharedModel).GetAwaiter().GetResult();
            return Json(flatId);
        }

        public List<FlatRoomTypesDto> PopulateFlatRoomType(string[] deposit, string[] rent, Guid[] Id)
        {
            var list = new List<FlatRoomTypesDto>();
            foreach (var item in Id)
            {
                list.Add(new FlatRoomTypesDto
                {
                    RoomTypeId = item,
                    Name = _roomTypeService.GetAllRoomTypes().GetAwaiter().GetResult().Where(x => x.Id == item).FirstOrDefault().Name,
                    Deposit = ProccessDepositList(deposit).Where(x => x.Id == item).FirstOrDefault().Amount,
                    Rent = ProccessRentList(rent).Where(x => x.Id == item).FirstOrDefault().Amount
                });
            }
            return list;
        }

        public List<IdAndAmount> ProccessRentList(string[] rentlist)
        {
            var list = new List<IdAndAmount>();
            foreach (var item in rentlist)
            {
                string[] arr = item.Split('|');
                list.Add(new IdAndAmount { Id = new Guid(arr[0]), Amount = decimal.Parse(arr[1]) });
            }
            return list;
        }
        public List<IdAndAmount> ProccessDepositList(string[] depositlist)
        {
            var list = new List<IdAndAmount>();
            foreach (var item in depositlist)
            {
                string[] arr = item.Split('|');
                list.Add(new IdAndAmount { Id = new Guid(arr[0]), Amount = decimal.Parse(arr[1]) });
            }
            return list;
        }



        public List<RoomTypeDto> PopulateRoomtypes(Guid[] roomtypes)
        {
            var list = new List<RoomTypeDto>();
            foreach (var item in roomtypes)
            {
                list.Add( _roomTypeService.GetAllRoomTypes().GetAwaiter().GetResult().Where(x => x.Id == item).FirstOrDefault());
            }
            return list;
        }

        public List<AmenitiesDto> PopulaAmenities(Guid[] amenities)
        {
            var list = new List<AmenitiesDto>();
            foreach (var item in amenities)
            {
                list.Add( _amenitiesService.GetAll().GetAwaiter().GetResult().Where(x => x.Id == item).FirstOrDefault());
            }
            return list;
        } 

    }
}

