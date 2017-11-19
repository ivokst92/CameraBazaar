using System.Collections.Generic;

namespace CameraBazaar.Services.BusinessModels
{
    public class SellerCamerasDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int CamerasInStock { get; set; }
        public int CamerasOutOfStock { get; set; }
        public IEnumerable<CameraDTO> Cameras { get; set; }
    }
}
