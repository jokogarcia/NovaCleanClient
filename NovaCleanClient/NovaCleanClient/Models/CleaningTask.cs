using System;
using System.Collections.Generic;
using System.Text;

namespace NovaCleanClient.Models
{
    public class CleaningTask:dbItemBase
    {
        public String descripcion { get; set; }
        public DateTimeOffset duration {get;set;}
        public int frequency {get;set;}
        public int sector_id {get;set;}
    }
}
