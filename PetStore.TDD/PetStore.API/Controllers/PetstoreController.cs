using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetStore.API.Models;
using PetStore.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class PetstoreController : Controller
    {
        private IUserService _userService;
        private IPetService _petService;
        private IAuthenticationService _authService;
        public PetstoreController(IUserService userService, IPetService petService, IAuthenticationService authService)
        {
            _userService = userService;
            _petService = petService;
            _authService = authService;
        }

        [Route("pets/{id}")]
        [HttpGet]
        public IActionResult GetPetById(int id, [FromQuery] string token)
        {
			try
			{
                var isTokenValid = _authService.CheckToken(token, 1);
                if (isTokenValid) return Ok(_petService.Get(id));
                return Unauthorized();
            }
			catch (Exception ex)
			{
                return BadRequest(ex.Message);
			}


        }

        [Route("pets")]
        [HttpPost]
        public IActionResult InsertPet([FromBody] Pet pet, [FromQuery] string token)
        {
            try
            {
                var isTokenValid = _authService.CheckToken(token, 1);
                if (isTokenValid) return Ok(_petService.Add(pet));
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("adopt/{id}")]
        [HttpPost]
        public IActionResult AdoptPet(int id, [FromQuery] string token)
        {
            try
            {
                var isTokenValid = _authService.CheckToken(token, 1);
                if (isTokenValid) return Ok(_petService.Adopt(id));
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("login")]
        [HttpGet]
        public IActionResult LogIn([FromQuery] string username, [FromQuery] string password)
        {
            try
            {
                return Ok(_userService.LogIn(username, password));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("register")]
        [HttpPost]
        public IActionResult Register([FromQuery] string username, [FromQuery] string password)
        {
            try
            {
                return Ok(_userService.Register(username, password));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
