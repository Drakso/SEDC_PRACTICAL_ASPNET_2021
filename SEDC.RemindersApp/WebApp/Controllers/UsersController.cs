using Application;
using AutoMapper;
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
		private readonly IUserService _userService;
		private readonly IMapper _mapper;

		public UsersController(IUserService userService, IMapper mapper)
		{
			_userService = userService;
			_mapper = mapper;
		}

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
			var loggedInUser = _userService.LogIn(_mapper.Map<UserDTO>(model));
			if (loggedInUser == null) return View("AppError", new AppErrorViewModel()
			{
				Title = "Login Failed",
				Description = "Incorrect username or password was entered. Please make sure that you have an account and that you are entering your username and password correctly!"
			});

			return RedirectToAction("Index", "Reminders");
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Register(RegisterViewModel model)
		{
			var loggedInUser = _userService.Register(_mapper.Map<UserDTO>(model));
			if (loggedInUser == null) return View("AppError", new AppErrorViewModel()
			{
				Title = "Register Failed",
				Description = "Registering was not successfull! Please make sure you don't already have an account and that the data you provided is correct!"
			});

			return RedirectToAction("Index", "Reminders");
		}
	}
}
