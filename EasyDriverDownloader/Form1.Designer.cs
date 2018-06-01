namespace EasyDriverDownloader
{
    partial class frmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.comboBoxVersion = new System.Windows.Forms.ComboBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblProgress = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lblOSVersion = new System.Windows.Forms.Label();
            this.notifyMessage = new System.Windows.Forms.NotifyIcon(this.components);
            this.lblCurrentDriverVer = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblNewVersionCheck = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxVersion
            // 
            this.comboBoxVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVersion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxVersion.FormattingEnabled = true;
            this.comboBoxVersion.Location = new System.Drawing.Point(120, 130);
            this.comboBoxVersion.Margin = new System.Windows.Forms.Padding(2, 10, 2, 10);
            this.comboBoxVersion.Name = "comboBoxVersion";
            this.comboBoxVersion.Size = new System.Drawing.Size(110, 21);
            this.comboBoxVersion.TabIndex = 1;
            this.comboBoxVersion.SelectedIndexChanged += new System.EventHandler(this.comboBoxVersion_SelectedIndexChanged);
            // 
            // btnDownload
            // 
            this.btnDownload.Enabled = false;
            this.btnDownload.Location = new System.Drawing.Point(120, 158);
            this.btnDownload.Margin = new System.Windows.Forms.Padding(2, 10, 2, 10);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(110, 23);
            this.btnDownload.TabIndex = 2;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.lblProgress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 193);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 14, 0);
            this.statusStrip1.Size = new System.Drawing.Size(347, 25);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = false;
            this.lblProgress.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(130, 20);
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(185, 19);
            // 
            // lblOSVersion
            // 
            this.lblOSVersion.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblOSVersion.Location = new System.Drawing.Point(2, 25);
            this.lblOSVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOSVersion.Name = "lblOSVersion";
            this.lblOSVersion.Size = new System.Drawing.Size(319, 24);
            this.lblOSVersion.TabIndex = 6;
            this.lblOSVersion.Text = "OS Version: ";
            this.lblOSVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // notifyMessage
            // 
            this.notifyMessage.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyMessage.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyMessage.Icon")));
            this.notifyMessage.Text = "Easy Driver Downloader";
            this.notifyMessage.Visible = true;
            this.notifyMessage.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyMessage_MouseDoubleClick);
            // 
            // lblCurrentDriverVer
            // 
            this.lblCurrentDriverVer.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCurrentDriverVer.Location = new System.Drawing.Point(2, 49);
            this.lblCurrentDriverVer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrentDriverVer.Name = "lblCurrentDriverVer";
            this.lblCurrentDriverVer.Size = new System.Drawing.Size(319, 24);
            this.lblCurrentDriverVer.TabIndex = 8;
            this.lblCurrentDriverVer.Text = "Current Driver Version: ";
            this.lblCurrentDriverVer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.lblNewVersionCheck);
            this.groupBox1.Controls.Add(this.lblCurrentDriverVer);
            this.groupBox1.Controls.Add(this.lblOSVersion);
            this.groupBox1.Location = new System.Drawing.Point(12, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 10, 2, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 10, 2, 10);
            this.groupBox1.Size = new System.Drawing.Size(323, 110);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "System Info";
            // 
            // lblNewVersionCheck
            // 
            this.lblNewVersionCheck.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNewVersionCheck.Location = new System.Drawing.Point(2, 73);
            this.lblNewVersionCheck.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNewVersionCheck.Name = "lblNewVersionCheck";
            this.lblNewVersionCheck.Size = new System.Drawing.Size(319, 24);
            this.lblNewVersionCheck.TabIndex = 9;
            this.lblNewVersionCheck.Text = "New Driver";
            this.lblNewVersionCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 218);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.comboBoxVersion);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 10, 2, 10);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.ShowInTaskbar = false;
            this.Text = "Easy Driver Downloader";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxVersion;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.Label lblOSVersion;
        private System.Windows.Forms.NotifyIcon notifyMessage;
        private System.Windows.Forms.Label lblCurrentDriverVer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblNewVersionCheck;
        private System.Windows.Forms.ToolStripStatusLabel lblProgress;
    }
}

