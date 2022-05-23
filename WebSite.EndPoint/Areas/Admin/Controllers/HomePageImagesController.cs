using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.HomePages.AddHomePageImages;
using Domain.Entities.HomePages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Operator, Admin")]
    public class HomePageImagesController : Controller
    {
        private readonly IAddHomePageImagesService _addHomePageImagesService;
        public HomePageImagesController(IAddHomePageImagesService addHomePageImagesService)
        {
            _addHomePageImagesService = addHomePageImagesService;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(IFormFile file, string link , ImageLocation imageLocation)
        {
            _addHomePageImagesService.Execute(new requestAddHomePageImagesDto
            {
                file = file,
                ImageLocation = imageLocation,
                Link = link,
            });
            return View();
        }

    }
}
