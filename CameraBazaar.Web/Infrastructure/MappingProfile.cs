namespace CameraBazaar.Web.Infrastructure
{
    using AutoMapper;
    using CameraBazaar.Services.BusinessModels;
    using CameraBazaar.Web.Models.Cameras;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CameraViewModel, CameraDTO>().ReverseMap();
        }
    }
}
