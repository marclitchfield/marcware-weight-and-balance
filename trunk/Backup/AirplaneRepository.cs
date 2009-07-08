using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Collections;
using System.Collections.Specialized;

namespace Marcware.WB
{
	/// <summary>
	/// Stores airplane profiles
	/// </summary>
	public class AirplaneRepository
	{
		private string airplaneProfileFolder;

		public AirplaneRepository()
		{
			string applicationDataFolder = EnvironmentEx.GetSpecialFolderPath(EnvironmentEx.SpecialFolder.Personal);
			airplaneProfileFolder = Path.Combine(applicationDataFolder, "MarcwareWB");
			Directory.CreateDirectory(airplaneProfileFolder);
		}

		private string GetAirplaneFilename(string tailNumber)
		{
			return Path.Combine(airplaneProfileFolder, tailNumber + ".xml");
		}

		public void Save(Airplane airplane)
		{
			string filename = GetAirplaneFilename(airplane.TailNumber);

			using(StreamWriter fileWriter = new StreamWriter(filename))
			{
				XmlTextWriter writer = new XmlTextWriter(fileWriter);
				writer.WriteStartDocument();
				writer.WriteStartElement("Airplane");
				writer.WriteElementString("MaxWeight", airplane.MaxWeight.ToString());
				writer.WriteElementString("StationMode", airplane.StationMode.ToString());
				
				writer.WriteStartElement("Stations");
				foreach(Station station in airplane.Stations)
				{
					WriteStation("Station", writer, station, true);
				}
				WriteStation("TakeoffFuel", writer, airplane.TakeoffFuel, false);
				WriteStation("LandingFuel", writer, airplane.LandingFuel, false);
				writer.WriteEndElement(); // </Stations>

				writer.WriteStartElement("Limits");
				foreach(Station limit in airplane.Limits)
				{
					WriteStation("Limit", writer, limit, false);
				}
				writer.WriteEndElement(); // </Limits>

				writer.WriteEndElement(); // </Airplane>
				writer.WriteEndDocument();
				writer.Close();
			}
		}

		private void WriteStation(string elementName, XmlTextWriter writer, 
			Station station, bool writeStationName)
		{
			writer.WriteStartElement(elementName);

			if (writeStationName)
			{
				writer.WriteElementString("Name", station.Name);
			}

			writer.WriteElementString("Weight", station.Weight.ToString());
			writer.WriteElementString("Arm", station.Arm.ToString());
			writer.WriteEndElement();
		}

		public void Delete(string tailNumber)
		{
			string filename = GetAirplaneFilename(tailNumber);
			File.Delete(filename);
		}

		public string[] GetAllTailNumbers()
		{
			ArrayList list = new ArrayList();
			foreach(FileInfo file in new DirectoryInfo(airplaneProfileFolder).GetFiles("*.xml"))
			{
				list.Add(Path.GetFileNameWithoutExtension(file.Name));
			}

			return (string[])list.ToArray(typeof(string));
		}

		public Airplane Get(string tailNumber)
		{
			string filename = GetAirplaneFilename(tailNumber);
			
			using(StreamReader fileReader = new StreamReader(filename))
			{
				XmlTextReader reader = new XmlTextReader(fileReader);
				Airplane airplane = new Airplane();
				airplane.TailNumber = tailNumber;

				reader.ReadStartElement("Airplane");
				airplane.MaxWeight = decimal.Parse(reader.ReadElementString("MaxWeight"));
				airplane.StationMode = ParseStationMode(reader.ReadElementString("StationMode"));
		
				reader.ReadStartElement("Stations");
				foreach(Station station in airplane.Stations)
				{
					ReadStation("Station", reader, station, true);
				}

				ReadStation("TakeoffFuel", reader, airplane.TakeoffFuel, false);
				ReadStation("LandingFuel", reader, airplane.LandingFuel, false);
				reader.ReadEndElement(); // </Stations>

				reader.ReadStartElement("Limits");
				foreach(Station limit in airplane.Limits)
				{
					ReadStation("Limit", reader, limit, false);
				}
				reader.ReadEndElement(); // </Limits>
				reader.ReadEndElement(); // </Airplane>
				reader.Close();

				return airplane;
			}
		}

		private static StationMode ParseStationMode(string stationMode)
		{
			if (stationMode == "Arm")
				return StationMode.Arm;

			if (stationMode == "Moment")
				return StationMode.Moment;

			throw new ApplicationException("Invalid StationMode: " + stationMode);
		}

		private void ReadStation(string elementName, XmlTextReader reader, 
			Station station, bool readStationName)
		{
			reader.ReadStartElement(elementName);

			if (readStationName)
			{
				station.Name = reader.ReadElementString("Name");
			}

			station.Weight = decimal.Parse(reader.ReadElementString("Weight"));
			station.Arm = decimal.Parse(reader.ReadElementString("Arm"));
			reader.ReadEndElement();
		}

		private void ReadFuelStation(XmlTextReader reader, Station station, string elementName)
		{
			reader.ReadStartElement(elementName);
			station.Weight = decimal.Parse(reader.ReadElementString("Weight"));
			station.Arm = decimal.Parse(reader.ReadElementString("Arm"));
			reader.ReadEndElement();
		}
	}
}
