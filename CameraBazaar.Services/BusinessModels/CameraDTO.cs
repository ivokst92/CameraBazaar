namespace CameraBazaar.Services.BusinessModels
{
    using CameraBazaar.Data.Models;
    using System.Collections.Generic;

    public class CameraDTO
    {
        public int Id { get; set; }

        public CameraMakeType Make { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int MinShutterSpeed { get; set; }

        public int MaxShutterSpeed { get; set; }

        public MinISO MinISO { get; set; }

        public int MaxISO { get; set; }

        public bool IsFullFrame { get; set; }

        public string VideoResolution { get; set; }

        public IEnumerable<LightMetering> LightMetering { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string UserId { get; set; }
        public string Username { get; set; }
    }
}
