﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Data;

namespace backend.Migrations
{
    [DbContext(typeof(Model))]
    partial class ModelModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0-preview.2.21154.2");

            modelBuilder.Entity("backend.Models.Agent", b =>
                {
                    b.Property<int>("AgentCIN")
                        .HasColumnType("INTEGER")
                        .HasColumnName("AgentCIN");

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Adresse");

                    b.Property<DateTime>("DateEmb")
                        .HasColumnType("TEXT")
                        .HasColumnName("DateEmb");

                    b.Property<short>("Fonction")
                        .HasColumnType("INTEGER")
                        .HasColumnName("Fonction");

                    b.Property<string>("Immatricule")
                        .HasColumnType("TEXT")
                        .HasColumnName("Immatricule");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Nom");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Prenom");

                    b.Property<double>("Salaire")
                        .HasColumnType("REAL")
                        .HasColumnName("Salaire");

                    b.HasKey("AgentCIN");

                    b.ToTable("Agents");
                });

            modelBuilder.Entity("backend.Models.Candidat", b =>
                {
                    b.Property<int>("CandidatCIN")
                        .HasColumnType("INTEGER")
                        .HasColumnName("CandidatCIN");

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Adresse");

                    b.Property<DateTime>("Naissance")
                        .HasColumnType("TEXT")
                        .HasColumnName("Naissance");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Nom");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Prenom");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Tel");

                    b.HasKey("CandidatCIN");

                    b.ToTable("Candidats");
                });

            modelBuilder.Entity("backend.Models.Exam", b =>
                {
                    b.Property<string>("Convocation")
                        .HasColumnType("TEXT")
                        .HasColumnName("Convocation");

                    b.Property<int>("CandidatCIN")
                        .HasColumnType("INTEGER")
                        .HasColumnName("CandidatCIN");

                    b.Property<DateTime>("DateExam")
                        .HasColumnType("TEXT")
                        .HasColumnName("DateExam");

                    b.Property<string>("List")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("List");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER")
                        .HasColumnName("Type");

                    b.HasKey("Convocation");

                    b.HasIndex("CandidatCIN");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("backend.Models.LoginAgents", b =>
                {
                    b.Property<int>("AgentCIN")
                        .HasColumnType("INTEGER")
                        .HasColumnName("AgentCIN");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Password");

                    b.HasKey("AgentCIN");

                    b.ToTable("LoginAgents");
                });

            modelBuilder.Entity("backend.Models.Seances", b =>
                {
                    b.Property<DateTime>("DateSeance")
                        .HasColumnType("TEXT")
                        .HasColumnName("DateSeance");

                    b.Property<int>("CandidatCIN")
                        .HasColumnType("INTEGER")
                        .HasColumnName("CandidatCIN");

                    b.Property<int>("AgentCIN")
                        .HasColumnType("INTEGER")
                        .HasColumnName("AgentCIN");

                    b.Property<int>("SeanceType")
                        .HasColumnType("INTEGER")
                        .HasColumnName("SeanceType");

                    b.HasKey("DateSeance", "CandidatCIN", "AgentCIN");

                    b.HasIndex("AgentCIN");

                    b.HasIndex("CandidatCIN");

                    b.ToTable("Seances");
                });

            modelBuilder.Entity("backend.Models.Vehicle", b =>
                {
                    b.Property<string>("Immatricule")
                        .HasColumnType("TEXT")
                        .HasColumnName("Immatricule");

                    b.Property<int>("AgentCIN")
                        .HasColumnType("INTEGER")
                        .HasColumnName("AgentCIN");

                    b.Property<DateTime>("DateCirculation")
                        .HasColumnType("TEXT")
                        .HasColumnName("DateCirculation");

                    b.Property<string>("Marque")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Marque");

                    b.HasKey("Immatricule");

                    b.HasIndex("AgentCIN")
                        .IsUnique();

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("backend.Models.Exam", b =>
                {
                    b.HasOne("backend.Models.Candidat", "Candidat")
                        .WithMany("Exams")
                        .HasForeignKey("CandidatCIN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidat");
                });

            modelBuilder.Entity("backend.Models.LoginAgents", b =>
                {
                    b.HasOne("backend.Models.Agent", "Agent")
                        .WithOne("LoginAgent")
                        .HasForeignKey("backend.Models.LoginAgents", "AgentCIN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");
                });

            modelBuilder.Entity("backend.Models.Seances", b =>
                {
                    b.HasOne("backend.Models.Agent", "Agent")
                        .WithMany("Seances")
                        .HasForeignKey("AgentCIN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Models.Candidat", "Candidat")
                        .WithMany("Seances")
                        .HasForeignKey("CandidatCIN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");

                    b.Navigation("Candidat");
                });

            modelBuilder.Entity("backend.Models.Vehicle", b =>
                {
                    b.HasOne("backend.Models.Agent", "Agent")
                        .WithOne("Vehicle")
                        .HasForeignKey("backend.Models.Vehicle", "AgentCIN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");
                });

            modelBuilder.Entity("backend.Models.Agent", b =>
                {
                    b.Navigation("LoginAgent");

                    b.Navigation("Seances");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("backend.Models.Candidat", b =>
                {
                    b.Navigation("Exams");

                    b.Navigation("Seances");
                });
#pragma warning restore 612, 618
        }
    }
}
