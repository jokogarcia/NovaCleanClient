using System;
using System.Collections.Generic;
using System.Text;

namespace NovaCleanClient.Models
{
    public class City:dbItemBase
    {
        public string name;
        public Province province;
        public int province_id;
    }
}
