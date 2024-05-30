namespace RemoveBG_Desktop
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.PanelLoading = new System.Windows.Forms.Panel();
            this.ucAppMain1 = new RemoveBG_Desktop.UCAppMain();
            this.ucPythonNotFound2 = new RemoveBG_Desktop.UCPythonNotFound();
            this.ucPythonNotFound1 = new RemoveBG_Desktop.UCPythonNotFound();
            this.saaPreloader1 = new SaaUI.SaaPreloader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PanelLoading.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelLoading
            // 
            this.PanelLoading.BackColor = System.Drawing.Color.White;
            this.PanelLoading.Controls.Add(this.ucAppMain1);
            this.PanelLoading.Controls.Add(this.ucPythonNotFound2);
            this.PanelLoading.Controls.Add(this.ucPythonNotFound1);
            this.PanelLoading.Controls.Add(this.saaPreloader1);
            resources.ApplyResources(this.PanelLoading, "PanelLoading");
            this.PanelLoading.Name = "PanelLoading";
            // 
            // ucAppMain1
            // 
            this.ucAppMain1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.ucAppMain1, "ucAppMain1");
            this.ucAppMain1.ForeColor = System.Drawing.Color.Black;
            this.ucAppMain1.Name = "ucAppMain1";
            // 
            // ucPythonNotFound2
            // 
            this.ucPythonNotFound2.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.ucPythonNotFound2, "ucPythonNotFound2");
            this.ucPythonNotFound2.ForeColor = System.Drawing.Color.White;
            this.ucPythonNotFound2.Name = "ucPythonNotFound2";
            // 
            // ucPythonNotFound1
            // 
            this.ucPythonNotFound1.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.ucPythonNotFound1, "ucPythonNotFound1");
            this.ucPythonNotFound1.ForeColor = System.Drawing.Color.White;
            this.ucPythonNotFound1.Name = "ucPythonNotFound1";
            // 
            // saaPreloader1
            // 
            resources.ApplyResources(this.saaPreloader1, "saaPreloader1");
            this.saaPreloader1.BackColor = System.Drawing.Color.Transparent;
            this.saaPreloader1.DashCap = System.Drawing.Drawing2D.DashCap.Round;
            this.saaPreloader1.DashOffset = 0F;
            this.saaPreloader1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.saaPreloader1.LineEnd = System.Drawing.Drawing2D.LineCap.Round;
            this.saaPreloader1.LineStart = System.Drawing.Drawing2D.LineCap.Round;
            this.saaPreloader1.LoaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.saaPreloader1.LoaderWidth = 10;
            this.saaPreloader1.MaxAngle = 360;
            this.saaPreloader1.MinAngle = 0;
            this.saaPreloader1.Name = "saaPreloader1";
            this.saaPreloader1.Reverse = false;
            this.saaPreloader1.SpeedInMilliSeconds = 10;
            this.saaPreloader1.Start = true;
            this.saaPreloader1.StepDown = 4;
            this.saaPreloader1.StepUp = 4;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.PanelLoading);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.PanelLoading.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelLoading;
        private System.Windows.Forms.Panel panel1;
        private SaaUI.SaaPreloader saaPreloader1;
        private UCPythonNotFound ucPythonNotFound1;
        private UCPythonNotFound ucPythonNotFound2;
        private UCAppMain ucAppMain1;
    }
}

