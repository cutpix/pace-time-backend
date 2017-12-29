using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaceTime.Domain.Models.Fitness
{
    public class TrainingSession
    {
        public Guid Id { get; set; }
        public DateTimeOffset Date { get; set; }
        public virtual ICollection<TrainingSet> Sets { get; set; }

        public TrainingSession()
        {
            Date = DateTimeOffset.Now;
            Sets = new HashSet<TrainingSet>();
        }
    }
}
