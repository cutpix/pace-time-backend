using PaceTime.Domain.Models;
using PaceTime.Domain.Models.Fitness;
using System.Data.Entity;


namespace PaceTime.WebAPI.Data
{
    public class FitnessContext : DbContext
    {
        public DbSet<TrainingSession> TrainingSessions { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<TrainingSet> TrainingSets { get; set; }

        public FitnessContext()
            : base("FitnessContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            // Primary Keys
            builder.Entity<TrainingSession>().HasKey(q => q.Id);
            builder.Entity<Exercise>().HasKey(q => q.Id);
            builder.Entity<TrainingSet>().HasKey(q => new { q.TrainingSessionId, q.ExerciseId });

            // Relationships
            builder.Entity<TrainingSet>()
                   .HasRequired(t => t.TrainingSession)
                   .WithMany(t => t.Sets)
                   .HasForeignKey(t => t.TrainingSessionId);

            builder.Entity<TrainingSet>()
                   .HasRequired(t => t.Exercise)
                   .WithMany(t => t.Sets)
                   .HasForeignKey(t => t.ExerciseId);

            base.OnModelCreating(builder);
        }
    }
}