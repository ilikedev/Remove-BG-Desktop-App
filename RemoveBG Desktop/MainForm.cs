using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RemoveBG_Desktop
{
    public partial class MainForm : Form
    {
        const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
        const int DWMWA_CAPTION_COLOR = 35;
        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);


        public static string ApiKey { get; } = "";



        public MainForm()
        {
            InitializeComponent();
        }

        private void CheckAll()
        {
            // Check the API key
            if (ApiKey == "")
            {
                MessageBox.Show("API Key Not Found", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Check Python
            if (!IsPythonInstalled())
            {
                ucPythonNotFound1.Visible = true;
            }
            else
            {
                ucAppMain1.Visible = true;
            }

            // Check Windows color mode
            CheckDarkModeAndExecute();
        }

        // Check The Python Installation
        private bool IsPythonInstalled()
        {
            return IsPythonInstalledByCommand("where python") || IsPythonInstalledByCommand("where python3");
        }

        private bool IsPythonInstalledByCommand(string command)
        {
            try
            {
                ProcessStartInfo start = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c {command}",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(start))
                {
                    using (StreamReader reader = process.StandardOutput)
                    {
                        string result = reader.ReadToEnd();
                        if (string.IsNullOrEmpty(result))
                        {
                            using (StreamReader errorReader = process.StandardError)
                            {
                                result = errorReader.ReadToEnd();
                            }
                        }
                        process.WaitForExit();
                        return !string.IsNullOrEmpty(result) && result.ToLower().Contains("python");
                    }
                }
            }
            catch
            {
                return false;
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
            catch (Exception ex)
            {
                MessageBox.Show("Error reading registry: " + ex.Message);
            }

            return false;
        }

        private void ExecuteDarkModeCode()
        {
            // Code to execute when in dark mode
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;

            int darkMode = 1; // Enable dark mode
            DwmSetWindowAttribute(this.Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref darkMode, sizeof(int));

            // Set the custom title bar color
            int color = ColorTranslator.ToWin32(Color.Black); // Convert Color to Win32 color
            DwmSetWindowAttribute(this.Handle, DWMWA_CAPTION_COLOR, ref color, sizeof(int));

            ucAppMain1.BackColor = Color.Black;
            ucAppMain1.ForeColor = Color.White;

            PanelLoading.BackColor = Color.Black;


        }

        private void ExecuteLightModeCode()
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CheckAll();
            ucPythonNotFound1.Visible = true;
        }


    }
}
