using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalServer.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Location { get; set; }
        public DateTime DateRegistered { get; set; }
    }
}
