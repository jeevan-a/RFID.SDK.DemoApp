using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Symbol.RFID.SDK.Domain.Reader;
using Symbol.RFID.SDK.DemoApp.Extensions;
using Symbol.RFID.SDK.DemoApp.Utilities;
using System.Reflection;

namespace Symbol.RFID.SDK.DemoApp
{
    // JA: rename to Settings
    public partial class frmSettings : Form
    {

        private Form tabItemForm; //JA: Not used, remove
        private Form home; // JA: not used remove
        private const int MAX_OUTPUT_LINES = 100; //JA: is this needed? This is usefull when everything is going to a single text box, now it is not
        private int outputLinePos = 0; // JA: is this needed? This is usefull when everything is going to a single text box, now it is not
        private StringBuilder sbOutStatus = new StringBuilder(); //JA: not needed a global String Builder
        private StringBuilder sbOutCapabilities = new StringBuilder(); // JA: Not needed
        private IRfidReader selectedReader;


        public frmSettings(IRfidReader selectedReader, Form tabItemForm, Form home)
        {
            InitializeComponent();

            this.selectedReader = selectedReader;
            this.RegisterEvents();
            this.tabItemForm = tabItemForm;
            this.home = home;
        }

        // JA: Rename to Form Event Handlers
        #region Settings Form Events

        private void btnGetPower_Click(object sender, EventArgs e)
        {
            this.GetPower();
            // JA: I thought Get will not show a dialog
            this.ShowAlert("Get Successfully...");
        }

        private void btnSingulationApply_Click(object sender, EventArgs e)
        {
            this.ApplySingulation(); //JA: Retrive the values from text boxes and combo boxes here and pass them as parameters to the ApplySingulation method. much cleaner. THis goes for other methods too
            // JA: based on the return, show the message, this will show up anyway even if it fails. This goes for other methods too
            this.ShowAlert("Applied Successfully...");
        }

