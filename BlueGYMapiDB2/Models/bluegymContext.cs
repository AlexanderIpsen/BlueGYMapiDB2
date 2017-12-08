using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlueGYMapiDB2.Models
{
    public partial class bluegymContext : DbContext
    {
        public virtual DbSet<BlueEvent> BlueEvent { get; set; }
        public virtual DbSet<Businessandserviceq> Businessandserviceq { get; set; }
        public virtual DbSet<Generalquestionaire> Generalquestionaire { get; set; }
        public virtual DbSet<Judge> Judge { get; set; }
        public virtual DbSet<Scienceandtechnologyq> Scienceandtechnologyq { get; set; }
        public virtual DbSet<Societyandglobalizationq> Societyandglobalizationq { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<Tradeandskillq> Tradeandskillq { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=(local);Database=bluegym;Trusted_Connection=True;");
            }
        }
        public bluegymContext(DbContextOptions<bluegymContext> options)
    : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlueEvent>(entity =>
            {
                entity.HasKey(e => e.Eventid);

                entity.Property(e => e.Eventid)
                    .HasColumnName("eventid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Deadline)
                    .HasColumnName("deadline")
                    .HasColumnType("datetime");

                entity.Property(e => e.Eventdate)
                    .HasColumnName("eventdate")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Businessandserviceq>(entity =>
            {
                entity.HasKey(e => e.Gqid);

                entity.ToTable("businessandserviceq");

                entity.Property(e => e.Gqid)
                    .HasColumnName("gqid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Gq1)
                    .HasColumnName("gq1")
                    .IsUnicode(false);

                entity.Property(e => e.Gq10)
                    .HasColumnName("gq10")
                    .IsUnicode(false);

                entity.Property(e => e.Gq2)
                    .HasColumnName("gq2")
                    .IsUnicode(false);

                entity.Property(e => e.Gq3)
                    .HasColumnName("gq3")
                    .IsUnicode(false);

                entity.Property(e => e.Gq4)
                    .HasColumnName("gq4")
                    .IsUnicode(false);

                entity.Property(e => e.Gq5)
                    .HasColumnName("gq5")
                    .IsUnicode(false);

                entity.Property(e => e.Gq6)
                    .HasColumnName("gq6")
                    .IsUnicode(false);

                entity.Property(e => e.Gq7)
                    .HasColumnName("gq7")
                    .IsUnicode(false);

                entity.Property(e => e.Gq8)
                    .HasColumnName("gq8")
                    .IsUnicode(false);

                entity.Property(e => e.Gq9)
                    .HasColumnName("gq9")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Generalquestionaire>(entity =>
            {
                entity.HasKey(e => e.Gqid);

                entity.Property(e => e.Gqid)
                    .HasColumnName("gqid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Gq1)
                    .HasColumnName("gq1")
                    .IsUnicode(false);

                entity.Property(e => e.Gq10)
                    .HasColumnName("gq10")
                    .IsUnicode(false);

                entity.Property(e => e.Gq2)
                    .HasColumnName("gq2")
                    .IsUnicode(false);

                entity.Property(e => e.Gq3)
                    .HasColumnName("gq3")
                    .IsUnicode(false);

                entity.Property(e => e.Gq4)
                    .HasColumnName("gq4")
                    .IsUnicode(false);

                entity.Property(e => e.Gq5)
                    .HasColumnName("gq5")
                    .IsUnicode(false);

                entity.Property(e => e.Gq6)
                    .HasColumnName("gq6")
                    .IsUnicode(false);

                entity.Property(e => e.Gq7)
                    .HasColumnName("gq7")
                    .IsUnicode(false);

                entity.Property(e => e.Gq8)
                    .HasColumnName("gq8")
                    .IsUnicode(false);

                entity.Property(e => e.Gq9)
                    .HasColumnName("gq9")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Judge>(entity =>
            {
                entity.Property(e => e.Judgeid)
                    .HasColumnName("judgeid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Eventid).HasColumnName("eventid");

                entity.Property(e => e.Judgeemail)
                    .HasColumnName("judgeemail")
                    .IsUnicode(false);

                entity.Property(e => e.Judgename)
                    .HasColumnName("judgename")
                    .IsUnicode(false);

                entity.Property(e => e.Judgepaas)
                    .HasColumnName("judgepaas")
                    .IsUnicode(false);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Judge)
                    .HasForeignKey(d => d.Eventid)
                    .HasConstraintName("FK__Judge__eventid__2A164134");
            });

            modelBuilder.Entity<Scienceandtechnologyq>(entity =>
            {
                entity.HasKey(e => e.Gqid);

                entity.ToTable("scienceandtechnologyq");

                entity.Property(e => e.Gqid)
                    .HasColumnName("gqid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Gq1)
                    .HasColumnName("gq1")
                    .IsUnicode(false);

                entity.Property(e => e.Gq10)
                    .HasColumnName("gq10")
                    .IsUnicode(false);

                entity.Property(e => e.Gq2)
                    .HasColumnName("gq2")
                    .IsUnicode(false);

                entity.Property(e => e.Gq3)
                    .HasColumnName("gq3")
                    .IsUnicode(false);

                entity.Property(e => e.Gq4)
                    .HasColumnName("gq4")
                    .IsUnicode(false);

                entity.Property(e => e.Gq5)
                    .HasColumnName("gq5")
                    .IsUnicode(false);

                entity.Property(e => e.Gq6)
                    .HasColumnName("gq6")
                    .IsUnicode(false);

                entity.Property(e => e.Gq7)
                    .HasColumnName("gq7")
                    .IsUnicode(false);

                entity.Property(e => e.Gq8)
                    .HasColumnName("gq8")
                    .IsUnicode(false);

                entity.Property(e => e.Gq9)
                    .HasColumnName("gq9")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Societyandglobalizationq>(entity =>
            {
                entity.HasKey(e => e.Gqid);

                entity.ToTable("societyandglobalizationq");

                entity.Property(e => e.Gqid)
                    .HasColumnName("gqid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Gq1)
                    .HasColumnName("gq1")
                    .IsUnicode(false);

                entity.Property(e => e.Gq10)
                    .HasColumnName("gq10")
                    .IsUnicode(false);

                entity.Property(e => e.Gq2)
                    .HasColumnName("gq2")
                    .IsUnicode(false);

                entity.Property(e => e.Gq3)
                    .HasColumnName("gq3")
                    .IsUnicode(false);

                entity.Property(e => e.Gq4)
                    .HasColumnName("gq4")
                    .IsUnicode(false);

                entity.Property(e => e.Gq5)
                    .HasColumnName("gq5")
                    .IsUnicode(false);

                entity.Property(e => e.Gq6)
                    .HasColumnName("gq6")
                    .IsUnicode(false);

                entity.Property(e => e.Gq7)
                    .HasColumnName("gq7")
                    .IsUnicode(false);

                entity.Property(e => e.Gq8)
                    .HasColumnName("gq8")
                    .IsUnicode(false);

                entity.Property(e => e.Gq9)
                    .HasColumnName("gq9")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(e => e.Teamid)
                    .HasColumnName("teamid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Eventid).HasColumnName("eventid");

                entity.Property(e => e.Teamemail)
                    .HasColumnName("teamemail")
                    .IsUnicode(false);

                entity.Property(e => e.Teamname)
                    .HasColumnName("teamname")
                    .IsUnicode(false);

                entity.Property(e => e.Teampaas)
                    .HasColumnName("teampaas")
                    .IsUnicode(false);

                entity.Property(e => e.Teamquestionpoints)
                    .HasColumnName("teamquestionpoints")
                    .IsUnicode(false);

                entity.Property(e => e.Teamreport)
                    .HasColumnName("teamreport")
                    .IsUnicode(false);

                entity.Property(e => e.Teamreportpoints)
                    .HasColumnName("teamreportpoints")
                    .IsUnicode(false);

                entity.Property(e => e.Teamtrack)
                    .HasColumnName("teamtrack")
                    .IsUnicode(false);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Team)
                    .HasForeignKey(d => d.Eventid)
                    .HasConstraintName("FK__Team__eventid__2739D489");
            });

            modelBuilder.Entity<Tradeandskillq>(entity =>
            {
                entity.HasKey(e => e.Gqid);

                entity.ToTable("tradeandskillq");

                entity.Property(e => e.Gqid)
                    .HasColumnName("gqid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Gq1)
                    .HasColumnName("gq1")
                    .IsUnicode(false);

                entity.Property(e => e.Gq10)
                    .HasColumnName("gq10")
                    .IsUnicode(false);

                entity.Property(e => e.Gq2)
                    .HasColumnName("gq2")
                    .IsUnicode(false);

                entity.Property(e => e.Gq3)
                    .HasColumnName("gq3")
                    .IsUnicode(false);

                entity.Property(e => e.Gq4)
                    .HasColumnName("gq4")
                    .IsUnicode(false);

                entity.Property(e => e.Gq5)
                    .HasColumnName("gq5")
                    .IsUnicode(false);

                entity.Property(e => e.Gq6)
                    .HasColumnName("gq6")
                    .IsUnicode(false);

                entity.Property(e => e.Gq7)
                    .HasColumnName("gq7")
                    .IsUnicode(false);

                entity.Property(e => e.Gq8)
                    .HasColumnName("gq8")
                    .IsUnicode(false);

                entity.Property(e => e.Gq9)
                    .HasColumnName("gq9")
                    .IsUnicode(false);
            });
        }
    }
}
