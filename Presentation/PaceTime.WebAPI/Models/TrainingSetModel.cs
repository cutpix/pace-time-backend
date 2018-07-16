using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaceTime.WebAPI.Models
{
    public class TrainingSetModel
    {
        public string Naming { get; set; }
        public int Repetitions { get; set; }
    }

    public enum Progress
    {
        NotStarted = 0,
        Started = 1,
        Done = 2,
        Canceled = 3
    }
}