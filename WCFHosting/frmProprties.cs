using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;

namespace WCFHosting
{
    public partial class frmProprties : Form
    {
        private ServiceHost host;
        public frmProprties()
        {
            InitializeComponent();

            host = new ServiceHost(typeof(CallerService));
            host.Open();
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            lblMessage.Text = "Service Started";
        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            var username = txtUser.Text.Trim();
            var password = txtPws.Text.Trim();
            var extension = txtExc.Text.Trim();
            // NB: Add reference to Microsoft.CSharp.dll
            dynamic wshShell = Activator.CreateInstance(Type.GetTypeFromProgID("WScript.Shell"));
            wshShell.Popup("Hello, world!");


            dynamic utilites = Activator.CreateInstance(Type.GetTypeFromProgID("SmartBarClient.Client"));

            var number = txtPhone.Text.Trim();
            utilites.Init(true, true, false, username, password, extension, 0);
            utilites.Agent_PressButton_MakeCall("", number, "");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            host = new ServiceHost(typeof(CallerService));
            host.Open();
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            lblMessage.Text = "Service Started";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            host.Close();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            lblMessage.Text = "Service Stopped";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            host.Close();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }
    }
}
