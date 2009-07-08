using System;
using NUnit.Framework;

namespace Marcware.WB.Test
{
	[TestFixture]
	public class FuelCalculatorTest
	{
		[Test]
		public void CalculateFuelWeightFromQuantities()
		{
			FuelCalculator calc = new FuelCalculator();
			calc.TakeoffFuelQuantity = 53M;
			calc.EnrouteFuelQuantity = 20M;
			calc.CalculateFuelWeightFromQuantities();
			Assert.AreEqual("318.0", calc.TakeoffFuelWeight.ToString("0.0"), "TakeoffFuelWeight");
			Assert.AreEqual("198.0", calc.LandingFuelWeight.ToString("0.0"), "LandingFuelWeight");
		}

		[Test]
		public void CalculateFuelQuantitiesFromWeight()
		{
			FuelCalculator calc = new FuelCalculator();
			calc.TakeoffFuelWeight = 318M;
			calc.LandingFuelWeight = 198M;
			calc.CalculateFuelQuantitiesFromWeight();
			Assert.AreEqual("53.0", calc.TakeoffFuelQuantity.ToString("0.0"), "TakeoffFuelQuantity");
			Assert.AreEqual("20.0", calc.EnrouteFuelQuantity.ToString("0.0"), "EnrouteFuelQuantity");
		}
	}
}
