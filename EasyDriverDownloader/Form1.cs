using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Xml.Linq;
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

        private void button1_Click(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create("http://www.nvidia.de/Download/processFind.aspx?psid=101&pfid=817&osid=57&lid=9&whql=&lang=de&ctk=0");
            // Get the stream containing content returned by the server.
            Stream dataStream = request.GetResponse().GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();

            string url = "http://www.nvidia.de/Download/processFind.aspx?psid=101&pfid=817&osid=57&lid=9&whql=&lang=de&ctk=0";
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(url);

            // Get driver list with XPath	
            HtmlNodeCollection driverNodes = doc.DocumentNode.SelectNodes("//table/tr[@id='driverList']");
            driverList = new Dictionary<string, string>(driverNodes.Count);

            foreach(HtmlNode currentNode in driverNodes)
            {
                // Get all column nodes 
                HtmlNodeCollection tmpNodes = currentNode.SelectNodes(".//td");
                // Get Version Numbers and create the download Url
                string version = tmpNodes[2].InnerText;
                string driverUrl = string.Format("http://de.download.nvidia.com/Windows/{0}/{0}-desktop-win10-64bit-international-whql.exe",version);

                driverList.Add(version, driverUrl);               
            }

            // Add driverList to combobox and select first item
            comboBoxVersion.Items.AddRange(driverList.Keys.ToArray());
            comboBoxVersion.SelectedIndex = 0;
        }

        private void comboBoxVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            string driverUrl = driverList[comboBoxVersion.SelectedItem.ToString()];
            // Get the filename
            string filename = Path.GetFileName(driverUrl);

            // Create Download events and start Download
            client.DownloadFileCompleted += Client_DownloadFileCompleted;
            client.DownloadProgressChanged += Client_DownloadProgressChanged;
            client.DownloadFileAsync(new Uri(driverUrl),filename);
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Show Download progress
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download finished");
        }

    }
}