        private void cmbStartTrigger_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStartTrigger.SelectedIndex == (int)START_TRIGGER_TYPE.START_TRIGGER_TYPE_IMMEDIATE)
            {
                SetVisibilityStartPeriodicParams(false);
                SetVisibilityStartTriggerParams(false);
            }
            else if (cmbStartTrigger.SelectedIndex == (int)START_TRIGGER_TYPE.START_TRIGGER_TYPE_PERIODIC)
            {
                SetVisibilityStartPeriodicParams(true);
                SetVisibilityStartTriggerParams(false);
            }
            else if (cmbStartTrigger.SelectedIndex == (int)START_TRIGGER_TYPE.START_TRIGGER_TYPE_HANDHELD)
            {
                SetVisibilityStartPeriodicParams(false);
                SetVisibilityStartTriggerParams(true);
            }
        }

        private void cmbStopTrigger_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStopTrigger.SelectedIndex == (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_IMMEDIATE)
            {
                SetVisibilityStopTriggerDurationParams(false);
                SetVisibilityStopTriggerTagParams(false);
                SetVisibilityStopTriggerAttemptParams(false);
                SetVisibilityStopTriggeParams(false);
            }
            else if (cmbStopTrigger.SelectedIndex == (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_DURATION)
            {
                SetVisibilityStopTriggerDurationParams(true);
                SetVisibilityStopTriggerTagParams(false);
                SetVisibilityStopTriggerAttemptParams(false);
                SetVisibilityStopTriggeParams(false);
            }
            else if (cmbStopTrigger.SelectedIndex == (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_TAG_OBSERVATION_WITH_TIMEOUT)
            {
                SetVisibilityStopTriggerDurationParams(false);
                SetVisibilityStopTriggerTagParams(true);
                SetVisibilityStopTriggerAttemptParams(false);
                SetVisibilityStopTriggeParams(false);
            }
            else if (cmbStopTrigger.SelectedIndex == (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_N_ATTEMPTS_WITH_TIMEOUT)
            {
                SetVisibilityStopTriggerDurationParams(false);
                SetVisibilityStopTriggerTagParams(false);
                SetVisibilityStopTriggerAttemptParams(true);
                SetVisibilityStopTriggeParams(false);
            }
            else if (cmbStopTrigger.SelectedIndex == (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_HANDHELD_WITH_TIMEOUT)
            {
                SetVisibilityStopTriggerDurationParams(false);
                SetVisibilityStopTriggerTagParams(false);
                SetVisibilityStopTriggerAttemptParams(false);
                SetVisibilityStopTriggeParams(true);
            }
        }

        private void rdoStartTriggerReleased_Click(object sender, EventArgs e)
        {
            // JA: Why do we need to do this explicitly? shouldint this work without code behind. Please check. YOu might need to group them in a container
            rdoStartTriggerPressed.Checked = false;
        }

        private void rdoStartTriggerPressed_Click(object sender, EventArgs e)
        {
            // JA: Why do we need to do this explicitly? shouldint this work without code behind. Please check. YOu might need to group them in a container
            rdoStartTriggerReleased.Checked = false;
        }

        private void rdoStopTriggerReleased_Click(object sender, EventArgs e)
        {
            // JA: Why do we need to do this explicitly? shouldint this work without code behind. Please check. YOu might need to group them in a container
            rdoStopTriggerPressed.Checked = false;
        }

        private void rdoStopTriggerPressed_Click(object sender, EventArgs e)
        {
            // JA: Why do we need to do this explicitly? shouldint this work without code behind. Please check. YOu might need to group them in a container
            rdoStopTriggerReleased.Checked = false;
        }

        private void btnStartTriggerApply_Click(object sender, EventArgs e)
        {
            // JA: Lookup above comment for ApplySingluation
            this.ApplyStartTriggerInfo();
            this.ShowAlert("Applied Successfully...");
        }

        private void btnStopTriggerApply_Click(object sender, EventArgs e)
        {
            // JA: Lookup above comment for ApplySingluation
            this.ApplyStopTriggerInfo();
            this.ShowAlert("Applied Successfully...");
        }

        private void btnSetPower_Click(object sender, EventArgs e)
        {
            // JA: Move to a method similar to other 
            // JA: Lookup above comment for ApplySingluation
            try
            {
                if (this.selectedReader != null)
                {
                    RFIDLibraryUtility.SetPower(this.selectedReader, txtPower.Text);
                    this.DebugWrite("SetPower : TransmitPowerIndex = " + RFIDLibraryUtility.GetPower(this.selectedReader).TransmitPowerIndex.ToString());
                    this.ShowAlert("Saved Changes");
                }
            }
            catch (Exception e1)
            {
                this.DebugWrite(e1.ToString());
            }
        }

        private void btnGetBeeperVolume_Click(object sender, EventArgs e)
        {
            this.GetBeeperVolume();
        }

        private void btnSetBeeperVolume_Click(object sender, EventArgs e)
        {
            // JA: Move to a method similar to other 
            // JA: Lookup above comment for ApplySingluation
            try
            {
                if (this.selectedReader != null)
                {
                    switch (this.cboBeeperVolume.Text)
                    {
                        case "HIGH_BEEP":
                            {
                                RFIDLibraryUtility.SetBeeperVolume(this.selectedReader, BEEPER_VOLUME.HIGH_BEEP);
                                break;
                            }
                        case "MEDIUM_BEEP":
                            {
                                RFIDLibraryUtility.SetBeeperVolume(this.selectedReader, BEEPER_VOLUME.MEDIUM_BEEP);
                                break;
                            }
                        case "LOW_BEEP":
                            {
                                RFIDLibraryUtility.SetBeeperVolume(this.selectedReader, BEEPER_VOLUME.LOW_BEEP);
                                break;
                            }
                        case "QUIET_BEEP":
                            {
                                RFIDLibraryUtility.SetBeeperVolume(this.selectedReader, BEEPER_VOLUME.QUIET_BEEP);
                                break;
                            }
                    }
                    this.DebugWrite("SetBeeperVolume = " + this.cboBeeperVolume.Text);
                    this.ShowAlert("Saved Changes");
                }
            }
            catch (Exception e1)
            {
                this.DebugWrite(e1.ToString());
            }
        }

        private void btnGetRegion_Click(object sender, EventArgs e)
        {
            this.GetRegionInfo();
        }

        private void btnGetStatus_Click(object sender, EventArgs e)
        {
            this.GetStatus();
        }

        private void btnGetBatchMode_Click(object sender, EventArgs e)
        {
            this.GetBatchMode();
        }

        private void btnSetBatchMode_Click(object sender, EventArgs e)
        {
            
            // JA: Lookup above comment for ApplySingluation
            this.SetBatchMode();
            this.ShowAlert("Saved Changes");
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            // JA: Move to a method similar to other 
            // JA: Lookup above comment for ApplySingluation            
            this.StartProgress();
            try
            {
                if (this.selectedReader != null)
                {
                    RFIDLibraryUtility.SaveConfiguration(this.selectedReader);
                    this.DebugWrite("Save Configuration : Successful");
                    this.ShowAlert("Saved Successfully...");
                }
            }
            catch (Exception e1)
            {
                this.DebugWrite(e1.ToString());
            }
            this.EndProgress();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabSetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabSetting.SelectedIndex)
            {
                    // JA: use the same enum suggested in Menu.cs
                case 0:
                    this.GetPower();
                    break;
                case 1:
                    this.GetSingulation();
                    break;
                case 2:
                    // JA: This will override Trigger to some value user have not saved. Please check
                    this.SetStartTriggerInit();
                    this.GetStartTriggerInfo();
                    break;
                case 3:
                    // JA: This will override Trigger to some value user have not saved. Please check
                    this.SetStopTriggerInit();
                    this.GetStopTriggerInfo();
                    break;
                case 4:
                    this.GetCapabilities();
                    break;
                case 5:
                    this.GetRegionInfo();
                    break;
                case 6:
                    cboStatus.SelectedIndex = 0;
                    break;
                case 7:
                    this.FillBeeperVolumeItems();
                    this.GetBeeperVolume();
                    break;
                case 8:
                    this.FillBatchModeItems();
                    this.GetBatchMode();
                    break;
            }
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtStatusResult.Text = "";
            sbOutStatus.Length = 0;
        }

        #endregion

        #region Event handlers

        private void SelectedReader_TemperatureStatusNotification(object sender, TemperatureStatusNotificationReceivedEventArgs e)
        {
            if (e != null)
            {
                // JA: Why casting the samething to same class type? can use directly
                TemperatureStatusNotificationReceivedEventArgs temperatureNotification = (TemperatureStatusNotificationReceivedEventArgs)e;
                this.OutputStatusText("Event: Reader=>Temperature Alarm" + Environment.NewLine);
                this.OutputStatusText("STM32 Temperature = " + temperatureNotification.AmbTemp + Environment.NewLine);
                this.OutputStatusText("Radio PA Temperature = " + temperatureNotification.PATemp + Environment.NewLine);
                this.OutputStatusText("Cause = " + temperatureNotification.Cause + Environment.NewLine);
            }
        }

        private void SelectedReader_PowerStatusNotification(object sender, PowerStatusNotificationReceivedEventArgs e)
        {
            if (e != null)
            {
                // JA: Why casting the samething to same class type? can use directly
                PowerStatusNotificationReceivedEventArgs powerNotification = (PowerStatusNotificationReceivedEventArgs)e;
                this.OutputStatusText("Event: Reader=>Power" + Environment.NewLine);
                this.OutputStatusText("Current = " + powerNotification.Current + Environment.NewLine);
                this.OutputStatusText("Power = " + powerNotification.Power + Environment.NewLine);
                this.OutputStatusText("Voltage = " + powerNotification.Voltage + Environment.NewLine);
                this.OutputStatusText("Cause = " + powerNotification.Cause + Environment.NewLine);
            }
        }

        private void SelectedReader_BatteryStatusNotification(object sender, BatteryStatusNotificationReceivedEventArgs e)
        {
            if (e != null)
            {
                // JA: Why casting the samething to same class type? can use directly
                BatteryStatusNotificationReceivedEventArgs battertyNotification = (BatteryStatusNotificationReceivedEventArgs)e;
                this.OutputStatusText("Event: Reader=>Battery" + Environment.NewLine);
                this.OutputStatusText("Level = " + (uint)battertyNotification.Level + "%" + Environment.NewLine);
                this.OutputStatusText("Status = " + battertyNotification.Charging + Environment.NewLine);
                this.OutputStatusText("Cause = " + battertyNotification.Cause + Environment.NewLine);
            }
        }

        #endregion

        #region Private Members

        private void FillBatchModeItems()
        {
            if (cmb_BatchMode.Items.Count == 0)
            {
                cmb_BatchMode.Items.Add("AUTO");
                cmb_BatchMode.Items.Add("ENABLE");
                cmb_BatchMode.Items.Add("DISABLE");
            }
            cmb_BatchMode.SelectedIndex = 0;
        }

        private void FillBeeperVolumeItems()
        {
            if (cboBeeperVolume.Items.Count == 0)
            {
                cboBeeperVolume.Items.Add("HIGH_BEEP");
                cboBeeperVolume.Items.Add("MEDIUM_BEEP");
                cboBeeperVolume.Items.Add("LOW_BEEP");
                cboBeeperVolume.Items.Add("QUIET_BEEP");
            }
            cboBeeperVolume.SelectedIndex = 0;
        }

        private void SetStartTriggerInit()
        {

            cmbStartTrigger.SelectedIndex = 0;
            txtPeriod.Text = "10000";
            rdoStartTriggerPressed.Checked = true;


            SetVisibilityStartPeriodicParams(false);
            SetVisibilityStartTriggerParams(false);
        }

        private void SetStopTriggerInit()
        {
            cmbStopTrigger.SelectedIndex = 0;
            txtDuration.Text = "10000";
            txtTag.Text = "100";
            txtTagTimeout.Text = "10000";
            txtAttempts.Text = "10";
            txtTimeoutAttempts.Text = "10000";
            txtHhTimeout.Text = "10000";
            rdoStopTriggerReleased.Checked = true;

            SetVisibilityStopTriggerDurationParams(false);
            SetVisibilityStopTriggerTagParams(false);
            SetVisibilityStopTriggerAttemptParams(false);
            SetVisibilityStopTriggeParams(false); ;
        }

        // JA: Encapsulate all of these methods to do with visbility toggles in a region with comments so it is not confusing
        private void SetVisibilityStartPeriodicParams(bool isVisible)
        {
            lblPeriodicParams.Visible = isVisible;
            lblPeriod.Visible = isVisible;
            txtPeriod.Visible = isVisible;
        }

        private void SetVisibilityStartTriggerParams(bool isVisible)
        {
            lblHhTriggerParams.Visible = isVisible;
            rdoStartTriggerReleased.Visible = isVisible;
            rdoStartTriggerPressed.Visible = isVisible;
        }

        private void SetVisibilityStopTriggerDurationParams(bool isVisible)
        {
            lblDuration.Visible = isVisible;
            txtDuration.Visible = isVisible;
        }

        private void SetVisibilityStopTriggerTagParams(bool isVisible)
        {
            lblTagObservation.Visible = isVisible;
            txtTag.Visible = isVisible;
            lblTimeoutTag.Visible = isVisible;
            txtTagTimeout.Visible = isVisible;
        }

        private void SetVisibilityStopTriggerAttemptParams(bool isVisible)
        {
            lblNoAttempts.Visible = isVisible;
            txtAttempts.Visible = isVisible;
            lblTimeoutAttempts.Visible = isVisible;
            txtTimeoutAttempts.Visible = isVisible;
        }

        private void SetVisibilityStopTriggeParams(bool isVisible)
        {
            lblHhTimeout.Visible = isVisible;
            txtHhTimeout.Visible = isVisible;
            rdoStopTriggerReleased.Visible = isVisible;
            rdoStopTriggerPressed.Visible = isVisible;
        }
        //JA: Till here

        private SESSION GetSession(string text)
        {
            if (text.Equals("SESSION_S0"))
            {
                return SESSION.SESSION_S0;
            }
            if (text.Equals("SESSION_S1"))
            {
                return SESSION.SESSION_S1;
            }
            if (text.Equals("SESSION_S2"))
            {
                return SESSION.SESSION_S2;
            }
            if (text.Equals("SESSION_S3"))
            {
                return SESSION.SESSION_S3;
            }
            return SESSION.SESSION_S1;
        }

        private string[] GetNames(Type enumType)
        {
            FieldInfo[] fieldInfo = enumType.GetFields(BindingFlags.Static | BindingFlags.Public);
            return fieldInfo.Select(f => f.Name).ToArray();
        }

        /// <summary>
        /// Registers the events.
        /// </summary>
        // JA: Private method should start with simple letter
        private void RegisterEvents()
        {
            this.selectedReader.BatteryStatusNotification += SelectedReader_BatteryStatusNotification;
            this.selectedReader.PowerStatusNotification += SelectedReader_PowerStatusNotification;
            this.selectedReader.TemperatureStatusNotification += SelectedReader_TemperatureStatusNotification;
        }

        /// <summary>
        /// Gets the power.
        /// </summary>
        private void GetPower()
        {
            try
            {
                if (this.selectedReader != null)
                {
                    AntennaConfiguration antConfig = RFIDLibraryUtility.GetPower(this.selectedReader);
                    this.txtPower.Text = antConfig.TransmitPowerIndex.ToString();
                    this.DebugWrite("GetPower : TransmitPowerIndex = " + this.txtPower.Text);
                }
            }
            catch (Exception e1)
            {
                this.DebugWrite(e1.ToString());
            }
        }


        /// <summary>
        /// Applies the singulation.
        /// </summary>
        private void ApplySingulation()
        {
            try
            {
                var curAntennaID = 0;
                SingulationControl singulationControl = RFIDLibraryUtility.GetSingulation(this.selectedReader, curAntennaID);

                if (singulationControl != null)
                {
                    singulationControl.Session = this.GetSession(this.cboSession.SelectedItem.ToString());
                    ushort population = 30;

                    if (this.txtPopulation.Text.TryParseToUshort(out population))
                    {
                        singulationControl.TagPopulation = population;

                        RFIDLibraryUtility.SetSingulation(this.selectedReader, curAntennaID, singulationControl);

                        this.DebugWrite("SetSingulation :  Session  = [" + singulationControl.Session + "]" + Environment.NewLine + "TagPopulation : " + singulationControl.TagPopulation.ToString());
                    }
                    else
                    {
                        this.DebugWrite("Error saving settings, singulationControl  incorrect tag population : " + this.txtPopulation.Text);
                    }

                }
                else
                {
                    this.DebugWrite("Error saving settings, singulationControl  object not found.");
                }
            }
            catch (Exception e1)
            {
                this.DebugWrite("Error saving singulationControl settings. " + e1.Message);
            }

        }

        /// <summary>
        /// Gets the singulation.
        /// </summary>
        private void GetSingulation()
        {
            var curAntennaID = 0;
            var singulationControl = RFIDLibraryUtility.GetSingulation(this.selectedReader, curAntennaID);

            if (singulationControl != null)
            {
                // JA: Why clean combo list and add again? 
                var sessionItems = this.GetNames(typeof(SESSION));

                cboSession.Items.Clear();

                foreach (var item in sessionItems)
                {
                    cboSession.Items.Add(item);
                }
                // JA: General comment: sometimes this. is used, sometimes, not. lets stick to one way.
                this.cboSession.Text = singulationControl.Session.ToString();
                this.txtPopulation.Text = singulationControl.TagPopulation.ToString();
            }
        }

        /// <summary>
        /// Applies the start trigger info.
        /// </summary>
        private void ApplyStartTriggerInfo()
        {
            var triggerInfo = RFIDLibraryUtility.GetTriggerInformation(this.selectedReader);
            var startTriggerCmbIndex = cmbStartTrigger.SelectedIndex;
            var startPeriod = txtPeriod.Text;
            var isStartTriggerPressed = rdoStartTriggerReleased.Checked;
            var isStartTriggerReleased = rdoStartTriggerPressed.Checked;

            try
            {
                if (startTriggerCmbIndex == (int)START_TRIGGER_TYPE.START_TRIGGER_TYPE_IMMEDIATE)
                {
                    triggerInfo.StartTrigger.Type = START_TRIGGER_TYPE.START_TRIGGER_TYPE_IMMEDIATE;
                }
                else if (startTriggerCmbIndex == (int)START_TRIGGER_TYPE.START_TRIGGER_TYPE_PERIODIC)
                {
                    triggerInfo.StartTrigger.Type = START_TRIGGER_TYPE.START_TRIGGER_TYPE_PERIODIC;

                    if (!String.IsNullOrEmpty((startPeriod)))
                        triggerInfo.StartTrigger.Periodic.Period = uint.Parse(startPeriod);
                }
                else if (startTriggerCmbIndex == (int)START_TRIGGER_TYPE.START_TRIGGER_TYPE_HANDHELD)
                {
                    triggerInfo.StartTrigger.Type = START_TRIGGER_TYPE.START_TRIGGER_TYPE_HANDHELD;

                    if (isStartTriggerPressed)
                        triggerInfo.StartTrigger.Handheld.HandheldEvent = HANDHELD_TRIGGER_EVENT_TYPE.HANDHELD_TRIGGER_PRESSED;
                    else if (isStartTriggerReleased)
                        triggerInfo.StartTrigger.Handheld.HandheldEvent = HANDHELD_TRIGGER_EVENT_TYPE.HANDHELD_TRIGGER_RELEASED;
                }

                RFIDLibraryUtility.SetTriggerInformation(this.selectedReader, triggerInfo);
            }
            catch (Exception e1)
            {
                this.DebugWrite("Error saving TriggerParams. " + e1.ToString());
            }
        }

        /// <summary>
        /// Applies the stop trigger info.
        /// </summary>
        private void ApplyStopTriggerInfo()
        {
            var triggerInfo = RFIDLibraryUtility.GetTriggerInformation(this.selectedReader);
            var stopTriggerCmbIndex = cmbStopTrigger.SelectedIndex;
            var stopDurationValue = txtDuration.Text;
            var stopTagObservationValue = txtTag.Text;
            var stopTriggerTagObTimeValue = txtTagTimeout.Text;
            var stopNumAttemptValue = txtAttempts.Text;
            var stopTriggerNAttTimeOut = txtTimeoutAttempts.Text;
            var handHeldTriggerTimeout = txtHhTimeout.Text;

            var isStopTriggerPressed = rdoStopTriggerReleased.Checked;
            var isStopTriggerReleased = rdoStopTriggerPressed.Checked;

            try
            {
                if (stopTriggerCmbIndex == (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_IMMEDIATE)
                {
                    triggerInfo.StopTrigger.Type = STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_IMMEDIATE;
                }
                else if (stopTriggerCmbIndex == (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_DURATION)
                {
                    triggerInfo.StopTrigger.Type = STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_DURATION;
                    if (!String.IsNullOrEmpty(stopDurationValue))
                        triggerInfo.StopTrigger.Duration = uint.Parse(stopDurationValue);
                }
                else if (stopTriggerCmbIndex == (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_TAG_OBSERVATION_WITH_TIMEOUT)
                {
                    triggerInfo.StopTrigger.Type = STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_TAG_OBSERVATION_WITH_TIMEOUT;
                    if (!String.IsNullOrEmpty(stopTagObservationValue))
                        triggerInfo.StopTrigger.TagObservation.N = ushort.Parse(stopTagObservationValue);
                    if (!String.IsNullOrEmpty(stopTriggerTagObTimeValue))
                        triggerInfo.StopTrigger.TagObservation.Timeout = uint.Parse(stopTriggerTagObTimeValue);
                }
                else if (stopTriggerCmbIndex == (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_N_ATTEMPTS_WITH_TIMEOUT)
                {
                    triggerInfo.StopTrigger.Type = STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_N_ATTEMPTS_WITH_TIMEOUT;
                    if (!String.IsNullOrEmpty(stopNumAttemptValue))
                        triggerInfo.StopTrigger.NumAttempts.N = ushort.Parse(stopNumAttemptValue);
                    if (!String.IsNullOrEmpty(stopTriggerNAttTimeOut))
                        triggerInfo.StopTrigger.NumAttempts.Timeout = uint.Parse(stopTriggerNAttTimeOut);
                }
                else if (stopTriggerCmbIndex == (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_HANDHELD_WITH_TIMEOUT)
                {
                    triggerInfo.StopTrigger.Type = STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_HANDHELD_WITH_TIMEOUT;
                    if (!String.IsNullOrEmpty(handHeldTriggerTimeout))
                        triggerInfo.StopTrigger.Handheld.Timeout = uint.Parse(handHeldTriggerTimeout);

                    if (isStopTriggerPressed)
                        triggerInfo.StopTrigger.Handheld.HandheldEvent = HANDHELD_TRIGGER_EVENT_TYPE.HANDHELD_TRIGGER_PRESSED;
                    else if (isStopTriggerReleased)
                        triggerInfo.StopTrigger.Handheld.HandheldEvent = HANDHELD_TRIGGER_EVENT_TYPE.HANDHELD_TRIGGER_RELEASED;
                }

                RFIDLibraryUtility.SetTriggerInformation(this.selectedReader, triggerInfo);
            }
            catch (Exception e1)
            {
                this.DebugWrite("Error saving TriggerParams. " + e1.ToString());
            }
        }

        /// <summary>
        /// Gets the beeper volume.
        /// </summary>
        private void GetBeeperVolume()
        {
            try
            {
                if (this.selectedReader != null)
                {
                    BEEPER_VOLUME beeperVolume = RFIDLibraryUtility.GetBeeperVolume(this.selectedReader);
                    string strBeeperVolume = "";
                    switch (beeperVolume)
                    {
                        case BEEPER_VOLUME.HIGH_BEEP:
                            {
                                strBeeperVolume = "HIGH_BEEP";
                                break;
                            }
                        case BEEPER_VOLUME.MEDIUM_BEEP:
                            {
                                strBeeperVolume = "MEDIUM_BEEP";
                                break;
                            }
                        case BEEPER_VOLUME.LOW_BEEP:
                            {
                                strBeeperVolume = "LOW_BEEP";
                                break;
                            }
                        case BEEPER_VOLUME.QUIET_BEEP:
                            {
                                strBeeperVolume = "QUIET_BEEP";
                                break;
                            }
                    }
                    this.cboBeeperVolume.Text = strBeeperVolume;
                    this.DebugWrite("GetBeeperVolume = " + strBeeperVolume);
                }
            }
            catch (Exception e1)
            {
                this.DebugWrite(e1.ToString());
            }
        }

        /// <summary>
        /// Gets the region info.
        /// </summary>
        private void GetRegionInfo()
        {
            try
            {
                if (this.selectedReader != null)
                {
                    RegulatoryConfig regConfig = RFIDLibraryUtility.GetRegion(this.selectedReader);

                    if (regConfig != null)
                    {
                        this.txtRegion.Text = regConfig.Region;
                    }
                    else
                    {
                        // If regulatory is not set, set it...
                        this.DebugWrite("Region: Not Configured. Configuring as USA");
                        //set default region.
                        RFIDLibraryUtility.SetDefaultRegion(this.selectedReader);
                    }

                    //this.View.SetRegionInfo();
                    this.DebugWrite("Config.RegulatoryConfig.Region : " + this.txtRegion.Text);
                }
            }
            catch (TimeoutException timeOutExc)
            {
                this.DebugWrite(timeOutExc.ToString() + Environment.NewLine);
                throw timeOutExc;
            }
            catch (Exception exception)
            {
                if (exception.Message == this.selectedReader.Configurations.ERROR_REGION_NOT_CONFIGURED)
                {

                    // If regulatory is not set, set it...
                    this.DebugWrite("Region: Not Configured. Configuring as USA");
                    //set default region.
                    RFIDLibraryUtility.SetDefaultRegion(this.selectedReader);
                }
                this.DebugWrite(exception.ToString() + Environment.NewLine);
                throw exception;
            }
        }

        /// <summary>
        /// Gets the status.
        /// </summary>
        private void GetStatus()
        {
            bool batteryStatus = false;
            bool powerStatus = false;
            bool temperatureStatus = false;
            int selectedIndex = this.cboStatus.SelectedIndex;

            if (selectedIndex == 0)
            {
                batteryStatus = true;
            }
            else if (selectedIndex == 1)
            {
                powerStatus = true;
            }
            else if (selectedIndex == 2)
            {
                temperatureStatus = true;
            }
            try
            {
                if (this.selectedReader != null)
                {
                    RFIDLibraryUtility.GetDeviceStatus(this.selectedReader, batteryStatus, powerStatus, temperatureStatus);
                }
            }
            catch (Exception exception)
            {
                this.DebugWrite(exception.ToString() + Environment.NewLine);
            }
        }

        /// <summary>
        /// Gets the batch mode.
        /// </summary>
        private void GetBatchMode()
        {
            try
            {
                if (this.selectedReader != null)
                {
                    BATCH_MODE batchMode = RFIDLibraryUtility.GetBatchMode(this.selectedReader);
                    string strBatchMode = "";
                    switch (batchMode)
                    {
                        case BATCH_MODE.AUTO:
                            strBatchMode = "AUTO";
                            break;
                        case BATCH_MODE.DISABLE:
                            strBatchMode = "DISABLE";
                            break;
                        case BATCH_MODE.ENABLE:
                            strBatchMode = "ENABLE";
                            break;
                    }
                    this.cmb_BatchMode.Text = strBatchMode;

                    this.DebugWrite("GetBatchMode = " + strBatchMode);
                }
            }
            catch (Exception exception)
            {
                this.DebugWrite(exception.ToString() + Environment.NewLine);
            }
        }

        /// <summary>
        /// Sets the batch mode.
        /// </summary>
        private void SetBatchMode()
        {
            try
            {
                if (this.selectedReader != null)
                {
                    switch (this.cmb_BatchMode.Text)
                    {
                        case "ENABLE":
                            {
                                RFIDLibraryUtility.SetBatchMode(this.selectedReader, BATCH_MODE.ENABLE);
                                break;
                            }
                        case "DISABLE":
                            {
                                RFIDLibraryUtility.SetBatchMode(this.selectedReader, BATCH_MODE.DISABLE);
                                break;
                            }
                        case "AUTO":
                            {
                                RFIDLibraryUtility.SetBatchMode(this.selectedReader, BATCH_MODE.AUTO);
                                break;
                            }
                    }
                    this.DebugWrite("SetBatchMode = " + this.cmb_BatchMode.Text);
                }
            }
            catch (Exception e1)
            {
                this.DebugWrite(e1.ToString() + Environment.NewLine);
            }
        }

        /// <summary>
        /// Gets the start trigger info.
        /// </summary>
        private void GetStartTriggerInfo()
        {
            var triggerInfo = RFIDLibraryUtility.GetTriggerInformation(this.selectedReader);

            try
            {
                if (triggerInfo.StartTrigger.Type == START_TRIGGER_TYPE.START_TRIGGER_TYPE_IMMEDIATE)
                {
                    this.cmbStartTrigger.SelectedIndex = (int)START_TRIGGER_TYPE.START_TRIGGER_TYPE_IMMEDIATE;
                }
                else if (triggerInfo.StartTrigger.Type == START_TRIGGER_TYPE.START_TRIGGER_TYPE_PERIODIC)
                {
                    this.cmbStartTrigger.SelectedIndex = (int)START_TRIGGER_TYPE.START_TRIGGER_TYPE_PERIODIC;
                    this.txtPeriod.Text = triggerInfo.StartTrigger.Periodic.Period.ToString();

                }
                else if (triggerInfo.StartTrigger.Type == START_TRIGGER_TYPE.START_TRIGGER_TYPE_HANDHELD)
                {
                    this.cmbStartTrigger.SelectedIndex = (int)START_TRIGGER_TYPE.START_TRIGGER_TYPE_HANDHELD;

                    if (triggerInfo.StartTrigger.Handheld.HandheldEvent == HANDHELD_TRIGGER_EVENT_TYPE.HANDHELD_TRIGGER_PRESSED)
                    {
                        this.rdoStartTriggerPressed.Checked = true;
                        this.rdoStartTriggerReleased.Checked = false;
                    }
                    else if (triggerInfo.StartTrigger.Handheld.HandheldEvent == HANDHELD_TRIGGER_EVENT_TYPE.HANDHELD_TRIGGER_RELEASED)
                    {
                        this.rdoStartTriggerPressed.Checked = false;
                        this.rdoStartTriggerReleased.Checked = true;
                    }
                }
            }
            catch (Exception e1)
            {
                this.DebugWrite(e1.ToString() + Environment.NewLine);
            }
        }

        /// <summary>
        /// Gets the stop trigger info.
        /// </summary>
        private void GetStopTriggerInfo()
        {
            var triggerInfo = RFIDLibraryUtility.GetTriggerInformation(this.selectedReader);

            try
            {
                if (triggerInfo.StopTrigger.Type == STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_IMMEDIATE)
                {
                    this.cmbStopTrigger.SelectedIndex = (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_IMMEDIATE;
                }
                else if (triggerInfo.StopTrigger.Type == STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_DURATION)
                {
                    this.cmbStopTrigger.SelectedIndex = (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_DURATION;
                    this.txtDuration.Text = triggerInfo.StopTrigger.Duration.ToString();
                }
                else if (triggerInfo.StopTrigger.Type == STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_TAG_OBSERVATION_WITH_TIMEOUT)
                {
                    this.cmbStopTrigger.SelectedIndex = (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_TAG_OBSERVATION_WITH_TIMEOUT;
                    this.txtTag.Text = triggerInfo.StopTrigger.TagObservation.N.ToString();
                    this.txtTagTimeout.Text = triggerInfo.StopTrigger.TagObservation.Timeout.ToString();
                }
                else if (triggerInfo.StopTrigger.Type == STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_N_ATTEMPTS_WITH_TIMEOUT)
                {
                    this.cmbStopTrigger.SelectedIndex = (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_N_ATTEMPTS_WITH_TIMEOUT;
                    this.txtAttempts.Text = triggerInfo.StopTrigger.NumAttempts.N.ToString();
                    this.txtTimeoutAttempts.Text = triggerInfo.StopTrigger.NumAttempts.Timeout.ToString();
                }
                else if (triggerInfo.StopTrigger.Type == STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_HANDHELD_WITH_TIMEOUT)
                {
                    this.cmbStopTrigger.SelectedIndex = (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_HANDHELD_WITH_TIMEOUT;
                    this.txtHhTimeout.Text = triggerInfo.StopTrigger.Handheld.Timeout.ToString();

                    if (triggerInfo.StopTrigger.Handheld.HandheldEvent == HANDHELD_TRIGGER_EVENT_TYPE.HANDHELD_TRIGGER_PRESSED)
                    {
                        this.rdoStopTriggerPressed.Checked = true;
                        this.rdoStopTriggerReleased.Checked = false;
                    }
                    else if (triggerInfo.StopTrigger.Handheld.HandheldEvent == HANDHELD_TRIGGER_EVENT_TYPE.HANDHELD_TRIGGER_RELEASED)
                    {
                        this.rdoStopTriggerPressed.Checked = false;
                        this.rdoStopTriggerReleased.Checked = true;
                    }
                }
            }
            catch (Exception e1)
            {
                this.DebugWrite("Error loading TriggerParams. " + e1.ToString());
            }
        }

        /// <summary>
        /// Gets the capabilities.
        /// </summary>
        private void GetCapabilities()
        {
            try
            {
                if (this.selectedReader != null)
                {
                    var capabilities = RFIDLibraryUtility.GetCapabilities(this.selectedReader);
                    string message = "Model Name" + Environment.NewLine + capabilities.ModelName + Environment.NewLine + Environment.NewLine +
                                     "Serial Number" + Environment.NewLine + capabilities.SerialNumber + Environment.NewLine + Environment.NewLine +
                                     "Manufacture Name" + Environment.NewLine + capabilities.ManufactureName + Environment.NewLine + Environment.NewLine +
                                     "Manufacture Date" + Environment.NewLine + capabilities.ManufacturingDate + Environment.NewLine;

                    this.OutputTextCapabilities(message);
                }
            }
            catch (Exception e1)
            {
                this.DebugWrite(e1.ToString());
            }
        }

        // JA: This is confusing, lets discuss I think we can simplfy this
        private void OutputStatusText(string txt)
        {
            if (this.txtStatusResult.InvokeRequired)
            {
                this.Invoke(delegate
                {
                    this.AppendOutputText(txt, this.txtStatusResult, this.sbOutStatus);
                });
            }
            else { this.AppendOutputText(txt, this.txtStatusResult, this.sbOutStatus); }
        }

        // JA: This is confusing, lets discuss I think we can simplfy this
        private void AppendOutputText(string text, TextBox textBox, StringBuilder logger)
        {
            try
            {
                outputLinePos++;
                if (outputLinePos > MAX_OUTPUT_LINES)
                {
                    this.sbOutStatus.Length = 0;
                    this.outputLinePos = 0;
                }

                if (!String.IsNullOrEmpty(text))
                {
                    logger.AppendLine(text);
                    textBox.Text = logger.ToString();
                    textBox.SelectionStart = textBox.Text.Length;
                    textBox.ScrollToCaret();
                }
            }
            catch (Exception ex)
            {
                if (ex is InvalidOperationException)
                {
                    this.DebugWrite(ex.ToString());
                }
            }
        }

        private void OutputTextCapabilities(string txt)
        {
            if (txtCapabilities.InvokeRequired)
            {
                this.Invoke(delegate
                {
                    this.txtCapabilities.Text = txt;
                });
            }
            else
            {
                this.txtCapabilities.Text = txt;
            }
        }

        /// <summary>
        /// Logs the output message.
        /// </summary>
        /// <param name="message">The message.</param>
        private void DebugWrite(string message)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine(message);
#endif
        }

        // JA: Method name misleading change or use the Cursor.Wait directly where needed
        private void StartProgress()
        {
            Cursor.Current = Cursors.WaitCursor;
        }

        // JA: Method name misleading change or use the Cursor.Default directly where needed
        private void EndProgress()
        {
            Cursor.Current = Cursors.Default;
        }

        private void ShowAlert(string message)
        {
            MessageBox.Show(message);
        }


        #endregion

        #region Public Members

        /// <summary>
        /// This is accessed by Home screen for unregistering event when reader is disconneced.
        /// </summary>
        /// // JA: Setting the settings form to null will do the same. Check. IF working remove all UnregisterEvents methods and set the form to null when required to unregister
        public void UnRegisterInventoryEvents()
        {
            this.selectedReader.BatteryStatusNotification -= SelectedReader_BatteryStatusNotification;
            this.selectedReader.PowerStatusNotification -= SelectedReader_PowerStatusNotification;
            this.selectedReader.TemperatureStatusNotification -= SelectedReader_TemperatureStatusNotification;

        }

        public void SetIndex(int tabIndex)
        {
            this.tabSetting.SelectedIndex = tabIndex;
        }

        #endregion

    }
}