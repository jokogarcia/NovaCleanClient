using System;
using System.Collections.Generic;
using System.Text;

namespace NovaCleanClient.Models
{
    public class dbItemBase
    {
        public int id { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }

    }
}
