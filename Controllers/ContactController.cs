using Microsoft.AspNetCore.Mvc;

//using RWP_Core_Web_App.Code;
//using RWP_Core_Web_App.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Xml.Linq;
using asp_dot_net_core_first_app.Models;
using asp_dot_net_core_first_app.Code;
using System.Diagnostics;

namespace asp_dot_net_core_first_app.Controllers
{
    [Route("~/contact-us")]
    public class ContactController : Controller
    {
        private readonly IEmailService _emailService;
        private IWebHostEnvironment Environment;

        public ContactController(IEmailService emailService, IWebHostEnvironment _environment)
        {
            _emailService = emailService;
            Environment = _environment;
        }

        [Route("")]
        [HttpGet]
        public ViewResult ContactUs()
        {
            return View("contact-us");
        }

        [Route("send-email")]
        [HttpPost]
        public async Task<IActionResult> SendEmail(ContactModel contact)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Message = "Invalid form submission. Please check your inputs.";
                    return RedirectToAction("ContactUs");
                }

                string bodyHTML = string.Empty;

                var filePath = Path.Combine(Environment.ContentRootPath, "EmailTemplates", "ContactUsEmailTemplate.txt");

                // Open and Read the email template/text file using a stream reader.
                using (StreamReader reader = new(filePath))
                {
                    bodyHTML = await reader.ReadToEndAsync();
                }

                if (string.IsNullOrEmpty(bodyHTML))
                {
                    ViewBag.Message = "Email template is empty or missing.";
                    return RedirectToAction("ContactUs");
                }

                // Replace placeholders with actual values
                bodyHTML = bodyHTML.Replace("{{Name}}", contact.Name)
                                   .Replace("{{Email}}", contact.Email)
                                   .Replace("{{Phone}}", contact.Phone)
                                   .Replace("{{Subject}}", contact.Subject)
                                   .Replace("{{Message}}", contact.Message)
                                   .Replace("{{Year}}", DateTime.Now.Year.ToString());

                // Call the email service
                var isEmailSent = await _emailService.SendEmailAsync(contact.Email, contact.Subject ?? "No Subject available!", bodyHTML);

                if (isEmailSent)
                {
                    return RedirectToAction("ThankYou");
                }
                else
                {
                    ViewBag.Message = "There was an issue sending your email. Please try again later.";
                    return RedirectToAction("Error");
                }
            }
            catch (Exception ex)
            {
                // Log the error (implement proper logging mechanism as required)
                Console.WriteLine($"Unexpected error: {ex.Message}");

                // Redirect to a generic error page
                ViewBag.Message = "An unexpected error occurred. Please try again later.";
                return RedirectToAction("Error");
            }
        }

        [Route("thank-you")]
        public ViewResult ThankYou()
        {
            return View("thank-you");
        }

        [Route("error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}