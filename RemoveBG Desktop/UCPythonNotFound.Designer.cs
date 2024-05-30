namespace RemoveBG_Desktop
{
    partial class UCPythonNotFound
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.BtnsGetPython = new System.Windows.Forms.Panel();
            this.BtnGetPythonMsStore = new MaterialSkin.Controls.MaterialButton();
            this.BtnGetPythonWeb = new MaterialSkin.Controls.MaterialButton();
            this.BtnsGetPython.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Inter", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(587, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "This application requires Python to work";
            // 
            // BtnsGetPython
            // 
            this.BtnsGetPython.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnsGetPython.Controls.Add(this.BtnGetPythonWeb);
            this.BtnsGetPython.Controls.Add(this.BtnGetPythonMsStore);
            this.BtnsGetPython.Location = new System.Drawing.Point(21, 77);
            this.BtnsGetPython.Name = "BtnsGetPython";
            this.BtnsGetPython.Size = new System.Drawing.Size(754, 91);
            this.BtnsGetPython.TabIndex = 1;
            // 
            // BtnGetPythonMsStore
            // 
            this.BtnGetPythonMsStore.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BtnGetPythonMsStore.Depth = 0;
            this.BtnGetPythonMsStore.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnGetPythonMsStore.HighEmphasis = true;
            this.BtnGetPythonMsStore.Icon = null;
            this.BtnGetPythonMsStore.Location = new System.Drawing.Point(0, 0);
            this.BtnGetPythonMsStore.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BtnGetPythonMsStore.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnGetPythonMsStore.Name = "BtnGetPythonMsStore";
            this.BtnGetPythonMsStore.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BtnGetPythonMsStore.Size = new System.Drawing.Size(754, 36);
            this.BtnGetPythonMsStore.TabIndex = 1;
            this.BtnGetPythonMsStore.Text = "Download Python";
            this.BtnGetPythonMsStore.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BtnGetPythonMsStore.UseAccentColor = true;
            this.BtnGetPythonMsStore.UseVisualStyleBackColor = true;
            this.BtnGetPythonMsStore.Visible = false;
            this.BtnGetPythonMsStore.Click += new System.EventHandler(this.BtnGetPythonMsStore_Click);
            // 
            // BtnGetPythonWeb
            // 
            this.BtnGetPythonWeb.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BtnGetPythonWeb.Depth = 0;
            this.BtnGetPythonWeb.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnGetPythonWeb.HighEmphasis = true;
            this.BtnGetPythonWeb.Icon = null;
            this.BtnGetPythonWeb.Location = new System.Drawing.Point(0, 36);
            this.BtnGetPythonWeb.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BtnGetPythonWeb.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnGetPythonWeb.Name = "BtnGetPythonWeb";
            this.BtnGetPythonWeb.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BtnGetPythonWeb.Size = new System.Drawing.Size(754, 36);
            this.BtnGetPythonWeb.TabIndex = 2;
            this.BtnGetPythonWeb.Text = "Download Python";
            this.BtnGetPythonWeb.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BtnGetPythonWeb.UseAccentColor = true;
            this.BtnGetPythonWeb.UseVisualStyleBackColor = true;
            this.BtnGetPythonWeb.Visible = false;
            this.BtnGetPythonWeb.Click += new System.EventHandler(this.BtnGetPythonWeb_Click);
            // 
            // UCPythonNotFound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnsGetPython);
            this.Controls.Add(this.label1);
            this.Name = "UCPythonNotFound";
            this.Size = new System.Drawing.Size(793, 491);
            this.BtnsGetPython.ResumeLayout(false);
            this.BtnsGetPython.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel BtnsGetPython;
        private MaterialSkin.Controls.MaterialButton BtnGetPythonMsStore;
        private MaterialSkin.Controls.MaterialButton BtnGetPythonWeb;
    }
}
