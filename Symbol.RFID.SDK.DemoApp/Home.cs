using System;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Symbol.RFID.SDK.Domain.Reader;
using Symbol.RFID.SDK;
using Symbol.RFID.SDK.DemoApp.Extensions;
using Symbol.RFID.SDK.DemoApp.Entities;
using System.IO;
using Symbol.RFID.SDK.DemoApp.Utilities;

namespace Symbol.RFID.SDK.DemoApp
{
    public partial class frmHome : Form // JA:Lets make this Home to be consistent with the file name
    {
        private StringBuilder sbOutStatus = new StringBuilder();
        private frmInventory frmInventory;
        private frmMenu frmMenu; // JA: Does this need to be public, can use like frmAbout
        private bool isWatingForEvent = false; // JA: spelling mistake (isWaitingForEvents) this is not needed can remove the property. On the disconnect/connect eventhandlers just change the cursor back
        private IRfidReader selectedReader;
        private Dictionary<string, DeviceInfo> availableReaders; //JA: is not required. You only need to fill the listbox. Can init the variable within the method scope
        private List<IRfidReader> readerList;
        private bool isConnected; // JA: Not needed. selectedReader == null can be used.

        public frmHome()
        {
            InitializeComponent();

            // JA: Lets move this to a function, initializeReaderWatcher
            IRemoteReaderWatcher readerWatcher = RfidSdk.RemoteReaderWatcherServicesFactory.Create();
            readerWatcher.ReaderAppeared += new EventHandler<ReaderStatusChangedEventArgs>(ReaderAppearedHandler);
            readerWatcher.ReaderDisappeared += new EventHandler<ReaderStatusChangedEventArgs>(ReaderDisappearedHandler);
            readerWatcher.ReaderConnected += new EventHandler<ReaderStatusChangedEventArgs>(ReaderConnectedHandler);
            readerWatcher.ReaderDisconnected += new EventHandler<ReaderStatusChangedEventArgs>(ReaderDisconnectedHandler);

            this.availableReaders = this.GetAvailableRFIDReaderList(); ; // JA: Not needed here, can be used inside the method to fill the listbox
        }
        // JA: Lets rename as Form Event Handlers
        #region Home Form Events 

        private void frmHome_Load(object sender, EventArgs e)
        {
            this.DisableUIControls();
            this.FillRFIDReadersItems();
        }

        private void frmHome_Closing(object sender, CancelEventArgs e)
        {
            try
            {
                if (this.selectedReader != null)
                {
                    RFIDLibraryUtility.Disconnect(this.selectedReader);

                    // JA: This will not work right as the disconnect is already done? Can remove the whole block.
                    if (this.frmInventory != null && this.frmInventory.inventoryInProgress)
                    {
                        RFIDLibraryUtility.StopInventory(this.selectedReader);

                    }
                }
            }
            catch (Exception e1)
            {
                this.DebugWrite(e1.ToString());
            }
        }

        private void frmHome_Activated(object sender, EventArgs e)
        {
            //call restore default if clicked restore default button in setting menu screen.
            // JA: Is there any possibility to do this in the setting screen and not have the logic in this screen? 
            if (DeviceStatus.IsRestoreDefaultClicked)
            {
                DeviceStatus.IsRestoreDefaultClicked = false;

                this.BeginInvoke(new Action(delegate
                    {
                        DialogResult result = MessageBox.Show("This will reset the device to factory defaults and you will have to re-pair the device before using. Do you want to continue?",
                            "Important",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2);

                        if (result == DialogResult.Yes)
                        {
                            RFIDLibraryUtility.RestoreDefault(this.selectedReader);
                        }
                        else
                        {

                        }
                    }));
            }
        }

        private void btnToggleConnection_Click(object sender, EventArgs e)
        {
            //at this point reader is not still initialized , so here we can't use reader.IsConnected bool. so keep internal bool in model 
            // JA: Can check selectedReader==null
            if (this.isConnected)
            {
                this.Disconnect();
            }
            else
            {
                this.Connect();
            }
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            // JA: Are we maintaining sessions in settings screen? if not we can init a new frame and show, similar to btnAbout_Click
            frmMenu.ShowDialog();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            frmInventory.ShowDialog();
            // JA: Chech the inventory in progress here and update the UI without asking the invneotory form to invoke methods in main
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout(this.selectedReader, this);
            frm.ShowDialog();
        }

        #endregion

        // JA: lets rename as RFIDReader Event Handlers
        #region Event Handlers

