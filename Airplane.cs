using System;
using System.Collections;

namespace Marcware.WB
{
	/// <summary>
	/// Represents an Airplane
	/// </summary>
	public class Airplane
	{
		private string tailNumber = string.Empty;
		private decimal maxWeight = 0.0M;
		private ArrayList stations = new ArrayList();
		private ArrayList limits = new ArrayList();
		private Station takeoffFuel;
		private Station landingFuel;
		private StationMode stationMode;

		public Airplane()
		{
			takeoffFuel = new Station("Takeoff Fuel");
			landingFuel = new Station("Landing Fuel");

			stations.Add(new Station("Basic Empty"));
			stations.Add(new Station("Pilot"));
			stations.Add(new Station("Front Passenger"));
			stations.Add(new Station("Rear Seat"));
			stations.Add(new Station("Baggage 1"));
			stations.Add(new Station("Baggege 2"));
			stations.Add(new Station());

			stationMode = StationMode.Arm;

			for(int i=0; i<9; i++)
			{
				limits.Add(new Station());
			}
		}

		public bool HasTailNumber
		{
			get { return tailNumber.Trim() != string.Empty; }
		}

		public string TailNumber
		{
			set { tailNumber = value; }
			get { return tailNumber; }
		}

		public StationMode StationMode
		{
			set { stationMode = value; }
			get { return stationMode; }
		}

		public Station TakeoffFuel
		{
			get { return takeoffFuel; }
		}

		public Station LandingFuel
		{
			get { return landingFuel; }
		}

		public decimal MaxWeight
		{
			get { return maxWeight; }
			set { maxWeight = value; }
		}

		public Station[] Stations
		{
			get { return (Station[])stations.ToArray(typeof(Station)); }
		}

		public Station[] Limits
		{
			get { return (Station[])limits.ToArray(typeof(Station)); }
		}

		public Station[] ValidLimits
		{
			get
			{
				ArrayList list = new ArrayList();
				foreach(Station limit in limits)
				{
					if (limit.Arm > 0M && limit.Weight > 0M)
						list.Add(limit);
				}

				return (Station[])list.ToArray(typeof(Station));
			}
		}

		public decimal ZeroFuelWeight
		{
			get
			{
				decimal weight = 0.0M;
				foreach(Station station in stations)
				{
					weight += station.Weight;
				}
				return weight;
			}
		}

		public decimal TakeoffWeight
		{
			get
			{
				return ZeroFuelWeight + TakeoffFuel.Weight;
			}
		}

		public decimal LandingWeight
		{
			get
			{
				return ZeroFuelWeight + LandingFuel.Weight;
			}
		}

		private decimal ZeroFuelMoment
		{
			get
			{
				decimal moment = 0.0M;
				foreach(Station station in stations)
				{
					moment += station.Moment;
				}
				return moment;
			}
		}

		public decimal TakeoffCGArm
		{
			get
			{
				if (TakeoffWeight == 0.0M)
					return 0.0M;

				decimal moment = ZeroFuelMoment + takeoffFuel.Moment;
				return moment / TakeoffWeight;
			}
		}

		public decimal LandingCGArm
		{
			get
			{
				if (LandingWeight == 0.0M)
					return 0.0M;

				decimal moment = ZeroFuelMoment + landingFuel.Moment;
				return moment / LandingWeight;
			}
		}

		public decimal ZeroFuelCGArm
		{
			get
			{
				if (ZeroFuelWeight == 0.0M)
					return 0.0M;

				return ZeroFuelMoment / ZeroFuelWeight;
			}
		}

		public bool TakeoffCGInLimits
		{
			get
			{
				Station takeoffStation = new Station("", TakeoffWeight, TakeoffCGArm);
				return StationInLimits(takeoffStation);
			}
		}

		public bool LandingCGInLimits
		{
			get
			{
				Station landingStation = new Station("", LandingWeight, LandingCGArm);
				return StationInLimits(landingStation);
			}
		}

		public bool ZeroFuelCGInLimits
		{
			get
			{
				Station zeroFuelStation = new Station(string.Empty, ZeroFuelWeight, ZeroFuelCGArm);
				return StationInLimits(zeroFuelStation);
			}
		}

		public bool TakeoffWeightInLimits
		{
			get
			{
				return TakeoffWeight <= MaxWeight;
			}
		}

		public bool LandingWeightInLimits
		{
			get
			{
				return LandingWeight <= MaxWeight;
			}
		}

		public bool ZeroFuelWeightInLimits
		{
			get
			{
				return ZeroFuelWeight <= MaxWeight;
			}
		}

		private bool StationInLimits(Station station)
		{
			bool inPolygon = false;
			Station[] v = this.ValidLimits;

			for(int i=0, j=v.Length-1; i<v.Length; j=i++)
			{
				if ((((v[i].Weight <= station.Weight) && (station.Weight < v[j].Weight)) ||
					((v[j].Weight <= station.Weight) && (station.Weight < v[i].Weight))) &&
					(station.Arm < (v[j].Arm - v[i].Arm) * (station.Weight - v[i].Weight) / 
					(v[j].Weight - v[i].Weight) + v[i].Arm))
				{
					inPolygon = !inPolygon;
				}
			}

			return inPolygon;
		}
	}
}
