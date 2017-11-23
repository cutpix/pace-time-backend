using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaceTime.Domain.Models
{
    public class Exercise
    {
        public Guid Id { get; set; }
        public string Naming { get; set; }
        public virtual List<TrainingSet> Sets { get; set; }

        public Exercise()
        {
            Id = Guid.NewGuid();
            Sets = new List<TrainingSet>();
        }
    }
}
