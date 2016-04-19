namespace WindowsFormsOcx
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.axClient1 = new AxSmartBarClient.AxClient();
            this.axClient2 = new AxSmartBarClient.AxClient();
            ((System.ComponentModel.ISupportInitialize)(this.axClient1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axClient2)).BeginInit();
            this.SuspendLayout();
            // 
            // axClient1
            // 
            this.axClient1.Enabled = true;
            this.axClient1.Location = new System.Drawing.Point(83, 86);
            this.axClient1.Name = "axClient1";
            this.axClient1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axClient1.OcxState")));
            this.axClient1.Size = new System.Drawing.Size(115, 64);
            this.axClient1.TabIndex = 0;
            // 
            // axClient2
            // 
            this.axClient2.Enabled = true;
            this.axClient2.Location = new System.Drawing.Point(64, 35);
            this.axClient2.Name = "axClient2";
            this.axClient2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axClient2.OcxState")));
            this.axClient2.Size = new System.Drawing.Size(115, 64);
            this.axClient2.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.axClient2);
            this.Controls.Add(this.axClient1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axClient1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axClient2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxSmartBarClient.AxClient axClient1;
        private AxSmartBarClient.AxClient axClient2;
    }
}

