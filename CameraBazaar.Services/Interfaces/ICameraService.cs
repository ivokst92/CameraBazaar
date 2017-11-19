namespace CameraBazaar.Services.Interfaces
{
    using CameraBazaar.Services.BusinessModels;
    using System.Collections.Generic;

    public interface ICameraService
    {
        void Delete(int Id, string userId);

        CameraDTO GetById(int id);

        IEnumerable<CameraDTO> All();

        void Create(CameraDTO camera,
                    string userId);

        void Update(CameraDTO camera,
                    string userId);

        bool IsCameraOfCurrentUser(int cameraId, string userId);

        CameraDTO GetCamera(int id, string userId);

        SellerCamerasDTO GetSellersCameras(string userId);

    }
}
