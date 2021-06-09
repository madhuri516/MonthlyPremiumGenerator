using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumGenerator.Models
{
    // this class calculates the monthly premium amount through CalculateMonthlyPremiumAmount method
    // it implements the CalculateMonthlyPremiumAmount method defined in IPremiumCalculator interface
    public class PremiumCalculator: IPremiumCalculator
    {
        public double? deathPremiumAmount = 0.0;
        //calculate premium
        public double? CalculateMonthlyPremiumAmount(double? deathCoverAmount, double occupationRatingFactor, int? age)
        {
            try
            {
                deathPremiumAmount = (deathCoverAmount * occupationRatingFactor * age) / 1000 * 12;
                return deathPremiumAmount;
            }
            catch(Exception)
            {
                throw new Exception();
                
            }
            
        }
    }
}
