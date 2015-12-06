using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using QueueDodge.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace QueueDodge
{
    public class QueueDodgeDB : DbContext
    {
        public DbSet<LadderChange> LadderChanges { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<LeaderboardComparison> LeaderboardComparisons { get; set; }

        // DERIVE FROM LEADERBOARDS SINCE DATA IS INCONSISTENT.
        public DbSet<Character> Characters { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Realm> Realms { get; set; }
        public DbSet<Faction> Factions { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Region> Regions { get; set; }

        // INSERTS FROM API REQUESTS ONLY.
        public DbSet<Leaderboard> Leaderboards { get; set; }

        public QueueDodgeDB() : base("QueueDodge")
        {
            this.Configuration.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
    
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}
