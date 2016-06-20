using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAdmin.Models
{
    public class Event
    {
        public string id { get; set; }
        public string eventname { get; set; }
        public string eventdate { get; set; }
        public string eventplace { get; set; }
        public string description { get; set; }
        public string registerationlink { get; set; } 
        public bool complete { get; set; }
        [CreatedAt]
        public DateTime CreatedAt;
    }
}
