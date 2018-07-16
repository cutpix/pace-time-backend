using PaceTime.Domain.Models.Fitness;
using System.Data.Entity.Migrations;
using System;
using System.Linq;

namespace PaceTime.WebAPI.Data
{
    public class FitnessConfiguration : DbMigrationsConfiguration<FitnessContext>
    {
        public FitnessConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(FitnessContext context)
        {
            //AddNewExercises(context);
            //AddTrainingSessionSets(context, Guid.Parse("1c25d54e-035d-4b77-b61d-832a8505267c"));

            base.Seed(context);
        }

        private void AddTrainingSessionSets(FitnessContext context, Guid sessionId)
        {
            var session = context.TrainingSessions.First(x => x.Id == sessionId);
            var exercise = context.Exercises.First(x => x.Naming == "Подтягивания");

            context.TrainingSets.AddOrUpdate(new TrainingSet
            {
                TrainingSession = session,
                Exercise = exercise,
                EndTime = DateTimeOffset.Parse("2017-11-25T20:30:25.3941959+02:00"),
                Repetitions = 9
            });

            context.TrainingSets.AddOrUpdate(new TrainingSet
            {
                TrainingSession = session,
                Exercise = exercise,
                EndTime = DateTimeOffset.Parse("2017-11-25T20:35:15.3911959+02:00"),
                Repetitions = 8
            });

            context.TrainingSets.AddOrUpdate(new TrainingSet
            {
                TrainingSession = session,
                Exercise = exercise,
                EndTime = DateTimeOffset.Parse("2017-11-25T20:40:15.3911959+02:00"),
                Repetitions = 7
            });

            context.TrainingSets.AddOrUpdate(new TrainingSet
            {
                TrainingSession = session,
                Exercise = exercise,
                EndTime = DateTimeOffset.Parse("2017-11-25T20:45:25.3911959+02:00"),
                Repetitions = 7
            });

            context.TrainingSets.AddOrUpdate(new TrainingSet
            {
                TrainingSession = session,
                Exercise = exercise,
                EndTime = DateTimeOffset.Parse("2017-11-25T20:50:25.3911959+02:00"),
                Repetitions = 6
            });

            context.TrainingSets.AddOrUpdate(new TrainingSet
            {
                TrainingSession = session,
                Exercise = exercise,
                EndTime = DateTimeOffset.Parse("2017-11-25T20:55:25.3911959+02:00"),
                Repetitions = 6
            });

            context.SaveChanges();
        }

        private static void AddNewExercises(FitnessContext context)
        {
            context.Exercises.AddOrUpdate(new Exercise
            {
                Naming = "Трицепс"
            });

            context.Exercises.AddOrUpdate(new Exercise
            {
                Naming = "Бицепс"
            });

            context.Exercises.AddOrUpdate(new Exercise
            {
                Naming = "Подтягивания"
            });

            context.Exercises.AddOrUpdate(new Exercise
            {
                Naming = "Брусья"
            });

            context.Exercises.AddOrUpdate(new Exercise
            {
                Naming = "Плечи"
            });

            context.Exercises.AddOrUpdate(new Exercise
            {
                Naming = "Отжимания"
            });

            context.SaveChanges();
        }
    }
}