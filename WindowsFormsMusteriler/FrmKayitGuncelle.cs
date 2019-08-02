using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsMusteriler
{
    public partial class FrmKayitGuncelle : Form
    {
        private readonly DataClasses1DataContext dc;
        ChangeSet changeSet;
        bool durum;

        public FrmKayitGuncelle()
        {
            InitializeComponent();
            dc = new DataClasses1DataContext();           
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridDoldur();
        }

        private void BtnKayitGuncelle_Click(object sender, EventArgs e)
        {
            SecileniBoya();
            ZorunlulariIsaretle();

            if (string.IsNullOrEmpty(this.txtID.Text))
            {
                DialogResult soru= MessageBox.Show("Güncelleme işlemi yapmak için DataGrid'den ilgili kaydı seçmelisiniz !", "Dikkat !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NesneleriKilitle();
                return;
            }

            if (durum == true) return;

            if (Varmi())
            {
                return;
            }

            VeriGuncelle();
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
            NesneleriKilitle();
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

        private void VeriGuncelle()
        {
            int deger = Convert.ToInt32(txtID.Text);
            var musteri = dc.musteriler_tbls.Where(w => w.musteriID == deger).FirstOrDefault();

            DialogResult soru = MessageBox.Show("Müşteri bilgilerini güncellemek istiyor musunuz ?", "Güncelleme işlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (soru == DialogResult.Yes)
            {
                musteri.ad = txtAdi.Text;
                musteri.soyad = txtSoyadi.Text;
                musteri.sehir = txtSehir.Text;
                musteri.ulke = txtUlke.Text;
                musteri.telefon = mskTelefon.Text;
            }
        }
        public List<Control> Zorunlular(List<Control> liste)
        {
            liste.Add(this.txtAdi);
            liste.Add(this.txtSoyadi);
            return liste;
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

        private void DataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.txtID.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            this.txtAdi.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            this.txtSoyadi.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            this.mskTelefon.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            this.txtUlke.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            this.txtSehir.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }
        void NesneleriTemizle()
        {
            dataGridView1.ClearSelection();
            this.txtID.Text = string.Empty;
            this.txtAdi.Text = string.Empty;
            this.txtSoyadi.Text = string.Empty;
            this.txtSehir.Text = string.Empty;
            this.txtUlke.Text = string.Empty;
            this.mskTelefon.Text = string.Empty;
            this.dataGridView1.MultiSelect = false;
        }

        private void FrmKayitGuncelle_Load(object sender, EventArgs e)
        {
            NesneleriTemizle();
            NesneleriKilitle();
        }

        private void FrmKayitGuncelle_FormClosing(object sender, FormClosingEventArgs e)
        {
            dc.Dispose();
        }

        private void DataGridView1_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            this.txtID.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            this.txtAdi.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            this.txtSoyadi.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            this.mskTelefon.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            this.txtUlke.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            this.txtSehir.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            NesneleriAc();
            this.errorProvider1.Clear();
        }

        void NesneleriKilitle()
        {
            this.txtAdi.ReadOnly = true;
            this.txtSoyadi.ReadOnly = true;
            this.mskTelefon.ReadOnly = true;
            this.txtUlke.ReadOnly = true;
            this.txtSehir.ReadOnly = true;
        }
        void NesneleriAc()
        {
            this.txtAdi.ReadOnly = false;
            this.txtSoyadi.ReadOnly = false;
            this.mskTelefon.ReadOnly = false;
            this.txtUlke.ReadOnly = false;
            this.txtSehir.ReadOnly = false;
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
                //c.KeyDown += new KeyEventHandler(this.Nesne_KeyDown);
            }
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
                int id = int.Parse(this.txtID.Text);
                int kayit = (from m in dc.musteriler_tbls
                             where m.ad == ad && m.soyad == soyad && m.musteriID!=id
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
    }
}
