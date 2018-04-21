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
    public class Device
    {
        private DeviceInfo deviceInfo;

        public Device(DeviceInfo deviceInfo)
        {
            TagUtility tagUtility = new TagUtility();
            this.deviceInfo = deviceInfo;
            Text = deviceInfo.FriendlyName + " (" + deviceInfo.ComPortNumber + ")";
            Value = deviceInfo.Reader;
        }

        public string Text { get; private set; }
        public object Value { get; private set; }

        public string Id
        {
            get
            {
                return deviceInfo.BluetoothAddress;
            }
        }
        public override string ToString()
        {
            return Text;
        }
    }
}
