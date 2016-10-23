using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace Azure.Data.ExchangeEntities
{
    public class Caching
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }

        static public void PlayGames(IEnumerable<Caching> teams)
        {
            // Simple random generation of statistics.
            Random r = new Random();

            foreach (var t in teams)
            {
                t.Wins = r.Next(33);
                t.Losses = r.Next(33);
                t.Ties = r.Next(0, 5);
            }
        }
    }

    public class TeamContext : DbContext
    {
        public TeamContext()
            : base("TeamContext")
        {
        }

        public DbSet<Caching> Teams { get; set; }
    }

    public class TeamInitializer : CreateDatabaseIfNotExists<TeamContext>
    {
        protected override void Seed(TeamContext context)
        {
            var teams = new List<Caching>
        {
            new Caching{Name="Adventure Works Cycles"},
            new Caching{Name="Alpine Ski House"},
            new Caching{Name="Blue Yonder Airlines"},
            new Caching{Name="Coho Vineyard"},
            new Caching{Name="Contoso, Ltd."},
            new Caching{Name="Fabrikam, Inc."},
            new Caching{Name="Lucerne Publishing"},
            new Caching{Name="Northwind Traders"},
            new Caching{Name="Consolidated Messenger"},
            new Caching{Name="Fourth Coffee"},
            new Caching{Name="Graphic Design Institute"},
            new Caching{Name="Nod Publishers"}
        };

            Caching.PlayGames(teams);

            teams.ForEach(t => context.Teams.Add(t));
            context.SaveChanges();
        }
    }

    public class TeamConfiguration : DbConfiguration
    {
        public TeamConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
    }
}