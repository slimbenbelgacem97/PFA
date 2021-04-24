using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class ModelContextV2 : DbContext
    {
        public ModelContextV2(DbContextOptions<ModelContextV2> options)
        : base(options)
        {

        }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<LoginAgent> LoginAgents { get; set; }
        public DbSet<Seance> Seances { get; set; }
        public DbSet<Vehicule> Vehicules { get; set; }
        public DbSet<Agent_Vehicule> Agents_Vehicules { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Agent_Vehicule>()
                            .HasKey(av => new { av.AgentId, av.Immatricule, });
            builder.Entity<Agent_Vehicule>()
                        .HasOne(av => av.Agent)
                        .WithMany(av => av.Vehicules)
                        .HasForeignKey(av => av.AgentId);
            builder.Entity<Agent_Vehicule>()
                        .HasOne(av => av.Vehicule)
                        .WithMany(av => av.Agents)
                        .HasForeignKey(av => av.Immatricule);

            builder.Entity<Candidate>()
                        .HasMany(x => x.Seances)
                        .WithOne(op => op.Candidate)
                        .HasForeignKey(op => op.CandidatCIN).IsRequired(true);
            builder.Entity<Agent>()
                        .HasMany(x => x.Seances)
                        .WithOne(op => op.Agent)
                        .HasForeignKey(op => op.AgentId).IsRequired(true);
            builder.Entity<Seance>()
            .HasKey(s => new { s.AgentId, s.CandidatCIN, s.DateSeance });


        }
    }
}