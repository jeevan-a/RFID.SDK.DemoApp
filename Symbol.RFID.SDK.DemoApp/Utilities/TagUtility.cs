using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Symbol.RFID.SDK.DemoApp.Entities;
using Symbol.RFID.SDK.DemoApp.Extensions;
using Symbol.RFID.SDK.Domain.Reader;
using System.Collections;

namespace Symbol.RFID.SDK.DemoApp.Utilities
{
    public class TagUtility
    {
        #region Public Methods

        public TagData GetTagData(string tagId, ushort tagSeenCount)
        {
            TagData data = new TagData();
            data._tagId = tagId;
            data._tagSeenCount = tagSeenCount;
            return data;
        }


        /// <summary>
        /// This method fetches a array of Tags that was read by the reader. 
        /// Tags will be read from the Reader using methods: Actions.Inventory.Perform or 
        /// Actions.TagAccess.ReadEvent or Actions.TagAccess.ReadWait.
        /// </summary>
        /// <param name="numberOfTags">Number of Tags that is to be fetched</param>
        /// <returns>An array of TagData if the method succeeds or an empty array if no Tags were available</returns>
        public TagData[] GetReadTags(int numberOfTags, IRfidReader reader)
        {
            TagDataReceivedEventArgs[] tagDataReceived = RFIDLibraryUtility.GetReadTags(numberOfTags, reader);

            // JA: Why use a queue when the return type is an Array. Use an array of size numberOfTags or length of tagDataRecieved and populate it
            var temp = new Queue();

            foreach (TagDataReceivedEventArgs dataReceived in tagDataReceived)
            {
                var tagData = new TagData
                {
                    _tagId = dataReceived.EPCId
                };

                //JA: New SDK will have this as int. Please check with Prasad
                dataReceived.TagSeenCount.TryParseToUshort(out tagData._tagSeenCount);

                temp.Enqueue(tagData);
            }
            // Remove the double boxing in the ruturn using the array instead of a queue
            return (temp.Count > 0) ? temp.ToArray().OfType<TagData>().ToArray() : null;
        }
        #endregion
    }
}
