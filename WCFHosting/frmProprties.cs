using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using System.Diagnostics;

namespace WCFHosting
{
    public partial class frmProprties : Form
    {

        private ServiceHost host;
        public frmProprties()
        {
            _config = Config.GetSinglton();
            InitializeComponent();
            TryOpen();
        }


        void Message(bool isOpen)
        {
            if (isOpen)
            {
                startToolStripMenuItem.Enabled = false;
                stopToolStripMenuItem.Enabled = true;
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                lblMessage.Text = "Service Started";
            }
            else
            {
                startToolStripMenuItem.Enabled = true;
                stopToolStripMenuItem.Enabled = false;
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                lblMessage.Text = "Service Stopped";
            }
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
            TryOpen();

        }

        void TryOpen()
        {
            try
            {
                host = new ServiceHost(typeof(CallerService));
                host.Open();
                Message(true);
            }
            catch (System.ServiceModel.AddressAlreadyInUseException eAlready)
            {
                MessageBox.Show("יש חייגן בשימוש");
                Message(false);
            }
            catch (Exception ee)
            {
                MessageBox.Show("נוצרה שגיאה");
                Message(false);
            }
        }


        void TryClosed()
        {
            try
            {
                if (host != null)
                {
                    host.Close();
                    Message(false);
                }
            }

            catch (Exception ee)
            {
                MessageBox.Show("נוצרה שגיאה בסגירה");

            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            TryClosed();

        }
        Config _config;
        private void Form1_Load(object sender, EventArgs e)
        {



        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            TryClosed();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TryOpen();

        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TryClosed();

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
            this.BringToFront();
            this.Show();
            //this.WindowState = FormWindowState.Normal;
            //notifyIcon1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _config.UserName = txtUser.Text;
            _config.Pws = txtPws.Text;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.BringToFront();
            this.Show();
        }




    }
}
