using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalServer.ViewModels
{
    public class EntryInsight
    {
        public int EntryAnalysisId { get; set; }
        public int UserId { get; set; }
        public int EntryId { get; set; }
        public decimal Anger { get; set; }
        public decimal Joy { get; set; }
        public decimal Fear { get; set; }
        public decimal Surprise { get; set; }
        public decimal Sadness { get; set; }
        public decimal Sentiment { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime DateSubmitted { get; set; }
        public int WordCount { get; set; }
    }
}
