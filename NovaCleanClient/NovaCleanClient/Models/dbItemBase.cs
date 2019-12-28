using System;
using System.Collections.Generic;
using System.Text;

namespace NovaCleanClient.Models
{
    public class dbItemBase
    {
        int id { get; set; }
        DateTime created_at { get; set; }
        DateTime updated_at { get; set; }

    }
}
