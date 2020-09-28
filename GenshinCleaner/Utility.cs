using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration.Install;

namespace GenshinCleaner
{
    public static class Utility
    {
        public static bool CreateDirectory(string path) 
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return Directory.Exists(path);
        }

        public static void InstallService(string serviceName)
        {
            ManagedInstallerClass.InstallHelper(new string[] { serviceName });
        } 

        public static void DeleteService(string serviceName)
        {
            ManagedInstallerClass.InstallHelper(new string[] { "/u", serviceName });
        }

        public static bool MoveFile(string source, string dest)
        {
            if (File.Exists(source))
            {
                File.Move(source, dest);
            }
            return File.Exists(dest);
        }
    }
}
