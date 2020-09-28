using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenshinCleaner
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var serviceName = "mhyprot2";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var path = folderBrowserDialog.SelectedPath;
                    Utility.CreateDirectory(Application.StartupPath + @"\backup");
                    Utility.DeleteService(serviceName);
                    Utility.MoveFile(path + $@"\{serviceName}.sys", Application.StartupPath + $@"\backup\{serviceName}.sys");
                    MessageBox.Show($"{serviceName} is sucessfully removed.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An exception occurred.");
                    MessageBox.Show(ex.StackTrace);
                }
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            var serviceName = "mhyprot2";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var path = folderBrowserDialog.SelectedPath;
                    Utility.CreateDirectory(Application.StartupPath + @"\backup");
                    Utility.MoveFile(Application.StartupPath + $@"\backup\{serviceName}.sys", path + $@"\{serviceName}.sys");
                    Utility.InstallService(path + $@"\{serviceName}.sys");
                    MessageBox.Show($"{serviceName} is sucessfully restored.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An exception occurred.");
                    MessageBox.Show(ex.StackTrace);
                }
            }
        }
    }
}
