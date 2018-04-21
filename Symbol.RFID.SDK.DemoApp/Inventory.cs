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
using Symbol.RFID.SDK.DemoApp.Entities;
using Symbol.RFID.SDK.DemoApp.Utilities;
using System.Threading;

namespace Symbol.RFID.SDK.DemoApp
{
    public partial class frmInventory : Form
    {
        private Form mainForm;
        private Dictionary<string, TagInfo> tagList = new Dictionary<string, TagInfo>();
        delegate void ShowTagDelegate();
        private TagUtility tagUtility;
        private Thread readerThread;
        private bool isStopPressed;
        private bool isAlertShown;
        private TagData[] tagData;

        public bool inventoryInProgress;
        public IRfidReader selectedReader;
        

        public frmInventory(IRfidReader selectedReader, Form main)
        {
            InitializeComponent();

            // this.Model = new InventoryModel();
            //this.presenter = new InventoryPresenter();
            //this.Model.SelectedReader = selectedReader;
            this.selectedReader = selectedReader;
            mainForm = main;

            //this.InitInventory();
            tagUtility = new TagUtility();
            this.InitInventoryList();
            this.RegisterEvents();
        }

        #region Inventory Form Events

        private void btnToggleInventory_Click(object sender, EventArgs e)
        {
            // Inventrory stop
            if (this.inventoryInProgress)
            {
                this.StopInventory();
            }
            // Inventrory start
            else
            {
                this.StartInventory();
            }
        }

        private void btnInvBack_Click(object sender, EventArgs e)
        {
            this.Close();
            ((Home)this.mainForm).CheckBatchState(this.inventoryInProgress);
        }

        private void frmInventory_Activated(object sender, EventArgs e)
        {
            this.DebugWrite("In ShowDialogActivated");
            this.DebugWrite("IsBatchModeRunning " + DeviceStatus.IsBatchModeInventoryRunning.ToString());
            this.DebugWrite("InventoryInProgress " + this.inventoryInProgress.ToString());

            //TODO check is this condition is required or not.
            if (this.isAlertShown)
            {
                this.isAlertShown = false;
            }
            else
            {
                this.OnBatchModeRun();
            }

        }

        #endregion

        #region Event Handlers

        private void Inventory_TagDataReceived(object sender, TagDataReceivedEventArgs e)
        {
            ProcessTagDataReceivedEvent(e);
        }

        private void Inventory_InventoryStarted(object sender, EventArgs e)
        {
            this.DebugWrite("Event: Reader=>Inventory Started" + Environment.NewLine);
        }

        private void Inventory_InventoryStopped(object sender, EventArgs e)
        {
            this.DebugWrite("Event: Reader=>Inventory Stopped" + Environment.NewLine);

            //set default region and isTriggerReapeat.
            if (!DeviceStatus.Initialized)
            {
                try
                {
                    RFIDLibraryUtility.CheckRegion(this.selectedReader);
                    DeviceStatus.IsTriggerRepeat = RFIDLibraryUtility.IsTriggerRepeat(this.selectedReader);
                    DeviceStatus.BatchMode = RFIDLibraryUtility.GetBatchMode(this.selectedReader);
                    DeviceStatus.Initialized = true;
                }
                catch (Exception ex)
                {
                    this.DebugWrite("Event: Reading Region and Triggers after Invenrtory Stopped" + Environment.NewLine);
                    DeviceStatus.Initialized = false;
                }
            }
            if (DeviceStatus.IsTriggerRepeat && !this.isStopPressed)
            {
                this.inventoryInProgress = true;
                this.ToggleInventoryButtonText();//here text will be changed as "Stop"  
            }
            else
            {
                this.inventoryInProgress = false;
                this.ToggleInventoryButtonText();//here text will be changed as "Start" 
                this.isStopPressed = false;

                if (DeviceStatus.IsBatchModeInventoryRunning && !this.isStopPressed)
                {
                    this.ToggleBatchModeNotification(false);
                    RFIDLibraryUtility.GetBatchedTags(this.selectedReader);
                    this.DebugWrite("Get Batched Tags : Successful");
                    DeviceStatus.IsBatchModeInventoryRunning = false;
                }
            }

        }

        private void Inventory_InventorySessionSummary(object sender, ReadSessionSummaryEventArgs e)
        {
            this.DebugWrite("Event: Reader=>Inventory Summary" + Environment.NewLine);
            if (e != null)
            {
                ReadSessionSummaryEventArgs readSessionSummary = (ReadSessionSummaryEventArgs)e;

                //omit this until we have a way of managing auto closing pop up dialogs

                //StringBuilder log = new StringBuilder();
                //log.Append("Total Rounds =" + readSessionSummary.TotalRounds + Environment.NewLine);
                //log.Append("Total Tags =" + readSessionSummary.TotalTags + Environment.NewLine);
                //log.Append("Total Time (μs) =" + readSessionSummary.TotalTimeuS + Environment.NewLine);

                //this.ShowAlert(log.ToString());
            }
        }

