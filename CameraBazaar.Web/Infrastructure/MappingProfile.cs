namespace CameraBazaar.Web.Infrastructure
{
    using AutoMapper;
    using CameraBazaar.Data.Models;
    using CameraBazaar.Services.BusinessModels;
    using CameraBazaar.Web.Models.Cameras;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CameraViewModel, CameraDTO>().ReverseMap();
            CreateMap<CameraDTO, Camera>().ForMember(x => x.LightMetering, opt => opt.Ignore()).ReverseMap();
        }
    }
}
