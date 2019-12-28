using System;
using System.Collections.Generic;
using System.Text;

namespace NovaCleanClient.Models
{
    public class Sector:dbItemBase
    {
        public String name {get;set;}
        public String photo_url {get;set;}
        public String description {get;set;}
        public List<CleaningTask> cleaningTasks {get;set;}
    }
}
