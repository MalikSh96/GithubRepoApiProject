using GithubApiProject.Models;
using GithubApiProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GithubApiProject.Controllers
{
    public class GithubRepoController : Controller
    {
        private readonly IGithubApiService _githubApiService;

        //Constructor injection, IoC pattern
        public GithubRepoController(IGithubApiService githubApiService)
        {
            _githubApiService = githubApiService;
        }

        // GET: GithubRepoController
        [HttpGet]
        [Route("githubrepo")]
        public IActionResult Index()
        {
            return View();
        }

        // GET: GithubRepoController/GetRepositoriesForSingleUser/{Username}
        [HttpGet]
        public async Task<IActionResult> GetRepositoriesForSingleUser(string Username)
        {
            IEnumerable<GithubRepo> result = await _githubApiService.GetRepositoriesForGivenUser(Username);
            ViewBag.Username = Username; //to retrieve the name of the inputted user
            //ViewBag.GithubRepo = result; //to be able to display data on page
            if(result.Count() > 0) //if we get repos back
                return View(result);
            else
                return RedirectToAction("Error404", "ErrorHandler", null);
        }
    }
}
