using Microsoft.AspNetCore.Mvc;

namespace RWP_Core_Web_App.Controllers
{
    [Route("~/about-us")]
    public class AboutController : Controller
    {
        [Route("ratnesh-wealth-partners")]
        public IActionResult RatneshWealthPartners()
        {
            return View("ratnesh-wealth-partners");
        }

        [Route("sv-printers")]
        public IActionResult SVPrinters()
        {
            return View("sv-printers");
        }
    }
}