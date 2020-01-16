using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Services.CustomModels;
using Services.Managers.Interfaces;

namespace SchoolBook.Controllers
{
	[Route("api/user")]
	[ApiController]
	public class UserController : Controller
    {
		private IUserManager userManager;
		public UserController(IUserManager userManager)
		{
			this.userManager = userManager;
		}
		[HttpGet]
		public ActionResult Test()
		{
			return Ok("Test passed");
			// тегли swagger
		}
        [HttpPost]
		[Route("register")]
		public IActionResult Register(RegisterModel model)
		{
			string result=userManager.Register(model);
			if (result.Length > 0)
			{
				return Ok(result);
			}
			return BadRequest();
		}
		[HttpPost]
		[Route("login")]
		public IActionResult Login(LoginModel model)
		{
			string result = userManager.LoginUser(model);
			if (result.Length > 0)
			{
				return Ok(result);
			}
			return Unauthorized();
		}
		[HttpPost]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
		[Route("delete")]
		public IActionResult Delete(int id)
		{
			return Ok("boi u did it");
		}
    }
}