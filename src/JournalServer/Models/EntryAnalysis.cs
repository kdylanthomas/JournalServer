using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalServer.Models
{
    public class EntryAnalysis
    {
        public int EntryAnalysisId { get; set; }
        public decimal Anger { get; set; }
        public decimal Joy { get; set; }
        public decimal Fear { get; set; }
        public decimal Surprise { get; set; }
        public decimal Sadness { get; set; }
        public decimal Sentiment { get; set; }
        public int UserId { get; set; }
        public int EntryId { get; set; }

        // establish foreign keys
        public User User { get; set; }
        public Entry Entry { get; set; }
    }
}
