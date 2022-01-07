
namespace App_PhotoVacances
{
    partial class form_Viewer
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.openFileDialog_1 = new System.Windows.Forms.OpenFileDialog();
            this.listView_Picture = new System.Windows.Forms.ListView();
            this.imageList_1 = new System.Windows.Forms.ImageList(this.components);
            this.lbl_SelectFile = new System.Windows.Forms.Label();
            this.btn_SelectFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.openFileDialog_1.FileName = "openFileDialog1";
            this.openFileDialog_1.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            this.listView_Picture.HideSelection = false;
            this.listView_Picture.LargeImageList = this.imageList_1;
            this.listView_Picture.Location = new System.Drawing.Point(12, 96);
            this.listView_Picture.Name = "listView_Picture";
            this.listView_Picture.Size = new System.Drawing.Size(728, 450);
            this.listView_Picture.TabIndex = 22;
            this.listView_Picture.UseCompatibleStateImageBehavior = false;
            this.imageList_1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList_1.ImageSize = new System.Drawing.Size(100, 100);
            this.imageList_1.TransparentColor = System.Drawing.Color.Transparent;
            this.lbl_SelectFile.AutoSize = true;
            this.lbl_SelectFile.Location = new System.Drawing.Point(12, 9);
            this.lbl_SelectFile.Name = "lbl_SelectFile";
            this.lbl_SelectFile.Size = new System.Drawing.Size(128, 13);
            this.lbl_SelectFile.TabIndex = 21;
            this.lbl_SelectFile.Text = "Pas de fichier selectionné";
            this.btn_SelectFile.Location = new System.Drawing.Point(35, 55);
            this.btn_SelectFile.Name = "btn_SelectFile";
            this.btn_SelectFile.Size = new System.Drawing.Size(75, 23);
            this.btn_SelectFile.TabIndex = 20;
            this.btn_SelectFile.Text = "Ajouter";
            this.btn_SelectFile.UseVisualStyleBackColor = true;
            this.btn_SelectFile.Click += new System.EventHandler(this.btn_SelectFile_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 555);
            this.Controls.Add(this.btn_SelectFile);
            this.Controls.Add(this.lbl_SelectFile);
            this.Controls.Add(this.listView_Picture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "form_Viewer";
            this.Text = "Visionneuse";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog_1;
        private System.Windows.Forms.ListView listView_Picture;
        private System.Windows.Forms.Label lbl_SelectFile;
        private System.Windows.Forms.Button btn_SelectFile;
        public System.Windows.Forms.ImageList imageList_1;
    }
}

