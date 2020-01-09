using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SchoolBook.Controllers
{
	[Route("api/auth")]
	[ApiController]
    public class AuthController : Controller
    {
       [HttpPost,Route("login")]
    }
}