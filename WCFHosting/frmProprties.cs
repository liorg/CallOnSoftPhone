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
using System.Threading;
using System.Net;
using System.IO;
namespace WCFHosting
{
    public partial class frmProprties : Form
    {

        public static ServiceHost host;

        public frmProprties()
        {
            _config = Config.GetSinglton();
            _config.SetRefresh(() =>
            {
                try
                {

                    MethodInvoker method = delegate
                    {
                        stopToolStripMenuItem.Enabled = false;
                        startToolStripMenuItem.Enabled = true;
                    };

                    if (Options.InvokeRequired)
                    {
                        BeginInvoke(method);
                    }
                    else
                    {
                        method.Invoke();
                    }

                }
                catch
                {


                }
                if (this.btnStart.InvokeRequired)
                {
                    this.btnStart.BeginInvoke((MethodInvoker)delegate()
                    {
                        this.btnStart.Enabled = true;

                    });
                }
                else
                    this.btnStart.Enabled = true;


                if (this.btnStop.InvokeRequired)
                {
                    this.btnStop.BeginInvoke((MethodInvoker)delegate()
                    {
                        this.btnStop.Enabled = false;

                    });
                }
                else
                    this.btnStop.Enabled = false;


                if (this.lblMessage.InvokeRequired)
                {
                    this.lblMessage.BeginInvoke((MethodInvoker)delegate()
                    {
                        this.lblMessage.Text = "Service Stopped";

                    });
                }
                else
                {
                    this.lblMessage.Text = "Service Stopped";
                }
            });
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


        public static void CallRestMethod(string url)
        {
            try
            {
                HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
                webrequest.Method = "GET";
                //  webrequest.ContentType = "application/x-www-form-urlencoded";

                using (HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse())
                {
                    Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
                    //StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
                    //string result = string.Empty;
                    //result = responseStream.ReadToEnd();
                    //webresponse.Close();
                }
            }
            catch { }

            // return result;
        }
        void TryOpenAgain()
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

        void TryCloseOtherProcess()
        {
            try
            {
                Process self = Process.GetCurrentProcess();
                foreach (Process p in Process.GetProcessesByName(self.ProcessName).Where(p => p.Id != self.Id))
                {
                    //MessageBox.Show("to be kill " + p.ProcessName);
                    p.Kill();
                }
            }

            catch (Exception ee)
            {
                MessageBox.Show("נוצרה שגיאה");
            }
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
                // יש חייגן בשימוש
                CallRestMethod("http://localhost:5884/CallerService/stop");
                TryOpenAgain();
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

        private void btnVersion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("version : 1.0.0.1");
        }

        private void frmProprties_FormClosing(object sender, FormClosingEventArgs e)
        {
            // e.Cancel = true;
            //Hide();
            if (e.CloseReason == CloseReason.UserClosing)
            {

                this.Hide();
                e.Cancel = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }




    }
}
