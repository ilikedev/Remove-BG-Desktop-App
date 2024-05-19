using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace RemoveBG
{
    public partial class MainForm : Form
    {

        private string ApiManagerPath = "BackRemover/BGRemover.py";
        private string initialFilePath;
        private string apiKey = "";  
        public MainForm()
        {
            InitializeComponent();
            ConfigureDragAndDrop();
            CenterButton();


            if (apiKey == "")
            {
                MessageBox.Show("Cette application ne peut pas fonctionner car la clé API n'est pas présente dans le code! Sans cette clé, cette application ne peut pas être autorisée à accéder au service Remove.bg (service servant à supprimer les arrière plan de vos images).", "Erreur liée à la clé API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void BoxDragDropnrml()
        {
            int newHeight = 519;
            BoxDragAndDrop.Height = newHeight;
        }

        private  void BoxDragDropfs()
        {
            int newHeight = 560;
            BoxDragAndDrop.Height = newHeight;
        }

        private void ConfigureDragAndDrop()
        {
            BoxDragAndDrop.AllowDrop = true;
            BoxDragAndDrop.DragEnter += new DragEventHandler(BoxDragAndDrop_DragEnter);
            BoxDragAndDrop.DragDrop += new DragEventHandler(BoxDragAndDrop_DragDrop);
        }

        private void BoxDragAndDrop_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0)
                {
                    InitialImagePath.Text = files[0];
                    LoadImage(files[0]);
                }
            }
        }

        private void LoadImage(string filePath)
        {
            try
            {
                Image image = Image.FromFile(filePath);
                ImgInitial.Image = image;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement de l'image : {ex.Message}");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            

            if (!IsPythonInstalled())
            {   
                if (IsMicrosoftStoreInstalled())
                {
                    PopUpWinNT10PyNotFound.Visible = true;
                    PopUpWinNT6xPyNotFound.Visible = true;
                }
                else
                {
                    PopUpWinNT6xPyNotFound.Visible = true;
                }
            }
            else
            {
                AppBox.Visible = true;
                BoxDragDropfs();
            }
        }

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

        private bool IsMicrosoftStoreInstalled()
        {
            string appFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Packages", "Microsoft.WindowsStore_8wekyb3d8bbwe");
            return Directory.Exists(appFolderPath);
        }

        private void OpenMicrosoftStore()
        {
            try
            {
                Process.Start("ms-windows-store://pdp/?productid=9PJPW5LDXLZ5");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Impossible d'ouvrir le Microsoft Store : {ex.Message}");
                OpenPythonDownloadPage();
            }
        }

        private void OpenPythonDownloadPage()
        {
            string pythonDownloadUrl = "https://www.python.org/downloads/";
            Process.Start(new ProcessStartInfo("cmd", $"/c start {pythonDownloadUrl}") { CreateNoWindow = true });
        }

        private void BtnInstallPyWeb_Click(object sender, EventArgs e)
        {
            OpenPythonDownloadPage();
        }

        private void BtnRestartApp_Click(object sender, EventArgs e)
        {

        }

        private void saaLine1_Load(object sender, EventArgs e)
        {

        }

        private void BtnGetPyMSStore_Click(object sender, EventArgs e)
        {
            OpenMicrosoftStore();
        }

        private void BoxDragAndDrop_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void InitialImagePath_TextChanged(object sender, EventArgs e)
        {
            if (InitialImagePath.Text == "")
            {
                BtnFirstNext.Visible = false;
                BtnCancelImport.Visible = false;
                filename.Visible = false;
                BoxDragDropfs();
            }
            else
            {
                BoxDragDropnrml();
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(InitialImagePath.Text);
                filename.Text = fileNameWithoutExtension + " va être importé";
                BtnFirstNext.Visible = true;
                BtnCancelImport.Visible = true;
                filename.Visible = true;
                initialFilePath = InitialImagePath.Text;
            }
        }

        private void CenterButton()
        {
            int containerWidth = BoxCenterBtnRmvBg.Width;
            int containerHeight = BoxCenterBtnRmvBg.Height;

            int buttonWidth = BtnRmvBg.Width;
            int buttonHeight = BtnRmvBg.Height;

            int centeredX = (containerWidth - buttonWidth) / 2;
            int centeredY = (containerHeight - buttonHeight) / 2;

            BtnRmvBg.Location = new Point(centeredX, centeredY);
        }

        

        private void BtnFirstNext_Click(object sender, EventArgs e)
        {
            ImgInitial.Image = Image.FromFile(InitialImagePath.Text);
            BoxCenterImg.Visible = true;
            BtnFirstNext.Visible = false;
            BtnCancelImport.Visible = false;
            filename.Visible = false;
            BoxDragDropfs();
            BoxDragAndDrop.Visible = false;
            BoxDragAndDrop.Visible = true;

            string directoryPath = @"Temp";

            try
            {
                // Supprimer le contenu du dossier
                foreach (string file in Directory.GetFiles(directoryPath))
                {
                    File.Delete(file);
                }
                foreach (string dir in Directory.GetDirectories(directoryPath))
                {
                    Directory.Delete(dir, true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
            }
        }

        private void BtnCancelImport_Click(object sender, EventArgs e)
        {
            InitialImagePath.Clear();
        }

        private void BtnRmvBg_Click(object sender, EventArgs e)
        {
            Loading.Visible = true;
            BoxCenterBtnRmvBg.Visible = false;
            

                            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(InitialImagePath.Text);

            if (string.IsNullOrEmpty(initialFilePath))
            {
                MessageBox.Show("Please select a source file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string tempSaveFilePath = "Temp/" + fileNameWithoutExtension + ".png";

            ExecutePythonScript(initialFilePath, tempSaveFilePath, apiKey);

            if (File.Exists(tempSaveFilePath))
            {
                Image tempImage = Image.FromFile(tempSaveFilePath);
                ImgInitial.Image = tempImage;
                BoxCenterImg.BackgroundImage = (RemoveBG.Properties.Resources.png32);
                outpoutimgpath.Text = tempSaveFilePath;
                BoxDragDropnrml();
                BoxFinishedAction.Visible = true;
            }
            else
            {
                MessageBox.Show("Erreur lors de la génération de l'image.");
            }
        }

        private void ExecutePythonScript(string initialFilePath, string tempSaveFilePath, string apiKey)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python";
            start.Arguments = $"\"{ApiManagerPath}\" \"{initialFilePath}\" \"{tempSaveFilePath}\" \"{apiKey}\"";
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
                        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void saaPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnCopyOutput_Click(object sender, EventArgs e)
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
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSaveOutPutImage_Click(object sender, EventArgs e)
        {
            string sourceFilePath = outpoutimgpath.Text;

            if (!File.Exists(sourceFilePath))
            {
                MessageBox.Show("Le fichier source n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Fichiers PNG (*.png)|*.png|Tous les fichiers (*.*)|*.*",
                Title = "Enregistrer l'image sous"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string destinationFilePath = saveFileDialog.FileName;

                    File.Copy(sourceFilePath, destinationFilePath, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la copie du fichier : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}