        #endregion

        #region Inventory Private Members

        private void ToggleInventoryButtonText()
        {
            this.Invoke(new Action(delegate
            {
                if (this.inventoryInProgress)
                {
                    btnStartInventoy.Text = "Stop";
                }
                else
                {
                    btnStartInventoy.Text = "Start";
                }

            }));
        }

        /// <summary>
        /// Outputs the text.
        /// </summary>
        /// <param name="message">The message.</param>
        private void DebugWrite(string message)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine(message);
#endif
        }

        /// <summary>
        /// Shows the tag data.
        /// </summary>
        private void ShowTagData()
        {
            ShowTagDelegate showTagDelegate = delegate
            {
                foreach (TagData data in this.tagData)
                {
                    if (!tagList.ContainsKey(data.TagID))
                    {
                        var item = this.listInventory.Items.Add(new ListViewItem(new string[] { data.TagID.ToString(), data.TagSeenCount.ToString() }));
                        TagInfo tag = new TagInfo(data, item.Index, data.TagSeenCount);
                        tagList.Add(data.TagID, tag);
                    }
                    else
                    {
                        tagList[data.TagID].Tag = data;
                        tagList[data.TagID].TagSeenTotalCount += tagList[data.TagID].Tag.TagSeenCount;
                        this.listInventory.Items[tagList[data.TagID].RowIndex].SubItems[1].Text = tagList[data.TagID].TagSeenTotalCount.ToString();
                    }
                }
            };

            this.Invoke(showTagDelegate);
        }

        /// <summary>
        /// Show alert message.
        /// </summary>
        private void ShowAlert(string message)
        {
            this.isAlertShown = true;
            MessageBox.Show(message);
        }

        /// <summary>
        /// Clean the tag data.
        /// </summary>
        private void ResetTagInfo()
        {
            this.tagData = null;
            this.tagList.Clear();

            if (this.listInventory != null && this.listInventory.Items.Count > 0)
            {
                this.listInventory.Items.Clear();
                this.listInventory.Refresh();
            }
        }

        private void ToggleBatchModeNotification(bool isVisible)
        {
            this.BeginInvoke(new Action(delegate
            {
                txtNotifyBatchMode.Visible = isVisible;
            }));
        }

        private void InitInventoryList()
        {
            this.listInventory.View = View.Details;
            this.listInventory.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
        }

        /// <summary>
        /// Registers the inventory related events.
        /// </summary>
        private void RegisterEvents()
        {
            try
            {
                if (this.selectedReader != null)
                {
                    // To make sure to register only once
                    this.selectedReader.Inventory.InventoryStarted -= Inventory_InventoryStarted;
                    this.selectedReader.Inventory.InventoryStopped -= Inventory_InventoryStopped;
                    this.selectedReader.Inventory.InventorySessionSummary -= Inventory_InventorySessionSummary;

                    this.selectedReader.Inventory.InventoryStarted += Inventory_InventoryStarted;
                    this.selectedReader.Inventory.InventoryStopped += Inventory_InventoryStopped;
                    this.selectedReader.Inventory.InventorySessionSummary += Inventory_InventorySessionSummary;
                }
            }
            catch (Exception e1)
            {
                this.DebugWrite(e1.ToString());
            }
        }

        /// <summary>
        /// UnRegister the inventory related events.
        /// </summary>
        /// <remarks>This is called when reader is disconneced.</remarks>
        private void UnRegisterEvents()
        {
            try
            {
                if (this.selectedReader != null)
                {
                    this.selectedReader.Inventory.InventoryStarted -= Inventory_InventoryStarted;
                    this.selectedReader.Inventory.InventoryStopped -= Inventory_InventoryStopped;
                    this.selectedReader.Inventory.InventorySessionSummary -= Inventory_InventorySessionSummary;
                }
            }
            catch (Exception e1)
            {
                this.DebugWrite(e1.ToString());
            }
        }

