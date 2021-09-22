using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GithubApiProject.Models
{
    public class GithubRepo
    {
        //This is your "data"
        //This repository can include whatever field we want to extract from the api calls
        public string Username { get; set; } //repo owner
        public string Name { get; set; } //repo name
        public string Full_name { get; set; } //owner+repo name
        public string Html_url { get; set; } //url for the repo
        public string Login { get; set; } //repo owner also
    }
}