        private void Inventory_BatchMode(object sender, ReadSessionBatchModeEventArgs e)
        {
            // JA: Lets add a comment here why this event is occuring. Ex. Device is connected in batch mode. Disabling settings screen. 
            this.DebugWrite("batch mode running event" + e.Mode.ToString());
            this.OnBatchModeRun(); // JA: no need for a different method. bring that code here.
            DeviceStatus.IsBatchModeInventoryRunning = true;
        }

        private void ReaderAppearedHandler(object sender, ReaderStatusChangedEventArgs e)
        {
            this.DebugWrite(e.RFIDReaderInfo.FriendlyName + " Appeared.");

            // JA: Lets add a new method UpdateReaderList(RFIDReaderInfo reader, bool Appeared) and move this logic there. 
            //     The logic here is about checking the device already in the list and if not update the list. Use the same method on disappear
            var iReaderInfo = GetCurrentReader(e); 
            if (iReaderInfo != null) return;

            var readerInfo = e.RFIDReaderInfo;

            IRfidReader iReader = RFIDLibraryUtility.CreateReader(readerInfo);

            this.readerList.Add(iReader);

            DeviceInfo deviceInfo = new DeviceInfo()
            {
                BluetoothAddress = readerInfo.BluetoothAddress,
                ComPortNumber = readerInfo.ComPortNumber,
                FriendlyName = iReader.FriendlyName,
                Reader = iReader
            };

            this.AddToReaderList(deviceInfo);
            // JA: Till here

        }

        private void ReaderDisappearedHandler(object sender, ReaderStatusChangedEventArgs e)
        {
            this.DebugWrite(e.RFIDReaderInfo.FriendlyName + " Disappeared.");
            // JA: Use the method mentioned above to update the readerl list and keep the connected device cleanup code here. 
            var reader = this.GetCurrentReader(e);
            if (reader != null)
            {
                if (reader.IsConnected)
                {
                    this.Disconnect();
                }
                this.OnDisconnected(reader.IsConnected, true, e.RFIDReaderInfo.FriendlyName);

                this.RemoveReader(reader);
            }
        }

        private void ReaderConnectedHandler(object sender, ReaderStatusChangedEventArgs e)
        {
            var reader = GetCurrentReader(e);
            // JA: Add comment here
            if (reader != null && this.selectedReader.BluetoothAddress == reader.BluetoothAddress)
            {
                // JA: onConnected is called only from here lets move that logic here as well and add more comments 
                this.OnConnected(reader.BluetoothAddress, reader.FriendlyName);


                // JA: comment here
                if (!DeviceStatus.IsBatchModeInventoryRunning)
                {
                    try
                    {
                        // JA: Lets comment each line why we need to maintain the information
                        RFIDLibraryUtility.CheckRegion(reader);
                        DeviceStatus.IsTriggerRepeat = RFIDLibraryUtility.IsTriggerRepeat(reader);
                        DeviceStatus.BatchMode = RFIDLibraryUtility.GetBatchMode(reader);
                        DeviceStatus.Initialized = true;
                    }
                    catch (Exception)
                    {
                        // JA: LEts change the debugwrite to include device in batch mode
                        this.DebugWrite("Event: Reading Region and Triggers after Invenrtory Stopped" + Environment.NewLine);
                        DeviceStatus.Initialized = false;
                    }
                }
            }
        }

        private void ReaderDisconnectedHandler(object sender, ReaderStatusChangedEventArgs e)
        {
            // JA: Logic change check for selectedReader is null and selectedReader.BluetoothAddress==e.RFIDReaderInfo.Bluetooth address

            // JA: Not needed
            var reader = GetCurrentReader(e);
            
            if (this.selectedReader != null)
            {
                
                if (reader != null && this.selectedReader.BluetoothAddress == reader.BluetoothAddress)
                {
                    // JA:add comment per line why
                    this.UnRegisterEvents();
                    this.selectedReader.Inventory.BatchMode -= Inventory_BatchMode;
                    this.ResetInventoryScreen();
                    this.OnDisconnected(true, false, e.RFIDReaderInfo.FriendlyName);
                    DeviceStatus.Reset();
                    this.selectedReader = null;
                }
            }
        }

        #endregion Event Handlers

        #region internal Members - calls from different screen

        // JA: Can this be done using the Device object ? when the inventory form close need to check the inventory in progress is all.
        internal void CheckBatchState(bool isInventoryInProgress)
        {
            if (DeviceStatus.IsBatchModeInventoryRunning || isInventoryInProgress)
            {
                this.btnSetting.Enabled = false;
            }
            else
            {
                this.btnSetting.Enabled = true;
            }
        }

        #endregion

        #region Home Private Members

