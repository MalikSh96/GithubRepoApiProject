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
        //this will get all repos for a given user
        public async Task<IEnumerable<GithubRepo>> GetRepositoriesForGivenUser(string Username)
        {
            /*
                The reason for using the "using" statement is to make sure the the object is disposed 
                as soon as it goes out of scope. The "using" keyword tells the compiler that the variable 
                being declared should be disposed at the end of the enclosing scope.
                Dispose() is called during "garbage collecting" (manages the allocation and release of memory).
                Dispose() is a method that is present in the IDisposable interface.
                "using" makes sure that Dispose is called once we are done with the object.
                Improves performance.
            */
            //The HttpClient class instance is used to send HTTP requests
            using (HttpClient client = new HttpClient())
            {
                var url = new Uri($"https://api.github.com/users/{Username}/repos");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                //for some reason without doing this the line below, we are not allowed to make a request, so we need it
                client.DefaultRequestHeaders.UserAgent.TryParseAdd("request"); //Set the User Agent to "request"

                //Represents a HTTP response message, includes status code and data
                using (HttpResponseMessage response = client.GetAsync(url).Result) //HttpClient has async method
                {
                    response.EnsureSuccessStatusCode(); //need to make sure we get a successful response
                    /*
                        Because we are using async, we need to ready out the response that we get
                        back and deserialize it from json object to our GithubRepository model
                    */
                    string json;
                    using (var content = response.Content)
                    {
                        json = await content.ReadAsStringAsync();
                    }
                    //we deserialize the json data to our desired type
                    IEnumerable<GithubRepo> repos = JsonConvert.DeserializeObject<IEnumerable<GithubRepo>>(json);
                    return repos;
                }
            }
        }

        //This will get only the username/owner
        public async Task<GithubRepo> GetOwnerName(string Username)
        {
            using (HttpClient client = new HttpClient())
            {
                var url = new Uri($"https://api.github.com/users/{Username}");
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
                    GithubRepo owner = JsonConvert.DeserializeObject<GithubRepo>(json);
                    return owner;
                }
            }
        }
    }
}
