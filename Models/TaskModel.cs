using System;
using System.ComponentModel.DataAnnotations;

namespace TaskApp2.Models
{
    public class Task
    {
        public int ID {get; set;}
        public string Name{get;set;}
        public string Desc{get;set;}

        [Display(Name = "Did you finish?")]
        public Boolean Complete{get;set;}
    }
}