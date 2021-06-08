using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumGenerator.Models
{
    public interface IOccupation
    {
        public string GetOccupationRating(string OccupationType);
        public double GetOccupationFactor(string OccupationRating);
        public double GetOccupationRatingFactor(string occupationType);
    }
}
