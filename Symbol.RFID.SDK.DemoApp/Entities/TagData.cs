using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Symbol.RFID.SDK.DemoApp.Entities
{
    public class TagData
    {
        #region Private Fields

        internal string _tagId;
        internal ushort _tagSeenCount;

        #endregion

        #region Public Propeties

        /// <summary>
        /// Gets the Tag ID 
        /// </summary>
        public string TagID { get { return _tagId; } }

        /// <summary>
        /// Gets the Tag seen count
        /// </summary>
        public ushort TagSeenCount { get { return _tagSeenCount; } }

        #endregion

    }
}
