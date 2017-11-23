using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaceTime.Domain.Models
{
    public class TrainingSet
    {
        public Guid ExerciseId { get; set; }
        public Guid TrainingSessionId { get; set; }

        public virtual Exercise Exercise { get; set; }
        public virtual TrainingSession TrainingSession { get; set; }


        public DateTimeOffset StartTime { get; set; }
        public int Repetitions { get; set; }
    }
}
