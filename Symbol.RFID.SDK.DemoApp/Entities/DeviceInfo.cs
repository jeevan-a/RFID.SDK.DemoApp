using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Symbol.RFID.SDK.Domain.Reader;

namespace Symbol.RFID.SDK.DemoApp.Entities
{
    public class DeviceInfo
    {
        /// <summary>
        /// Friendly name of the reader
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Bluetooth address of the reader
        /// </summary>
        public string BluetoothAddress { get; set; }

        /// <summary>
        /// Com Port number of the reader
        /// </summary>
        public string ComPortNumber { get; set; }

        /// <summary>
        /// RFID reader
        /// </summary>
        public IRfidReader Reader { get; set; }

    }
}
