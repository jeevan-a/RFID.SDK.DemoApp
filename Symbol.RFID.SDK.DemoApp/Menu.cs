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
    //JA: Change class name to Menu to match filename
    public partial class frmMenu : Form
    {
        private Form mainForm; //JA: not used, lets remove. Used to pass to Settings screen but inside again not used
        private frmSettings frmSettings; // JA: Does it need to be public?
        private IRfidReader selectedReader;
        private int tabIndex; // JA: Not needed, pass the index as a parameter to the method. Refrain from using global variables as much as posibble. 


        public frmMenu(IRfidReader selectedReader, Form mainForm)
        {
            InitializeComponent();
            this.selectedReader = selectedReader;
            this.mainForm = mainForm;
        }

        //JA: Rename to Form Event HAndlers 
        #region Menu Form Events

        private void btnTabAntenna_Click(object sender, EventArgs e)
        {
            //JA: Use a enum to map tabIndex to readable names and use it. SettingsTabs.Antenna, SettingsTabs.Singulation etc. 
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
            // JA: What is the purpose? to clsoe the screens recursively on a rest to defautls? if so comment
            DeviceStatus.IsRestoreDefaultClicked = true;
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region MenuView Private Members


        // JA: Add a parameter and pass the index instead of using global variable
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
            // JA: Setting the settings form to null will do the same. Check. IF working remove all UnregisterEvents methods and set the form to null when required to unregister
            if (frmSettings != null)
                this.frmSettings.UnRegisterInventoryEvents();
        }

        #endregion

        
    }
}