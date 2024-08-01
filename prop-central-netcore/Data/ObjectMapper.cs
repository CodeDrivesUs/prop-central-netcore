using System;
using AutoMapper;
using prop_central_netcore.Data.Entities.Amenities;
using prop_central_netcore.Data.Entities.Flat;
using prop_central_netcore.Data.Entities.PopularPlaces;
using prop_central_netcore.Data.Entities.RoomType;
using prop_central_netcore.Dto.Amenities;
using prop_central_netcore.Dto.Flats;
using prop_central_netcore.Dto.PopularPlaces;
using prop_central_netcore.Dto.RoomType;

namespace prop_central_netcore.Data
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Amenities, AmenitiesDto>().ReverseMap();
                cfg.CreateMap<City, CityDto>().ReverseMap();
                cfg.CreateMap<CreatePopularPlace, CreatePopularPlaceDto>().ReverseMap();
                cfg.CreateMap<PopularPlaces, PopularPlacesDto>().ReverseMap();
                cfg.CreateMap<Province, ProvinceDto>().ReverseMap();
                cfg.CreateMap<Surbub, SurbubDto>().ReverseMap();
                cfg.CreateMap<AddLandLord, AddLandLordDto>().ReverseMap();
                cfg.CreateMap<AddToFlatHistory, AddToFlatHistory>().ReverseMap();
                cfg.CreateMap<CreateUpdateFlat, CreateUpdateFlatDto>().ReverseMap();
                cfg.CreateMap<Flat, FlatDto>().ReverseMap();
                cfg.CreateMap<FlatRoomsAmenities, FlatAmenitiesRoomsDto>().ReverseMap();
                cfg.CreateMap<FlatRoomTypes, FlatRoomTypesDto>().ReverseMap();
                cfg.CreateMap<FlatView, FlatViewDto>().ReverseMap();
                cfg.CreateMap<SearchFlat, SearchFlatDto>().ReverseMap();
                cfg.CreateMap<RoomType, RoomTypeDto>().ReverseMap();



            });

            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }
}

