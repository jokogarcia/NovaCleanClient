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
        public City city { get; set; }
        public string email { get; set; }
        public string api_token { get; set; }
        public UserRole user_role { get; set; }
        //Parametros que solo se usan para correcta deserializacion

        public int city_id { get; set; }
        public DateTime email_verified_at { get; set; }
        public int user_role_id { get; set; }
        public string tcn_state { get; set; }
        public int condicion_afip_id { get; set; }



    }
}
