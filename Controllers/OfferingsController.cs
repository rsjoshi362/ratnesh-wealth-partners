using Microsoft.AspNetCore.Mvc;

namespace asp_dot_net_core_first_app.Controllers
{
    [Route("~/offerings")]
    public class OfferingsController : Controller
    {
        #region ratnesh-wealth-partners

        [Route("ratnesh-wealth-partners/mutual-funds")]
        public IActionResult MutualFunds()
        {
            return View("mutual-funds");
        }

        [Route("ratnesh-wealth-partners/fixed-deposits")]
        public IActionResult FixedDeposits()
        {
            return View("fixed-deposits");
        }

        [Route("/ratnesh-wealth-partners/insurance-products")]
        public ActionResult InsuranceProducts()
        {
            return View("insurance-products");
        }

        [Route("/ratnesh-wealth-partners/bonds")]
        public ActionResult Bonds()
        {
            return View("bonds");
        }

        [Route("/ratnesh-wealth-partners/equity-investments")]
        public ActionResult EquityInvestments()
        {
            return View("equity-investments");
        }

        [Route("/ratnesh-wealth-partners/retirement-planning")]
        public ActionResult RetirementPlanning()
        {
            return View("retirement-planning");
        }

        [Route("/ratnesh-wealth-partners/wealth-management")]
        public ActionResult WealthManagement()
        {
            return View("wealth-management");
        }

        [Route("/ratnesh-wealth-partners/tax-planning")]
        public ActionResult TaxPlanning()
        {
            return View("tax-planning");
        }

        [Route("/ratnesh-wealth-partners/estate-planning")]
        public ActionResult EstatePlanning()
        {
            return View("estate-planning");
        }

        [Route("/ratnesh-wealth-partners/real-estate-investments")]
        public ActionResult RealEstateInvestments()
        {
            return View("real-estate-investments");
        }

        #endregion

        #region sv-printers

        [Route("/sv-printers/commercial-printing-services")]
        public ActionResult CommercialPrintingServices()
        {
            return View("commercial-printing-services");
        }

        [Route("/sv-printers/packaging-printing-services")]
        public ActionResult PackagingPrintingServices()
        {
            return View("packaging-printing-services");
        }

        [Route("/sv-printers/stationery-printing-services")]
        public ActionResult StationeryPrintingServices()
        {
            return View("stationery-printing-services");
        }

        [Route("/sv-printers/book-and-magazine-printing-services")]
        public ActionResult BookMagazinePrintingServices()
        {
            return View("book-and-magazine-printing-services");
        }

        [Route("/sv-printers/promotional-printing-services")]
        public ActionResult PromotionalPrintingServices()
        {
            return View("promotional-printing-services");
        }

        #endregion
    }
}