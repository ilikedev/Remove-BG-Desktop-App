using MaterialSkin;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoveBG_Desktop
{
    public partial class UCPythonNotFound : UserControl
    {
        public UCPythonNotFound()
        {
            InitializeComponent();
            CheckDarkModeAndExecute();


            if (IsMicrosoftStoreInstalled())
            {
                BtnGetPythonWeb.Visible = false;
                BtnGetPythonMsStore.Visible = true;
            }
            else
            {
                BtnGetPythonMsStore.Visible = false;
                BtnGetPythonWeb.Visible = true;
            }


        }

        // Check Windows color mode
        private void CheckDarkModeAndExecute()
        {
            bool isDarkMode = IsWindowsInDarkMode();
            if (isDarkMode)
            {
                ExecuteDarkModeCode();
            }
            else
            {
                ExecuteLightModeCode();
            }
        }

        // Check if Windows is in Dark Mode.
        private bool IsWindowsInDarkMode()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize"))
                {
                    if (key != null)
                    {
                        object value = key.GetValue("AppsUseLightTheme");
                        if (value != null && value is int)
                        {
                            int useLightTheme = (int)value;
                            return useLightTheme == 0;
                        }
                    }
                }
            }
            catch (Exception)
            {}

            return false;
        }

        private void ExecuteDarkModeCode()
        {
            // Code to execute when in dark mode
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;
        }

        private void ExecuteLightModeCode()
        {
            // Code to execute when in light mode
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
        }

        private bool IsMicrosoftStoreInstalled()
        {
            string appFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Packages", "Microsoft.WindowsStore_8wekyb3d8bbwe");
            return Directory.Exists(appFolderPath);
        }

        private void BtnGetPythonMsStore_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("ms-windows-store://pdp/?productid=9PJPW5LDXLZ5");
            }
            catch (Exception)
            {
                string pythonDownloadUrl = "https://www.python.org/downloads/";
                Process.Start(new ProcessStartInfo("cmd", $"/c start {pythonDownloadUrl}") { CreateNoWindow = true });
            }
        }

        private void BtnGetPythonWeb_Click(object sender, EventArgs e)
        {
            string pythonDownloadUrl = "https://www.python.org/downloads/";
            Process.Start(new ProcessStartInfo("cmd", $"/c start {pythonDownloadUrl}") { CreateNoWindow = true });
        }
    }
}
