using Business.Services;
using Microsoft.AspNetCore.Mvc;
using Business.ViewModels;
using System.Threading.Tasks;

namespace MyEduProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly ISliderService _sliderService;
        public HomeController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM homeVm = new HomeVM();

            homeVm.Sliders = await _sliderService.GetAll();

            return View(homeVm);

        }
    }
}
