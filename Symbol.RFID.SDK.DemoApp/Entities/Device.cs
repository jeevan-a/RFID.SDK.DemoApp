using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Symbol.RFID.SDK.DemoApp.Utilities;

namespace Symbol.RFID.SDK.DemoApp.Entities
{
    /// <summary>
    /// This is used to create device info object which is used in filling combox redear list.
    /// </summary>
    // JA: rename to RFIDReaderItem to represent a Item in the combo box
    public class Device
    {
        private DeviceInfo deviceInfo;

        public Device(DeviceInfo deviceInfo) // JA: Can use a RFIDReader object to create this instead of a new DeviceInfo type. 
        {
            TagUtility tagUtility = new TagUtility(); // JA:Not used remove
            this.deviceInfo = deviceInfo; // JA: Not used, remove. Save Bluetooth address in a string. 
            Text = deviceInfo.FriendlyName + " (" + deviceInfo.ComPortNumber + ")";
            Value = deviceInfo.Reader;
        }

        public string Text { get; private set; }
        public object Value { get; private set; }

        public string Id
        {
            get
            {
                return deviceInfo.BluetoothAddress; //JA: Can use reader.BluetoothAddress
            }
        }
        public override string ToString()
        {
            return Text;
        }
    }
}
