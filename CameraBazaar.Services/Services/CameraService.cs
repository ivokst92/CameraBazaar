namespace CameraBazaar.Services.Services
{
    using CameraBazaar.Data;
    using CameraBazaar.Data.Models;
    using CameraBazaar.Services.BusinessModels;
    using CameraBazaar.Services.Interfaces;
    using CameraBazaar.Services.Utils;
    using System.Collections.Generic;
    using System.Linq;

    public class CameraService : ICameraService
    {
        private readonly CameraBazaarDbContext db;

        public CameraService(CameraBazaarDbContext db)
        {
            this.db = db;
        }

        public void Create(CameraMakeType make,
            string model,
            decimal price,
            int quantity,
            int minShutterSpeed,
            int maxShutterSpeed,
            MinISO minISO,
            int maxISO,
            bool isFullFrame,
            string videoResolution,
            IEnumerable<LightMetering> lightMeterings,
            string description,
            string imageUrl,
            string userId)
        {
            var camera = new Camera
            {
                Make = make,
                Description = description,
                ImageUrl = imageUrl,
                IsFullFrame = isFullFrame,
                LightMetering = (LightMetering)lightMeterings.Cast<int>().Sum(),
                MaxISO = maxISO,
                MaxShutterSpeed = maxShutterSpeed,
                MinISO = minISO,
                MinShutterSpeed = minShutterSpeed,
                Model = model,
                Price = price,
                Quantity = quantity,
                VideoResolution = videoResolution,
                UserId = userId
            };

            this.db.Cameras.Add(camera);
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

    }
}
