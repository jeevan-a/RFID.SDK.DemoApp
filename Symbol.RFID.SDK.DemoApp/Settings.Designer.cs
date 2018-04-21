namespace Symbol.RFID.SDK.DemoApp
{
    partial class frmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.tabSetting = new System.Windows.Forms.TabControl();
            this.tabAntenna = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSetPower = new System.Windows.Forms.Button();
            this.btnGetPower = new System.Windows.Forms.Button();
            this.txtPower = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabSingulation = new System.Windows.Forms.TabPage();
            this.btnSingulationApply = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblSL = new System.Windows.Forms.Label();
            this.cmbInventory = new System.Windows.Forms.ComboBox();
            this.lblInventory = new System.Windows.Forms.Label();
            this.txtPopulation = new System.Windows.Forms.TextBox();
            this.lblTag = new System.Windows.Forms.Label();
            this.cboSession = new System.Windows.Forms.ComboBox();
            this.lblSession = new System.Windows.Forms.Label();
            this.tabStartTrigger = new System.Windows.Forms.TabPage();
            this.btnStartTriggerApply = new System.Windows.Forms.Button();
            this.lblPeriodicParams = new System.Windows.Forms.Label();
            this.rdoStartTriggerPressed = new System.Windows.Forms.RadioButton();
            this.rdoStartTriggerReleased = new System.Windows.Forms.RadioButton();
            this.lblHhTriggerParams = new System.Windows.Forms.Label();
            this.txtPeriod = new System.Windows.Forms.TextBox();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.cmbStartTrigger = new System.Windows.Forms.ComboBox();
            this.lblStartTrigger = new System.Windows.Forms.Label();
            this.tabStopTrigger = new System.Windows.Forms.TabPage();
            this.btnStopTriggerApply = new System.Windows.Forms.Button();
            this.rdoStopTriggerPressed = new System.Windows.Forms.RadioButton();
            this.rdoStopTriggerReleased = new System.Windows.Forms.RadioButton();
            this.txtHhTimeout = new System.Windows.Forms.TextBox();
            this.lblHhTimeout = new System.Windows.Forms.Label();
            this.txtTimeoutAttempts = new System.Windows.Forms.TextBox();
            this.lblTimeoutAttempts = new System.Windows.Forms.Label();
            this.txtAttempts = new System.Windows.Forms.TextBox();
            this.lblNoAttempts = new System.Windows.Forms.Label();
            this.txtTagTimeout = new System.Windows.Forms.TextBox();
            this.lblTimeoutTag = new System.Windows.Forms.Label();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.lblTagObservation = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.cmbStopTrigger = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabCapabilities = new System.Windows.Forms.TabPage();
            this.txtCapabilities = new System.Windows.Forms.TextBox();
            this.tabRegulatory = new System.Windows.Forms.TabPage();
            this.txtRegion = new System.Windows.Forms.TextBox();
            this.lblRegion = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGetRegion = new System.Windows.Forms.Button();
            this.tabStatus = new System.Windows.Forms.TabPage();
            this.txtStatusResult = new System.Windows.Forms.TextBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnGetStatus = new System.Windows.Forms.Button();
            this.tabBeeper = new System.Windows.Forms.TabPage();
            this.cboBeeperVolume = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSetBeeperVolume = new System.Windows.Forms.Button();
            this.btnGetBeeperVolume = new System.Windows.Forms.Button();
            this.tabBatch = new System.Windows.Forms.TabPage();
            this.cmb_BatchMode = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSetBatchMode = new System.Windows.Forms.Button();
            this.btnGetBatchMode = new System.Windows.Forms.Button();
            this.tabSave = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tabSetting.SuspendLayout();
            this.tabAntenna.SuspendLayout();
            this.tabSingulation.SuspendLayout();
            this.tabStartTrigger.SuspendLayout();
            this.tabStopTrigger.SuspendLayout();
            this.tabCapabilities.SuspendLayout();
            this.tabRegulatory.SuspendLayout();
            this.tabStatus.SuspendLayout();
            this.tabBeeper.SuspendLayout();
            this.tabBatch.SuspendLayout();
            this.tabSave.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSetting
            // 
            this.tabSetting.Controls.Add(this.tabAntenna);
            this.tabSetting.Controls.Add(this.tabSingulation);
            this.tabSetting.Controls.Add(this.tabStartTrigger);
            this.tabSetting.Controls.Add(this.tabStopTrigger);
            this.tabSetting.Controls.Add(this.tabCapabilities);
            this.tabSetting.Controls.Add(this.tabRegulatory);
            this.tabSetting.Controls.Add(this.tabStatus);
            this.tabSetting.Controls.Add(this.tabBeeper);
            this.tabSetting.Controls.Add(this.tabBatch);
            this.tabSetting.Controls.Add(this.tabSave);
            this.tabSetting.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.tabSetting.Location = new System.Drawing.Point(0, 0);
            this.tabSetting.Name = "tabSetting";
            this.tabSetting.SelectedIndex = 0;
            this.tabSetting.Size = new System.Drawing.Size(240, 262);
            this.tabSetting.TabIndex = 0;
            this.tabSetting.SelectedIndexChanged += new System.EventHandler(this.tabSetting_SelectedIndexChanged);
            // 
            // tabAntenna
            // 
            this.tabAntenna.Controls.Add(this.label2);
            this.tabAntenna.Controls.Add(this.btnSetPower);
            this.tabAntenna.Controls.Add(this.btnGetPower);
            this.tabAntenna.Controls.Add(this.txtPower);
            this.tabAntenna.Controls.Add(this.label1);
            this.tabAntenna.Location = new System.Drawing.Point(0, 0);
            this.tabAntenna.Name = "tabAntenna";
            this.tabAntenna.Size = new System.Drawing.Size(240, 231);
            this.tabAntenna.Text = "Antenna";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(20, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 22);
            this.label2.Text = "Antenna Config";
            // 
            // btnSetPower
            // 
            this.btnSetPower.Location = new System.Drawing.Point(147, 85);
            this.btnSetPower.Name = "btnSetPower";
            this.btnSetPower.Size = new System.Drawing.Size(75, 29);
            this.btnSetPower.TabIndex = 8;
            this.btnSetPower.Text = "Set";
            this.btnSetPower.Click += new System.EventHandler(this.btnSetPower_Click);
            // 
            // btnGetPower
            // 
            this.btnGetPower.Location = new System.Drawing.Point(20, 85);
            this.btnGetPower.Name = "btnGetPower";
            this.btnGetPower.Size = new System.Drawing.Size(75, 29);
            this.btnGetPower.TabIndex = 7;
            this.btnGetPower.Text = "Get";
            this.btnGetPower.Click += new System.EventHandler(this.btnGetPower_Click);
            // 
            // txtPower
            // 
            this.txtPower.Location = new System.Drawing.Point(122, 54);
            this.txtPower.Name = "txtPower";
            this.txtPower.Size = new System.Drawing.Size(100, 25);
            this.txtPower.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 25);
            this.label1.Text = "Power Index";
            // 
            // tabSingulation
            // 
            this.tabSingulation.Controls.Add(this.btnSingulationApply);
            this.tabSingulation.Controls.Add(this.comboBox1);
            this.tabSingulation.Controls.Add(this.lblSL);
            this.tabSingulation.Controls.Add(this.cmbInventory);
            this.tabSingulation.Controls.Add(this.lblInventory);
            this.tabSingulation.Controls.Add(this.txtPopulation);
            this.tabSingulation.Controls.Add(this.lblTag);
            this.tabSingulation.Controls.Add(this.cboSession);
            this.tabSingulation.Controls.Add(this.lblSession);
            this.tabSingulation.Location = new System.Drawing.Point(0, 0);
            this.tabSingulation.Name = "tabSingulation";
            this.tabSingulation.Size = new System.Drawing.Size(240, 231);
            this.tabSingulation.Text = "Singulation";
            // 
            // btnSingulationApply
            // 
            this.btnSingulationApply.Location = new System.Drawing.Point(123, 165);
            this.btnSingulationApply.Name = "btnSingulationApply";
            this.btnSingulationApply.Size = new System.Drawing.Size(110, 27);
            this.btnSingulationApply.TabIndex = 14;
            this.btnSingulationApply.Text = "Apply";
            this.btnSingulationApply.Click += new System.EventHandler(this.btnSingulationApply_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.Location = new System.Drawing.Point(123, 125);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(110, 26);
            this.comboBox1.TabIndex = 9;
            // 
            // lblSL
            // 
            this.lblSL.Enabled = false;
            this.lblSL.Location = new System.Drawing.Point(3, 125);
            this.lblSL.Name = "lblSL";
            this.lblSL.Size = new System.Drawing.Size(100, 20);
            this.lblSL.Text = "SL Flag";
            // 
            // cmbInventory
            // 
            this.cmbInventory.Enabled = false;
            this.cmbInventory.Location = new System.Drawing.Point(123, 87);
            this.cmbInventory.Name = "cmbInventory";
            this.cmbInventory.Size = new System.Drawing.Size(110, 26);
            this.cmbInventory.TabIndex = 7;
            // 
            // lblInventory
            // 
            this.lblInventory.Enabled = false;
            this.lblInventory.Location = new System.Drawing.Point(3, 93);
            this.lblInventory.Name = "lblInventory";
            this.lblInventory.Size = new System.Drawing.Size(111, 20);
            this.lblInventory.Text = "Inventory State";
            // 
            // txtPopulation
            // 
            this.txtPopulation.Location = new System.Drawing.Point(123, 53);
            this.txtPopulation.Name = "txtPopulation";
            this.txtPopulation.Size = new System.Drawing.Size(110, 25);
            this.txtPopulation.TabIndex = 4;
            this.txtPopulation.Text = "100";
            // 
            // lblTag
            // 
            this.lblTag.Location = new System.Drawing.Point(3, 58);
            this.lblTag.Name = "lblTag";
            this.lblTag.Size = new System.Drawing.Size(108, 20);
            this.lblTag.Text = "Tag Population";
            // 
            // cboSession
            // 
            this.cboSession.Location = new System.Drawing.Point(123, 17);
            this.cboSession.Name = "cboSession";
            this.cboSession.Size = new System.Drawing.Size(110, 26);
            this.cboSession.TabIndex = 1;
            // 
            // lblSession
            // 
            this.lblSession.Location = new System.Drawing.Point(3, 17);
            this.lblSession.Name = "lblSession";
            this.lblSession.Size = new System.Drawing.Size(87, 26);
            this.lblSession.Text = "Session";
            // 
            // tabStartTrigger
            // 
            this.tabStartTrigger.Controls.Add(this.btnStartTriggerApply);
            this.tabStartTrigger.Controls.Add(this.lblPeriodicParams);
            this.tabStartTrigger.Controls.Add(this.rdoStartTriggerPressed);
            this.tabStartTrigger.Controls.Add(this.rdoStartTriggerReleased);
            this.tabStartTrigger.Controls.Add(this.lblHhTriggerParams);
            this.tabStartTrigger.Controls.Add(this.txtPeriod);
            this.tabStartTrigger.Controls.Add(this.lblPeriod);
            this.tabStartTrigger.Controls.Add(this.cmbStartTrigger);
            this.tabStartTrigger.Controls.Add(this.lblStartTrigger);
            this.tabStartTrigger.Location = new System.Drawing.Point(0, 0);
            this.tabStartTrigger.Name = "tabStartTrigger";
            this.tabStartTrigger.Size = new System.Drawing.Size(240, 231);
            this.tabStartTrigger.Text = "Start Trigger";
            // 
            // btnStartTriggerApply
            // 
            this.btnStartTriggerApply.Location = new System.Drawing.Point(161, 202);
            this.btnStartTriggerApply.Name = "btnStartTriggerApply";
            this.btnStartTriggerApply.Size = new System.Drawing.Size(72, 24);
            this.btnStartTriggerApply.TabIndex = 38;
            this.btnStartTriggerApply.Text = "Apply";
            this.btnStartTriggerApply.Click += new System.EventHandler(this.btnStartTriggerApply_Click);
            // 
            // lblPeriodicParams
            // 
            this.lblPeriodicParams.Location = new System.Drawing.Point(8, 51);
            this.lblPeriodicParams.Name = "lblPeriodicParams";
            this.lblPeriodicParams.Size = new System.Drawing.Size(225, 20);
            this.lblPeriodicParams.Text = "Periodic Params";
            // 
            // rdoStartTriggerPressed
            // 
            this.rdoStartTriggerPressed.Location = new System.Drawing.Point(28, 167);
            this.rdoStartTriggerPressed.Name = "rdoStartTriggerPressed";
            this.rdoStartTriggerPressed.Size = new System.Drawing.Size(144, 20);
            this.rdoStartTriggerPressed.TabIndex = 11;
            this.rdoStartTriggerPressed.Text = "Trigger Pressed";
            this.rdoStartTriggerPressed.Click += new System.EventHandler(this.rdoStartTriggerPressed_Click);
            // 
            // rdoStartTriggerReleased
            // 
            this.rdoStartTriggerReleased.Location = new System.Drawing.Point(28, 141);
            this.rdoStartTriggerReleased.Name = "rdoStartTriggerReleased";
            this.rdoStartTriggerReleased.Size = new System.Drawing.Size(144, 20);
            this.rdoStartTriggerReleased.TabIndex = 10;
            this.rdoStartTriggerReleased.Text = "Trigger Released";
            this.rdoStartTriggerReleased.Click += new System.EventHandler(this.rdoStartTriggerReleased_Click);
            // 
            // lblHhTriggerParams
            // 
            this.lblHhTriggerParams.Location = new System.Drawing.Point(8, 118);
            this.lblHhTriggerParams.Name = "lblHhTriggerParams";
            this.lblHhTriggerParams.Size = new System.Drawing.Size(225, 20);
            this.lblHhTriggerParams.Text = "Handheld Trigger Params";
            // 
            // txtPeriod
            // 
            this.txtPeriod.Location = new System.Drawing.Point(113, 74);
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.Size = new System.Drawing.Size(100, 25);
            this.txtPeriod.TabIndex = 7;
            // 
            // lblPeriod
            // 
            this.lblPeriod.Location = new System.Drawing.Point(28, 77);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(100, 20);
            this.lblPeriod.Text = "Period (ms)";
            // 
            // cmbStartTrigger
            // 
            this.cmbStartTrigger.Items.Add("Immediate");
            this.cmbStartTrigger.Items.Add("Periodic");
            this.cmbStartTrigger.Items.Add("Handheld");
            this.cmbStartTrigger.Location = new System.Drawing.Point(113, 11);
            this.cmbStartTrigger.Name = "cmbStartTrigger";
            this.cmbStartTrigger.Size = new System.Drawing.Size(120, 26);
            this.cmbStartTrigger.TabIndex = 1;
            this.cmbStartTrigger.SelectedIndexChanged += new System.EventHandler(this.cmbStartTrigger_SelectedIndexChanged);
            // 
            // lblStartTrigger
            // 
            this.lblStartTrigger.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblStartTrigger.Location = new System.Drawing.Point(0, 12);
            this.lblStartTrigger.Name = "lblStartTrigger";
            this.lblStartTrigger.Size = new System.Drawing.Size(107, 20);
            this.lblStartTrigger.Text = "Start Trigger";
            // 
            // tabStopTrigger
            // 
            this.tabStopTrigger.Controls.Add(this.btnStopTriggerApply);
            this.tabStopTrigger.Controls.Add(this.rdoStopTriggerPressed);
            this.tabStopTrigger.Controls.Add(this.rdoStopTriggerReleased);
            this.tabStopTrigger.Controls.Add(this.txtHhTimeout);
            this.tabStopTrigger.Controls.Add(this.lblHhTimeout);
            this.tabStopTrigger.Controls.Add(this.txtTimeoutAttempts);
            this.tabStopTrigger.Controls.Add(this.lblTimeoutAttempts);
            this.tabStopTrigger.Controls.Add(this.txtAttempts);
            this.tabStopTrigger.Controls.Add(this.lblNoAttempts);
            this.tabStopTrigger.Controls.Add(this.txtTagTimeout);
            this.tabStopTrigger.Controls.Add(this.lblTimeoutTag);
            this.tabStopTrigger.Controls.Add(this.txtTag);
            this.tabStopTrigger.Controls.Add(this.lblTagObservation);
            this.tabStopTrigger.Controls.Add(this.txtDuration);
            this.tabStopTrigger.Controls.Add(this.lblDuration);
            this.tabStopTrigger.Controls.Add(this.cmbStopTrigger);
            this.tabStopTrigger.Controls.Add(this.label3);
            this.tabStopTrigger.Location = new System.Drawing.Point(0, 0);
            this.tabStopTrigger.Name = "tabStopTrigger";
            this.tabStopTrigger.Size = new System.Drawing.Size(240, 231);
            this.tabStopTrigger.Text = "Stop Trigger";
            // 
            // btnStopTriggerApply
            // 
            this.btnStopTriggerApply.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnStopTriggerApply.Location = new System.Drawing.Point(161, 207);
            this.btnStopTriggerApply.Name = "btnStopTriggerApply";
            this.btnStopTriggerApply.Size = new System.Drawing.Size(72, 24);
            this.btnStopTriggerApply.TabIndex = 37;
            this.btnStopTriggerApply.Text = "Apply";
            this.btnStopTriggerApply.Click += new System.EventHandler(this.btnStopTriggerApply_Click);
            // 
            // rdoStopTriggerPressed
            // 
            this.rdoStopTriggerPressed.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.rdoStopTriggerPressed.Location = new System.Drawing.Point(122, 187);
            this.rdoStopTriggerPressed.Name = "rdoStopTriggerPressed";
            this.rdoStopTriggerPressed.Size = new System.Drawing.Size(118, 20);
            this.rdoStopTriggerPressed.TabIndex = 29;
            this.rdoStopTriggerPressed.Text = "Trigger Pressed";
            this.rdoStopTriggerPressed.Click += new System.EventHandler(this.rdoStopTriggerPressed_Click);
            // 
            // rdoStopTriggerReleased
            // 
            this.rdoStopTriggerReleased.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.rdoStopTriggerReleased.Location = new System.Drawing.Point(3, 187);
            this.rdoStopTriggerReleased.Name = "rdoStopTriggerReleased";
            this.rdoStopTriggerReleased.Size = new System.Drawing.Size(128, 20);
            this.rdoStopTriggerReleased.TabIndex = 28;
            this.rdoStopTriggerReleased.Text = "Trigger Released";
            this.rdoStopTriggerReleased.Click += new System.EventHandler(this.rdoStopTriggerReleased_Click);
            // 
            // txtHhTimeout
            // 
            this.txtHhTimeout.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtHhTimeout.Location = new System.Drawing.Point(111, 158);
            this.txtHhTimeout.Name = "txtHhTimeout";
            this.txtHhTimeout.Size = new System.Drawing.Size(126, 23);
            this.txtHhTimeout.TabIndex = 26;
            // 
            // lblHhTimeout
            // 
            this.lblHhTimeout.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblHhTimeout.Location = new System.Drawing.Point(3, 159);
            this.lblHhTimeout.Name = "lblHhTimeout";
            this.lblHhTimeout.Size = new System.Drawing.Size(117, 20);
            this.lblHhTimeout.Text = "HH Timeout(ms)";
            // 
            // txtTimeoutAttempts
            // 
            this.txtTimeoutAttempts.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtTimeoutAttempts.Location = new System.Drawing.Point(111, 132);
            this.txtTimeoutAttempts.Name = "txtTimeoutAttempts";
            this.txtTimeoutAttempts.Size = new System.Drawing.Size(126, 23);
            this.txtTimeoutAttempts.TabIndex = 18;
            // 
            // lblTimeoutAttempts
            // 
            this.lblTimeoutAttempts.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblTimeoutAttempts.Location = new System.Drawing.Point(3, 135);
            this.lblTimeoutAttempts.Name = "lblTimeoutAttempts";
            this.lblTimeoutAttempts.Size = new System.Drawing.Size(85, 20);
            this.lblTimeoutAttempts.Text = "Timeout(ms)";
            // 
            // txtAttempts
            // 
            this.txtAttempts.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtAttempts.Location = new System.Drawing.Point(111, 105);
            this.txtAttempts.Name = "txtAttempts";
            this.txtAttempts.Size = new System.Drawing.Size(126, 23);
            this.txtAttempts.TabIndex = 17;
            // 
            // lblNoAttempts
            // 
            this.lblNoAttempts.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblNoAttempts.Location = new System.Drawing.Point(3, 106);
            this.lblNoAttempts.Name = "lblNoAttempts";
            this.lblNoAttempts.Size = new System.Drawing.Size(101, 20);
            this.lblNoAttempts.Text = "No. of Attempts";
            // 
            // txtTagTimeout
            // 
            this.txtTagTimeout.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtTagTimeout.Location = new System.Drawing.Point(111, 80);
            this.txtTagTimeout.Name = "txtTagTimeout";
            this.txtTagTimeout.Size = new System.Drawing.Size(126, 23);
            this.txtTagTimeout.TabIndex = 13;
            // 
            // lblTimeoutTag
            // 
            this.lblTimeoutTag.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblTimeoutTag.Location = new System.Drawing.Point(3, 82);
            this.lblTimeoutTag.Name = "lblTimeoutTag";
            this.lblTimeoutTag.Size = new System.Drawing.Size(84, 20);
            this.lblTimeoutTag.Text = "Timeout(ms)";
            // 
            // txtTag
            // 
            this.txtTag.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtTag.Location = new System.Drawing.Point(111, 53);
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(126, 23);
            this.txtTag.TabIndex = 10;
            // 
            // lblTagObservation
            // 
            this.lblTagObservation.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblTagObservation.Location = new System.Drawing.Point(3, 54);
            this.lblTagObservation.Name = "lblTagObservation";
            this.lblTagObservation.Size = new System.Drawing.Size(117, 20);
            this.lblTagObservation.Text = "Tag Observation";
            // 
            // txtDuration
            // 
            this.txtDuration.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtDuration.Location = new System.Drawing.Point(111, 27);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(126, 23);
            this.txtDuration.TabIndex = 8;
            // 
            // lblDuration
            // 
            this.lblDuration.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblDuration.Location = new System.Drawing.Point(3, 27);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(85, 20);
            this.lblDuration.Text = "Duration(ms)";
            // 
            // cmbStopTrigger
            // 
            this.cmbStopTrigger.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.cmbStopTrigger.Items.Add("Immediate");
            this.cmbStopTrigger.Items.Add("Duration");
            this.cmbStopTrigger.Items.Add("Tag Observation");
            this.cmbStopTrigger.Items.Add("N Attempts");
            this.cmbStopTrigger.Items.Add("Handheld");
            this.cmbStopTrigger.Location = new System.Drawing.Point(111, 2);
            this.cmbStopTrigger.Name = "cmbStopTrigger";
            this.cmbStopTrigger.Size = new System.Drawing.Size(126, 24);
            this.cmbStopTrigger.TabIndex = 5;
            this.cmbStopTrigger.SelectedIndexChanged += new System.EventHandler(this.cmbStopTrigger_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(3, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 26);
            this.label3.Text = "Stop Trigger";
            // 
            // tabCapabilities
            // 
            this.tabCapabilities.Controls.Add(this.txtCapabilities);
            this.tabCapabilities.Location = new System.Drawing.Point(0, 0);
            this.tabCapabilities.Name = "tabCapabilities";
            this.tabCapabilities.Size = new System.Drawing.Size(240, 231);
            this.tabCapabilities.Text = "Capabilities";
            // 
            // txtCapabilities
            // 
            this.txtCapabilities.Location = new System.Drawing.Point(7, 8);
            this.txtCapabilities.Multiline = true;
            this.txtCapabilities.Name = "txtCapabilities";
            this.txtCapabilities.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCapabilities.Size = new System.Drawing.Size(226, 195);
            this.txtCapabilities.TabIndex = 0;
            // 
            // tabRegulatory
            // 
            this.tabRegulatory.Controls.Add(this.txtRegion);
            this.tabRegulatory.Controls.Add(this.lblRegion);
            this.tabRegulatory.Controls.Add(this.label4);
            this.tabRegulatory.Controls.Add(this.btnGetRegion);
            this.tabRegulatory.Location = new System.Drawing.Point(0, 0);
            this.tabRegulatory.Name = "tabRegulatory";
            this.tabRegulatory.Size = new System.Drawing.Size(240, 231);
            this.tabRegulatory.Text = "Regulatory";
            // 
            // txtRegion
            // 
            this.txtRegion.Location = new System.Drawing.Point(77, 54);
            this.txtRegion.Multiline = true;
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.Size = new System.Drawing.Size(144, 26);
            this.txtRegion.TabIndex = 22;
            // 
            // lblRegion
            // 
            this.lblRegion.Location = new System.Drawing.Point(19, 54);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(55, 25);
            this.lblRegion.Text = "Region";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(19, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 22);
            this.label4.Text = "Regulatory Config";
            // 
            // btnGetRegion
            // 
            this.btnGetRegion.Location = new System.Drawing.Point(19, 86);
            this.btnGetRegion.Name = "btnGetRegion";
            this.btnGetRegion.Size = new System.Drawing.Size(75, 29);
            this.btnGetRegion.TabIndex = 21;
            this.btnGetRegion.Text = "Get";
            this.btnGetRegion.Click += new System.EventHandler(this.btnGetRegion_Click);
            // 
            // tabStatus
            // 
            this.tabStatus.Controls.Add(this.txtStatusResult);
            this.tabStatus.Controls.Add(this.cboStatus);
            this.tabStatus.Controls.Add(this.label9);
            this.tabStatus.Controls.Add(this.btnGetStatus);
            this.tabStatus.Location = new System.Drawing.Point(0, 0);
            this.tabStatus.Name = "tabStatus";
            this.tabStatus.Size = new System.Drawing.Size(240, 231);
            this.tabStatus.Text = "Status";
            // 
            // txtStatusResult
            // 
            this.txtStatusResult.Location = new System.Drawing.Point(27, 121);
            this.txtStatusResult.Multiline = true;
            this.txtStatusResult.Name = "txtStatusResult";
            this.txtStatusResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStatusResult.Size = new System.Drawing.Size(206, 107);
            this.txtStatusResult.TabIndex = 27;
            // 
            // cboStatus
            // 
            this.cboStatus.Items.Add("Battery");
            this.cboStatus.Items.Add("Power");
            this.cboStatus.Items.Add("Temperature");
            this.cboStatus.Location = new System.Drawing.Point(27, 54);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(144, 26);
            this.cboStatus.TabIndex = 25;
            this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.cboStatus_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(27, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 25);
            this.label9.Text = "Status";
            // 
            // btnGetStatus
            // 
            this.btnGetStatus.Location = new System.Drawing.Point(27, 86);
            this.btnGetStatus.Name = "btnGetStatus";
            this.btnGetStatus.Size = new System.Drawing.Size(75, 29);
            this.btnGetStatus.TabIndex = 24;
            this.btnGetStatus.Text = "Get";
            this.btnGetStatus.Click += new System.EventHandler(this.btnGetStatus_Click);
            // 
            // tabBeeper
            // 
            this.tabBeeper.Controls.Add(this.cboBeeperVolume);
            this.tabBeeper.Controls.Add(this.label11);
            this.tabBeeper.Controls.Add(this.btnSetBeeperVolume);
            this.tabBeeper.Controls.Add(this.btnGetBeeperVolume);
            this.tabBeeper.Location = new System.Drawing.Point(0, 0);
            this.tabBeeper.Name = "tabBeeper";
            this.tabBeeper.Size = new System.Drawing.Size(240, 231);
            this.tabBeeper.Text = "Beeper";
            // 
            // cboBeeperVolume
            // 
            this.cboBeeperVolume.Location = new System.Drawing.Point(27, 54);
            this.cboBeeperVolume.Name = "cboBeeperVolume";
            this.cboBeeperVolume.Size = new System.Drawing.Size(156, 26);
            this.cboBeeperVolume.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(27, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 20);
            this.label11.Text = "Beeper Volume";
            // 
            // btnSetBeeperVolume
            // 
            this.btnSetBeeperVolume.Location = new System.Drawing.Point(108, 86);
            this.btnSetBeeperVolume.Name = "btnSetBeeperVolume";
            this.btnSetBeeperVolume.Size = new System.Drawing.Size(75, 29);
            this.btnSetBeeperVolume.TabIndex = 14;
            this.btnSetBeeperVolume.Text = "Set";
            this.btnSetBeeperVolume.Click += new System.EventHandler(this.btnSetBeeperVolume_Click);
            // 
            // btnGetBeeperVolume
            // 
            this.btnGetBeeperVolume.Location = new System.Drawing.Point(27, 86);
            this.btnGetBeeperVolume.Name = "btnGetBeeperVolume";
            this.btnGetBeeperVolume.Size = new System.Drawing.Size(75, 29);
            this.btnGetBeeperVolume.TabIndex = 13;
            this.btnGetBeeperVolume.Text = "Get";
            this.btnGetBeeperVolume.Click += new System.EventHandler(this.btnGetBeeperVolume_Click);
            // 
            // tabBatch
            // 
            this.tabBatch.Controls.Add(this.cmb_BatchMode);
            this.tabBatch.Controls.Add(this.label10);
            this.tabBatch.Controls.Add(this.btnSetBatchMode);
            this.tabBatch.Controls.Add(this.btnGetBatchMode);
            this.tabBatch.Location = new System.Drawing.Point(0, 0);
            this.tabBatch.Name = "tabBatch";
            this.tabBatch.Size = new System.Drawing.Size(240, 231);
            this.tabBatch.Text = "Batch";
            // 
            // cmb_BatchMode
            // 
            this.cmb_BatchMode.Location = new System.Drawing.Point(26, 54);
            this.cmb_BatchMode.Name = "cmb_BatchMode";
            this.cmb_BatchMode.Size = new System.Drawing.Size(156, 26);
            this.cmb_BatchMode.TabIndex = 31;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(26, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 25);
            this.label10.Text = "Batch Mode";
            // 
            // btnSetBatchMode
            // 
            this.btnSetBatchMode.Location = new System.Drawing.Point(107, 86);
            this.btnSetBatchMode.Name = "btnSetBatchMode";
            this.btnSetBatchMode.Size = new System.Drawing.Size(75, 29);
            this.btnSetBatchMode.TabIndex = 30;
            this.btnSetBatchMode.Text = "Set";
            this.btnSetBatchMode.Click += new System.EventHandler(this.btnSetBatchMode_Click);
            // 
            // btnGetBatchMode
            // 
            this.btnGetBatchMode.Location = new System.Drawing.Point(26, 86);
            this.btnGetBatchMode.Name = "btnGetBatchMode";
            this.btnGetBatchMode.Size = new System.Drawing.Size(75, 29);
            this.btnGetBatchMode.TabIndex = 29;
            this.btnGetBatchMode.Text = "Get";
            this.btnGetBatchMode.Click += new System.EventHandler(this.btnGetBatchMode_Click);
            // 
            // tabSave
            // 
            this.tabSave.Controls.Add(this.btnSave);
            this.tabSave.Location = new System.Drawing.Point(0, 0);
            this.tabSave.Name = "tabSave";
            this.tabSave.Size = new System.Drawing.Size(232, 228);
            this.tabSave.Text = "Save";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(37, 86);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(174, 45);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save Configuration";
            this.btnSave.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(0, 268);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(87, 23);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.Text = "Timeout(ms)";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 20);
            this.label7.Text = "Tag Observation";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(133, 87);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 25);
            this.textBox3.TabIndex = 13;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(133, 60);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 25);
            this.textBox4.TabIndex = 10;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(133, 34);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 25);
            this.textBox5.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 20);
            this.label8.Text = "Duration(ms)";
            // 
            // comboBox2
            // 
            this.comboBox2.Location = new System.Drawing.Point(94, 4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(139, 26);
            this.comboBox2.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(3, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 26);
            this.label12.Text = "Stop Trigger";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.ControlBox = false;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.tabSetting);
            this.Name = "frmSettings";
            this.Text = "Settings";
            this.tabSetting.ResumeLayout(false);
            this.tabAntenna.ResumeLayout(false);
            this.tabSingulation.ResumeLayout(false);
            this.tabStartTrigger.ResumeLayout(false);
            this.tabStopTrigger.ResumeLayout(false);
            this.tabCapabilities.ResumeLayout(false);
            this.tabRegulatory.ResumeLayout(false);
            this.tabStatus.ResumeLayout(false);
            this.tabBeeper.ResumeLayout(false);
            this.tabBatch.ResumeLayout(false);
            this.tabSave.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSetting;
        private System.Windows.Forms.TabPage tabAntenna;
        private System.Windows.Forms.TabPage tabSingulation;
        private System.Windows.Forms.TabPage tabStartTrigger;
        private System.Windows.Forms.TabPage tabCapabilities;
        private System.Windows.Forms.TabPage tabRegulatory;
        private System.Windows.Forms.TabPage tabStatus;
        private System.Windows.Forms.TabPage tabBeeper;
        private System.Windows.Forms.TabPage tabBatch;
        private System.Windows.Forms.TabPage tabSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSetPower;
        private System.Windows.Forms.Button btnGetPower;
        private System.Windows.Forms.TextBox txtPower;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSession;
        private System.Windows.Forms.Label lblSession;
        private System.Windows.Forms.Label lblTag;
        private System.Windows.Forms.TextBox txtPopulation;
        private System.Windows.Forms.Label lblInventory;
        private System.Windows.Forms.ComboBox cmbInventory;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblSL;
        private System.Windows.Forms.Label lblStartTrigger;
        private System.Windows.Forms.ComboBox cmbStartTrigger;
        private System.Windows.Forms.TextBox txtRegion;
        private System.Windows.Forms.Label lblRegion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGetRegion;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnGetStatus;
        private System.Windows.Forms.ComboBox cmb_BatchMode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSetBatchMode;
        private System.Windows.Forms.Button btnGetBatchMode;
        private System.Windows.Forms.ComboBox cboBeeperVolume;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSetBeeperVolume;
        private System.Windows.Forms.Button btnGetBeeperVolume;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtCapabilities;
        private System.Windows.Forms.Button btnSingulationApply;
        private System.Windows.Forms.RadioButton rdoStartTriggerPressed;
        private System.Windows.Forms.RadioButton rdoStartTriggerReleased;
        private System.Windows.Forms.Label lblHhTriggerParams;
        private System.Windows.Forms.TextBox txtPeriod;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.TabPage tabStopTrigger;
        private System.Windows.Forms.ComboBox cmbStopTrigger;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.TextBox txtTimeoutAttempts;
        private System.Windows.Forms.Label lblTimeoutAttempts;
        private System.Windows.Forms.TextBox txtAttempts;
        private System.Windows.Forms.Label lblNoAttempts;
        private System.Windows.Forms.TextBox txtTagTimeout;
        private System.Windows.Forms.Label lblTimeoutTag;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.Label lblTagObservation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton rdoStopTriggerPressed;
        private System.Windows.Forms.RadioButton rdoStopTriggerReleased;
        private System.Windows.Forms.TextBox txtHhTimeout;
        private System.Windows.Forms.Label lblHhTimeout;
        private System.Windows.Forms.Label lblPeriodicParams;
        private System.Windows.Forms.Button btnStopTriggerApply;
        private System.Windows.Forms.Button btnStartTriggerApply;
        private System.Windows.Forms.TextBox txtStatusResult;
    }
}