namespace Symbol.RFID.SDK.DemoApp
{
    partial class frmAbout
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
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblHardwareVersion = new System.Windows.Forms.Label();
            this.lblBluetoothVerstion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelProductName
            // 
            this.labelProductName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelProductName.Location = new System.Drawing.Point(10, 10);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(220, 35);
            this.labelProductName.Text = "Title";
            this.labelProductName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelVersion
            // 
            this.labelVersion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelVersion.Location = new System.Drawing.Point(10, 89);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(220, 20);
            this.labelVersion.Text = "Application Version";
            // 
            // labelCopyright
            // 
            this.labelCopyright.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelCopyright.Location = new System.Drawing.Point(10, 210);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(220, 20);
            this.labelCopyright.Text = "Copyright";
            this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelCompanyName.Location = new System.Drawing.Point(10, 50);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size(220, 20);
            this.labelCompanyName.Text = "Company Name";
            this.labelCompanyName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(75, 247);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(90, 27);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblHardwareVersion
            // 
            this.lblHardwareVersion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblHardwareVersion.Location = new System.Drawing.Point(10, 139);
            this.lblHardwareVersion.Name = "lblHardwareVersion";
            this.lblHardwareVersion.Size = new System.Drawing.Size(220, 20);
            this.lblHardwareVersion.Text = "Hardware Version";
            // 
            // lblBluetoothVerstion
            // 
            this.lblBluetoothVerstion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblBluetoothVerstion.Location = new System.Drawing.Point(10, 170);
            this.lblBluetoothVerstion.Name = "lblBluetoothVerstion";
            this.lblBluetoothVerstion.Size = new System.Drawing.Size(220, 20);
            this.lblBluetoothVerstion.Text = "Bluetooth Version";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(10, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 2);
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(10, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 2);
            this.label2.Text = "label2";
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 295);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBluetoothVerstion);
            this.Controls.Add(this.lblHardwareVersion);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.labelCompanyName);
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelProductName);
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.Text = "About";
            this.Load += new System.EventHandler(this.frmAbout_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblHardwareVersion;
        private System.Windows.Forms.Label lblBluetoothVerstion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

    }
}