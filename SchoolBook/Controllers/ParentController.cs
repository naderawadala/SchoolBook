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
		private IParentManager manager;
		public ParentController(IParentManager manager)
		{
			this.manager = manager;
		}
		[HttpGet]
		[Route("getall")]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
		public IActionResult GetAllParents()
		{
			return Ok(manager.GetAll().ToList());
		}
		[HttpPost]
		[Route("childgrade")]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin, Parent")]
		public IActionResult GetChildGrades(int parentID)
		{
			Parent parent = manager.GetByID(parentID);
			if (parent != null)
			{
				List<Grade> grades = manager.GetChildGrades(parentID);
				if (grades.Count() > 0)
				{
					return Ok(grades.Select(x => new
					{
						StudentID=x.StudentID,
						SubjectID=x.SubjectID,
						Score=x.Score
					}).ToList());
				}
			}
			return BadRequest();
		}
		[HttpPost]
		[Route("delete")]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
		public IActionResult DeleteParent(int parentID)
		{
			bool result = manager.DeleteByID(parentID);
			if (result == false)
			{
				return BadRequest();
			}
			return Ok();
		}
		

	}
}