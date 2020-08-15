using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eBooking.Models;

namespace eBooking.Controllers
{
    public class HomeController : Controller
    {
        [ActionName("Login")]
        public async Task<IActionResult> Login()
        {
            return await Task.Run(() => {
                return View();
            });
        }
        [ActionName("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            return await Task.Run(() => {
                return RedirectToAction("Login","Home");
            });
        }
        [HttpGet]
        [ActionName("Home")]
        public async Task<IActionResult> Home()
        {
            return await Task.Run(() => {
                return View();
            });
        }
        [HttpGet]
        [ActionName("RegisterUser")]
        public async Task<IActionResult> RegisterUser()
        {
            return await Task.Run(() => {
                return View("~/Views/Home/_RegisterUser.cshtml");
            });
        }
        [HttpGet]
        [ActionName("SignIn")]
        public async Task<PartialViewResult> SignIn()
        {
            return await Task.Run(() => {
                return PartialView("~/Views/Home/_SignIn.cshtml");
            });
        }
        [HttpGet]
        [ActionName("GetMap")]
        public async Task<PartialViewResult> _Map()
        {
            return await Task.Run(() => {
                return PartialView("~/Views/Home/_Map.cshtml");
            });
        }
        public async Task<IActionResult> Map()
        {
            return await Task.Run(() => {
                return View();
            });
        }
    }
}
