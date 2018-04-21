using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Symbol.RFID.SDK.DemoApp;
using Symbol.RFID.SDK.DemoApp.Entities;
using Symbol.RFID.SDK.Domain.Reader;

namespace Symbol.RFID.SDK.DemoApp.Utilities
{
    public class RFIDLibraryUtility
    {

        #region Home Operations

        /// <summary>
        /// Initializes the readers.
        /// </summary>
        public static void InitReaderList(out List<IRfidReaderInfo> readerInfoList)
        {
            var readerManager = RfidSdk.RemoteReaderManagementServicesFactory.Create();

            //get available readers list
            readerInfoList = readerManager.GetReaders(ReaderSearchOptions.AllReaders);
        }

        /// <summary>
        ///Creates reader intance based on reader information.
        /// </summary>
        /// <param name="readerInfo"></param>
        /// <returns></returns>
        public static IRfidReader CreateReader(IRfidReaderInfo readerInfo)
        {
            return RfidSdk.RfidReaderFactory.Create(readerInfo);
        }

        /// <summary>
        /// Connects the device.
        /// </summary>
        public static void Connect(IRfidReader reader)
        {
            reader.Connect();
        }

        /// <summary>
        /// Disconnects the device.
        /// </summary>
        public static void Disconnect(IRfidReader reader)
        {
            //call when reader manually disconnect
            reader.Disconnect();
        }

        /// <summary>
        /// Restores default the device.
        /// </summary>
        /// <param name="reader"></param>
        public static void RestoreDefault(IRfidReader reader)
        {
            if (reader != null)
            {
                reader.ResetFactoryDefaults();
            }
        }
        #endregion

        #region Inventory Operations

        /// <summary>
        /// Perform inventory process.
        /// </summary>
        /// <param name="reader"></param>
        public static void InventoryPerfom(IRfidReader reader)
        {
            reader.Inventory.Perform();
        }

        /// <summary>
        /// Stops an ongoing inventory.
        /// </summary>
        /// <param name="reader"></param>
        public static void StopInventory(IRfidReader reader)
        {
            reader.Inventory.Stop();
        }

        /// <summary>
        /// Get batch tags once stopped the inventory in batch mode.
        /// </summary>
        public static void GetBatchedTags(IRfidReader reader)
        {
            try
            {
                if (reader != null)
                {
                    reader.Inventory.GetBatchedTags();
                    //this.View.DebugWrite("Get Batched Tags : Successful");
                }
            }
            catch (Exception e1)
            {
                //this.View.DebugWrite(e1.ToString());
            }
        }

        /// <summary>
        /// Purge tags.
        /// </summary>
        public static void PurgeTags(IRfidReader reader)
        {
            try
            {
                if (reader != null)
                {
                    reader.Inventory.PurgeTags();
                }
            }
            catch (Exception ex)
            {
                //this.View.DebugWrite(ex.Message);
            }
        }

        /// <summary>
        /// Fetches an array of tags that was read by the reader.
        /// </summary>
        /// <param name="numberOfTags">Number of Tags that is to be fetched.</param>
        /// <param name="reader"></param>
        /// <returns>An array of TagDataReceivedEventArgs if the method succeeds or an empty array if no Tags were 
        /// available.</returns>
        public static TagDataReceivedEventArgs[] GetReadTags(int numberOfTags, IRfidReader reader)
        {
            return reader.Inventory.GetReadTags(numberOfTags);
        }

        /// <summary>
        /// Get Tag data via queue
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static TagDataReceivedEventArgs GetNextTagDataReceivedEventArg(IRfidReader reader)
        {
            return reader.Inventory.GetNextTagDataReceivedEventArg();
        }

        #endregion

        #region Configuration Operations

        /// <summary>
        /// Sets IsTirggerRepeat bool value.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="isTriggerRepeat"></param>
        public static bool IsTriggerRepeat(IRfidReader reader)
        {
            var isTriggerRepeat = false;

            if (reader != null)
            {
                var startTriggerType = reader.Configurations.TriggerInfo.StartTrigger.Type;

                if (startTriggerType == START_TRIGGER_TYPE.START_TRIGGER_TYPE_PERIODIC || startTriggerType == START_TRIGGER_TYPE.START_TRIGGER_TYPE_HANDHELD)
                {
                    isTriggerRepeat = true;
                }
            }
            return isTriggerRepeat;

        }

        /// <summary>
        /// Gets the antenna configuration.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static AntennaConfiguration GetPower(IRfidReader reader)
        {
            ushort[] antID = new ushort[1];
            return reader.Configurations.Antennas[antID[0]].Configuration;
        }

