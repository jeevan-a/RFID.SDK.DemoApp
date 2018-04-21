namespace Symbol.RFID.SDK.DemoApp
{
    partial class frmInventory
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
            this.btnStartInventoy = new System.Windows.Forms.Button();
            this.btnInvBack = new System.Windows.Forms.Button();
            this.listInventory = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.txtNotifyBatchMode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStartInventoy
            // 
            this.btnStartInventoy.Location = new System.Drawing.Point(3, 3);
            this.btnStartInventoy.Name = "btnStartInventoy";
            this.btnStartInventoy.Size = new System.Drawing.Size(234, 30);
            this.btnStartInventoy.TabIndex = 11;
            this.btnStartInventoy.Text = "Start";
            this.btnStartInventoy.Click += new System.EventHandler(this.btnToggleInventory_Click);
            // 
            // btnInvBack
            // 
            this.btnInvBack.Location = new System.Drawing.Point(3, 261);
            this.btnInvBack.Name = "btnInvBack";
            this.btnInvBack.Size = new System.Drawing.Size(97, 30);
            this.btnInvBack.TabIndex = 13;
            this.btnInvBack.Text = "Back";
            this.btnInvBack.Click += new System.EventHandler(this.btnInvBack_Click);
            // 
            // listInventory
            // 
            this.listInventory.BackColor = System.Drawing.SystemColors.ControlLight;
            this.listInventory.Columns.Add(this.columnHeader1);
            this.listInventory.Columns.Add(this.columnHeader2);
            this.listInventory.Location = new System.Drawing.Point(3, 39);
            this.listInventory.Name = "listInventory";
            this.listInventory.Size = new System.Drawing.Size(234, 216);
            this.listInventory.TabIndex = 14;
            this.listInventory.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ColumnHeader";
            this.columnHeader1.Width = 188;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ColumnHeader";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 45;
            // 
            // txtNotifyBatchMode
            // 
            this.txtNotifyBatchMode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNotifyBatchMode.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtNotifyBatchMode.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtNotifyBatchMode.Location = new System.Drawing.Point(10, 125);
            this.txtNotifyBatchMode.Multiline = true;
            this.txtNotifyBatchMode.Name = "txtNotifyBatchMode";
            this.txtNotifyBatchMode.Size = new System.Drawing.Size(220, 18);
            this.txtNotifyBatchMode.TabIndex = 15;
            this.txtNotifyBatchMode.Text = "Inventory is running in batch mode";
            this.txtNotifyBatchMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNotifyBatchMode.Visible = false;
            // 
            // frmInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.txtNotifyBatchMode);
            this.Controls.Add(this.listInventory);
            this.Controls.Add(this.btnInvBack);
            this.Controls.Add(this.btnStartInventoy);
            this.Name = "frmInventory";
            this.Text = "Inventory";
            this.Activated += new System.EventHandler(this.frmInventory_Activated);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartInventoy;
        private System.Windows.Forms.Button btnInvBack;
        private System.Windows.Forms.ListView listInventory;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox txtNotifyBatchMode;
    }
}