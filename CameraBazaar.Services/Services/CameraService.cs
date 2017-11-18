namespace CameraBazaar.Services.Services
{
    using AutoMapper;
    using CameraBazaar.Data;
    using CameraBazaar.Data.Models;
    using CameraBazaar.Services.BusinessModels;
    using CameraBazaar.Services.Interfaces;
    using CameraBazaar.Services.Utils;
    using System.Linq;

    public class CameraService : ICameraService
    {
        private readonly CameraBazaarDbContext db;
        private readonly IMapper mapper;
        public CameraService(CameraBazaarDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }


        public void Create(CameraDTO camera, string userId)
        {
            var cameraEntity = mapper.Map<CameraDTO, Camera>(camera);
            cameraEntity.LightMetering = (LightMetering)camera.LightMetering.Cast<int>().Sum();
            cameraEntity.UserId = userId;
            this.db.Cameras.Add(cameraEntity);
            this.db.SaveChanges();
        }

        public CameraDTO GetCamera(int id, string userId)
        => this.db.Cameras
            .Where(x => x.Id == id && x.UserId == userId)
                .Select(x => new CameraDTO
                {
                    Make = x.Make,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    IsFullFrame = x.IsFullFrame,
                    LightMetering = EnumMapping.ToValues<LightMetering>(x.LightMetering),
                    MaxISO = x.MaxISO,
                    MaxShutterSpeed = x.MaxShutterSpeed,
                    MinISO = x.MinISO,
                    MinShutterSpeed = x.MinShutterSpeed,
                    Model = x.Model,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    VideoResolution = x.VideoResolution,
                }).First();

        public bool IsCameraOfCurrentUser(int cameraId, string userId)
        => this.db.Cameras.Where(x => x.Id == cameraId && x.UserId == userId).Any();


        public void Update(CameraDTO camera, string userId)
        {
            var cameraEntity = mapper.Map<CameraDTO, Camera>(camera);
            cameraEntity.LightMetering = (LightMetering)camera.LightMetering.Cast<int>().Sum();
            cameraEntity.UserId = userId;
            this.db.Cameras.Update(cameraEntity);
            this.db.SaveChanges();
        }
    }
}
