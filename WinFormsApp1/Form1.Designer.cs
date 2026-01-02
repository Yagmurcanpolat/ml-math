namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnYukle = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnAnalizEt = new System.Windows.Forms.Button();
            this.txtSonuc = new System.Windows.Forms.RichTextBox();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnYukle
            // 
            this.btnYukle.Location = new System.Drawing.Point(12, 50);
            this.btnYukle.Name = "btnYukle";
            this.btnYukle.Size = new System.Drawing.Size(150, 35);
            this.btnYukle.TabIndex = 0;
            this.btnYukle.Text = "Resim Yükle";
            this.btnYukle.UseVisualStyleBackColor = true;
            this.btnYukle.Click += new System.EventHandler(this.btnYukle_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(12, 100);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(380, 400);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // btnAnalizEt
            // 
            this.btnAnalizEt.Enabled = false;
            this.btnAnalizEt.Location = new System.Drawing.Point(180, 50);
            this.btnAnalizEt.Name = "btnAnalizEt";
            this.btnAnalizEt.Size = new System.Drawing.Size(150, 35);
            this.btnAnalizEt.TabIndex = 2;
            this.btnAnalizEt.Text = "Analiz Et ve Çöz";
            this.btnAnalizEt.UseVisualStyleBackColor = true;
            this.btnAnalizEt.Click += new System.EventHandler(this.btnAnalizEt_Click);
            // 
            // txtSonuc
            // 
            this.txtSonuc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSonuc.Location = new System.Drawing.Point(410, 100);
            this.txtSonuc.Name = "txtSonuc";
            this.txtSonuc.ReadOnly = true;
            this.txtSonuc.Size = new System.Drawing.Size(570, 400);
            this.txtSonuc.TabIndex = 3;
            this.txtSonuc.Text = "";
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.Location = new System.Drawing.Point(12, 10);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(320, 30);
            this.lblBaslik.TabIndex = 4;
            this.lblBaslik.Text = "Matematik Sorusu Analiz ve Çözüm";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Tüm Dosyalar|*.*";
            this.openFileDialog.Title = "Matematik Sorusu Resmini Seçin";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 520);
            this.Controls.Add(this.lblBaslik);
            this.Controls.Add(this.txtSonuc);
            this.Controls.Add(this.btnAnalizEt);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.btnYukle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Matematik Sorusu Çözücü";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnYukle;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btnAnalizEt;
        private System.Windows.Forms.RichTextBox txtSonuc;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}
