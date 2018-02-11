using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.IO;
using HtmlAgilityPack;
using System.Drawing;
using System.Management;

namespace EasyDriverDownloader
{
    public partial class frmMain : Form
    {
        // Dictonary for the Driver Version and URL
        private Dictionary<string, string> driverList;
        private string filename;

        public frmMain()
        {
            InitializeComponent();
        }

        private void comboBoxVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDownload.Enabled = true;
        }
        WebClient client;
        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                client = new WebClient();
                string driverUrl = driverList[comboBoxVersion.SelectedItem.ToString()];
                // Get the filename
                filename = Path.GetFileName(driverUrl);

                // Create Download events and start asynchron Download
                client.DownloadFileCompleted += Client_DownloadFileCompleted;
                client.DownloadProgressChanged += Client_DownloadProgressChanged;
                client.DownloadFileAsync(new Uri(driverUrl), filename);
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                // Show Download progress
                toolStripProgressBar.Value = e.ProgressPercentage;
                lblProgress.Text = string.Format("Download: {0}%", e.ProgressPercentage);
            }
            catch (Exception)
            {
                // In case the user kills the application
                client.CancelAsync();
                //Application.ExitThread();
            }
        }

        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                //cleanup delete partial file
                File.Delete(filename);
                client.Dispose();
                return;
            }

            // Show Notify Message in taskbar
            NotifyIcon notifyMessage = new NotifyIcon();
            notifyMessage.Icon = SystemIcons.Application;
            notifyMessage.Visible = true;
            notifyMessage.ShowBalloonTip(8000, "Download finished", "The Nvidia Setup file was download.\nClick to Install Driver.", ToolTipIcon.Info);
            notifyMessage.BalloonTipClicked += NotifyMessage_BalloonTipClicked;
        }

        private void NotifyMessage_BalloonTipClicked(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\" + filename);
            }
            catch (Exception)
            {
                // User didnt allow admin rights
            }         
        }          

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Get System info and changed URL for the current OS
            OSInfo osInfo = OSInfo.Instance;
            lblOSVersion.Text += string.Format("{0} {1} - {2}", osInfo.OS, osInfo.Version, (osInfo.is64bit ? "64bit" : "32bit"));
            lblCurrentDriverVer.Text += GPUInfo.Instance.currentGPUVersion;
            string OSid = GetOSId(osInfo);

            // osid = Which OS
            string url = string.Format("http://www.nvidia.de/Download/processFind.aspx?psid=101&pfid=817&osid={0}&lid=9&whql=&lang=de&ctk=0",OSid);
            HtmlAgilityPack.HtmlDocument doc = new HtmlWeb().Load(url);

            // Get driver list with XPath	
            HtmlNodeCollection driverNodes = doc.DocumentNode.SelectNodes("//table/tr[@id='driverList']");
            driverList = new Dictionary<string, string>(driverNodes.Count);

            foreach (HtmlNode currentNode in driverNodes)
            {
                // Get all column nodes
                HtmlNodeCollection tmpNodes = currentNode.SelectNodes(".//td");
                // Get Version Numbers and create the download Url
                string version = tmpNodes[2].InnerText;
                string driverUrl = string.Format("http://de.download.nvidia.com/Windows/{0}/{0}-desktop-win10-{1}-international-whql.exe", version, OSInfo.Instance.is64bit ? "64bit" : "32bit");
                // Add to driveList directory
                driverList.Add(version, driverUrl);
            }
            // Add driverList to combobox and select first item
            comboBoxVersion.Items.AddRange(driverList.Keys.ToArray());
            comboBoxVersion.SelectedIndex = 0;

            Version currentVersion = new Version(GPUInfo.Instance.currentGPUVersion);
            Version newestVersion = new Version(driverList.Keys.ToArray()[0]);

            if(currentVersion.CompareTo(newestVersion) < 0 )
            {
                lblNewVersionCheck.Text = "New Nvidia Driver Version " + newestVersion.ToString() + " available.";
            }
            else
            {
                lblNewVersionCheck.Text = "Newest Nvidia Driver already installed";
            }
        }
                
        private string GetOSId(OSInfo osInfo)
        {
            if (string.Equals(osInfo.OS, "Windows"))
            {
                string versionShort = osInfo.Version.Substring(0, osInfo.Version.IndexOf('.'));
                switch ( versionShort)
                {
                    case "10":  return "57";
                    case "8":   return "41";
                    case "7":   return "19";
                    default:
                        break;
                }
            }
            return string.Empty;
        }

        private void notifyMessage_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string HH;
        }
    }
}