        private void FillRFIDReadersItems()
        {
            try
            {
                comboBoxReaders.Items.Clear();

                foreach (KeyValuePair<string, DeviceInfo> reader in this.availableReaders)
                {
                    Device device = new Device(reader.Value);
                    comboBoxReaders.Items.Add(device);
                }

                if (comboBoxReaders.Items.Count > 0)
                {
                    comboBoxReaders.SelectedIndex = 0;
                    btnConnect.Enabled = true;
                }
            }
            catch (Exception e1)
            {
                this.DebugWrite(e1.ToString());
            }
        }

        /// <summary>
        /// Gets the available RFID reader list.
        /// </summary>
        /// <returns></returns>
        // JA: This can be moved to the Utility class and use the output to populate the listbox
        private Dictionary<string, DeviceInfo> GetAvailableRFIDReaderList()
        {
            List<IRfidReaderInfo> readerInfoList = null;

            this.readerList = new List<IRfidReader>();
            Dictionary<string, DeviceInfo> ReaderComList = new Dictionary<string, DeviceInfo>();

            //init reader management and reader info list.
            RFIDLibraryUtility.InitReaderList(out readerInfoList);

            foreach (IRfidReaderInfo readerInfo in readerInfoList)
            {
                //create reader intance based on reader information.
                IRfidReader reader = RFIDLibraryUtility.CreateReader(readerInfo);

                this.readerList.Add(reader);

                //creating reader device info object to create reader item on comboBox.
                DeviceInfo deviceInfo = new DeviceInfo()
                {
                    BluetoothAddress = readerInfo.BluetoothAddress,
                    ComPortNumber = readerInfo.ComPortNumber,
                    FriendlyName = reader.FriendlyName,
                    Reader = reader
                };

                ReaderComList.Add(readerInfo.BluetoothAddress, deviceInfo);
            }
            return ReaderComList;
        }

        private void Connect()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                this.DebugWrite("Connecting...");

                Device selectedItem = (Device)comboBoxReaders.SelectedItem;
                this.selectedReader = (IRfidReader)selectedItem.Value;

                // JA: Lets move the Inits outside the try catch. The device might not connect for some reason, have to handle that and not init before that.
                this.InitFormInventory();

                this.frmMenu = new frmMenu(this.selectedReader, this);

                // When battery removed from device or set to factory default, previous open connection to the port still exist
                // So first close the connection 
                if (this.selectedReader.IsConnected)
                {
                    RFIDLibraryUtility.Disconnect(this.selectedReader);
                }

                //register batch mode event before connect the reader.
                selectedReader.Inventory.BatchMode += new EventHandler<ReadSessionBatchModeEventArgs>(Inventory_BatchMode);

