using System;

namespace Marcware.WB
{
	/// <summary>
	/// Calculates Takeoff and Landing Fuel from Quantity (e.g. Gallons)
	/// </summary>
	public class FuelCalculator
	{
		private const decimal WeightPerQuantityUnit = 6.0M; // US Gallons
		private decimal takeoffFuelWeight;
		private decimal landingFuelWeight;
		private decimal takeoffFuelQuantity;
		private decimal enrouteFuelQuantity;

		public decimal TakeoffFuelWeight
		{
			get { return takeoffFuelWeight; }
			set { takeoffFuelWeight = value; }
		}

		public decimal LandingFuelWeight
		{
			get { return landingFuelWeight; }
			set { landingFuelWeight = value; }
		}

		public decimal TakeoffFuelQuantity
		{
			get { return takeoffFuelQuantity; }
			set { takeoffFuelQuantity = value; }
		}

		public decimal EnrouteFuelQuantity
		{
			get { return enrouteFuelQuantity; }
			set { enrouteFuelQuantity = value; }
		}

		public void CalculateFuelWeightFromQuantities()
		{
			takeoffFuelWeight = takeoffFuelQuantity * WeightPerQuantityUnit;
			landingFuelWeight = takeoffFuelWeight - (enrouteFuelQuantity * WeightPerQuantityUnit);
		}

		public void CalculateFuelQuantitiesFromWeight()
		{
			takeoffFuelQuantity = takeoffFuelWeight / WeightPerQuantityUnit;
			enrouteFuelQuantity = takeoffFuelQuantity - (landingFuelWeight / WeightPerQuantityUnit);
		}
	}
}
