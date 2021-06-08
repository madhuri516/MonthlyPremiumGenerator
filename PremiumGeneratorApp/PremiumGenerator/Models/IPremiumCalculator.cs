using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumGenerator.Models
{
    public interface IPremiumCalculator
    {
        double CalculateMonthlyPremiumAmount(double deathCoverAmount, double occupationRatingFactor, int age);
    }
}
