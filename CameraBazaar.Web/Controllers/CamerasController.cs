namespace CameraBazaar.Web.Controllers
{
    using AutoMapper;
    using CameraBazaar.Data.Models;
    using CameraBazaar.Services.BusinessModels;
    using CameraBazaar.Services.Interfaces;
    using CameraBazaar.Web.Models.Cameras;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class CamerasController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly ICameraService cameraService;
        private readonly IMapper mapper;

        public CamerasController(UserManager<User> userManager, ICameraService cameraService, IMapper mapper)
        {
            this.userManager = userManager;
            this.cameraService = cameraService;
            this.mapper = mapper;
        }

        [Authorize]
        public IActionResult Add() => View();

        [Authorize]
        [HttpPost]
        public IActionResult Add(CameraViewModel cameraModel)
        {
            if (!ModelState.IsValid)
            {
                return View(cameraModel);
            }

            this.cameraService.Create(cameraModel.Make,
                cameraModel.Model,
                cameraModel.Price,
                cameraModel.Quantity,
                cameraModel.MinShutterSpeed,
                cameraModel.MaxShutterSpeed,
                cameraModel.MinISO,
                cameraModel.MaxISO,
                cameraModel.IsFullFrame,
                cameraModel.VideoResolution,
                cameraModel.LightMetering,
                cameraModel.Description,
                cameraModel.ImageUrl,
                this.userManager.GetUserId(User));

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [Authorize]
        public IActionResult Edit(int Id)
        {
            var camera = this.cameraService.GetCamera(Id, this.userManager.GetUserId(User));
            var model = mapper.Map<CameraDTO, CameraViewModel>(camera);
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(CameraViewModel cameraModel)
        {
            if (!ModelState.IsValid)
            {
                return View(cameraModel);
            }

            //TODO EDIT

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}