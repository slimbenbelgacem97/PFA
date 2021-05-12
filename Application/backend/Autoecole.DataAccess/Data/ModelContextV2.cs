using backend.Autoecole.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace backend.Autoecole.DataAccess.Data
{
    public class ModelContextV2 :IdentityDbContext<ApplicationUser>
    {
        public ModelContextV2(DbContextOptions<ModelContextV2> options)
        : base(options)
        {

        }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // builder.Entity<Agent_Vehicule>()
            //                 .HasKey(av => new { av.AgentId, av.VehiculeId });
            builder.Entity<Agent_Vehicule>()
                        .HasOne(av => av.Agent)
                        .WithMany(av => av.Vehicules)
                        .HasForeignKey(av => av.AgentId).IsRequired(true);
            builder.Entity<Agent_Vehicule>()
                        .HasOne(av => av.Vehicule)
                        .WithMany(av => av.Agents)
                        .HasForeignKey(av => av.VehiculeId).IsRequired(true);

            builder.Entity<Candidate>()
                        .HasMany(x => x.Seances)
                        .WithOne(op => op.Candidate)
                        .HasForeignKey(op => op.CandidatId).IsRequired(true);
                        
            builder.Entity<Agent>()
                        .HasMany(x => x.Seances)
                        .WithOne(op => op.Agent)
                        .HasForeignKey(op => op.AgentId).IsRequired(true);
            builder.Entity<Seance>()
            .HasKey(s => new { s.AgentId, s.CandidatId, s.DateSeance });
            // builder.Entity<Vehicule>()
            // .HasAlternateKey(c => c.Immatricule)
            // .HasName("Immatricule");


        }
        #region Tables
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Seance> Seances { get; set; }
        public DbSet<Vehicule> Vehicules { get; set; }
        public DbSet<Agent_Vehicule> Agents_Vehicules { get; set; }

        #endregion
    }
}