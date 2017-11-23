using PaceTime.Domain.Models.Fitness;
using System.Data.Entity.Migrations;


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
            AddNewExercises(context);

            base.Seed(context);
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