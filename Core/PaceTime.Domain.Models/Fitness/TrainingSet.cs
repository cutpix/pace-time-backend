using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaceTime.Domain.Models.Fitness
{
    public class TrainingSet
    {
        public Guid Id { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public int Repetitions { get; set; }

        public Guid ExerciseId { get; set; }
        public virtual Exercise Exercise { get; set; }

        public Guid TrainingSessionId { get; set; }
        public virtual TrainingSession TrainingSession { get; set; }
    }
}
