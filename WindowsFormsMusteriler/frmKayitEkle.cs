using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsMusteriler
{
    public partial class frmKayitEkle : Form
    {
        
       private readonly DataClasses1DataContext dc;
        ChangeSet changeSet;
        bool durum;
        
        public frmKayitEkle()
        {
            InitializeComponent();
            dc = new DataClasses1DataContext();
            DataGridDoldur();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            SecileniBoya();
        }

        private void BtnKayitEkle_Click(object sender, EventArgs e)
        {
            ZorunlulariIsaretle();
            if (durum == true) return;

            if (Varmi())
            {
                return;
            }

            VeriEkle();
            changeSet = dc.GetChangeSet();

            try
            {
                dc.SubmitChanges();
                DataGridDoldur();
                ChangeSetCalistir();
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            NesneleriTemizle();
        }

        void NesneleriTemizle()
        {
            this.txtAdi.Text = string.Empty;
            this.txtSoyadi.Text = string.Empty;
            this.txtSehir.Text = string.Empty;
            this.txtUlke.Text = string.Empty;
            this.mskTelefon.Text = string.Empty;
        }

        public void DataGridDoldur()
        {
            
            dataGridView1.DataSource = from a in dc.musteriler_tbls
                                       select new
                                       {
                                           a.musteriID,
                                           a.ad,
                                           a.soyad,
                                           a.telefon,
                                           a.ulke,
                                           a.sehir,
                                       };
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Adı";
            dataGridView1.Columns[2].HeaderText = "Soyadı";
            dataGridView1.Columns[3].HeaderText = "Telefon";
            dataGridView1.Columns[4].HeaderText = "Ülke";
            dataGridView1.Columns[5].HeaderText = "Şehir";
        }

        private void VeriEkle()
        {
            musteriler_tbl ekle = new musteriler_tbl();
            ekle.ad = txtAdi.Text.Trim();
            ekle.soyad = txtSoyadi.Text.Trim();
            ekle.ulke = txtUlke.Text.Trim();
            ekle.sehir = txtSehir.Text.Trim();
            ekle.telefon = mskTelefon.Text.Trim();
            DialogResult kaydet = MessageBox.Show("Müşteriyi eKlemek istiyor musunuz ?", "Kayıt işlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kaydet == DialogResult.Yes)
            {
                dc.musteriler_tbls.InsertOnSubmit(ekle);
                //dc.SubmitChanges();
                //MessageBox.Show("Kayıt Başarılı Bir Şekilde Gerçekleşti", "Bilgilendirme Mesajı");
            }
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.LightBlue;
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.White;
            ZorunlulariIsaretle();
        }

        private void MaskedBox_Enter(object sender, EventArgs e)
        {
            ((MaskedTextBox)sender).BackColor = Color.LightBlue;
        }

        private void MaskedBox_Leave(object sender, EventArgs e)
        {
            ((MaskedTextBox)sender).BackColor = Color.White;
            ZorunlulariIsaretle();
        }
        public List<Control> Secilecekler(List<Control> liste)
        {
            liste.Add(this.txtAdi);
            liste.Add(this.txtSoyadi);
            liste.Add(this.txtSehir);
            liste.Add(this.txtUlke);
            liste.Add(this.mskTelefon);
            return liste;
        }

        void SecileniBoya()
        {
            var sec = Secilecekler(new List<Control>());
            foreach (Control c in sec)
            {
                if (c is TextBox)
                {
                    c.Enter += new EventHandler(this.TextBox_Enter);
                    c.Leave += new EventHandler(this.TextBox_Leave);
                }
                else if (c is MaskedTextBox)
                {
                    c.Enter += new EventHandler(this.MaskedBox_Enter);
                    c.Leave += new EventHandler(this.MaskedBox_Leave);
                }
                c.KeyDown += new KeyEventHandler(this.Nesne_KeyDown);
            }
        }

        public List<Control> Zorunlular(List<Control> liste)
        {
            liste.Add(this.txtAdi);
            liste.Add(this.txtSoyadi);
            return liste;
        }
        void ZorunlulariIsaretle()
        {
            durum = false;
            int say = 0;
            errorProvider1.Clear();
            var sec = Zorunlular(new List<Control>());
            foreach (Control c in sec)
            {           
                if (String.IsNullOrWhiteSpace(c.Text))
                {
                    errorProvider1.SetError(c, "Boş geçilemez!");
                    c.Text = String.Empty;
                    say++;
                    if (say == 1) c.Focus();
                    durum = true;
                }
            }
            //if (durum == true) MessageBox.Show("Lütfen boş geçilemez alanları doldurun.", "Dikkat !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private bool Varmi()
        {
            using (DataClasses1DataContext dc = new DataClasses1DataContext())
            {
                string ad = txtAdi.Text.Trim();
                string soyad = txtSoyadi.Text.Trim();
                int kayit = (from m in dc.musteriler_tbls
                             where m.ad == ad && m.soyad == soyad
                             select m).Count();
                if (kayit > 0)
                {
                    MessageBox.Show("Bu kişi zaten tanımlı. Lütfen başka bir kişi Adı yazın.", "Dikkat !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtAdi.Focus();
                    return true;
                }
                else return false;
            }
        }
        private void ChangeSetCalistir()
        {
            if (changeSet.Inserts.Count > 0)
            {
                MessageBox.Show("Kayıt başarıyla girilmiştir.", "Rapor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (changeSet.Updates.Count > 0)
            {
                MessageBox.Show("Kayıt başarıyla güncellenmiştir.", "Rapor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (changeSet.Deletes.Count > 0)
            {
                MessageBox.Show("Kayıt başarıyla silinmiştir.", "Rapor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Nesne_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void FrmKayitEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            dc.Dispose();
        }
    }
}
