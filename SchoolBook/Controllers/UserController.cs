using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.CustomModels;
using Services.Managers.Interfaces;

namespace SchoolBook.Controllers
{
	[Route("api/users")]
	[ApiController]
    public class UserController : Controller
    {
		private IUserManager userManager;
		public UserController(IUserManager identityManager)
		{
			this.userManager = identityManager;
		}
        [HttpPost]
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
		public IActionResult Login(LoginModel model)
		{
			string result = userManager.LoginUser(model);
			if (result.Length > 0)
			{
				return Ok(result);
			}
			return Unauthorized();
		}
    }
}