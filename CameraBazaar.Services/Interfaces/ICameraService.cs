namespace CameraBazaar.Services.Interfaces
{
    using CameraBazaar.Services.BusinessModels;

    public interface ICameraService
    {
        void Create(CameraDTO camera,
                    string userId);

        void Update(CameraDTO camera,
                    string userId);

        bool IsCameraOfCurrentUser(int cameraId, string userId);

        CameraDTO GetCamera(int Id, string userId);

    }
}
