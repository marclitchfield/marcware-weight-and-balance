using System;
using System.Windows.Forms;

namespace Marcware.WB
{
	/// <summary>
	/// Synchronizes a Station with UI Elements
	/// </summary>
	public class StationView
	{
		private Station station;
		private Control nameControl;
		private TextBox weightTextBox;
		private TextBox armTextBox;

		public StationView(Station station, Control nameControl, 
			TextBox weightTextBox, TextBox armTextBox)
		{
			this.station = station;
			this.nameControl = nameControl;
			this.weightTextBox = weightTextBox;
			this.armTextBox = armTextBox;
		}

		public void Display()
		{
			if (nameControl is TextBox)
			{
				nameControl.Text = station.Name;
			}

			weightTextBox.Text = WriteDecimalString(station.Weight);
			armTextBox.Text = WriteDecimalString(station.Arm);
		}

		public void Update()
		{
			if (nameControl != null)
			{
				station.Name = nameControl.Text;
			}

			station.Weight = ReadDecimalString(weightTextBox.Text);
			station.Arm = ReadDecimalString(armTextBox.Text);
		}

		public void SynchronizeFuelArms(Airplane airplane)
		{
			airplane.TakeoffFuel.Arm = station.Arm;
			airplane.LandingFuel.Arm = station.Arm;
		}

		private decimal ReadDecimalString(string decimalString)
		{
			if (decimalString.Trim() == string.Empty)
			{
				return 0.0M;
			}

			return decimal.Parse(decimalString);
		}

		private string WriteDecimalString(decimal decimalValue)
		{
			if (decimalValue == 0.0M)
			{
				return string.Empty;
			}

			return decimalValue.ToString();
		}
	}
}