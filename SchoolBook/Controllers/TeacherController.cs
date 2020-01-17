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
    [Route("api/teacher")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
		private ITeacherManager manager;
		public TeacherController(ITeacherManager manager)
		{
			this.manager = manager;
		}
		[HttpGet]
		[Route("getall")]
		[Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme, Roles = "Admin, Teacher")]
		public IActionResult GetAllTeachers()
		{
			return Ok(manager.GetAll().ToList());
		}
		[HttpPost]
		[Route("delete")]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
		public IActionResult Delete(int id)
		{
			bool res = manager.DeleteByID(id);
			if (res == true)
			{
				return Ok();
			}
			return BadRequest();
		}
		
	}
}