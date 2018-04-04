using System;
using System.ComponentModel.DataAnnotations;


namespace TaskApp2
{
    public enum RepeatFrequencyEnum
    {
        [Display(Name = "Every Day")]
        Daily,
        [Display(Name = "Weekdays (M-F)")]
        Weekdays,
        [Display(Name = "Weekends (S+S+)")]
        Weekends,
        [Display(Name = "One day a week")]
        Weekly,
        [Display(Name = "One day every other week")]
        BiWeekly,
        [Display(Name = "One day a Month")]
        Monthly,
     //   [Display(Name = "One day a Quarter")]
       // Quartly,
        [Display(Name = "One day a Year")]
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
}