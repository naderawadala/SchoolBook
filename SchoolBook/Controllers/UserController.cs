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
		[Route("getall")]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
		public IActionResult GetAll()
		{
			return Ok(userManager.GetAll());
		}
		[HttpPost]
		[Route("register")]
		public IActionResult Register(RegisterModel model)
		{
			string result = userManager.Register(model);
			if (result.Length > 0)
			{
				return Ok(result);
			}
			return BadRequest("Couldn't register, this is either because the user already exists or the parameters are invalid");
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
			return BadRequest("Couldn't log in, check if the password and email combination is correct");
		}
		[HttpPost]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
		[Route("delete")]
		public IActionResult Delete(int id)
		{
			bool res = userManager.DeleteUser(id);
			if (res == false)
			{
				return BadRequest("Couldn't delete user, this may be because the ID was either invalid, or the user still is assigned" +
			"to a role, try deleting the user from a role they have first.");

			}
			return Ok("User deleted");
		}
		[HttpPost]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
		[Route("edit")]
		public IActionResult Edit(EditPersonModel model)
		{
			bool res = userManager.EditUser(model);
			if (res == false)
			{
				return BadRequest("Couldn't edit user, this may be because the params passed were invalid, make sure the information is" +
				"valid and then try again");
			}
			return Ok("User changes applied");
		}
		[HttpPost]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
		[Route("setteacher")]
		public IActionResult SetTeacher(SetTeacherModel model)
		{
			bool res = userManager.SetTeacher(model);
			if (res == false)
			{
				return BadRequest("Could not teacher, this could be because the teacher already exists, or the" +
					" parameters entered are invalid ");
			}
			return Ok("User successfully made teacher");
		}
		[HttpPost]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
		[Route("setstudent")]
		public IActionResult SetStudentAndParent(SetStudentAndParentModel model)
		{
			bool res = userManager.SetStudentAndParent(model);
			if (res == false)
			{
				return BadRequest("Could not make parent and student, this could be because the relation already exists, or the" +
					" parameters entered are invalid ");
			}
			return Ok("Student and Parent successfully applied");

		}
	}
}