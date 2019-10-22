using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DarknetImage.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using DarknetImage.Services.Email;

namespace DarknetImage.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;
        public HomeController(IHostingEnvironment environment)
        {
            hostingEnvironment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            string filePath = "";
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + formFile.FileName.Substring(formFile.FileName.LastIndexOf(".")).Trim('"');
                    string uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
                    filePath = Path.Combine(uploads, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        formFile.CopyTo(stream);
                    }
                }
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "check_image.bat";
            p.StartInfo.Arguments = filePath;
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            System.IO.File.Delete(filePath);

            bool hasKnife = output.Contains("knife");
            ViewData["Message"] = "Knife = " + hasKnife;
            ViewData["Output"] = output;

            if(hasKnife)
            {
                IEmailService emailService = new EmailService();
                IFeedbackMessageBuilder feedbackMessageBuilder = new FeedbackMessageBuilder();
                feedbackMessageBuilder.Build(output);
                emailService.SendHtml(feedbackMessageBuilder);
            }
            //return Ok(new { count = files.Count, size, filePath, output });
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
