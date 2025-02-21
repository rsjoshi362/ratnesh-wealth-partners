using asp_dot_net_core_first_app.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace asp_dot_net_core_first_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //default Home-Index
        public IActionResult Index()
        {
            var offerings = new List<OfferingModel>
            {
                new() { Name = "Mutual Funds", ImageUrl = "~/img/offerings/Mutual-Funds.png", AltText = "Mutual Funds", Action = "MutualFunds", Delay = "0.1s", extraClass="" },
                new() { Name = "Fixed Deposits (FDs)", ImageUrl = "~/img/offerings/Bank-Fixed-Deposits.jpg", AltText = "Fixed Deposits (FDs)", Action = "FixedDeposits", Delay = "0.3s", extraClass="" },
                new() { Name = "Insurance Products", ImageUrl = "~/img/offerings/health-insurance-fam.png", AltText = "Insurance Products", Action = "InsuranceProducts", Delay = "0.5s", extraClass="" },
                new() { Name = "Bonds", ImageUrl = "~/img/offerings/what-are-bonds.png", AltText = "Bonds", Action = "Bonds", Delay = "0.1s", extraClass="" },
                new() { Name = "Equity Investments", ImageUrl = "~/img/offerings/Equity-Investments.png", AltText = "Equity Investments", Action = "EquityInvestments", Delay = "0.3s", extraClass="" },
                new() { Name = "Retirement Planning", ImageUrl = "~/img/offerings/RetirementPlanning.png", AltText = "Retirement Planning", Action = "RetirementPlanning", Delay = "0.5s", extraClass="" },
                new() { Name = "Wealth Management", ImageUrl = "~/img/offerings/Wealth-Management--scaled.jpg", AltText = "Wealth Management", Action = "WealthManagement", Delay = "0.1s", extraClass="" },
                new() { Name = "Tax Planning", ImageUrl = "~/img/offerings/tax-planning.png", AltText = "Tax Planning", Action = "TaxPlanning", Delay = "0.3s", extraClass="" },
                new() { Name = "Estate Planning", ImageUrl = "~/img/offerings/Estate Planning.jpg", AltText = "Estate Planning", Action = "EstatePlanning", Delay = "0.5s", extraClass="w-75" },
                new() { Name = "Real Estate Investments", ImageUrl = "~/img/offerings/investment-property.jpg", AltText = "Real Estate Investments", Action = "RealEstateInvestments", Delay = "0.1s", extraClass="" }
            };

            return View(offerings);
        }

        [Route("~/kyc-fatca-forms")]
        public IActionResult KYCFatcaForm()
        {
            return View("kyc-fatca-forms");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}