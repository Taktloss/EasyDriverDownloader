using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace EasyDriverDownloader
{
    sealed class GPUInfo
    {
        private static readonly GPUInfo _instance = new GPUInfo();
        public string currentGPUVersion { get; }
        
        private GPUInfo()
        {
            //The Win32_VideoController WMI class represents the capabilities and management capacity of the video controller on a computer system running Windows.
            // more info here https://msdn.microsoft.com/en-us/library/aa394512(v=vs.85).aspx
            // https://www.microsoft.com/en-us/download/details.aspx?id=8572
            ManagementObjectCollection objCollection = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController").Get();

            foreach (ManagementObject obj in objCollection)
            {
                if (obj["Description"].ToString().ToLower().Contains("nvidia"))
                {
                    string info = String.Format("Description='{0}',DriverVersion='{1}' ", obj["Description"], obj["DriverVersion"]);
                    currentGPUVersion = obj["DriverVersion"].ToString().Replace(".", string.Empty).Substring(5);
                    currentGPUVersion = currentGPUVersion.Substring(0, 3) + "." + currentGPUVersion.Substring(3);
                }
            }
        }

        public static GPUInfo Instance
        {
            get
            {
                return _instance;
            }
        }

    }
}
