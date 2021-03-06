﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalServer.Models
{
    public class Entry
    {
        public int EntryId { get; set; }
        public string Text { get; set; }
        public int WordCount { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime DateSubmitted { get; set; }
        public int UserId { get; set; }

        // establish foreign key
        public User User { get; set; }
    }
}
