namespace RemoveBG_Desktop
{
    partial class UCAppMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCAppMain));
            this.BoxDragAndDrop = new SaaUI.SaaPanel();
            this.PanelImgViewer = new System.Windows.Forms.Panel();
            this.InProcessingPicBox = new System.Windows.Forms.PictureBox();
            this.BtnsFinishedActions = new System.Windows.Forms.Panel();
            this.FinishedSave = new MaterialSkin.Controls.MaterialButton();
            this.FinishedCopy = new MaterialSkin.Controls.MaterialButton();
            this.BoxDragNDrop = new SaaUI.SaaLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.outpoutimgpath = new System.Windows.Forms.TextBox();
            this.materialDrawer1 = new MaterialSkin.Controls.MaterialDrawer();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.BoxDragAndDrop.SuspendLayout();
            this.PanelImgViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InProcessingPicBox)).BeginInit();
            this.BtnsFinishedActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // BoxDragAndDrop
            // 
            this.BoxDragAndDrop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BoxDragAndDrop.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.BoxDragAndDrop.BackColorAngle = 90F;
            this.BoxDragAndDrop.Border = 0;
            this.BoxDragAndDrop.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.BoxDragAndDrop.BorderColor2 = System.Drawing.Color.LightSkyBlue;
            this.BoxDragAndDrop.BorderColorAngle = 0;
            this.BoxDragAndDrop.ColorType = SaaUI.PanelColorType.Default;
            this.BoxDragAndDrop.Controls.Add(this.PanelImgViewer);
            this.BoxDragAndDrop.Controls.Add(this.BoxDragNDrop);
            this.BoxDragAndDrop.EnableDoubleBuffering = true;
            this.BoxDragAndDrop.ForceDrawRegion = true;
            resources.ApplyResources(this.BoxDragAndDrop, "BoxDragAndDrop");
            this.BoxDragAndDrop.Name = "BoxDragAndDrop";
            this.BoxDragAndDrop.Radius.BottomLeft = 20;
            this.BoxDragAndDrop.Radius.BottomRight = 20;
            this.BoxDragAndDrop.Radius.TopLeft = 20;
            this.BoxDragAndDrop.Radius.TopRight = 20;
            this.BoxDragAndDrop.Transparence = 100;
            // 
            // PanelImgViewer
            // 
            this.PanelImgViewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PanelImgViewer.BackgroundImage = global::RemoveBG_Desktop.Properties.Resources.png32;
            this.PanelImgViewer.Controls.Add(this.InProcessingPicBox);
            this.PanelImgViewer.Controls.Add(this.BtnsFinishedActions);
            resources.ApplyResources(this.PanelImgViewer, "PanelImgViewer");
            this.PanelImgViewer.Name = "PanelImgViewer";
            // 
            // InProcessingPicBox
            // 
            resources.ApplyResources(this.InProcessingPicBox, "InProcessingPicBox");
            this.InProcessingPicBox.Name = "InProcessingPicBox";
            this.InProcessingPicBox.TabStop = false;
            // 
            // BtnsFinishedActions
            // 
            this.BtnsFinishedActions.Controls.Add(this.FinishedSave);
            this.BtnsFinishedActions.Controls.Add(this.FinishedCopy);
            resources.ApplyResources(this.BtnsFinishedActions, "BtnsFinishedActions");
            this.BtnsFinishedActions.Name = "BtnsFinishedActions";
            // 
            // FinishedSave
            // 
            resources.ApplyResources(this.FinishedSave, "FinishedSave");
            this.FinishedSave.BackColor = System.Drawing.Color.Transparent;
            this.FinishedSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.FinishedSave.Depth = 0;
            this.FinishedSave.HighEmphasis = true;
            this.FinishedSave.Icon = null;
            this.FinishedSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.FinishedSave.Name = "FinishedSave";
            this.FinishedSave.NoAccentTextColor = System.Drawing.Color.Empty;
            this.FinishedSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.FinishedSave.UseAccentColor = false;
            this.FinishedSave.UseVisualStyleBackColor = false;
            this.FinishedSave.Click += new System.EventHandler(this.FinishedSave_Click);
            // 
            // FinishedCopy
            // 
            resources.ApplyResources(this.FinishedCopy, "FinishedCopy");
            this.FinishedCopy.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.FinishedCopy.Depth = 0;
            this.FinishedCopy.HighEmphasis = true;
            this.FinishedCopy.Icon = null;
            this.FinishedCopy.MouseState = MaterialSkin.MouseState.HOVER;
            this.FinishedCopy.Name = "FinishedCopy";
            this.FinishedCopy.NoAccentTextColor = System.Drawing.Color.Empty;
            this.FinishedCopy.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.FinishedCopy.UseAccentColor = false;
            this.FinishedCopy.UseVisualStyleBackColor = true;
            this.FinishedCopy.Click += new System.EventHandler(this.FinishedCopy_Click);
            // 
            // BoxDragNDrop
            // 
            this.BoxDragNDrop.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.BoxDragNDrop, "BoxDragNDrop");
            this.BoxDragNDrop.ForeColor = System.Drawing.Color.Gray;
            this.BoxDragNDrop.Name = "BoxDragNDrop";
            this.BoxDragNDrop.DragDrop += new System.Windows.Forms.DragEventHandler(this.BoxDragNDrop_DragDrop);
            this.BoxDragNDrop.DragEnter += new System.Windows.Forms.DragEventHandler(this.BoxDragNDrop_DragEnter);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // textBoxFilePath
            // 
            resources.ApplyResources(this.textBoxFilePath, "textBoxFilePath");
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.TabStop = false;
            // 
            // outpoutimgpath
            // 
            resources.ApplyResources(this.outpoutimgpath, "outpoutimgpath");
            this.outpoutimgpath.Name = "outpoutimgpath";
            this.outpoutimgpath.TabStop = false;
            // 
            // materialDrawer1
            // 
            this.materialDrawer1.AutoHide = false;
            this.materialDrawer1.AutoShow = false;
            this.materialDrawer1.BackgroundWithAccent = false;
            this.materialDrawer1.BaseTabControl = null;
            this.materialDrawer1.Depth = 0;
            this.materialDrawer1.HighlightWithAccent = true;
            this.materialDrawer1.IndicatorWidth = 0;
            this.materialDrawer1.IsOpen = false;
            resources.ApplyResources(this.materialDrawer1, "materialDrawer1");
            this.materialDrawer1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDrawer1.Name = "materialDrawer1";
            this.materialDrawer1.ShowIconsWhenHidden = false;
            this.materialDrawer1.UseColors = false;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "png";
            this.saveFileDialog.DereferenceLinks = false;
            resources.ApplyResources(this.saveFileDialog, "saveFileDialog");
            this.saveFileDialog.InitialDirectory = "%USERPROFILE%/Images";
            this.saveFileDialog.SupportMultiDottedExtensions = true;
            // 
            // UCAppMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.materialDrawer1);
            this.Controls.Add(this.outpoutimgpath);
            this.Controls.Add(this.textBoxFilePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BoxDragAndDrop);
            this.Name = "UCAppMain";
            this.BoxDragAndDrop.ResumeLayout(false);
            this.PanelImgViewer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InProcessingPicBox)).EndInit();
            this.BtnsFinishedActions.ResumeLayout(false);
            this.BtnsFinishedActions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SaaUI.SaaPanel BoxDragAndDrop;
        private SaaUI.SaaLabel BoxDragNDrop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PanelImgViewer;
        private System.Windows.Forms.PictureBox InProcessingPicBox;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.TextBox outpoutimgpath;
        private MaterialSkin.Controls.MaterialDrawer materialDrawer1;
        private System.Windows.Forms.Panel BtnsFinishedActions;
        private MaterialSkin.Controls.MaterialButton FinishedSave;
        private MaterialSkin.Controls.MaterialButton FinishedCopy;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}
