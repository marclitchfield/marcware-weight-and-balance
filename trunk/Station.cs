using System;

namespace Marcware.WB
{
	/// <summary>
	/// Represents a station with an associated arm and weight
	/// </summary>
	public class Station
	{
		private string name;
		private decimal weight;
		private decimal arm;

		public Station() : this(string.Empty)
		{
		}

		public Station(string name) : this(name, 0.0M, 0.0M)
		{
		}

		public Station(string name, decimal weight, decimal arm)
		{
			this.name = name;
			this.weight	= weight;
			this.arm = arm;
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public decimal Weight
		{
			get { return weight; }
			set { weight = value; }
		}

		public decimal Arm
		{
			get { return arm; }
			set { arm = value; }
		}

		public decimal Moment
		{
			get { return Weight * Arm; }
		}
	}
}
