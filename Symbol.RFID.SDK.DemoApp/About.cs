using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Symbol.RFID.SDK.Domain.Reader;
using System.Reflection;
using System.IO;

namespace Symbol.RFID.SDK.DemoApp
{
    // JA: Change name to About to be same as class name
    public partial class frmAbout : Form
    {
        private IRfidReader reader;
        private Form mainForm;
        

        public frmAbout(IRfidReader selectedReader, Form mainForm)
        {
            InitializeComponent();


            this.mainForm = mainForm;
            this.reader = selectedReader;
        }

        //JA: Lets rename to Frm Event Handlers
        #region About Form Events

        private void frmAbout_Load(object sender, EventArgs e)
        {
            this.labelProductName.Text = this.AssemblyTitle;
            this.labelCopyright.Text = this.AssemblyCopyright;
            this.labelCompanyName.Text = this.AssemblyCompany;

            this.labelVersion.Text = "Application Version : " + this.AssemblyVersion;
            this.lblHardwareVersion.Text = (reader == null) ? string.Empty : "Module Version : " + reader.Version.Hardware.ToString();
            this.lblBluetoothVerstion.Text = (reader == null) ? string.Empty : "Radio Version : " + reader.Version.Bluetooth.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Private Properties


        private string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        private string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyTitleAttribute)attributes[0]).Title;
            }
        }

        private string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        private string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        private string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }


        #endregion

    }
}