using System;
using System.ComponentModel.DataAnnotations;


namespace TaskApp2
{
    public enum RepeatFrequencyEnum
    {
        [Display(Name = "Every Day")]
        Daily=1,
        [Display(Name = "Weekdays (M-F)")]
        Weekdays=2,
        [Display(Name = "Weekends (S+S+)")]
        Weekends=3,
        [Display(Name = "One day a week")]
        Weekly=4,
        [Display(Name = "One day every other week")]
        BiWeekly=5,
        [Display(Name = "One day a Month")]
        Monthly=6,
     //   [Display(Name = "One day a Quarter")]
       // Quartly,
        [Display(Name = "One day a Year")]
        Yearly=7
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
        public Boolean Complete {get;set;}
        public RepeatFrequencyEnum RepeatFreq {get;set;}
        
        public DayOfWeek SelectedDay {get; set;}
        public DateTime ScheduleDay {get;set;}
        /*
            Once a week - will use day of week (1-7)
            Biweekly - will use day of week, and date for the first occurance (1-7)
            Monthly - will use day of month (1-31) and date for the first occurance
            Yearly - will use day of year (1-365) and date for the first occurance
        */
    }

    public class TaskTemplate
    {
        public int ID {get; set;}
        public string Name{get;set;}
        public string Desc{get;set;}
        public RepeatFrequencyEnum RepeatFreq {get;set;} //how often
        public DayOfWeek SelectedDay {get; set;} //day of the week for Weekly tasks
        public DateTime FirstDay {get;set;} //the day used for the base of the repatition.
    }

    public class TaskInstance{
        public int ID {get; set;}
        public string Name{get; set;}
        public string Desc {get; set;}
        public bool Complete { get; set;}
        public DateTime TaskDate {get; set;}

    }

}