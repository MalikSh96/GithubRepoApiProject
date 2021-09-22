using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GithubApiProject.Models
{
    public class UserRepository
    {
        //Setting fk restraints
        //[ForeignKey("GithuRepo")]
        public string RepositoryName { get; set; } //name of repository

        //One repository can have one user
        //Using navigation property, virtual one
        public virtual GithubRepo GithubRepo { get; set; }
    }
}
