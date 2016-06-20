using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAdmin.Models
{
    public class Session
    {
        public string id { get; set; }
        public string eventid { get; set; }
        public string sessionname { get; set; }
        public string sessiontime { get; set; }
        public string endtime { get; set; } 
        public string speaker { get; set; } 
        public string description { get; set; } 
        [CreatedAt]
        public DateTime CreatedAt;
    }
}
