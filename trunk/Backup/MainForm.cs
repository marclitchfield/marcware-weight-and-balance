using System;
using System.Xml;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;

namespace Marcware.WB
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox airplaneList;
		private System.Windows.Forms.Panel mainButtonPanel;
		private System.Windows.Forms.Panel mainPanel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button calcButton;
		private System.Windows.Forms.Button newAirplaneButton;
		private System.Windows.Forms.Button deleteAirplaneButton;
		private System.Windows.Forms.Button limitsButton;
		private System.Windows.Forms.Button backToMainButton;
		private System.Windows.Forms.Panel limitsPanel;
		private System.Windows.Forms.Panel limitsButtonPanel;
		private System.Windows.Forms.Button limitsOkButton;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.Panel inputPanel;
		private System.Windows.Forms.Panel inputButtonPanel;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.Panel calculationPanel;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button calculationOkButton;
		private Microsoft.WindowsCE.Forms.InputPanel systemInputPanel;
		private System.Windows.Forms.TextBox basicEmptyStationText;
		private System.Windows.Forms.Label stationLabel;
		private System.Windows.Forms.TextBox tailNumberText;
		private System.Windows.Forms.Label weightLabel;
		private System.Windows.Forms.TextBox basicEmptyArmText;
		private System.Windows.Forms.TextBox basicEmptyWeightText;
		private System.Windows.Forms.TextBox fuelArmText;
		private System.Windows.Forms.TextBox fuelWeightText;
		private System.Windows.Forms.TextBox pilotArmText;
		private System.Windows.Forms.TextBox pilotWeightText;
		private System.Windows.Forms.TextBox station1WeightText;
		private System.Windows.Forms.TextBox station1ArmText;
		private System.Windows.Forms.TextBox station2WeightText;
		private System.Windows.Forms.TextBox station2ArmText;
		private System.Windows.Forms.TextBox station2Text;
		private System.Windows.Forms.TextBox station3Text;
		private System.Windows.Forms.TextBox station3WeightText;
		private System.Windows.Forms.TextBox station3ArmText;
		private System.Windows.Forms.TextBox station4ArmText;
		private System.Windows.Forms.TextBox station4Text;
		private System.Windows.Forms.TextBox station4WeightText;
		private System.Windows.Forms.TextBox maxWeightText;
		private System.Windows.Forms.TextBox pilotStationText;
		private const int controlSpacing = 4;
		private System.Windows.Forms.Button copyAirplaneButton;
		private Panel[] panels;
		private AirplaneRepository repository;
		private System.Windows.Forms.Button selectAirplaneButton;
		private System.Windows.Forms.Label tailNumberLabel;
		private System.Windows.Forms.Panel tailNumberPanel;
		private System.Windows.Forms.TextBox station5ArmText;
		private System.Windows.Forms.TextBox station5WeightText;
		private System.Windows.Forms.TextBox station5Text;
		private System.Windows.Forms.ComboBox fuelStationComboBox;
		private System.Windows.Forms.TextBox station1Text;
		private Airplane currentAirplane = null;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label10;
		private StationView fuelStationView;
		private System.Windows.Forms.Label takeoffWeightLabel;
		private System.Windows.Forms.Label landingWeightLabel;
		private System.Windows.Forms.Label zeroFuelWeightLabel;
		private System.Windows.Forms.Label takeoffCGArmLabel;
		private System.Windows.Forms.Label landingCGArmLabel;
		private System.Windows.Forms.Label zeroFuelCGArmLabel;
		private System.Windows.Forms.TextBox limit1ArmText;
		private System.Windows.Forms.TextBox limit1WeightText;
		private System.Windows.Forms.TextBox limit2ArmText;
		private System.Windows.Forms.TextBox limit2WeightText;
		private System.Windows.Forms.TextBox limit3ArmText;
		private System.Windows.Forms.TextBox limit3WeightText;
		private System.Windows.Forms.TextBox limit4WeightText;
		private System.Windows.Forms.TextBox limit4ArmText;
		private System.Windows.Forms.TextBox limit5ArmText;
		private System.Windows.Forms.TextBox limit5WeightText;
		private System.Windows.Forms.TextBox limit6ArmText;
		private System.Windows.Forms.TextBox limit6WeightText;
		private System.Windows.Forms.TextBox limit7ArmText;
		private System.Windows.Forms.TextBox limit7WeightText;
		private StationView[] inputStationViews;
		private System.Windows.Forms.PictureBox limitsPicture;
		private StationView[] limitStationViews;
		private LimitGraph cgEnvelopeDefinitionGraph;
		private System.Windows.Forms.PictureBox calculationPicture;
		private System.Windows.Forms.TextBox limit8ArmText;
		private System.Windows.Forms.TextBox limit8WeightText;
		private System.Windows.Forms.TextBox limit9ArmText;
		private System.Windows.Forms.TextBox limit9WeightText;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.PictureBox takeoffPointPicture;
		private System.Windows.Forms.PictureBox landingPointPicture;
		private System.Windows.Forms.PictureBox zeroFuelPointPicture;
		private System.Windows.Forms.Label armLabel;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Button fuelButton;
		private System.Windows.Forms.Panel fuelPanel;
		private System.Windows.Forms.Button fuelOkButton;
		private System.Windows.Forms.Button fuelCancelButton;
		private System.Windows.Forms.Panel fuelPanelShadow;
		private LimitGraph cgEnvelopeCalculationGraph;
		private System.Windows.Forms.TextBox fuelCalculatorTakeoffFuelQuantityText;
		private System.Windows.Forms.TextBox fuelCalculatorFuelConsumedQuantityText;
		private FuelCalculator fuelCalculator;

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			repository = new AirplaneRepository();
			panels = new Panel[] { mainPanel, inputPanel, limitsPanel, calculationPanel };

			cgEnvelopeDefinitionGraph = new LimitGraph(limitsPicture, false);
			cgEnvelopeCalculationGraph = new LimitGraph(calculationPicture, true);
			fuelCalculator = new FuelCalculator();
		}
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			base.Dispose( disposing );
		}
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.label1 = new System.Windows.Forms.Label();
			this.airplaneList = new System.Windows.Forms.ListBox();
			this.newAirplaneButton = new System.Windows.Forms.Button();
			this.deleteAirplaneButton = new System.Windows.Forms.Button();
			this.mainButtonPanel = new System.Windows.Forms.Panel();
			this.copyAirplaneButton = new System.Windows.Forms.Button();
			this.selectAirplaneButton = new System.Windows.Forms.Button();
			this.mainPanel = new System.Windows.Forms.Panel();
			this.inputPanel = new System.Windows.Forms.Panel();
			this.fuelStationComboBox = new System.Windows.Forms.ComboBox();
			this.tailNumberPanel = new System.Windows.Forms.Panel();
			this.tailNumberText = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tailNumberLabel = new System.Windows.Forms.Label();
			this.inputButtonPanel = new System.Windows.Forms.Panel();
			this.backToMainButton = new System.Windows.Forms.Button();
			this.calcButton = new System.Windows.Forms.Button();
			this.fuelButton = new System.Windows.Forms.Button();
			this.basicEmptyStationText = new System.Windows.Forms.TextBox();
			this.stationLabel = new System.Windows.Forms.Label();
			this.limitsButton = new System.Windows.Forms.Button();
			this.weightLabel = new System.Windows.Forms.Label();
			this.basicEmptyArmText = new System.Windows.Forms.TextBox();
			this.basicEmptyWeightText = new System.Windows.Forms.TextBox();
			this.fuelArmText = new System.Windows.Forms.TextBox();
			this.fuelWeightText = new System.Windows.Forms.TextBox();
			this.pilotArmText = new System.Windows.Forms.TextBox();
			this.pilotWeightText = new System.Windows.Forms.TextBox();
			this.station1WeightText = new System.Windows.Forms.TextBox();
			this.station1ArmText = new System.Windows.Forms.TextBox();
			this.station2WeightText = new System.Windows.Forms.TextBox();
			this.station2ArmText = new System.Windows.Forms.TextBox();
			this.station2Text = new System.Windows.Forms.TextBox();
			this.station3Text = new System.Windows.Forms.TextBox();
			this.station3WeightText = new System.Windows.Forms.TextBox();
			this.station3ArmText = new System.Windows.Forms.TextBox();
			this.station4ArmText = new System.Windows.Forms.TextBox();
			this.station4Text = new System.Windows.Forms.TextBox();
			this.station4WeightText = new System.Windows.Forms.TextBox();
			this.pilotStationText = new System.Windows.Forms.TextBox();
			this.station1Text = new System.Windows.Forms.TextBox();
			this.station5ArmText = new System.Windows.Forms.TextBox();
			this.station5WeightText = new System.Windows.Forms.TextBox();
			this.station5Text = new System.Windows.Forms.TextBox();
			this.armLabel = new System.Windows.Forms.Label();
			this.fuelPanel = new System.Windows.Forms.Panel();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.fuelCalculatorTakeoffFuelQuantityText = new System.Windows.Forms.TextBox();
			this.fuelCalculatorFuelConsumedQuantityText = new System.Windows.Forms.TextBox();
			this.fuelOkButton = new System.Windows.Forms.Button();
			this.fuelCancelButton = new System.Windows.Forms.Button();
			this.fuelPanelShadow = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.maxWeightText = new System.Windows.Forms.TextBox();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.limitsPanel = new System.Windows.Forms.Panel();
			this.limitsPicture = new System.Windows.Forms.PictureBox();
			this.limitsButtonPanel = new System.Windows.Forms.Panel();
			this.limitsOkButton = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.limit1ArmText = new System.Windows.Forms.TextBox();
			this.limit1WeightText = new System.Windows.Forms.TextBox();
			this.limit2ArmText = new System.Windows.Forms.TextBox();
			this.limit2WeightText = new System.Windows.Forms.TextBox();
			this.limit3ArmText = new System.Windows.Forms.TextBox();
			this.limit3WeightText = new System.Windows.Forms.TextBox();
			this.limit4WeightText = new System.Windows.Forms.TextBox();
			this.limit4ArmText = new System.Windows.Forms.TextBox();
			this.limit5ArmText = new System.Windows.Forms.TextBox();
			this.limit5WeightText = new System.Windows.Forms.TextBox();
			this.limit6ArmText = new System.Windows.Forms.TextBox();
			this.limit6WeightText = new System.Windows.Forms.TextBox();
			this.limit7ArmText = new System.Windows.Forms.TextBox();
			this.limit7WeightText = new System.Windows.Forms.TextBox();
			this.limit8ArmText = new System.Windows.Forms.TextBox();
			this.limit8WeightText = new System.Windows.Forms.TextBox();
			this.limit9ArmText = new System.Windows.Forms.TextBox();
			this.limit9WeightText = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.calculationPanel = new System.Windows.Forms.Panel();
			this.takeoffPointPicture = new System.Windows.Forms.PictureBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.calculationPicture = new System.Windows.Forms.PictureBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.calculationOkButton = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.takeoffWeightLabel = new System.Windows.Forms.Label();
			this.landingWeightLabel = new System.Windows.Forms.Label();
			this.zeroFuelWeightLabel = new System.Windows.Forms.Label();
			this.takeoffCGArmLabel = new System.Windows.Forms.Label();
			this.landingCGArmLabel = new System.Windows.Forms.Label();
			this.zeroFuelCGArmLabel = new System.Windows.Forms.Label();
			this.landingPointPicture = new System.Windows.Forms.PictureBox();
			this.zeroFuelPointPicture = new System.Windows.Forms.PictureBox();
			this.systemInputPanel = new Microsoft.WindowsCE.Forms.InputPanel();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(4, 16);
			this.label1.Text = "Airplanes:";
			// 
			// airplaneList
			// 
			this.airplaneList.Location = new System.Drawing.Point(4, 32);
			this.airplaneList.Size = new System.Drawing.Size(232, 198);
			// 
			// newAirplaneButton
			// 
			this.newAirplaneButton.Location = new System.Drawing.Point(60, 0);
			this.newAirplaneButton.Size = new System.Drawing.Size(52, 24);
			this.newAirplaneButton.Text = "New";
			this.newAirplaneButton.Click += new System.EventHandler(this.newButton_Click);
			// 
			// deleteAirplaneButton
			// 
			this.deleteAirplaneButton.Location = new System.Drawing.Point(172, 0);
			this.deleteAirplaneButton.Size = new System.Drawing.Size(52, 24);
			this.deleteAirplaneButton.Text = "Delete";
			this.deleteAirplaneButton.Click += new System.EventHandler(this.deleteAirplaneButton_Click);
			// 
			// mainButtonPanel
			// 
			this.mainButtonPanel.BackColor = System.Drawing.Color.WhiteSmoke;
			this.mainButtonPanel.Controls.Add(this.newAirplaneButton);
			this.mainButtonPanel.Controls.Add(this.deleteAirplaneButton);
			this.mainButtonPanel.Controls.Add(this.copyAirplaneButton);
			this.mainButtonPanel.Controls.Add(this.selectAirplaneButton);
			this.mainButtonPanel.Location = new System.Drawing.Point(0, 240);
			this.mainButtonPanel.Size = new System.Drawing.Size(240, 24);
			// 
			// copyAirplaneButton
			// 
			this.copyAirplaneButton.Location = new System.Drawing.Point(116, 0);
			this.copyAirplaneButton.Size = new System.Drawing.Size(52, 24);
			this.copyAirplaneButton.Text = "Copy";
			this.copyAirplaneButton.Click += new System.EventHandler(this.copyAirplaneButton_Click);
			// 
			// selectAirplaneButton
			// 
			this.selectAirplaneButton.Location = new System.Drawing.Point(4, 0);
			this.selectAirplaneButton.Size = new System.Drawing.Size(52, 24);
			this.selectAirplaneButton.Text = "Select";
			this.selectAirplaneButton.Click += new System.EventHandler(this.selectAirplaneButton_Click);
			// 
			// mainPanel
			// 
			this.mainPanel.BackColor = System.Drawing.Color.WhiteSmoke;
			this.mainPanel.Controls.Add(this.mainButtonPanel);
			this.mainPanel.Controls.Add(this.airplaneList);
			this.mainPanel.Controls.Add(this.label1);
			this.mainPanel.Location = new System.Drawing.Point(8, 8);
			this.mainPanel.Size = new System.Drawing.Size(240, 264);
			// 
			// inputPanel
			// 
			this.inputPanel.BackColor = System.Drawing.Color.WhiteSmoke;
			this.inputPanel.Controls.Add(this.fuelStationComboBox);
			this.inputPanel.Controls.Add(this.tailNumberPanel);
			this.inputPanel.Controls.Add(this.tailNumberLabel);
			this.inputPanel.Controls.Add(this.inputButtonPanel);
			this.inputPanel.Controls.Add(this.basicEmptyStationText);
			this.inputPanel.Controls.Add(this.stationLabel);
			this.inputPanel.Controls.Add(this.limitsButton);
			this.inputPanel.Controls.Add(this.weightLabel);
			this.inputPanel.Controls.Add(this.basicEmptyArmText);
			this.inputPanel.Controls.Add(this.basicEmptyWeightText);
			this.inputPanel.Controls.Add(this.fuelArmText);
			this.inputPanel.Controls.Add(this.fuelWeightText);
			this.inputPanel.Controls.Add(this.pilotArmText);
			this.inputPanel.Controls.Add(this.pilotWeightText);
			this.inputPanel.Controls.Add(this.station1WeightText);
			this.inputPanel.Controls.Add(this.station1ArmText);
			this.inputPanel.Controls.Add(this.station2WeightText);
			this.inputPanel.Controls.Add(this.station2ArmText);
			this.inputPanel.Controls.Add(this.station2Text);
			this.inputPanel.Controls.Add(this.station3Text);
			this.inputPanel.Controls.Add(this.station3WeightText);
			this.inputPanel.Controls.Add(this.station3ArmText);
			this.inputPanel.Controls.Add(this.station4ArmText);
			this.inputPanel.Controls.Add(this.station4Text);
			this.inputPanel.Controls.Add(this.station4WeightText);
			this.inputPanel.Controls.Add(this.pilotStationText);
			this.inputPanel.Controls.Add(this.station1Text);
			this.inputPanel.Controls.Add(this.station5ArmText);
			this.inputPanel.Controls.Add(this.station5WeightText);
			this.inputPanel.Controls.Add(this.station5Text);
			this.inputPanel.Controls.Add(this.armLabel);
			this.inputPanel.Controls.Add(this.fuelPanel);
			this.inputPanel.Controls.Add(this.fuelPanelShadow);
			this.inputPanel.Location = new System.Drawing.Point(256, 8);
			this.inputPanel.Size = new System.Drawing.Size(240, 264);
			// 
			// fuelStationComboBox
			// 
			this.fuelStationComboBox.Items.Add("Takeoff Fuel");
			this.fuelStationComboBox.Items.Add("Landing Fuel");
			this.fuelStationComboBox.Location = new System.Drawing.Point(4, 72);
			this.fuelStationComboBox.Size = new System.Drawing.Size(108, 22);
			this.fuelStationComboBox.SelectedIndexChanged += new System.EventHandler(this.fuelStationComboBox_SelectedIndexChanged);
			// 
			// tailNumberPanel
			// 
			this.tailNumberPanel.BackColor = System.Drawing.Color.WhiteSmoke;
			this.tailNumberPanel.Controls.Add(this.tailNumberText);
			this.tailNumberPanel.Controls.Add(this.label2);
			this.tailNumberPanel.Location = new System.Drawing.Point(4, 4);
			this.tailNumberPanel.Size = new System.Drawing.Size(168, 24);
			// 
			// tailNumberText
			// 
			this.tailNumberText.Location = new System.Drawing.Point(72, 0);
			this.tailNumberText.MaxLength = 15;
			this.tailNumberText.Size = new System.Drawing.Size(96, 22);
			this.tailNumberText.Text = "";
			this.tailNumberText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.tailNumberText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
			// 
			// label2
			// 
			this.label2.Size = new System.Drawing.Size(76, 20);
			this.label2.Text = "Tail Number";
			// 
			// tailNumberLabel
			// 
			this.tailNumberLabel.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular);
			this.tailNumberLabel.Location = new System.Drawing.Point(4, 4);
			this.tailNumberLabel.Size = new System.Drawing.Size(136, 24);
			this.tailNumberLabel.Text = "N12345";
			// 
			// inputButtonPanel
			// 
			this.inputButtonPanel.BackColor = System.Drawing.Color.WhiteSmoke;
			this.inputButtonPanel.Controls.Add(this.backToMainButton);
			this.inputButtonPanel.Controls.Add(this.calcButton);
			this.inputButtonPanel.Controls.Add(this.fuelButton);
			this.inputButtonPanel.Location = new System.Drawing.Point(0, 240);
			this.inputButtonPanel.Size = new System.Drawing.Size(240, 24);
			// 
			// backToMainButton
			// 
			this.backToMainButton.Location = new System.Drawing.Point(60, 0);
			this.backToMainButton.Size = new System.Drawing.Size(52, 24);
			this.backToMainButton.Text = "Back";
			this.backToMainButton.Click += new System.EventHandler(this.backButton_Click);
			// 
			// calcButton
			// 
			this.calcButton.Location = new System.Drawing.Point(4, 0);
			this.calcButton.Size = new System.Drawing.Size(52, 24);
			this.calcButton.Text = "Calc";
			this.calcButton.Click += new System.EventHandler(this.calcButton_Click);
			// 
			// fuelButton
			// 
			this.fuelButton.Location = new System.Drawing.Point(176, 0);
			this.fuelButton.Size = new System.Drawing.Size(56, 24);
			this.fuelButton.Text = "Fuel";
			this.fuelButton.Click += new System.EventHandler(this.fuelButton_Click);
			// 
			// basicEmptyStationText
			// 
			this.basicEmptyStationText.BackColor = System.Drawing.Color.SteelBlue;
			this.basicEmptyStationText.ForeColor = System.Drawing.Color.White;
			this.basicEmptyStationText.Location = new System.Drawing.Point(4, 48);
			this.basicEmptyStationText.MaxLength = 30;
			this.basicEmptyStationText.Size = new System.Drawing.Size(108, 22);
			this.basicEmptyStationText.Text = "Basic Empty";
			this.basicEmptyStationText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.disabledTextBox_KeyPress);
			// 
			// stationLabel
			// 
			this.stationLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.stationLabel.Location = new System.Drawing.Point(4, 32);
			this.stationLabel.Size = new System.Drawing.Size(56, 16);
			this.stationLabel.Text = "Station";
			// 
			// limitsButton
			// 
			this.limitsButton.Location = new System.Drawing.Point(176, 4);
			this.limitsButton.Size = new System.Drawing.Size(56, 22);
			this.limitsButton.Text = "Limits";
			this.limitsButton.Click += new System.EventHandler(this.limitsButton_Click);
			// 
			// weightLabel
			// 
			this.weightLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.weightLabel.Location = new System.Drawing.Point(116, 32);
			this.weightLabel.Size = new System.Drawing.Size(56, 16);
			this.weightLabel.Text = "Weight";
			// 
			// basicEmptyArmText
			// 
			this.basicEmptyArmText.Location = new System.Drawing.Point(176, 48);
			this.basicEmptyArmText.MaxLength = 10;
			this.basicEmptyArmText.Size = new System.Drawing.Size(56, 22);
			this.basicEmptyArmText.Text = "";
			this.basicEmptyArmText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.basicEmptyArmText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.basicEmptyArmText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// basicEmptyWeightText
			// 
			this.basicEmptyWeightText.Location = new System.Drawing.Point(116, 48);
			this.basicEmptyWeightText.MaxLength = 10;
			this.basicEmptyWeightText.Size = new System.Drawing.Size(56, 22);
			this.basicEmptyWeightText.Text = "";
			this.basicEmptyWeightText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.basicEmptyWeightText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.basicEmptyWeightText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// fuelArmText
			// 
			this.fuelArmText.Location = new System.Drawing.Point(176, 72);
			this.fuelArmText.MaxLength = 10;
			this.fuelArmText.Size = new System.Drawing.Size(56, 22);
			this.fuelArmText.Text = "";
			this.fuelArmText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.fuelArmText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.fuelArmText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// fuelWeightText
			// 
			this.fuelWeightText.Location = new System.Drawing.Point(116, 72);
			this.fuelWeightText.MaxLength = 10;
			this.fuelWeightText.Size = new System.Drawing.Size(56, 22);
			this.fuelWeightText.Text = "";
			this.fuelWeightText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.fuelWeightText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.fuelWeightText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// pilotArmText
			// 
			this.pilotArmText.Location = new System.Drawing.Point(176, 96);
			this.pilotArmText.MaxLength = 10;
			this.pilotArmText.Size = new System.Drawing.Size(56, 22);
			this.pilotArmText.Text = "";
			this.pilotArmText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.pilotArmText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.pilotArmText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// pilotWeightText
			// 
			this.pilotWeightText.Location = new System.Drawing.Point(116, 96);
			this.pilotWeightText.MaxLength = 10;
			this.pilotWeightText.Size = new System.Drawing.Size(56, 22);
			this.pilotWeightText.Text = "";
			this.pilotWeightText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.pilotWeightText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.pilotWeightText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// station1WeightText
			// 
			this.station1WeightText.Location = new System.Drawing.Point(116, 120);
			this.station1WeightText.MaxLength = 10;
			this.station1WeightText.Size = new System.Drawing.Size(56, 22);
			this.station1WeightText.Text = "";
			this.station1WeightText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.station1WeightText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.station1WeightText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// station1ArmText
			// 
			this.station1ArmText.Location = new System.Drawing.Point(176, 120);
			this.station1ArmText.MaxLength = 10;
			this.station1ArmText.Size = new System.Drawing.Size(56, 22);
			this.station1ArmText.Text = "";
			this.station1ArmText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.station1ArmText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.station1ArmText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// station2WeightText
			// 
			this.station2WeightText.Location = new System.Drawing.Point(116, 144);
			this.station2WeightText.MaxLength = 10;
			this.station2WeightText.Size = new System.Drawing.Size(56, 22);
			this.station2WeightText.Text = "";
			this.station2WeightText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.station2WeightText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.station2WeightText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// station2ArmText
			// 
			this.station2ArmText.Location = new System.Drawing.Point(176, 144);
			this.station2ArmText.MaxLength = 10;
			this.station2ArmText.Size = new System.Drawing.Size(56, 22);
			this.station2ArmText.Text = "";
			this.station2ArmText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.station2ArmText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.station2ArmText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// station2Text
			// 
			this.station2Text.Location = new System.Drawing.Point(4, 144);
			this.station2Text.MaxLength = 30;
			this.station2Text.Size = new System.Drawing.Size(108, 22);
			this.station2Text.Text = "Rear Seat";
			this.station2Text.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.station2Text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
			// 
			// station3Text
			// 
			this.station3Text.Location = new System.Drawing.Point(4, 168);
			this.station3Text.MaxLength = 30;
			this.station3Text.Size = new System.Drawing.Size(108, 22);
			this.station3Text.Text = "Baggage 1";
			this.station3Text.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.station3Text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
			// 
			// station3WeightText
			// 
			this.station3WeightText.Location = new System.Drawing.Point(116, 168);
			this.station3WeightText.MaxLength = 10;
			this.station3WeightText.Size = new System.Drawing.Size(56, 22);
			this.station3WeightText.Text = "";
			this.station3WeightText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.station3WeightText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.station3WeightText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// station3ArmText
			// 
			this.station3ArmText.Location = new System.Drawing.Point(176, 168);
			this.station3ArmText.MaxLength = 10;
			this.station3ArmText.Size = new System.Drawing.Size(56, 22);
			this.station3ArmText.Text = "";
			this.station3ArmText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.station3ArmText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.station3ArmText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// station4ArmText
			// 
			this.station4ArmText.Location = new System.Drawing.Point(176, 192);
			this.station4ArmText.MaxLength = 10;
			this.station4ArmText.Size = new System.Drawing.Size(56, 22);
			this.station4ArmText.Text = "";
			this.station4ArmText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.station4ArmText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.station4ArmText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// station4Text
			// 
			this.station4Text.Location = new System.Drawing.Point(4, 192);
			this.station4Text.MaxLength = 30;
			this.station4Text.Size = new System.Drawing.Size(108, 22);
			this.station4Text.Text = "Baggage 2";
			this.station4Text.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.station4Text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
			// 
			// station4WeightText
			// 
			this.station4WeightText.Location = new System.Drawing.Point(116, 192);
			this.station4WeightText.MaxLength = 10;
			this.station4WeightText.Size = new System.Drawing.Size(56, 22);
			this.station4WeightText.Text = "";
			this.station4WeightText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.station4WeightText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.station4WeightText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// pilotStationText
			// 
			this.pilotStationText.BackColor = System.Drawing.Color.SteelBlue;
			this.pilotStationText.ForeColor = System.Drawing.Color.White;
			this.pilotStationText.Location = new System.Drawing.Point(4, 96);
			this.pilotStationText.MaxLength = 30;
			this.pilotStationText.Size = new System.Drawing.Size(108, 22);
			this.pilotStationText.Text = "Pilot";
			this.pilotStationText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.disabledTextBox_KeyPress);
			// 
			// station1Text
			// 
			this.station1Text.Location = new System.Drawing.Point(4, 120);
			this.station1Text.MaxLength = 30;
			this.station1Text.Size = new System.Drawing.Size(108, 22);
			this.station1Text.Text = "Passenger";
			this.station1Text.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.station1Text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
			// 
			// station5ArmText
			// 
			this.station5ArmText.Location = new System.Drawing.Point(176, 216);
			this.station5ArmText.MaxLength = 10;
			this.station5ArmText.Size = new System.Drawing.Size(56, 22);
			this.station5ArmText.Text = "";
			this.station5ArmText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.station5ArmText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.station5ArmText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// station5WeightText
			// 
			this.station5WeightText.Location = new System.Drawing.Point(116, 216);
			this.station5WeightText.MaxLength = 10;
			this.station5WeightText.Size = new System.Drawing.Size(56, 22);
			this.station5WeightText.Text = "";
			this.station5WeightText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.station5WeightText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.station5WeightText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// station5Text
			// 
			this.station5Text.Location = new System.Drawing.Point(4, 216);
			this.station5Text.MaxLength = 30;
			this.station5Text.Size = new System.Drawing.Size(108, 22);
			this.station5Text.Text = "";
			this.station5Text.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.station5Text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
			// 
			// armLabel
			// 
			this.armLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.armLabel.Location = new System.Drawing.Point(176, 32);
			this.armLabel.Size = new System.Drawing.Size(56, 16);
			this.armLabel.Text = "Arm";
			// 
			// fuelPanel
			// 
			this.fuelPanel.BackColor = System.Drawing.Color.SteelBlue;
			this.fuelPanel.Controls.Add(this.label11);
			this.fuelPanel.Controls.Add(this.label12);
			this.fuelPanel.Controls.Add(this.fuelCalculatorTakeoffFuelQuantityText);
			this.fuelPanel.Controls.Add(this.fuelCalculatorFuelConsumedQuantityText);
			this.fuelPanel.Controls.Add(this.fuelOkButton);
			this.fuelPanel.Controls.Add(this.fuelCancelButton);
			this.fuelPanel.Location = new System.Drawing.Point(28, 90);
			this.fuelPanel.Size = new System.Drawing.Size(184, 88);
			this.fuelPanel.Visible = false;
			// 
			// label11
			// 
			this.label11.ForeColor = System.Drawing.Color.White;
			this.label11.Location = new System.Drawing.Point(8, 8);
			this.label11.Size = new System.Drawing.Size(112, 16);
			this.label11.Text = "Takeoff Gallons:";
			// 
			// label12
			// 
			this.label12.ForeColor = System.Drawing.Color.White;
			this.label12.Location = new System.Drawing.Point(8, 32);
			this.label12.Size = new System.Drawing.Size(112, 16);
			this.label12.Text = "Gallons Consumed:";
			// 
			// fuelCalculatorTakeoffFuelQuantityText
			// 
			this.fuelCalculatorTakeoffFuelQuantityText.Location = new System.Drawing.Point(120, 5);
			this.fuelCalculatorTakeoffFuelQuantityText.MaxLength = 10;
			this.fuelCalculatorTakeoffFuelQuantityText.Size = new System.Drawing.Size(56, 22);
			this.fuelCalculatorTakeoffFuelQuantityText.Text = "";
			this.fuelCalculatorTakeoffFuelQuantityText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.fuelCalculatorTakeoffFuelQuantityText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.fuelCalculatorTakeoffFuelQuantityText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// fuelCalculatorFuelConsumedQuantityText
			// 
			this.fuelCalculatorFuelConsumedQuantityText.Location = new System.Drawing.Point(120, 29);
			this.fuelCalculatorFuelConsumedQuantityText.MaxLength = 10;
			this.fuelCalculatorFuelConsumedQuantityText.Size = new System.Drawing.Size(56, 22);
			this.fuelCalculatorFuelConsumedQuantityText.Text = "";
			this.fuelCalculatorFuelConsumedQuantityText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.fuelCalculatorFuelConsumedQuantityText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.fuelCalculatorFuelConsumedQuantityText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// fuelOkButton
			// 
			this.fuelOkButton.Location = new System.Drawing.Point(120, 56);
			this.fuelOkButton.Size = new System.Drawing.Size(56, 24);
			this.fuelOkButton.Text = "OK";
			this.fuelOkButton.Click += new System.EventHandler(this.fuelOkButton_Click);
			// 
			// fuelCancelButton
			// 
			this.fuelCancelButton.Location = new System.Drawing.Point(60, 56);
			this.fuelCancelButton.Size = new System.Drawing.Size(56, 24);
			this.fuelCancelButton.Text = "Cancel";
			this.fuelCancelButton.Click += new System.EventHandler(this.fuelCancelButton_Click);
			// 
			// fuelPanelShadow
			// 
			this.fuelPanelShadow.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.fuelPanelShadow.Location = new System.Drawing.Point(32, 94);
			this.fuelPanelShadow.Size = new System.Drawing.Size(184, 88);
			this.fuelPanelShadow.Visible = false;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(128, 8);
			this.label5.Size = new System.Drawing.Size(76, 16);
			this.label5.Text = "Max Weight";
			// 
			// maxWeightText
			// 
			this.maxWeightText.Location = new System.Drawing.Point(128, 24);
			this.maxWeightText.MaxLength = 10;
			this.maxWeightText.Size = new System.Drawing.Size(72, 22);
			this.maxWeightText.Text = "";
			this.maxWeightText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.maxWeightText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.maxWeightText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// limitsPanel
			// 
			this.limitsPanel.BackColor = System.Drawing.Color.WhiteSmoke;
			this.limitsPanel.Controls.Add(this.limitsPicture);
			this.limitsPanel.Controls.Add(this.limitsButtonPanel);
			this.limitsPanel.Controls.Add(this.label8);
			this.limitsPanel.Controls.Add(this.label9);
			this.limitsPanel.Controls.Add(this.limit1ArmText);
			this.limitsPanel.Controls.Add(this.limit1WeightText);
			this.limitsPanel.Controls.Add(this.limit2ArmText);
			this.limitsPanel.Controls.Add(this.limit2WeightText);
			this.limitsPanel.Controls.Add(this.limit3ArmText);
			this.limitsPanel.Controls.Add(this.limit3WeightText);
			this.limitsPanel.Controls.Add(this.limit4WeightText);
			this.limitsPanel.Controls.Add(this.limit4ArmText);
			this.limitsPanel.Controls.Add(this.limit5ArmText);
			this.limitsPanel.Controls.Add(this.limit5WeightText);
			this.limitsPanel.Controls.Add(this.limit6ArmText);
			this.limitsPanel.Controls.Add(this.limit6WeightText);
			this.limitsPanel.Controls.Add(this.limit7ArmText);
			this.limitsPanel.Controls.Add(this.limit7WeightText);
			this.limitsPanel.Controls.Add(this.label5);
			this.limitsPanel.Controls.Add(this.maxWeightText);
			this.limitsPanel.Controls.Add(this.limit8ArmText);
			this.limitsPanel.Controls.Add(this.limit8WeightText);
			this.limitsPanel.Controls.Add(this.limit9ArmText);
			this.limitsPanel.Controls.Add(this.limit9WeightText);
			this.limitsPanel.Controls.Add(this.label6);
			this.limitsPanel.Location = new System.Drawing.Point(8, 280);
			this.limitsPanel.Size = new System.Drawing.Size(240, 264);
			// 
			// limitsPicture
			// 
			this.limitsPicture.Location = new System.Drawing.Point(128, 72);
			this.limitsPicture.Size = new System.Drawing.Size(104, 96);
			// 
			// limitsButtonPanel
			// 
			this.limitsButtonPanel.BackColor = System.Drawing.Color.WhiteSmoke;
			this.limitsButtonPanel.Controls.Add(this.limitsOkButton);
			this.limitsButtonPanel.Location = new System.Drawing.Point(0, 240);
			this.limitsButtonPanel.Size = new System.Drawing.Size(240, 24);
			// 
			// limitsOkButton
			// 
			this.limitsOkButton.Location = new System.Drawing.Point(4, 0);
			this.limitsOkButton.Size = new System.Drawing.Size(52, 24);
			this.limitsOkButton.Text = "OK";
			this.limitsOkButton.Click += new System.EventHandler(this.limitsOkButton_Click);
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.label8.Location = new System.Drawing.Point(4, 8);
			this.label8.Size = new System.Drawing.Size(56, 16);
			this.label8.Text = "Weight";
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.label9.Location = new System.Drawing.Point(64, 8);
			this.label9.Size = new System.Drawing.Size(56, 16);
			this.label9.Text = "Arm";
			// 
			// limit1ArmText
			// 
			this.limit1ArmText.Location = new System.Drawing.Point(64, 24);
			this.limit1ArmText.MaxLength = 10;
			this.limit1ArmText.Size = new System.Drawing.Size(56, 22);
			this.limit1ArmText.Text = "";
			this.limit1ArmText.LostFocus += new System.EventHandler(this.limitControl_LostFocus);
			this.limit1ArmText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.limit1ArmText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.limit1ArmText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// limit1WeightText
			// 
			this.limit1WeightText.Location = new System.Drawing.Point(4, 24);
			this.limit1WeightText.MaxLength = 10;
			this.limit1WeightText.Size = new System.Drawing.Size(56, 22);
			this.limit1WeightText.Text = "";
			this.limit1WeightText.LostFocus += new System.EventHandler(this.limitControl_LostFocus);
			this.limit1WeightText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.limit1WeightText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.limit1WeightText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// limit2ArmText
			// 
			this.limit2ArmText.Location = new System.Drawing.Point(64, 48);
			this.limit2ArmText.MaxLength = 10;
			this.limit2ArmText.Size = new System.Drawing.Size(56, 22);
			this.limit2ArmText.Text = "";
			this.limit2ArmText.LostFocus += new System.EventHandler(this.limitControl_LostFocus);
			this.limit2ArmText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.limit2ArmText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.limit2ArmText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// limit2WeightText
			// 
			this.limit2WeightText.Location = new System.Drawing.Point(4, 48);
			this.limit2WeightText.MaxLength = 10;
			this.limit2WeightText.Size = new System.Drawing.Size(56, 22);
			this.limit2WeightText.Text = "";
			this.limit2WeightText.LostFocus += new System.EventHandler(this.limitControl_LostFocus);
			this.limit2WeightText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.limit2WeightText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.limit2WeightText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// limit3ArmText
			// 
			this.limit3ArmText.Location = new System.Drawing.Point(64, 72);
			this.limit3ArmText.MaxLength = 10;
			this.limit3ArmText.Size = new System.Drawing.Size(56, 22);
			this.limit3ArmText.Text = "";
			this.limit3ArmText.LostFocus += new System.EventHandler(this.limitControl_LostFocus);
			this.limit3ArmText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.limit3ArmText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.limit3ArmText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// limit3WeightText
			// 
			this.limit3WeightText.Location = new System.Drawing.Point(4, 72);
			this.limit3WeightText.MaxLength = 10;
			this.limit3WeightText.Size = new System.Drawing.Size(56, 22);
			this.limit3WeightText.Text = "";
			this.limit3WeightText.LostFocus += new System.EventHandler(this.limitControl_LostFocus);
			this.limit3WeightText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.limit3WeightText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.limit3WeightText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// limit4WeightText
			// 
			this.limit4WeightText.Location = new System.Drawing.Point(4, 96);
			this.limit4WeightText.MaxLength = 10;
			this.limit4WeightText.Size = new System.Drawing.Size(56, 22);
			this.limit4WeightText.Text = "";
			this.limit4WeightText.LostFocus += new System.EventHandler(this.limitControl_LostFocus);
			this.limit4WeightText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.limit4WeightText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.limit4WeightText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// limit4ArmText
			// 
			this.limit4ArmText.Location = new System.Drawing.Point(64, 96);
			this.limit4ArmText.MaxLength = 10;
			this.limit4ArmText.Size = new System.Drawing.Size(56, 22);
			this.limit4ArmText.Text = "";
			this.limit4ArmText.LostFocus += new System.EventHandler(this.limitControl_LostFocus);
			this.limit4ArmText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.limit4ArmText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.limit4ArmText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// limit5ArmText
			// 
			this.limit5ArmText.Location = new System.Drawing.Point(64, 120);
			this.limit5ArmText.MaxLength = 10;
			this.limit5ArmText.Size = new System.Drawing.Size(56, 22);
			this.limit5ArmText.Text = "";
			this.limit5ArmText.LostFocus += new System.EventHandler(this.limitControl_LostFocus);
			this.limit5ArmText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.limit5ArmText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.limit5ArmText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// limit5WeightText
			// 
			this.limit5WeightText.Location = new System.Drawing.Point(4, 120);
			this.limit5WeightText.MaxLength = 10;
			this.limit5WeightText.Size = new System.Drawing.Size(56, 22);
			this.limit5WeightText.Text = "";
			this.limit5WeightText.LostFocus += new System.EventHandler(this.limitControl_LostFocus);
			this.limit5WeightText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.limit5WeightText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.limit5WeightText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// limit6ArmText
			// 
			this.limit6ArmText.Location = new System.Drawing.Point(64, 144);
			this.limit6ArmText.MaxLength = 10;
			this.limit6ArmText.Size = new System.Drawing.Size(56, 22);
			this.limit6ArmText.Text = "";
			this.limit6ArmText.LostFocus += new System.EventHandler(this.limitControl_LostFocus);
			this.limit6ArmText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.limit6ArmText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.limit6ArmText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// limit6WeightText
			// 
			this.limit6WeightText.Location = new System.Drawing.Point(4, 144);
			this.limit6WeightText.MaxLength = 10;
			this.limit6WeightText.Size = new System.Drawing.Size(56, 22);
			this.limit6WeightText.Text = "";
			this.limit6WeightText.LostFocus += new System.EventHandler(this.limitControl_LostFocus);
			this.limit6WeightText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.limit6WeightText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.limit6WeightText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// limit7ArmText
			// 
			this.limit7ArmText.Location = new System.Drawing.Point(64, 168);
			this.limit7ArmText.MaxLength = 10;
			this.limit7ArmText.Size = new System.Drawing.Size(56, 22);
			this.limit7ArmText.Text = "";
			this.limit7ArmText.LostFocus += new System.EventHandler(this.limitControl_LostFocus);
			this.limit7ArmText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.limit7ArmText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.limit7ArmText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// limit7WeightText
			// 
			this.limit7WeightText.Location = new System.Drawing.Point(4, 168);
			this.limit7WeightText.MaxLength = 10;
			this.limit7WeightText.Size = new System.Drawing.Size(56, 22);
			this.limit7WeightText.Text = "";
			this.limit7WeightText.LostFocus += new System.EventHandler(this.limitControl_LostFocus);
			this.limit7WeightText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.limit7WeightText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.limit7WeightText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// limit8ArmText
			// 
			this.limit8ArmText.Location = new System.Drawing.Point(64, 192);
			this.limit8ArmText.MaxLength = 10;
			this.limit8ArmText.Size = new System.Drawing.Size(56, 22);
			this.limit8ArmText.Text = "";
			this.limit8ArmText.LostFocus += new System.EventHandler(this.limitControl_LostFocus);
			this.limit8ArmText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.limit8ArmText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.limit8ArmText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// limit8WeightText
			// 
			this.limit8WeightText.Location = new System.Drawing.Point(4, 192);
			this.limit8WeightText.MaxLength = 10;
			this.limit8WeightText.Size = new System.Drawing.Size(56, 22);
			this.limit8WeightText.Text = "";
			this.limit8WeightText.LostFocus += new System.EventHandler(this.limitControl_LostFocus);
			this.limit8WeightText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.limit8WeightText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.limit8WeightText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// limit9ArmText
			// 
			this.limit9ArmText.Location = new System.Drawing.Point(64, 216);
			this.limit9ArmText.MaxLength = 10;
			this.limit9ArmText.Size = new System.Drawing.Size(56, 22);
			this.limit9ArmText.Text = "";
			this.limit9ArmText.LostFocus += new System.EventHandler(this.limitControl_LostFocus);
			this.limit9ArmText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.limit9ArmText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.limit9ArmText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// limit9WeightText
			// 
			this.limit9WeightText.Location = new System.Drawing.Point(4, 216);
			this.limit9WeightText.MaxLength = 10;
			this.limit9WeightText.Size = new System.Drawing.Size(56, 22);
			this.limit9WeightText.Text = "";
			this.limit9WeightText.LostFocus += new System.EventHandler(this.limitControl_LostFocus);
			this.limit9WeightText.GotFocus += new System.EventHandler(this.editableControl_GotFocus);
			this.limit9WeightText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
			this.limit9WeightText.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox_Validating);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(128, 56);
			this.label6.Size = new System.Drawing.Size(80, 16);
			this.label6.Text = "CG Envelope";
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
			this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
			this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn3);
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.HeaderText = "Station";
			this.dataGridTextBoxColumn1.NullText = "(null)";
			this.dataGridTextBoxColumn1.Width = 100;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.HeaderText = "Weight";
			this.dataGridTextBoxColumn2.NullText = "(null)";
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.HeaderText = "Arm";
			this.dataGridTextBoxColumn3.NullText = "(null)";
			// 
			// calculationPanel
			// 
			this.calculationPanel.BackColor = System.Drawing.Color.WhiteSmoke;
			this.calculationPanel.Controls.Add(this.takeoffPointPicture);
			this.calculationPanel.Controls.Add(this.label4);
			this.calculationPanel.Controls.Add(this.label19);
			this.calculationPanel.Controls.Add(this.calculationPicture);
			this.calculationPanel.Controls.Add(this.panel2);
			this.calculationPanel.Controls.Add(this.label3);
			this.calculationPanel.Controls.Add(this.label7);
			this.calculationPanel.Controls.Add(this.label10);
			this.calculationPanel.Controls.Add(this.takeoffWeightLabel);
			this.calculationPanel.Controls.Add(this.landingWeightLabel);
			this.calculationPanel.Controls.Add(this.zeroFuelWeightLabel);
			this.calculationPanel.Controls.Add(this.takeoffCGArmLabel);
			this.calculationPanel.Controls.Add(this.landingCGArmLabel);
			this.calculationPanel.Controls.Add(this.zeroFuelCGArmLabel);
			this.calculationPanel.Controls.Add(this.landingPointPicture);
			this.calculationPanel.Controls.Add(this.zeroFuelPointPicture);
			this.calculationPanel.Location = new System.Drawing.Point(256, 280);
			this.calculationPanel.Size = new System.Drawing.Size(240, 264);
			// 
			// takeoffPointPicture
			// 
			this.takeoffPointPicture.Location = new System.Drawing.Point(16, 24);
			this.takeoffPointPicture.Size = new System.Drawing.Size(8, 8);
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.label4.Location = new System.Drawing.Point(24, 20);
			this.label4.Size = new System.Drawing.Size(72, 16);
			this.label4.Text = "Takeoff";
			// 
			// label19
			// 
			this.label19.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.label19.Location = new System.Drawing.Point(104, 4);
			this.label19.Size = new System.Drawing.Size(56, 16);
			this.label19.Text = "Weight";
			// 
			// calculationPicture
			// 
			this.calculationPicture.Location = new System.Drawing.Point(4, 80);
			this.calculationPicture.Size = new System.Drawing.Size(228, 152);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
			this.panel2.Controls.Add(this.calculationOkButton);
			this.panel2.Location = new System.Drawing.Point(0, 240);
			this.panel2.Size = new System.Drawing.Size(240, 24);
			// 
			// calculationOkButton
			// 
			this.calculationOkButton.Location = new System.Drawing.Point(4, 0);
			this.calculationOkButton.Size = new System.Drawing.Size(52, 24);
			this.calculationOkButton.Text = "OK";
			this.calculationOkButton.Click += new System.EventHandler(this.calculationOkButton_Click);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.label3.Location = new System.Drawing.Point(168, 4);
			this.label3.Size = new System.Drawing.Size(56, 16);
			this.label3.Text = "CG Arm";
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.label7.Location = new System.Drawing.Point(24, 36);
			this.label7.Size = new System.Drawing.Size(72, 16);
			this.label7.Text = "Landing";
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.label10.Location = new System.Drawing.Point(24, 52);
			this.label10.Size = new System.Drawing.Size(72, 16);
			this.label10.Text = "Zero-Fuel";
			// 
			// takeoffWeightLabel
			// 
			this.takeoffWeightLabel.ForeColor = System.Drawing.Color.Green;
			this.takeoffWeightLabel.Location = new System.Drawing.Point(104, 20);
			this.takeoffWeightLabel.Size = new System.Drawing.Size(56, 16);
			this.takeoffWeightLabel.Text = "2550";
			// 
			// landingWeightLabel
			// 
			this.landingWeightLabel.ForeColor = System.Drawing.Color.Green;
			this.landingWeightLabel.Location = new System.Drawing.Point(104, 36);
			this.landingWeightLabel.Size = new System.Drawing.Size(56, 16);
			this.landingWeightLabel.Text = "2350";
			// 
			// zeroFuelWeightLabel
			// 
			this.zeroFuelWeightLabel.ForeColor = System.Drawing.Color.Green;
			this.zeroFuelWeightLabel.Location = new System.Drawing.Point(104, 52);
			this.zeroFuelWeightLabel.Size = new System.Drawing.Size(56, 16);
			this.zeroFuelWeightLabel.Text = "2100";
			// 
			// takeoffCGArmLabel
			// 
			this.takeoffCGArmLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.takeoffCGArmLabel.Location = new System.Drawing.Point(168, 20);
			this.takeoffCGArmLabel.Size = new System.Drawing.Size(56, 16);
			this.takeoffCGArmLabel.Text = "45.1";
			// 
			// landingCGArmLabel
			// 
			this.landingCGArmLabel.ForeColor = System.Drawing.Color.Green;
			this.landingCGArmLabel.Location = new System.Drawing.Point(168, 36);
			this.landingCGArmLabel.Size = new System.Drawing.Size(56, 16);
			this.landingCGArmLabel.Text = "42.12";
			// 
			// zeroFuelCGArmLabel
			// 
			this.zeroFuelCGArmLabel.ForeColor = System.Drawing.Color.Green;
			this.zeroFuelCGArmLabel.Location = new System.Drawing.Point(168, 52);
			this.zeroFuelCGArmLabel.Size = new System.Drawing.Size(56, 16);
			this.zeroFuelCGArmLabel.Text = "40.1";
			// 
			// landingPointPicture
			// 
			this.landingPointPicture.Location = new System.Drawing.Point(16, 40);
			this.landingPointPicture.Size = new System.Drawing.Size(8, 8);
			// 
			// zeroFuelPointPicture
			// 
			this.zeroFuelPointPicture.Location = new System.Drawing.Point(16, 56);
			this.zeroFuelPointPicture.Size = new System.Drawing.Size(8, 8);
			// 
			// systemInputPanel
			// 
			this.systemInputPanel.EnabledChanged += new System.EventHandler(this.systemInputPanel_EnabledChanged);
			// 
			// MainForm
			// 
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(522, 567);
			this.Controls.Add(this.inputPanel);
			this.Controls.Add(this.mainPanel);
			this.Controls.Add(this.limitsPanel);
			this.Controls.Add(this.calculationPanel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu1;
			this.Text = "Weight and Balance";
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			this.Load += new System.EventHandler(this.MainForm_Load);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>

		static void Main() 
		{
			Application.Run(new MainForm());
		}

		private void MainForm_Load(object sender, System.EventArgs e)
		{
			fuelStationComboBox.BackColor = basicEmptyStationText.BackColor;
			fuelStationComboBox.ForeColor = basicEmptyStationText.ForeColor;
			fuelStationComboBox.SelectedIndex = 0;

			fuelPanel.Paint += new PaintEventHandler(fuelPanel_Paint);

			LoadAirplanes();
			GotoPanel(mainPanel);
		}

		private void MainForm_Resize(object sender, System.EventArgs e)
		{
			foreach(Panel panel in panels)
			{
				panel.Left = panel.Top = 0;
			}
		}

		private void newButton_Click(object sender, System.EventArgs e)
		{
			currentAirplane = new Airplane();
			LoadCurrentAirplane();
			GotoPanel(inputPanel);
		}

		private void backButton_Click(object sender, System.EventArgs e)
		{
			if (!DoneEditingAirplane())
			{
				return;
			}

			SaveCurrentAirplane();
			LoadAirplanes();
			GotoPanel(mainPanel);
		}

		private void limitsButton_Click(object sender, System.EventArgs e)
		{
			cgEnvelopeDefinitionGraph.Airplane = currentAirplane;
			GotoPanel(limitsPanel);
		}

		private void limitsOkButton_Click(object sender, System.EventArgs e)
		{
			SaveCurrentAirplane();
			GotoPanel(inputPanel);
		}

		private void calculationOkButton_Click(object sender, System.EventArgs e)
		{
			GotoPanel(inputPanel);
		}

		private void calcButton_Click(object sender, System.EventArgs e)
		{
			SaveCurrentAirplane();
			DisplayCalculations();
			GotoPanel(calculationPanel);
		}

		private void systemInputPanel_EnabledChanged(object sender, System.EventArgs e)
		{
			ShiftFormIfNecessary();
		}

		private void editableControl_GotFocus(object sender, System.EventArgs e)
		{
			if (!systemInputPanel.Enabled)
			{
				systemInputPanel.Enabled = true;
			}
			else
			{
				ShiftFormIfNecessary();
			}
		}

		private bool DoneEditingAirplane()
		{
			if (tailNumberText.Text.Trim() == string.Empty)
			{
				DialogResult result = MessageBox.Show(
					"You have not entered a tail number. Discard airplane profile?",
					"Tail Number Required", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, 
					MessageBoxDefaultButton.Button1);

				if (result != DialogResult.Yes)
				{
					tailNumberText.Focus();
					return false;
				}
			}

			return true;
		}

		private void SaveCurrentAirplane()
		{
			currentAirplane.TailNumber = tailNumberText.Text;
			currentAirplane.MaxWeight = maxWeightText.Text.Trim() == string.Empty ? 
				0M : decimal.Parse(maxWeightText.Text);

			foreach(StationView view in inputStationViews)
			{
				view.Update();
			}

			foreach(StationView view in limitStationViews)
			{
				view.Update();
			}

			fuelStationView.Update();
			fuelStationView.SynchronizeFuelArms(currentAirplane);

			if (!currentAirplane.HasTailNumber)
			{
				return;
			}

			repository.Save(currentAirplane);
		}

		private void LoadCurrentAirplane()
		{
			if (currentAirplane.HasTailNumber)
			{
				tailNumberPanel.Visible = false;
			}
			else
			{
				tailNumberPanel.Visible = true;
			}

			tailNumberText.Text = currentAirplane.TailNumber;
			tailNumberLabel.Text = currentAirplane.TailNumber;
			maxWeightText.Text = currentAirplane.MaxWeight == 0.0M ? string.Empty 
				: currentAirplane.MaxWeight.ToString();

			LoadViews();
			DisplayViews();

			fuelStationComboBox.SelectedIndex = 0;
		}

		private void DisplayViews()
		{
			foreach(StationView view in inputStationViews)
			{
				view.Display();
			}

			foreach(StationView view in limitStationViews)
			{
				view.Display();
			}

			fuelStationView.Display();
		}

		private void LoadViews()
		{
			inputStationViews = new StationView[] {
				new StationView(currentAirplane.Stations[0], basicEmptyStationText, basicEmptyWeightText, basicEmptyArmText),
				new StationView(currentAirplane.Stations[1], pilotStationText, pilotWeightText, pilotArmText),
				new StationView(currentAirplane.Stations[2], station1Text, station1WeightText, station1ArmText),
				new StationView(currentAirplane.Stations[3], station2Text, station2WeightText, station2ArmText),
				new StationView(currentAirplane.Stations[4], station3Text, station3WeightText, station3ArmText),
				new StationView(currentAirplane.Stations[5], station4Text, station4WeightText, station4ArmText),
				new StationView(currentAirplane.Stations[6], station5Text, station5WeightText, station5ArmText)
			};

			limitStationViews = new StationView[] {
				new StationView(currentAirplane.Limits[0], null, limit1WeightText, limit1ArmText),
				new StationView(currentAirplane.Limits[1], null, limit2WeightText, limit2ArmText),
				new StationView(currentAirplane.Limits[2], null, limit3WeightText, limit3ArmText),
				new StationView(currentAirplane.Limits[3], null, limit4WeightText, limit4ArmText),
				new StationView(currentAirplane.Limits[4], null, limit5WeightText, limit5ArmText),
				new StationView(currentAirplane.Limits[5], null, limit6WeightText, limit6ArmText),
				new StationView(currentAirplane.Limits[6], null, limit7WeightText, limit7ArmText)
			};

			fuelStationView = new StationView(currentAirplane.TakeoffFuel, 
				fuelStationComboBox, fuelWeightText, fuelArmText);
		}

		private void LoadAirplanes()
		{
			airplaneList.Items.Clear();

			foreach(string tailNumber in repository.GetAllTailNumbers())
			{
				airplaneList.Items.Add(tailNumber);
			}
		}

		private void GotoPanel(Panel panel)
		{
			systemInputPanel.Enabled = false;
			ShiftFormIfNecessary();
			panel.BringToFront();
		}
		
		private void ShiftFormIfNecessary()
		{
			bool isLowControl = IsSelectedControlBelowKeyboardTop();
			
			foreach(Panel panel in panels)
			{
				if (systemInputPanel.Enabled & isLowControl)
				{
					panel.Top = -systemInputPanel.Bounds.Height;
				}
				else
				{
					panel.Top = 0;
				}
			}
		}

		private bool IsSelectedControlBelowKeyboardTop()
		{
			foreach(Panel panel in panels)
			{
				foreach(Control control in panel.Controls)
				{
					if (control.Focused)
					{
						Point screenPoint = control.PointToScreen(new Point(0, control.Height));
						if (screenPoint.Y - panel.Top > systemInputPanel.VisibleDesktop.Bottom)
						{
							return true;
						}
					}
				}
			}

			return false;
		}

		private void selectAirplaneButton_Click(object sender, System.EventArgs e)
		{
			OpenAirplane(false);
		}

		private void copyAirplaneButton_Click(object sender, System.EventArgs e)
		{
			OpenAirplane(true);
		}

		private void deleteAirplaneButton_Click(object sender, System.EventArgs e)
		{
			string selectedTailNumber = (string)airplaneList.SelectedItem;

			if (selectedTailNumber == null)
			{
				return;
			}

			if (MessageBox.Show("Are you sure you want to delete " + selectedTailNumber + "?", 
				"Confirm Delete Airplane", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button2) != DialogResult.Yes)
			{
				return;
			}

			repository.Delete(selectedTailNumber);
			LoadAirplanes();
		}

		private void numericTextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			bool isNumber = e.KeyChar >= '0' && e.KeyChar <= '9';

			// Allow numbers, dash, period, and backspace.`
			if (!isNumber && e.KeyChar != '-' && e.KeyChar != '.' 
				&& e.KeyChar != (char)8)
			{
				e.Handled = true;
				return;
			}

			// On return close keypad
			if (e.KeyChar == (char)13)
			{
				systemInputPanel.Enabled = false;
				e.Handled = true;
			}
		}

		private void textBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			// On return close keypad
			if (e.KeyChar == (char)13)
			{
				systemInputPanel.Enabled = false;
				e.Handled = true;
			}
		}

		private void disabledTextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		private void fuelStationComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (currentAirplane == null)
				return;

			fuelStationView.Update();
			fuelStationView.SynchronizeFuelArms(currentAirplane);

			switch(fuelStationComboBox.SelectedIndex)
			{
				case 0:
					fuelStationView = new StationView(currentAirplane.TakeoffFuel, 
						fuelStationComboBox, fuelWeightText, fuelArmText);
					break;
				case 1:
					fuelStationView = new StationView(currentAirplane.LandingFuel, 
						fuelStationComboBox, fuelWeightText, fuelArmText);
					break;
			}

			fuelStationView.Display();
			fuelPanel.Invalidate();
		}

		private void OpenAirplane(bool copy)
		{
			string selectedTailNumber = (string)airplaneList.SelectedItem;

			if (selectedTailNumber == null)
			{
				return;
			}

			try
			{
				currentAirplane = repository.Get(selectedTailNumber);
			}
			catch(XmlException ex)
			{
				MessageBox.Show("The data file for this airplane is corrupt.\n" + ex.Message, 
					"Cannot load airplane data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
					MessageBoxDefaultButton.Button1);
				return;
			}

			if (copy)
				currentAirplane.TailNumber = string.Empty;

			LoadCurrentAirplane();
			GotoPanel(inputPanel);
		}

		private void DisplayCalculations()
		{
			LimitGraph.DrawTakeoffImage(takeoffPointPicture);
			LimitGraph.DrawLandingImage(landingPointPicture);
			LimitGraph.DrawZeroFuelImage(zeroFuelPointPicture);

			cgEnvelopeCalculationGraph.Airplane = currentAirplane;
			SetCalculationLabelColor(takeoffCGArmLabel, currentAirplane.TakeoffCGInLimits);
			SetCalculationLabelColor(landingCGArmLabel, currentAirplane.LandingCGInLimits);
			SetCalculationLabelColor(zeroFuelCGArmLabel, currentAirplane.ZeroFuelCGInLimits);
			SetCalculationLabelColor(takeoffWeightLabel, currentAirplane.TakeoffWeightInLimits);
			SetCalculationLabelColor(landingWeightLabel, currentAirplane.LandingWeightInLimits);
			SetCalculationLabelColor(zeroFuelWeightLabel, currentAirplane.ZeroFuelWeightInLimits);

			takeoffWeightLabel.Text = currentAirplane.TakeoffWeight.ToString();
			takeoffCGArmLabel.Text = currentAirplane.TakeoffCGArm.ToString("0.000");
			landingWeightLabel.Text = currentAirplane.LandingWeight.ToString();
			landingCGArmLabel.Text = currentAirplane.LandingCGArm.ToString("0.000");
			zeroFuelWeightLabel.Text = currentAirplane.ZeroFuelWeight.ToString();
			zeroFuelCGArmLabel.Text = currentAirplane.ZeroFuelCGArm.ToString("0.000");
		}

		private void SetCalculationLabelColor(Label label, bool inLimits)
		{
			if (currentAirplane.ValidLimits.Length == 0)
			{
				label.BackColor = label.Parent.BackColor;
				label.ForeColor = label.Parent.ForeColor;
				return;
			}

			if (inLimits)
			{
				label.BackColor = label.Parent.BackColor;
				label.ForeColor = Color.Green;
			}
			else
			{
				label.BackColor = Color.Red;
				label.ForeColor = Color.White;
			}
		}

		private void limitControl_LostFocus(object sender, System.EventArgs e)
		{
			foreach(StationView view in limitStationViews)
			{
				view.Update();
			}

			cgEnvelopeDefinitionGraph.Refresh();
			SetMaxWeight();
		}

		private void SetMaxWeight()
		{
			decimal maxWeight = maxWeightText.Text.Trim() == string.Empty ? 0M : decimal.Parse(maxWeightText.Text);
			foreach(Station limit in currentAirplane.Limits)
			{
				maxWeight = Math.Max(maxWeight, limit.Weight);
			}
			maxWeightText.Text = maxWeight.ToString();
		}

		private void numericTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			TextBox textBox = (TextBox)sender;

			if (textBox.Text.Length == 0)
				return;
			
			try
			{
				decimal number = decimal.Parse(textBox.Text);
				textBox.Text = number.ToString();
			}
			catch(FormatException)
			{
				MessageBox.Show("Please enter a numeric value", "Invalid Input", MessageBoxButtons.OK, 
					MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
				e.Cancel = true;
				textBox.Focus();
			}
		}

		private void fuelButton_Click(object sender, System.EventArgs e)
		{
			fuelPanelShadow.BringToFront();
			fuelPanel.BringToFront();
			SaveCurrentAirplane();
			fuelCalculator.TakeoffFuelWeight = currentAirplane.TakeoffFuel.Weight;
			fuelCalculator.LandingFuelWeight = currentAirplane.LandingFuel.Weight;
			fuelCalculator.CalculateFuelQuantitiesFromWeight();
			fuelCalculatorTakeoffFuelQuantityText.Text = fuelCalculator.TakeoffFuelQuantity.ToString();
			fuelCalculatorFuelConsumedQuantityText.Text = fuelCalculator.EnrouteFuelQuantity.ToString();
			fuelPanel.Show();
			fuelPanelShadow.Show();
			fuelPanel.Invalidate();
		}

		private void fuelPanel_Paint(object sender, PaintEventArgs e)
		{
			Rectangle c = e.ClipRectangle;
			Rectangle rect = new Rectangle(c.X, c.Y, c.Width - 1, c.Height - 1);
			e.Graphics.DrawRectangle(new Pen(Color.Black), rect);
		}

		private void fuelCancelButton_Click(object sender, System.EventArgs e)
		{
			fuelPanel.Hide();
			fuelPanelShadow.Hide();
			systemInputPanel.Enabled = false;			
		}

		private void fuelOkButton_Click(object sender, System.EventArgs e)
		{
			fuelCalculator.TakeoffFuelQuantity = decimal.Parse(fuelCalculatorTakeoffFuelQuantityText.Text);
			fuelCalculator.EnrouteFuelQuantity = decimal.Parse(fuelCalculatorFuelConsumedQuantityText.Text);
			fuelCalculator.CalculateFuelWeightFromQuantities();
			currentAirplane.TakeoffFuel.Weight = fuelCalculator.TakeoffFuelWeight;
			currentAirplane.LandingFuel.Weight = fuelCalculator.LandingFuelWeight;
			DisplayViews();
			fuelPanel.Hide();
			fuelPanelShadow.Hide();
			systemInputPanel.Enabled = false;			
		}
	}
}