        /// <summary>
        /// Sets the antenna configuration.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="power"></param>
        public static void SetPower(IRfidReader reader, string power)
        {
            ushort[] antID = new ushort[1];
            AntennaConfiguration antConfig = GetPower(reader);
            antConfig.TransmitPowerIndex = ushort.Parse(power); //Handle errors
            reader.Configurations.Antennas[antID[0]].Configuration = antConfig;
        }

        /// <summary>
        /// Gets the beeper volume.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static BEEPER_VOLUME GetBeeperVolume(IRfidReader reader)
        {
            return reader.Configurations.BeeperVolume;
        }

        /// <summary>
        /// Sets the beeper volume.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="bEEPER_VOLUME"></param>
        public static void SetBeeperVolume(IRfidReader reader, BEEPER_VOLUME bEEPER_VOLUME)
        {
            reader.Configurations.BeeperVolume = bEEPER_VOLUME;
        }

        /// <summary>
        /// Gets regulatory configuration.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>The regulatory configuration.</returns>
        public static RegulatoryConfig GetRegion(IRfidReader reader)
        {
            return reader.Configurations.RegulatoryConfig;
        }

        /// <summary>
        /// Set Region to USA 
        /// </summary>
        public static void SetDefaultRegion(IRfidReader reader)
        {
            RegulatoryConfig config = new RegulatoryConfig();
            config.Region = "USA";
            reader.Configurations.RegulatoryConfig = config;
        }

        /// <summary>
        /// Gets device status in terms of battery, power and temperature.
        /// </summary>
        /// <param name="battery">Whether battery events required.</param>
        /// <param name="power">Whether power events required.</param>
        /// <param name="temperature">Whether temperature events required.</param>
        public static void GetDeviceStatus(IRfidReader reader, bool batteryStatus, bool powerStatus, bool temperatureStatus)
        {
            reader.Configurations.GetDeviceStatus(batteryStatus, powerStatus, temperatureStatus);
        }

        /// <summary>
        /// Gets the batch mode configuration.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static BATCH_MODE GetBatchMode(IRfidReader reader)
        {
            return reader.Configurations.BatchModeConfig;
        }

        /// <summary>
        /// Sets the batch mode configuration.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="bATCH_MODE"></param>
        public static void SetBatchMode(IRfidReader reader, BATCH_MODE bATCH_MODE)
        {
            reader.Configurations.BatchModeConfig = bATCH_MODE;
            DeviceStatus.BatchMode = bATCH_MODE;
        }

        /// <summary>
        /// Gets the trigger information.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static TriggerInfo GetTriggerInformation(IRfidReader reader)
        {
            return reader.Configurations.TriggerInfo;
        }

        /// <summary>
        /// Sets the trigger information.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="triggerInfo"></param>
        public static void SetTriggerInformation(IRfidReader reader, TriggerInfo triggerInfo)
        {
            reader.Configurations.TriggerInfo = triggerInfo;
            DeviceStatus.IsTriggerRepeat = RFIDLibraryUtility.IsTriggerRepeat(reader);
        }

        /// <summary>
        /// Gets the singulation control.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="curAntennaID">Antenna ID</param>
        /// <returns></returns>
        public static SingulationControl GetSingulation(IRfidReader reader, int curAntennaID)
        {
            return reader.Configurations.Antennas[curAntennaID].SingulationControl;
        }

        /// <summary>
        /// Sets the singulation control.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="curAntennaID"></param>
        /// <param name="singulationControl"></param>
        public static void SetSingulation(IRfidReader reader, int curAntennaID, SingulationControl singulationControl)
        {
            reader.Configurations.Antennas[curAntennaID].SingulationControl = singulationControl;
        }

        /// <summary>
        /// This method is used to make the current configuration persistent over power down and power up cycles.
        /// </summary>
        /// <param name="reader"></param>
        public static void SaveConfiguration(IRfidReader reader)
        {
            reader.Configurations.SaveConfig();
        }

        /// <summary>
        /// Gets the capabilities of the reader.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static Capabilities GetCapabilities(IRfidReader reader)
        {
            return reader.Capabilities;
        }

        /// <summary>
        /// Check Current Region and if not set set it to USA
        /// </summary>
        /// <param name="reader"></param>
        public static void CheckRegion(IRfidReader reader)
        {
            try
            {
                if (reader != null)
                {
                    // Read the regulatory from the reader...
                    RegulatoryConfig regConfig = RFIDLibraryUtility.GetRegion(reader);

                    // If regulatory is not set, set it...
                    if (regConfig == null)
                    {
                        //set default region.
                        RFIDLibraryUtility.SetDefaultRegion(reader);
                    }
                }
            }
            catch (TimeoutException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                if (e.Message == reader.Configurations.ERROR_REGION_NOT_CONFIGURED)
                {
                    //set default region.
                    RFIDLibraryUtility.SetDefaultRegion(reader);
                }
                throw e;
            }
        }

        #endregion

    }
}
