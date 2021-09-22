using GithubApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubApiProject.Services
{
    public interface IGithubApiService
    {
        Task<IEnumerable<GithubRepo>> GetRepositoriesForGivenUser(string Username);
        Task<GithubRepo> GetOwnerName(string Username);
    }
}