        /// <summary>
        /// Starts the inventory.
        /// </summary>
        private void StartInventory()
        {
            try
            {
                if (!this.inventoryInProgress)
                {
                    //clean the inventory tag data list
                    this.ResetTagInfo();

                    this.DebugWrite("selectedReader.Inventory.Perform()");

                    //abort reader thread before starting new reader thread.
                    this.AbortTagDataQueuingThread();

                    //Start tag data reading from the inventory queue background thread.
                    StartTagDataQueuingThread();

                    this.isStopPressed = false;
                    this.inventoryInProgress = true;

                    this.ToggleInventoryButtonText();

                    RFIDLibraryUtility.InventoryPerfom(this.selectedReader);

                    if (DeviceStatus.BatchMode == BATCH_MODE.ENABLE)
                    {
                        //this.View.ShowAlert("Inventory is running in batch mode");
                        this.ToggleBatchModeNotification(true);
                        DeviceStatus.IsBatchModeInventoryRunning = true;
                    }
                }
                else
                {
                    this.DebugWrite("Inventory perform already in progress....");
                    this.inventoryInProgress = false;
                    this.ToggleInventoryButtonText();
                }
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message.Contains("Unknown read session is in place"))
                {
                    this.ShowAlert("Unknown inventory is running in batch mode. Click to Stop");
                    DeviceStatus.IsBatchModeInventoryRunning = true;
                    this.inventoryInProgress = true;
                    this.ToggleInventoryButtonText();
                }
            }
            catch (Exception e1)
            {
                this.inventoryInProgress = false;
                this.ToggleInventoryButtonText();
                this.DebugWrite(e1.ToString());
            }
        }

        /// <summary>
        /// Stops the inventory.
        /// </summary>
        private void StopInventory()
        {
            try
            {
                if (this.inventoryInProgress)
                {
                    this.DebugWrite("selectedReader.Inventory.Stop()");

                    this.isStopPressed = true;
                    //abort the running inventory.
                    RFIDLibraryUtility.StopInventory(this.selectedReader);

                    if (DeviceStatus.IsBatchModeInventoryRunning)
                    {
                        this.ToggleBatchModeNotification(false);
                        RFIDLibraryUtility.GetBatchedTags(this.selectedReader);
                        this.DebugWrite("Get Batched Tags : Successful");
                        DeviceStatus.IsBatchModeInventoryRunning = false;
                    }
                    this.inventoryInProgress = false;
                    //call toggling button txt here, if user pressed "stop" button, when isTriggerRepeat = true.
                    this.ToggleInventoryButtonText();
                }
                else
                {
                    this.DebugWrite("Already Inventory Stopped...");
                }
            }
            catch (Exception e1)
            {
                this.inventoryInProgress = true;
                this.DebugWrite(e1.ToString());
            }
        }

        private void StartTagDataQueuingThread()
        {
            readerThread = new Thread(ReadTagData);
            readerThread.IsBackground = true;
            readerThread.Start();
        }

        private void AbortTagDataQueuingThread()
        {
            if (readerThread != null)
            {
                try
                {
                    readerThread.Abort();
                }
                catch (ThreadAbortException e)
                {
                    this.DebugWrite(e.ToString());
                }
                catch (Exception e)
                {
                    this.DebugWrite("finally: " + e.ToString());
                }
            }
        }

        private void ReadTagData()
        {
            while (readerThread != null)
            {
                var e = RFIDLibraryUtility.GetNextTagDataReceivedEventArg(this.selectedReader);
                ProcessTagDataReceivedEvent(e);
            }
        }

        private void ProcessTagDataReceivedEvent(TagDataReceivedEventArgs e)
        {
            if (e != null)
            {
                string id = e.EPCId;

                //tags which are not having EPCID
                if (e.EPCId == null)
                {
                    //show it as empty row.
                    id = "";
                }

                TagData data = this.tagUtility.GetTagData(id, ushort.Parse(e.TagSeenCount));
                this.tagData = new TagData[] { data };
                if (data != null) this.ShowTagData();
            }
            else
            {
                try
                {
                    if (this.selectedReader != null)
                    {
                        TagData[] tagDataArr = tagUtility.GetReadTags(100, this.selectedReader);
                        if (tagDataArr != null)
                        {
                            this.tagData = tagDataArr;
                            this.ShowTagData();
                        }
                    }
                }
                catch (Exception e1)
                {
                    this.DebugWrite(e1.ToString());
                }
            }
        }

        #endregion

        #region Public Memebers - calls from different screen

        /// <summary>
        /// This is accessed by Home screen for unregistering event when reader is disconneced.
        /// </summary>
        public void UnRegisterInventoryEvents()
        {
            this.UnRegisterEvents();
        }

        public void OnBatchModeRun()
        {
            BeginInvoke(new Action(delegate
            {
                if (DeviceStatus.IsBatchModeInventoryRunning)
                {
                    this.ResetTagInfo();
                    this.inventoryInProgress = true;
                    this.ToggleInventoryButtonText();
                    this.ToggleBatchModeNotification(true);
                }
            }));
        }

        public void CleanUIOnDisconnect()
        {
            BeginInvoke(new Action(delegate
            {
                this.ResetTagInfo();
                this.inventoryInProgress = false;
                this.ToggleInventoryButtonText();
                this.ToggleBatchModeNotification(false);
            }));
        }

        public void InitInventory()
        {
            tagUtility = new TagUtility();
            this.InitInventoryList();
            this.RegisterEvents();
        }

        #endregion
    }
}