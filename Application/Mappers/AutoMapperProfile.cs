namespace Application.Mappers;

using Application.DTOs;
using AutoMapper;
using Domain.Entities;

/// <summary>
/// AutoMapper profile for mapping between <see cref="VehicleModel"/> entities and <see cref="VehicleModelDto"/>.
/// </summary>
public class AutoMapperProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AutoMapperProfile"/> class.
    /// Defines the mappings between <see cref="VehicleModel"/> and <see cref="VehicleModelDto"/>.
    /// </summary>
    public AutoMapperProfile()
    {
        CreateMap<VehicleModel, VehicleModelDto>();
        CreateMap<CreateVehicleModelDto, VehicleModel>();
        CreateMap<UpdateVehicleModelDto, VehicleModel>()
            .ForMember(x => x.Id, src => src.Ignore());
        CreateMap<Announcement, AnnouncementDto>();
        CreateMap<CreateAnnouncementDto, Announcement>();
        CreateMap<UpdateAnnouncementDto, Announcement>();
        CreateMap<RegisterDto, User>();
        CreateMap<User, UserInfoDto>()
            .ForMember(x => x.ImgUrl, src => src.MapFrom(x => x.Image.Url));
    }
}