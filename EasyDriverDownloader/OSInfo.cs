using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDriverDownloader
{
    public sealed class OSInfo
    {
        private static readonly OSInfo _instance = new OSInfo();

        public string OS { get; }
        public string Version { get; }
        public bool is64bit { get; }

        private OSInfo()
        {
            // Get current System info 
            OS = Microsoft.DotNet.PlatformAbstractions.RuntimeEnvironment.OperatingSystem;
            // Environment.OSVersion.VersionString gives back the wrong Windows Version for Win 10 !?
            //string Version = Environment.OSVersion.VersionString;
            Version = Microsoft.DotNet.PlatformAbstractions.RuntimeEnvironment.OperatingSystemVersion;
            is64bit = Environment.Is64BitOperatingSystem;
        }

        public static OSInfo Instance
        {
            get
            {
                return _instance;
            }
        }
  
    }
}
