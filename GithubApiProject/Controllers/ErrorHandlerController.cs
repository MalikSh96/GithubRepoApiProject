using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubApiProject.Controllers
{
    [Route("Redirected")]
    public class ErrorHandlerController : Controller
    {
        [HttpGet]
        public IActionResult Error404()
        {
            return View();
        }
    }
}
