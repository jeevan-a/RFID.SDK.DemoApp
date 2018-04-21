using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Symbol.RFID.SDK.DemoApp.Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// Invokes the specified control.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="action">The action.</param>
        public static void Invoke(this Control control, Action action)
        {
            try
            {
                control.Invoke((Delegate)action);
            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);
            }
            
        }

        /// <summary>
        /// String value Try Parse To Ushort
        /// </summary>
        /// <param name="value">The string value.</param>
        /// <param name="result">The ushort result.</param>
        public static bool TryParseToUshort(this string value, out UInt16 result) 
        {
            bool retVal = false;

            try
            {
                result = Convert.ToUInt16(value);
                retVal = true;
            }
            catch (FormatException) { result = 0; }
            catch (InvalidCastException) { result = 0; }

            return retVal;
        }
    }
}
