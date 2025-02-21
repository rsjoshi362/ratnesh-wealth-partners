using Microsoft.AspNetCore.Mvc;

namespace RWP_Core_Web_App.Controllers
{
    public class WhyChooseUsController : Controller
    {
        [Route("~/why-choose-us/ratnesh-wealth-partners")]
        public IActionResult RatneshWealthPartners()
        {
            return View();
        }

        [Route("~/why-choose-us/sv-printers")]
        public IActionResult SVPrinters()
        {
            return View();
        }
    }
}