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
        WebClient webClient = new WebClient();
        HttpClient client = new HttpClient();
        private readonly IGithubApiService _githubApiService;

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
            //var url = new Uri($"h-ttps://api.github.com/users/{Owner}/repos");
            //string json;
            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");//Set the User Agent to "request"
            //HttpResponseMessage response = client.GetAsync(url).Result;
            //response.EnsureSuccessStatusCode();
            //var content = response.Content;
            //json = await content.ReadAsStringAsync();
            //GithubRepo[] repo = JsonConvert.DeserializeObject<GithubRepo[]>(json);
            IEnumerable<GithubRepo> result = await _githubApiService.GetRepositoriesForGivenUser(Username);
            ViewBag.Username = Username; //to retrieve the name of the inputted user
            ViewBag.GithubRepo = result; //to be able to display data on page
            return View(result);
        }
    }
}
