using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            try
            {
                return Utils.ReadTextFromFile(Constants.DataFilePath);
            }
            catch
            {
                return "Data file doesn't exist";
            }
        }

        public IActionResult Trim()
        {
            Utils.WriteTextToFile(Constants.DataFilePath, "");

            return Redirect("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}