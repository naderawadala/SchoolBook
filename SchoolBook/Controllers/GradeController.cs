using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.CustomModels;
using Services.Managers.Interfaces;

namespace SchoolBook.Controllers
{
    [Route("api/grade")]
    [ApiController]
    public class GradeController : ControllerBase
    {
		IGradeManager manager;
		public GradeController(IGradeManager manager)
		{
			this.manager = manager;
		}
		[HttpGet]
		[Route("getall")]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Teacher")]
		public IActionResult GetGrades()
		{
			return Ok(manager.GetAll().ToList());
		}
		[HttpPost]
		[Route("set")]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Teacher")]
		public IActionResult SetGrade(SetGradeModel model)
		{
			bool result = manager.SetGrade(model);
			if (result == false)
			{
				return BadRequest("Couldn't set grade, check if the parameters are correct");
			}
			return Ok("Grade set successfully");
		}
		[HttpPost]
		[Route("edit")]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Teacher")]
		public IActionResult EditGrade(EditGradeModel model)
		{
			bool result = manager.EditGrade(model);
			if (result == false)
			{
				return BadRequest("Couldn't edit grade, check if the parameters are correct");
			}
			return Ok("Grade changed successfully");
		}
		[HttpPost]
		[Route("delete")]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
		public IActionResult DeleteGrade(int id)
		{
			bool result = manager.DeleteByID(id);
			if (result == false)
			{
				return BadRequest("Couldn't delete grade, check if the ID is correct");
			}
			return Ok("Grade deleted successfully");
		}
	}
}