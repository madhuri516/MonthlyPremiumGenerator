using System;
using Xunit;
using PremiumGenerator.Models;

namespace PremiumGenerator.Tests
{
    public class PremiumCalculatorTests
    {
        [Theory]
        [InlineData(24000,1.25,34,12240)]
        [InlineData(3500.75, 1.50, 25, 1575.3374999999999)]
        public void CanCalculatePremium(double deathCoverAMount, double occupationRatingFactor,int age,double expectedpremiumAmount)
        {
            //Arrange
            PremiumCalculator calculator = new PremiumCalculator();

            //Act
            double actualpremiumAmount = calculator.CalculateMonthlyPremiumAmount(deathCoverAMount,occupationRatingFactor,age);

            //Assert
            Assert.Equal(expectedpremiumAmount, actualpremiumAmount);        
        }



    }
}
