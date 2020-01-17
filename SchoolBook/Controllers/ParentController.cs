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
		[HttpPost]
		[Route("childgrade")]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin, Parent")]
		public IActionResult GetChildGrades(int parentID)
		{
			Parent parent = manager.GetByID(parentID);
			
			Dictionary<Student,List<Grade>> grades = manager.GetChildGrades(parent);
			if (grades.Count() > 0)
			{
				return Ok(grades);
			}
			return BadRequest();
		}
	
    }
}