namespace Symbol.RFID.SDK.DemoApp
{
    partial class frmHome
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
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.comboBoxReaders = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSetting
            // 
            this.btnSetting.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnSetting.Location = new System.Drawing.Point(124, 41);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(106, 106);
            this.btnSetting.TabIndex = 24;
            this.btnSetting.TabStop = false;
            this.btnSetting.Text = "Settings";
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnInventory.Location = new System.Drawing.Point(124, 153);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(106, 106);
            this.btnInventory.TabIndex = 25;
            this.btnInventory.TabStop = false;
            this.btnInventory.Text = "Inventory";
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnAbout.Location = new System.Drawing.Point(10, 153);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(106, 106);
            this.btnAbout.TabIndex = 27;
            this.btnAbout.TabStop = false;
            this.btnAbout.Text = "About";
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // comboBoxReaders
            // 
            this.comboBoxReaders.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.comboBoxReaders.Location = new System.Drawing.Point(10, 10);
            this.comboBoxReaders.Name = "comboBoxReaders";
            this.comboBoxReaders.Size = new System.Drawing.Size(220, 24);
            this.comboBoxReaders.TabIndex = 23;
            this.comboBoxReaders.TabStop = false;
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnConnect.Location = new System.Drawing.Point(10, 41);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(106, 106);
            this.btnConnect.TabIndex = 21;
            this.btnConnect.TabStop = false;
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.btnToggleConnection_Click);
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.btnInventory);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.comboBoxReaders);
            this.Controls.Add(this.btnConnect);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "frmHome";
            this.Text = "RFID SDK DEMO APP";
            this.Load += new System.EventHandler(this.frmHome_Load);
            this.Activated += new System.EventHandler(this.frmHome_Activated);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmHome_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.ComboBox comboBoxReaders;
        private System.Windows.Forms.Button btnConnect;

    }
}

