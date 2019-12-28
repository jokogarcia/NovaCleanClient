using System;
using System.Collections.Generic;
using System.Text;

namespace NovaCleanClient.Models
{
    public class User:dbItemBase
    {
        public string name { get;set; }
        public string  last_name {get;set;}
        public string  dni {get;set;}
        public string  phone {get;set;}
        public string  cuit {get;set;}
        public string  photo_url {get;set;}
        public DateTime birth_date { get; set; }
        public DateTime employee_start_date { get; set; }
        public City City { get; set; }
        public string email { get; set; }
        public string api_token { get; set; }
        public string UserRole { get; set; }


    }
}
