using GithubApiProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GithubApiProject.Services
{
    public class GithubApiService : IGithubApiService
    {
        public async Task<IEnumerable<GithubRepo>> GetRepositoriesForGivenUser(string Username)
        {
            using (HttpClient client = new HttpClient())
            {
                var url = new Uri($"https://api.github.com/users/{Username}/repos");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");//Set the User Agent to "request"

                using (HttpResponseMessage response = client.GetAsync(url).Result) //HttpClient has async method
                {
                    response.EnsureSuccessStatusCode();
                    /*
                        Because we are using async, we need to ready out the response that we get
                        back and deserialize it from json object to our GithubRepository model
                    */
                    string json;
                    using (var content = response.Content)
                    {
                        json = await content.ReadAsStringAsync();
                    }
                    IEnumerable<GithubRepo> repos = JsonConvert.DeserializeObject<IEnumerable<GithubRepo>>(json);
                    return repos;
                }
            }
        }
    }
}
