using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Symbol.RFID.SDK.Domain.Reader;
using Symbol.RFID.SDK.DemoApp.Entities;

namespace Symbol.RFID.SDK.DemoApp
{
    public partial class frmMenu : Form
    {
        private Form mainForm;
        private frmSettings frmSettings;
        private IRfidReader selectedReader;
        private int tabIndex;


        public frmMenu(IRfidReader selectedReader, Form mainForm)
        {
            InitializeComponent();
            this.selectedReader = selectedReader;
            this.mainForm = mainForm;
        }

        #region Menu Form Events

        private void btnTabAntenna_Click(object sender, EventArgs e)
        {
            this.tabIndex = 0;
            this.LoadAllSettingScreen();
        }

        private void btnTabSingulation_Click(object sender, EventArgs e)
        {
            this.tabIndex = 1;
            this.LoadAllSettingScreen();
        }

        private void btnTabStartTrigger_Click(object sender, EventArgs e)
        {
            this.tabIndex = 2;
            this.LoadAllSettingScreen();
        }

        private void btnTabStopTrigger_Click(object sender, EventArgs e)
        {
            this.tabIndex = 3;
            this.LoadAllSettingScreen();
        }

        private void btnTabCapabilities_Click(object sender, EventArgs e)
        {
            this.tabIndex = 4;
            this.LoadAllSettingScreen();
        }

        private void btnTabRegulatory_Click(object sender, EventArgs e)
        {
            this.tabIndex = 5;
            this.LoadAllSettingScreen();
        }

        private void btnTabStatus_Click(object sender, EventArgs e)
        {
            this.tabIndex = 6;
            this.LoadAllSettingScreen();
        }

        private void btnTabBeeper_Click(object sender, EventArgs e)
        {
            this.tabIndex = 7;
            this.LoadAllSettingScreen();
        }

        private void btnTabBatchMode_Click(object sender, EventArgs e)
        {
            this.tabIndex = 8;
            this.LoadAllSettingScreen();
        }

        private void btnTabSave_Click(object sender, EventArgs e)
        {
            this.tabIndex = 9;
            this.LoadAllSettingScreen();
        }

        private void btnRestore(object sender, EventArgs e)
        {
            DeviceStatus.IsRestoreDefaultClicked = true;
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region MenuView Private Members

        private void LoadAllSettingScreen()
        {
            if (frmSettings == null)
            {
                this.frmSettings = new frmSettings(this.selectedReader, this, mainForm);
            }
            this.frmSettings.SetIndex(this.tabIndex);
            frmSettings.ShowDialog();
        }

        #endregion

        #region Public Memebers - calling from Home screen to unregister settings related events.

        public void UnRegisterSettingEvents()
        {
            if (frmSettings != null)
                this.frmSettings.UnRegisterInventoryEvents();
        }

        #endregion

        
    }
}