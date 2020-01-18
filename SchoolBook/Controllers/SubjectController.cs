using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Managers.Interfaces;

namespace SchoolBook.Controllers
{
    [Route("api/subject")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
		ISubjectManager manager;
		public SubjectController(ISubjectManager manager)
		{
			this.manager = manager;
		}
		[HttpGet]
		[Route("getall")]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Teacher")]
		public IActionResult GetSubjects()
		{
			return (Ok(manager.GetAll().ToList()));
		}
		[HttpPost]
		[Route("delete")]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
		public IActionResult DeleteSubject(int id)
		{
			bool result = manager.DeleteByID(id);
			if (result == false)
			{
				return BadRequest("Couldn't delete subject, check if the ID is correct");
			}
			return Ok("Subject deleted successfully");

		}
	}
}