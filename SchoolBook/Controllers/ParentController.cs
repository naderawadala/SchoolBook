using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Managers.Implementations;
using Services.Managers.Interfaces;

namespace SchoolBook.Controllers
{
    [Route("api/parent")]
    [ApiController]
    public class ParentController : ControllerBase
    {
		private ParentManager manager;
		public ParentController(ParentManager manager)
		{
			this.manager = manager;
		}
		[HttpPost]
		[Route("childgrade")]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Parent")]
		public IActionResult GetChildGrades(int parentID)
		{
			Parent parent = manager.GetByID(parentID);
			List<Grade> grades = manager.GetChildGrades(parent);
			if (grades.Count() > 0)
			{
				return Ok(grades);
			}
			return BadRequest();
		}
		[HttpPost]
		[Route("makeparent")]
		public IActionResult MakeParent()
		{
			return null;
		}
		[HttpPost]
		[Route("setchild")]
		public IActionResult SetChild()
		{
			return null;
		}
    }
}