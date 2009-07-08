using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Marcware.WB
{
	/// <summary>
	/// Draws the CG envelope and plots the CG positions
	/// </summary>
	public class LimitGraph
	{
		private Airplane airplane;
		private PictureBox picture;
		private bool drawFuelStations;
		private const int ellipseSize = 4;
		private static Color takeoffPointColor = Color.Blue;
		private static Color landingPointColor = Color.DarkOrchid;
		private static Color zeroFuelPointColor = Color.Red;
		private Label takeoffCGArmLabel = null;
		private Label landingCGArmLabel = null;
		private Label zeroFuelCGArmLabel = null;

		public LimitGraph(PictureBox pictureBox, bool drawFuelStations)
		{
			picture = pictureBox;
			picture.Paint -= new PaintEventHandler(picture_Paint);
			picture.Paint += new PaintEventHandler(picture_Paint);
			this.drawFuelStations = drawFuelStations;
		}

		public Airplane Airplane
		{
			get { return airplane; }
			set 
			{ 
				airplane = value; 
				this.Refresh();
			}
		}

		public static void DrawTakeoffImage(PictureBox picture)
		{
			picture.Paint -= new PaintEventHandler(takeoffPoint_Paint);
			picture.Paint += new PaintEventHandler(takeoffPoint_Paint);
		}
		private static void takeoffPoint_Paint(object sender, PaintEventArgs e)
		{
			PictureBox picture = (PictureBox)sender;
			e.Graphics.FillEllipse(new SolidBrush(takeoffPointColor), 0, 0, ellipseSize, ellipseSize);
			e.Graphics.DrawEllipse(new Pen(Color.Black), 0, 0, ellipseSize, ellipseSize);
		}

		public static void DrawLandingImage(PictureBox picture)
		{
			picture.Paint -= new PaintEventHandler(landingPoint_Paint);
			picture.Paint += new PaintEventHandler(landingPoint_Paint);
		}
		private static void landingPoint_Paint(object sender, PaintEventArgs e)
		{
			PictureBox picture = (PictureBox)sender;
			e.Graphics.FillEllipse(new SolidBrush(landingPointColor), 0, 0, ellipseSize, ellipseSize);
			e.Graphics.DrawEllipse(new Pen(Color.Black), 0, 0, ellipseSize, ellipseSize);
		}

		public static void DrawZeroFuelImage(PictureBox picture)
		{
			picture.Paint -= new PaintEventHandler(zeroFuelPoint_Paint);
			picture.Paint += new PaintEventHandler(zeroFuelPoint_Paint);
		}
		private static void zeroFuelPoint_Paint(object sender, PaintEventArgs e)
		{
			PictureBox picture = (PictureBox)sender;
			e.Graphics.FillEllipse(new SolidBrush(zeroFuelPointColor), 0, 0, ellipseSize, ellipseSize);
			e.Graphics.DrawEllipse(new Pen(Color.Black), 0, 0, ellipseSize, ellipseSize);
		}

		public void Refresh()
		{
			picture.Refresh();
			Application.DoEvents();
		}

		private void picture_Paint(object sender, PaintEventArgs e)
		{
			PictureBox picture = (PictureBox)sender;
			Rectangle rect = picture.ClientRectangle;
			rect.Width--;
			rect.Height--;

			Graphics g = e.Graphics;
			g.FillRectangle(new SolidBrush(Color.AliceBlue), rect);
			DrawLimits(rect, g);
			g.DrawRectangle(new Pen(Color.Black), rect);
		}

		private void DrawLimits(Rectangle rect, Graphics g)
		{
			decimal minArm = MinArm;
			decimal maxArm = MaxArm;
			decimal minWeight = MinWeight;
			decimal maxWeight = MaxWeight;

			if (minArm == maxArm || minWeight == maxWeight)
				return;

			if (maxWeight == 0.0M)
				return;

			ArrayList pointList = new ArrayList();

			foreach(Station limit in airplane.Limits)
			{
				if (limit.Weight > 0)
				{
					decimal armPosition = (limit.Arm - minArm) / (maxArm - minArm);
					decimal weightPosition = (limit.Weight - minWeight) / (maxWeight - minWeight);
					pointList.Add(ConvertPositionToPoint(rect, armPosition, weightPosition));
				}
			}

			Point[] points = (Point[])pointList.ToArray(typeof(Point));
			g.FillPolygon(new SolidBrush(Color.LightSteelBlue), points);
			g.DrawPolygon(new Pen(Color.SteelBlue), points);

			if (drawFuelStations)
			{
				decimal takeoffArmPosition = (airplane.TakeoffCGArm - minArm) / (maxArm - minArm);
				decimal takeoffWeightPosition = (airplane.TakeoffWeight - minWeight) / (maxWeight - minWeight);
				Point takeoffPoint = ConvertPositionToPoint(rect, takeoffArmPosition, takeoffWeightPosition);

				decimal landingArmPosition = (airplane.LandingCGArm - minArm) / (maxArm - minArm);
				decimal landingWeightPosition = (airplane.LandingWeight - minWeight) / (maxWeight - minWeight);
				Point landingPoint = ConvertPositionToPoint(rect, landingArmPosition, landingWeightPosition);

				decimal zeroFuelArmPosition = (airplane.ZeroFuelCGArm - minArm) / (maxArm - minArm);
				decimal zeroFuelWeightPosition = (airplane.ZeroFuelWeight - minWeight) / (maxWeight - minWeight);
				Point zeroFuelPoint = ConvertPositionToPoint(rect, zeroFuelArmPosition, zeroFuelWeightPosition);

//				g.DrawLine(new Pen(Color.Black), takeoffPoint.X, takeoffPoint.Y, landingPoint.X, landingPoint.Y);
//				g.DrawLine(new Pen(Color.Black), landingPoint.X, landingPoint.Y, zeroFuelPoint.X, zeroFuelPoint.Y);

				DrawPoint(g, takeoffPointColor, takeoffPoint, rect);
				DrawPoint(g, landingPointColor, landingPoint, rect);
				DrawPoint(g, zeroFuelPointColor, zeroFuelPoint, rect);
			}
		}

		private void DrawPoint(Graphics g, Color color, Point point, Rectangle rect)
		{
			g.DrawLine(new Pen(color), 0, point.Y, point.X, point.Y);
			g.DrawLine(new Pen(color), point.X, rect.Height, point.X, point.Y);
			g.FillEllipse(new SolidBrush(color), point.X - 2, point.Y - 2, ellipseSize, ellipseSize);
			g.DrawEllipse(new Pen(Color.Black), point.X - 2, point.Y - 2, ellipseSize, ellipseSize);
		}

		private Point ConvertPositionToPoint(Rectangle rect, decimal armPosition, decimal weightPosition)
		{
			const int padding = 10;
			int x = (int)(armPosition * (rect.Width - padding * 2)) + padding;
			int y = (int)(weightPosition * (rect.Height - padding));
			return new Point(x, rect.Height - y);
		}

		private decimal MaxArm
		{
			get
			{
				decimal maxArm = 0M;
				foreach(Station limit in airplane.Limits)
				{
					if (limit.Weight > 0M)
						maxArm = Math.Max(maxArm, limit.Arm);
				}

				return maxArm;
			}
		}

		private decimal MinArm
		{
			get
			{
				decimal minArm = decimal.MaxValue;
				foreach(Station limit in airplane.Limits)
				{
					if (limit.Weight > 0M)
						minArm = Math.Min(minArm, limit.Arm);
				}

				return minArm;
			}
		}

		private decimal MaxWeight
		{
			get
			{
				decimal maxWeight = 0M;
				foreach(Station limit in airplane.Limits)
				{
					if (limit.Weight > 0.0M)
						maxWeight = Math.Max(maxWeight, limit.Weight);
				}

				return maxWeight;
			}
		}

		private decimal MinWeight
		{
			get
			{
				decimal minWeight = decimal.MaxValue;
				foreach(Station limit in airplane.Limits)
				{
					if (limit.Weight > 0M)
						minWeight = Math.Min(minWeight, limit.Weight);
				}

				return minWeight;
			}
		}

		public Label TakeoffCGArmLabel
		{
			get
			{
				return takeoffCGArmLabel;
			}
			set
			{
				takeoffCGArmLabel = value;
			}
		}

		public Label LandingCGArmLabel
		{
			get
			{
				return landingCGArmLabel;
			}
			set
			{
				landingCGArmLabel = value;
			}
		}

		public Label ZeroFuelCGArmLabel
		{
			get
			{
				return zeroFuelCGArmLabel;
			}
			set
			{
				zeroFuelCGArmLabel = value;
			}
		}
	}
}
