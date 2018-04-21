using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Symbol.RFID.SDK.DemoApp.Entities
{
    public class TagInfo
    {
        public TagInfo(TagData tg)
        {
            tagData = tg;
        }

        public TagInfo(TagData tg, int rowID)
        {
            tagData = tg;
            rowIndex = rowID;
        }

        public TagInfo(TagData tg, int rowID, long tagSeenCnt)
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
