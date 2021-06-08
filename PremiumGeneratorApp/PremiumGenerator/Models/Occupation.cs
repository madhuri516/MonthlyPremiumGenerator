using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumGenerator.Models
{
    public class Occupation : IOccupation
    {
        public List<string> OccupationType = new List<string>()
        { "Cleaner", "Doctor", "Author", "Farmer", "Mechanic", "Florist" };

        public List<string> OccupationRating = new List<string>()
        { "Professional", "White Collar", "Light Manual", "Heavy Manual"};
        public List<double> OccupationFactor = new List<double>()
        { 1.0, 1.25, 1.50, 1.75};

        public string GetOccupationRating(string OccupationType)
        {
            string occupationRating = "";

            switch (OccupationType)
            {
                case "Cleaner":
                    occupationRating = OccupationRating[2];
                    break;
                case "Doctor":
                    occupationRating = OccupationRating[2];
                    break;
                case "Author":
                    occupationRating = OccupationRating[2];
                    break;
                case "Farmer":
                    occupationRating = OccupationRating[2];
                    break;
                case "Mechanic":
                    occupationRating = OccupationRating[2];
                    break;
                case "Florist":
                    occupationRating = OccupationRating[2];
                    break;
            }

            return occupationRating;
        }

        public double GetOccupationFactor(string OccupationRating)
        {
            double occupationFactor = 0.0;
            switch (OccupationRating)
            {
                case "Professional":
                    occupationFactor = OccupationFactor[0];
                    break;
                case "White Collar":
                    occupationFactor = OccupationFactor[1];
                    break;
                case "Light Manual":
                    occupationFactor = OccupationFactor[2];
                    break;
                case "Heavy Manual":
                    occupationFactor = OccupationFactor[3];
                    break;

            }
            return occupationFactor;
        }

        public double GetOccupationRatingFactor(string occupation)
        {
            double occupationRatingFactor = 0.0;
            string occRating;

            switch (occupation)
            {
                case "Cleaner":
                    occRating = GetOccupationRating(occupation);
                    occupationRatingFactor = GetOccupationFactor(occRating);
                    break;
                case "Doctor":
                    occRating = GetOccupationRating(occupation);
                    occupationRatingFactor = GetOccupationFactor(occRating);
                    break;
                case "Author":
                    occRating = GetOccupationRating(occupation);
                    occupationRatingFactor = GetOccupationFactor(occRating);
                    break;
                case "Farmer":
                    occRating = GetOccupationRating(occupation);
                    occupationRatingFactor = GetOccupationFactor(occRating);
                    break;
                case "Mechanic":
                    occRating = GetOccupationRating(occupation);
                    occupationRatingFactor = GetOccupationFactor(occRating);
                    break;
                case "Florist":
                    occRating = GetOccupationRating(occupation);
                    occupationRatingFactor = GetOccupationFactor(occRating);
                    break;
            }

        
            return occupationRatingFactor;
        }
    }
}
