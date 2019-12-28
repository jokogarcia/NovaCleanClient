using System;
using System.Collections.Generic;
using System.Text;

namespace NovaCleanClient.Models
{
    class NonConformityReport:dbItemBase
    {
        public int complaint_type {get;set;}
        public DateTime referenceDate {get;set;}
        public String comment {get;set;}
        public String photo_url {get;set;}
        public int visit_event_id {get;set;}

    }
}
