using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Shapes;

namespace RemoveBG_Desktop
{
    public partial class UCAppMain : UserControl
    {
        private string imagePath;
        private bool isDragging = false;
        private Point originalPosition;
        private string filePath;
        private string ApiManagerPath = "Temp/TempOutput/ApiManager.py";
        string apiKey = MainForm.ApiKey;
        string tempSaveFilePath;

        public UCAppMain()
        {
            InitializeComponent();
            CheckDarkModeAndExecute();

            BoxDragNDrop.AllowDrop = true;
            BoxDragNDrop.DragEnter += BoxDragNDrop_DragEnter;
            BoxDragNDrop.DragDrop += BoxDragNDrop_DragDrop;
        }

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
            catch (Exception) { }

            return false;
        }

        private void ExecuteDarkModeCode()
        {
            this.BackColor = System.Drawing.Color.Black;
            this.ForeColor = System.Drawing.Color.White;
            PanelImgViewer.BackColor = System.Drawing.Color.FromArgb(31, 31, 31);
            BtnsFinishedActions.BackColor = System.Drawing.Color.FromArgb(31, 31, 31);
            BoxDragNDrop.BackColor = System.Drawing.Color.FromArgb(31, 31, 31);
            BoxDragAndDrop.BackColor = System.Drawing.Color.FromArgb(31, 31, 31);
        }

        private void ExecuteLightModeCode()
        {
            this.BackColor = System.Drawing.Color.White;
            this.ForeColor = System.Drawing.Color.Black;
            BoxDragNDrop.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            PanelImgViewer.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            BtnsFinishedActions.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            BoxDragAndDrop.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
        }

        private void BoxDragNDrop_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void BoxDragNDrop_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length == 1)
            {
                textBoxFilePath.Text = files[0];
                InProcessingPicBox.Image = Image.FromFile(textBoxFilePath.Text);
                PythonProcess();
                PanelImgViewer.Visible = true;
            }
            else
            {
                MessageBox.Show("Please drop only one file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PythonProcess()
        {


            if (string.IsNullOrEmpty(textBoxFilePath.Text))
            {
                MessageBox.Show("Please select a source file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            string tempSaveFilePath = System.IO.Path.Combine("tempout.png");

            ExecutePythonScript(textBoxFilePath.Text, tempSaveFilePath, apiKey);

            if (File.Exists(tempSaveFilePath))
            {
                Image tempImage = Image.FromFile(tempSaveFilePath);
                InProcessingPicBox.Image = tempImage;
                InProcessingPicBox.BackColor = System.Drawing.Color.Transparent;
                outpoutimgpath.Text = tempSaveFilePath;
            }
            else
            {
                MessageBox.Show("An error occurred while processing the image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PanelImgViewer.Visible = false;
            }
        }

        private void ExecutePythonScript(string imagePath, string tempSaveFilePath, string apiKey)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python";
            start.Arguments = $"\"{ApiManagerPath}\" \"{textBoxFilePath.Text}\" \"{tempSaveFilePath}\" \"{apiKey}\"";
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.RedirectStandardError = true;
            start.CreateNoWindow = true;

            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.Write(result);
                }
                using (StreamReader reader = process.StandardError)
                {
                    string error = reader.ReadToEnd();
                    if (!string.IsNullOrEmpty(error))
                    {
                    }
                }
            }
        }

        private void FinishedSave_Click(object sender, EventArgs e)
        {
            string sourceFilePath = outpoutimgpath.Text;
            string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(textBoxFilePath.Text);
            saveFileDialog.FileName = fileNameWithoutExtension;

            if (!File.Exists(sourceFilePath))
            {
                MessageBox.Show("The output image file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string destinationFilePath = saveFileDialog.FileName;
                    File.Copy(sourceFilePath, destinationFilePath, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FinishedCopy_Click(object sender, EventArgs e)
        {
            string imagePath = outpoutimgpath.Text;

            try
            {
                using (Bitmap bitmap = new Bitmap(imagePath))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        ms.Seek(0, SeekOrigin.Begin);

                        DataObject dataObject = new DataObject();
                        dataObject.SetData("PNG", true, ms);

                        Clipboard.SetDataObject(dataObject, true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error copying image to clipboard: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
