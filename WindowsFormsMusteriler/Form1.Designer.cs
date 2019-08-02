namespace WindowsFormsMusteriler
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnKayitEkle = new System.Windows.Forms.Button();
            this.btnKayitSil = new System.Windows.Forms.Button();
            this.btnKayitGuncelle = new System.Windows.Forms.Button();
            this.btnKayitAra = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnKayitEkle
            // 
            this.btnKayitEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKayitEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKayitEkle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnKayitEkle.Image = ((System.Drawing.Image)(resources.GetObject("btnKayitEkle.Image")));
            this.btnKayitEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKayitEkle.Location = new System.Drawing.Point(38, 102);
            this.btnKayitEkle.Name = "btnKayitEkle";
            this.btnKayitEkle.Size = new System.Drawing.Size(152, 51);
            this.btnKayitEkle.TabIndex = 0;
            this.btnKayitEkle.Text = "Kayıt Ekle";
            this.btnKayitEkle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKayitEkle.UseVisualStyleBackColor = true;
            this.btnKayitEkle.Click += new System.EventHandler(this.BtnKayitEkle_Click);
            // 
            // btnKayitSil
            // 
            this.btnKayitSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKayitSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKayitSil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnKayitSil.Image = ((System.Drawing.Image)(resources.GetObject("btnKayitSil.Image")));
            this.btnKayitSil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKayitSil.Location = new System.Drawing.Point(197, 102);
            this.btnKayitSil.Name = "btnKayitSil";
            this.btnKayitSil.Size = new System.Drawing.Size(152, 51);
            this.btnKayitSil.TabIndex = 1;
            this.btnKayitSil.Text = "Kayıt Sil";
            this.btnKayitSil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKayitSil.UseVisualStyleBackColor = true;
            this.btnKayitSil.Click += new System.EventHandler(this.BtnKayitSil_Click);
            // 
            // btnKayitGuncelle
            // 
            this.btnKayitGuncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKayitGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKayitGuncelle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnKayitGuncelle.Image = ((System.Drawing.Image)(resources.GetObject("btnKayitGuncelle.Image")));
            this.btnKayitGuncelle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKayitGuncelle.Location = new System.Drawing.Point(356, 102);
            this.btnKayitGuncelle.Name = "btnKayitGuncelle";
            this.btnKayitGuncelle.Size = new System.Drawing.Size(152, 51);
            this.btnKayitGuncelle.TabIndex = 2;
            this.btnKayitGuncelle.Text = "Kayıt Güncelle";
            this.btnKayitGuncelle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKayitGuncelle.UseVisualStyleBackColor = true;
            this.btnKayitGuncelle.Click += new System.EventHandler(this.BtnKayitGuncelle_Click);
            // 
            // btnKayitAra
            // 
            this.btnKayitAra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKayitAra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKayitAra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnKayitAra.Image = ((System.Drawing.Image)(resources.GetObject("btnKayitAra.Image")));
            this.btnKayitAra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKayitAra.Location = new System.Drawing.Point(515, 102);
            this.btnKayitAra.Name = "btnKayitAra";
            this.btnKayitAra.Size = new System.Drawing.Size(152, 51);
            this.btnKayitAra.TabIndex = 3;
            this.btnKayitAra.Text = "Kayıt Ara";
            this.btnKayitAra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKayitAra.UseVisualStyleBackColor = true;
            this.btnKayitAra.Click += new System.EventHandler(this.BtnKayitAra_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(49, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(608, 44);
            this.label1.TabIndex = 4;
            this.label1.Text = "MÜŞTERİ TAKİP OTOMASYONU";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateBlue;
            this.ClientSize = new System.Drawing.Size(728, 211);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKayitAra);
            this.Controls.Add(this.btnKayitGuncelle);
            this.Controls.Add(this.btnKayitSil);
            this.Controls.Add(this.btnKayitEkle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ana Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKayitEkle;
        private System.Windows.Forms.Button btnKayitSil;
        private System.Windows.Forms.Button btnKayitGuncelle;
        private System.Windows.Forms.Button btnKayitAra;
        private System.Windows.Forms.Label label1;
    }
}

