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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateRegistered { get; set; }
      
        public string Entries { get; set; }
        public string EntryAnalyses { get; set; }
    }
}
