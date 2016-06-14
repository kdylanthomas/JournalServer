using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace JournalServer.Models
{
    public class JournalContext : DbContext
    {
        public JournalContext(DbContextOptions<JournalContext> options)
            : base(options)
        { }

        public DbSet<User> User { get; set; }
        public DbSet<Entry> JournalEntry { get; set; }
        public DbSet<EntryAnalysis> EntryAnalysis { get; set; }
    }
}
