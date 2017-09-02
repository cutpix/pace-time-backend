using System;

namespace PaceTime.Domain.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public Guid BookId { get; set; }
    }
}