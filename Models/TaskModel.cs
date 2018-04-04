using System;
using System.ComponentModel.DataAnnotations;
namespace TaskApp2
{
    public enum RepeatFrequency
    {
        Daily,
        Weekdays,
        Weekend,
        Weekly,
        BiWeekly,
        Monthly,
        Quartly,
        Yearly
    }
}
namespace TaskApp2.Models
{

    public class Task
    {
        public int ID {get; set;}
        public string Name{get;set;}
        public string Desc{get;set;}

        [Display(Name = "Did you finish?")]
        public Boolean Complete{get;set;}
        public RepeatFrequency RepeatFreq{get;set;}

    }
}