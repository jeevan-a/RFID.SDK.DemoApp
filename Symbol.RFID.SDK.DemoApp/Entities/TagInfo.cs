using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Symbol.RFID.SDK.DemoApp.Entities
{
    // JA: Lets rename to TagDataListViewItem (or something similar) as this is used for that.
    public class TagInfo
    {
        public TagInfo(TagData tg) //JA: Not used
        {
            tagData = tg;
        }

        public TagInfo(TagData tg, int rowID) //JA: Not used
        {
            tagData = tg;
            rowIndex = rowID;
        }

        public TagInfo(TagData tg, int rowID, long tagSeenCnt) //JA: Only used. lets make it tagSeenTotalCount
        {            
            tagData = tg;
            rowIndex = rowID;
            tagSeenTotalCount = tagSeenCnt;
        }

        private TagData tagData;
        public TagData Tag
        {
            get { return tagData; }
            set { tagData = value; }
        }

        private int rowIndex = -1;
        public int RowIndex
        {
            get { return rowIndex; }
            set { rowIndex = value; }
        }

        private long tagSeenTotalCount = 0;
        public long TagSeenTotalCount
        {
            get { return tagSeenTotalCount; }
            set { tagSeenTotalCount = value; }
        }
    }
}
