using Microsoft.AspNetCore.Mvc;

namespace asp_dot_net_core_first_app.Controllers
{
    [Route("~/calculators")]
    public class CalculatorsController : Controller
    {
        [Route("sip-calculator")]
        public IActionResult SIP()
        {
            return View("sip-calculator");
        }

        [Route("retirement-calculator")]
        public IActionResult Retirement()
        {
            return View("retirement-calculator");
        }

        [Route("marriage-calculator")]
        public IActionResult Marriage()
        {
            return View("marriage-calculator");
        }

        [Route("education-calculator")]
        public IActionResult Education()
        {
            return View("education-calculator");
        }
    }
}