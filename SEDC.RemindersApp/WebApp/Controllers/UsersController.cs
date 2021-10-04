using Application;
using Application.Services;
using Application.Utilities;
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
		private readonly IAuthenticationService _authenticationService;
		private readonly IUserService _userService;
		private readonly IMapper _mapper;
		private readonly string _token = "token";

		public UsersController(IUserService userService, IMapper mapper, IAuthenticationService authenticationService)
		{
			_userService = userService;
			_mapper = mapper;
			_authenticationService = authenticationService;
		}

		// The user asks for the login page
		// This action provides the page to the user
		[HttpGet]
		public IActionResult Login()
		{
			var tokenFromCookie = Request.GetCookie(_token);
			var userId = _authenticationService.GetUserIdFromToken(tokenFromCookie);

			if (tokenFromCookie != "" && userId > 0) return RedirectToAction("Index", "Reminders");

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

			Response.SetCookie(_token, loggedInUser.Id);

			return RedirectToAction("Index", "Reminders");
		}

		[HttpGet]
		public IActionResult Register()
		{
			var tokenFromCookie = Request.GetCookie(_token);
			var userId = _authenticationService.GetUserIdFromToken(tokenFromCookie);

			if (tokenFromCookie != "" && userId > 0) return RedirectToAction("Index", "Reminders");

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

			Response.SetCookie(_token, loggedInUser.Id);

			return RedirectToAction("Index", "Reminders");
		}

		[HttpGet]
		public IActionResult Logout()
		{
			Response.Cookies.Delete(_token);

			return RedirectToAction("Login", "Users");
		}
	}
}
