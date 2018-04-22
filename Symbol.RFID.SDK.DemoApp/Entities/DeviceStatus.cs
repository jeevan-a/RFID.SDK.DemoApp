using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Symbol.RFID.SDK.Domain.Reader;

namespace Symbol.RFID.SDK.DemoApp.Entities
{
    //JA: Lets rename to ReaderStatus or ActiveReaderStatus
    public class DeviceStatus
    {
        public static bool IsBatchModeInventoryRunning { get; set; }

        public static bool Initialized { get; set; }

        /// <summary>
        /// This is added to check batch mode auto mode while inventory in progress (remote reader is busy, so can't get directory mode value via reader at that time)
        /// </summary>
        public static BATCH_MODE BatchMode { get; set; }

        /// <summary>
        /// Is restore default clicked.
        /// </summary>
        public static bool IsRestoreDefaultClicked { get; set; }

        /// <summary>
        /// Gets or Sets flag of isTriggerRepeat.
        /// </summary>
        public static bool IsTriggerRepeat { get; set; }


        internal static void Reset()
        {
            IsTriggerRepeat = false;
            IsRestoreDefaultClicked = false;
            BatchMode = BATCH_MODE.AUTO;
            Initialized = false;
            IsBatchModeInventoryRunning = false;
        }
    }
}
