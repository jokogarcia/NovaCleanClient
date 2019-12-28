using System;
using System.Collections.Generic;
using System.Text;

namespace NovaCleanClient.Models
{
    public class VisitEvent:dbItemBase
    {
        public bool repeats {get;set;}

        public DateTime starting_date {get;set;}
        public DateTime starts_at {get;set;}
        public DateTimeOffset duration {get;set;}
        public DateTime date {get;set;}
        public List<CleaningTask> cleaningTasks {get;set;}
        public List<User> asignedEmployees {get;set;}
        public bool monday {get;set;}
        public bool tuesday {get;set;}
        public bool wednesday {get;set;}
        public bool thursday {get;set;}
        public bool friday {get;set;}
        public bool saturday {get;set;}
        public bool sunday {get;set;}

    }
}
