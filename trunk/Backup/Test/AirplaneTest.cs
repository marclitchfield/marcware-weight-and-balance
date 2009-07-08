using System;
using NUnit.Framework;

namespace Marcware.WB.Test
{
	[TestFixture]
	public class AirplaneTest
	{
		private Airplane CreateTestAirplane()
		{
			Airplane airplane = new Airplane();
			airplane.Stations[0].Weight = 1489M;
			airplane.Stations[0].Arm = 38.8M;
			airplane.Stations[1].Weight = 190M;
			airplane.Stations[1].Arm = 37M;
			airplane.Stations[2].Weight = 180M;
			airplane.Stations[2].Arm = 73M;
			airplane.Stations[3].Weight = 50M;
			airplane.Stations[3].Arm = 95M;
			return airplane;
		}

		[Test]
		public void StationMomentCalculations()
		{
			Airplane airplane = CreateTestAirplane();
			Assert.AreEqual(57773.2M, airplane.Stations[0].Moment, "Station 0");
			Assert.AreEqual(7030M, airplane.Stations[1].Moment, "Station 1");
			Assert.AreEqual(13140M, airplane.Stations[2].Moment, "Station 2");
			Assert.AreEqual(4750M, airplane.Stations[3].Moment, "Station 3");
		}

		[Test]
		public void CalculateZeroFuelCG()
		{
			Airplane airplane = CreateTestAirplane();
			airplane.TakeoffFuel.Weight = 318M;
			airplane.TakeoffFuel.Arm = 48M;
			airplane.LandingFuel.Weight = 318M;
			airplane.LandingFuel.Arm = 48M;
			Assert.AreEqual(1909M, airplane.ZeroFuelWeight, "ZeroFuel Weight");
			Assert.AreEqual("43.32", airplane.ZeroFuelCGArm.ToString("0.00"), "Zero CG");
		}

		[Test]
		public void CalculateTakeoffCG()
		{
			Airplane airplane = CreateTestAirplane();
			airplane.TakeoffFuel.Weight = 318M;
			airplane.TakeoffFuel.Arm = 48M;
			airplane.LandingFuel.Weight = 318M;
			airplane.LandingFuel.Arm = 48M;
			Assert.AreEqual(15264M, airplane.TakeoffFuel.Moment, "Takeoff Fuel Moment");
			Assert.AreEqual(2227M, airplane.TakeoffWeight, "Takeoff Weight");
			Assert.AreEqual("43.99", airplane.TakeoffCGArm.ToString("0.00"), "Takeoff CG");
		}

		[Test]
		public void CalculateLandingCG()
		{
			Airplane airplane = CreateTestAirplane();
			airplane.TakeoffFuel.Weight = 318M;
			airplane.TakeoffFuel.Arm = 48M;
			airplane.LandingFuel.Weight = 198M;
			airplane.LandingFuel.Arm = 48M;
			Assert.AreEqual(9504M, airplane.LandingFuel.Moment, "Landing Fuel Moment");
			Assert.AreEqual(2107M, airplane.LandingWeight, "Landing Weight");
			Assert.AreEqual("43.76", airplane.LandingCGArm.ToString("0.00"), "Landing CG");
		}
	}
}