                //connect selected reader.
                RFIDLibraryUtility.Connect(this.selectedReader);
            }
            catch (Exception ex)
            {
                this.DebugWrite(ex.ToString());
            }
            this.isWatingForEvent = true;
        }

        private void InitFormInventory()
        {
            //due to readerThread = null if we didn't stop inventory and diconnect, then connect,click inventory-->if creates new inventory object, then old reader thread will be garbage collected.
            if (frmInventory == null)
            {
                this.frmInventory = new frmInventory(this.selectedReader, this);
            }
            else
            {
                //asign latest selected reader as formInventory selected reader. 
                this.frmInventory.selectedReader = this.selectedReader;

                //register events and other init calls (due to not creating new inventory objects every time, inventory constructor is not calling always)
                this.frmInventory.InitInventory();
            }
        }

        private void Disconnect()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                this.DebugWrite("Disconnecting...");

                RFIDLibraryUtility.Disconnect(this.selectedReader);

            }
            catch (Exception e1)
            {
                this.DebugWrite(e1.ToString());
            }
            this.isWatingForEvent = true;
        }

        private void DisableUIControls()
        {
            btnConnect.Enabled = false;
            btnInventory.Enabled = false;
            btnSetting.Enabled = false;
        }

        private void UnRegisterEvents()
        {
            if (this.frmInventory != null)
            {
                this.frmInventory.UnRegisterInventoryEvents();
            }

            if (this.frmMenu != null)
            {
                this.frmMenu.UnRegisterSettingEvents();
            }
        }

        private void ResetInventoryScreen()
        {
            if (this.frmInventory != null)
            {
                frmInventory.CleanUIOnDisconnect();
            }
        }

        // JA: This method name is misleading. lets rename to something like GetRFIDReader and change argument from EventArgs to RFIDReaderInfo as only the RFIDReaderInfor is used
        private IRfidReader GetCurrentReader(ReaderStatusChangedEventArgs e) 
        {
            var readerList = this.readerList;
            var reader = readerList.Find(i => i.BluetoothAddress.Equals(e.RFIDReaderInfo.BluetoothAddress, StringComparison.OrdinalIgnoreCase));
            return reader;
        }

        // JA: DO we need to check if the selectedReader is the one to be removed?
        private void RemoveReader(IRfidReader reader)
        {
            this.RemoveFromReaderList(reader);
            this.readerList.Remove(reader);
        }

        
        private void DebugWrite(string txt)
        {
#if DEBUG
            // JA: Add a comment about debug messages
            System.Diagnostics.Debug.WriteLine(txt);
#endif
        }

        //adding from device combo list when reader is appeared. (paired)
        private void AddToReaderList(DeviceInfo deviceInfo)
        {
            this.Invoke(delegate
            {
                this.DebugWrite("Events_StatusNotify: Appeared." + Environment.NewLine);

                bool found = false;
                Device currentDevice = null;
                for (int n = 0; n < comboBoxReaders.Items.Count; n++)
                {
                    currentDevice = (Device)comboBoxReaders.Items[n];
                    if (currentDevice.Id == deviceInfo.BluetoothAddress)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    Device device = new Device(deviceInfo);
                    comboBoxReaders.Items.Add(device);
                }
                if (comboBoxReaders.Items.Count > 0)
                {
                    comboBoxReaders.SelectedIndex = 0;
                    btnConnect.Enabled = true;
                }
            });

        }

        //removing from the device combo list when reader is disappeared.(unpaired)
        private void RemoveFromReaderList(IRfidReader reader)
        {
            this.Invoke(delegate
            {
                bool found = false;
                Device currentDevice = null;
                for (int n = 0; n < comboBoxReaders.Items.Count; n++)
                {
                    currentDevice = (Device)comboBoxReaders.Items[n];
                    if (currentDevice.Id == reader.BluetoothAddress)
                    {
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    comboBoxReaders.Items.Remove(currentDevice);
                    if (comboBoxReaders.Items.Count == 0)
                    {
                        DisableUIControls();
                        btnConnect.Enabled = true;
                    }
                }
            });

        }

        /// <summary>
        /// Called when [connected].
        /// </summary>
        /// <param name="bluetoothAddress">The Bluetooth address.</param>
        /// <param name="friendlyName">Name of the friendly.</param>
        private void OnConnected(string bluetoothAddress, string friendlyName)
        {
            this.DebugWrite("Connected Successfully...");
            this.DebugWrite("Friendly Name:" + friendlyName);
            this.DebugWrite("Bluetooth Address:" + bluetoothAddress);

            BeginInvoke(new Action(delegate
            {
                try
                {
                    // JA: As mentioned above nto needed just set to default
                    if (this.isWatingForEvent)
                        Cursor.Current = Cursors.Default;

                    this.ShowAlert("Connected Successfully..." + Environment.NewLine + friendlyName);
                    this.isConnected = true;
                    btnConnect.Text = "Disconnect";
                    btnInventory.Enabled = true;
                    comboBoxReaders.Enabled = false;

                    //handle batch mode UI changes (setting need to be disabled)
                    if (DeviceStatus.IsBatchModeInventoryRunning)
                    {
                        btnSetting.Enabled = false;
                    }
                    else
                    {
                        btnSetting.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    if (ex is InvalidOperationException)
                    {
                        this.DebugWrite(ex.ToString());
                    }
                }

            }));
        }

        //changing the UI based on disconnected event.
        /// <summary>
        /// Called when [disconnected].
        /// </summary>
        private void OnDisconnected(bool isCurrentReader, bool isDissapeared, string friendlyName)
        {
            this.DebugWrite(isDissapeared ? "Disappeared..." + Environment.NewLine : "Disconnected Successfully..." + Environment.NewLine);
            BeginInvoke(new Action(delegate
            {
                try
                {
                    if (this.isWatingForEvent)
                        Cursor.Current = Cursors.Default;

                    this.ShowAlert((isDissapeared ? "Disappeared..." + Environment.NewLine : "Disconnected Successfully..." + Environment.NewLine) + friendlyName);
                    if (isCurrentReader)
                    {
                        this.isConnected = false;
                        btnConnect.Text = "Connect";
                        btnSetting.Enabled = false;
                        btnInventory.Enabled = false;
                        comboBoxReaders.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    if (ex is InvalidOperationException)
                    {
                        this.DebugWrite(ex.ToString());
                    }
                }
            }));
        }

        //showing the alert dialog.
        /// <summary>
        /// Show alert message.
        /// </summary>
        private void ShowAlert(string message)
        {
            MessageBox.Show(message);
        }

        //changing on UI in home screen based on batch mode status 
        private void OnBatchModeRun()
        {
            BeginInvoke(new Action(delegate
            {
                this.btnSetting.Enabled = false;
            }));
        }

        #endregion
    }
}