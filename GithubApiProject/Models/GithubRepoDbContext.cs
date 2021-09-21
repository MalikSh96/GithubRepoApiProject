using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubApiProject.Models
{
    public class GithubRepoDbContext : DbContext
    {
        //Every time you create a Db context class, you need an empty constructor
        //Since we are using Core, we need dependency injection
        //Which also will invoke base class constructor
        public GithubRepoDbContext(DbContextOptions<GithubRepoDbContext> options) : base(options)
        {

        }

        public DbSet<GithubRepo> GithubRepos { get; set; }
        public DbSet<UserRepository> UserRepositories { get; set; }
    }
}
