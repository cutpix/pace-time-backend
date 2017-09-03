using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PaceTime.Domain.Models;

namespace PaceTime.WebAPI.Models
{
    public class ReviewModel
    {
        public ReviewModel(Review review)
        {
            if (review == null)
                throw new ArgumentNullException(nameof(review));

            this.BookId = review.BookId.ToString();
            this.Description = review.Description;
            this.Rating = review.Rating;
        }

        public string BookId { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
    }
}