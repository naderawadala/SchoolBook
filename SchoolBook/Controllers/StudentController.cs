﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Managers.Interfaces;

namespace SchoolBook.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
		IStudentManager manager;
		public StudentController(IStudentManager manager)
		{
			this.manager = manager;
		}
		[HttpGet]
		[Route("getall")]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Teacher")]
		public IActionResult GetStudents()
		{
			return (Ok(manager.GetAll().ToList()));
		}
		
		[HttpPost]
		[Route("getavg")]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Teacher,Student")]
		public IActionResult GetAverageGrade(int studentID)
		{
			double result = manager.GetAverageGrade(studentID);
			if (result == -1)
			{
				return BadRequest();
			}
			return Ok(result);
		}
		[HttpPost]
		[Route("getgrades")]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Teacher,Student")]
		public IActionResult GetGrades(int studentID)
		{
			List<Grade> result = manager.GetStudentGrades(studentID);
			if (result == null)
			{
				return BadRequest();
			}
			return Ok(result.ToList());
		}
		[HttpPost]
		[Route("delete")]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
		public IActionResult DeleteStudent(int id)
		{
			bool result = manager.DeleteByID(id);
			if (result == false)
			{
				return BadRequest();
			}
			return Ok();
		}
	}
}