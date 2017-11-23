using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaceTime.Domain.Models.Fitness
{
    public class Exercise
    {
        public Guid Id { get; set; }
        public string Naming { get; set; }
        public virtual ICollection<TrainingSet> Sets { get; set; }

        public Exercise()
        {
            Id = Guid.NewGuid();
            Sets = new HashSet<TrainingSet>();
        }
    }
}
