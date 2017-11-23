using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaceTime.Domain.Models
{
    public class TrainingSession
    {
        public Guid Id { get; set; }
        public DateTimeOffset Date { get; set; }
        public virtual List<TrainingSet> Sets { get; set; }

        public TrainingSession()
        {
            Id = Guid.NewGuid();
            Date = DateTimeOffset.Now;
            Sets = new List<TrainingSet>();
        }
    }
}
