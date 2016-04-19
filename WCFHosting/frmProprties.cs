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

            startToolStripMenuItem.Enabled = false;
            stopToolStripMenuItem.Enabled = true;
            this.WindowState = FormWindowState.Minimized;
            _config = Config.GetSinglton();
            
        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            var username = txtUser.Text.Trim();
            var password = txtPws.Text.Trim();
            var extension = txtExc.Text.Trim();
            var sloch = txtSlocha.Text.Trim();
            int iSloch = 0;
            int.TryParse(sloch, out iSloch);
            


            dynamic utilites = Activator.CreateInstance(Type.GetTypeFromProgID("SmartBarClient.Client"));

            var number = txtPhone.Text.Trim();
            utilites.Init(true, true, false, username, password, extension, iSloch);
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
        Config _config;
        private void Form1_Load(object sender, EventArgs e)
        {
          
            

        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            host.Close();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            startToolStripMenuItem.Enabled = true;
            stopToolStripMenuItem.Enabled = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            host = new ServiceHost(typeof(CallerService));
            host.Open();
            btnStart.Enabled = false;
            startToolStripMenuItem.Enabled = false;
            stopToolStripMenuItem.Enabled = true;
            btnStop.Enabled = true;
            lblMessage.Text = "Service Started";
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            host.Close();
            btnStart.Enabled = true;
            startToolStripMenuItem.Enabled = true;
            stopToolStripMenuItem.Enabled = false;
            btnStop.Enabled = false;
            lblMessage.Text = "Service Stopped";
        }

        private void frmProprties_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;

                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _config.UserName = txtUser.Text;
            _config.Pws = txtPws.Text;
        }

        
    }
}
