using System;
using System.Collections.Generic;
using System.Text;

namespace NovaCleanClient.Models
{
    public class Location:dbItemBase
    {
        public String name {get;set;}
        public String address_street_name {get;set;}
        public String address_street_number {get;set;}
        public String address_floor {get;set;}
        public String address_appartment {get;set;}
        public String phone_number {get;set;}
        public String local_contact_name {get;set;}
        public String local_contact_email {get;set;}
        public String local_contact_phone {get;set;}
        public String photo_url {get;set;}
        public double latitude {get;set;}
        public double longitude {get;set;}
        public String contract_number {get;set;}
        public User Supervisor {get;set;}

        public List<VisitEvent> visitEvents {get;set;}
        public List<Sector> sectors {get;set;}

    }
}
