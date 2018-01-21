using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.IO;
using HtmlAgilityPack;

namespace EasyDriverDownloader
{
    public partial class frmMain : Form
    {
        // Dictonary for the Driver Version and URL
        Dictionary<string, string> driverList;

        public frmMain()
        {
            InitializeComponent();
        }

        private void comboBoxVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDownload.Enabled = true;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                WebClient client = new WebClient();
                string driverUrl = driverList[comboBoxVersion.SelectedItem.ToString()];
                // Get the filename
                string filename = Path.GetFileName(driverUrl);

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
            // Show Download progress
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download finished");
            // Open current directory
            System.Diagnostics.Process.Start(".");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Get System info and changed URL for the current OS
             string OSid = CurrentOS();
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
                string driverUrl = string.Format("http://de.download.nvidia.com/Windows/{0}/{0}-desktop-win10-64bit-international-whql.exe", version);
                // Add to driveList directory
                driverList.Add(version, driverUrl);
            }
            // Add driverList to combobox and select first item
            comboBoxVersion.Items.AddRange(driverList.Keys.ToArray());
            comboBoxVersion.SelectedIndex = 0;
        }

        class OSInfo
        {
            public string OS { get; set; }
            public string Version { get; set; }
            public bool is64bit { get; set; }

            public void GetCurrentOS()
            {
                // Get current System info
                OS = Microsoft.DotNet.PlatformAbstractions.RuntimeEnvironment.OperatingSystem;
                // Environment.OSVersion.VersionString gives back the wrong Windows Version for Win 10 !?
                //string Version = Environment.OSVersion.VersionString;
                Version = Microsoft.DotNet.PlatformAbstractions.RuntimeEnvironment.OperatingSystemVersion;
                is64bit = Environment.Is64BitOperatingSystem;
            }
        }

        private string CurrentOS()
        {
            OSInfo osInfo = new OSInfo();
            osInfo.GetCurrentOS();

            if (string.Equals(osInfo.OS, "Windows"))
            {
                // Shorten Version string so we only need to check the first digit
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

    }
}
