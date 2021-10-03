using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
	public class UsersController : Controller
	{
		// The user asks for the login page
		// This action provides the page to the user
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		// The view login form sends the information to the backend ( this action )
		// This action accepts that information and does something with it
		[HttpPost]
		public IActionResult Login(LoginViewModel model)
		{

			return View();
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Register(RegisterViewModel model)
		{

			return View();
		}
	}
}
