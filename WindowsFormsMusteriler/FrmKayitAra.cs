using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsMusteriler
{
    public partial class FrmKayitAra : Form
    {
        private readonly DataClasses1DataContext dc;
        public FrmKayitAra()
        {
            InitializeComponent();
            dc = new DataClasses1DataContext();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridDoldur();
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

        private void VeriAra()
        {
            string ad = this.txtAdi.Text;
            string soyad = this.txtSoyadi.Text;
            string ulke = this.txtUlke.Text;
            string sehir = this.txtSehir.Text;
            string telefon = this.mskTelefon.Text;
            //var sorgu = dc.musteriler_tbls.Where(w => w.ad.Contains(ad)).ToList();
            var sorgu = dc.musteriler_tbls.Where(w => w.ad.Contains(ad) && w.soyad.Contains(soyad) && w.sehir.Contains(sehir) && w.ulke.Contains(ulke)).ToList();
            dataGridView1.DataSource = sorgu;
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
        private void TextBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.LightBlue;
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.White;
        }

        private void MaskedBox_Enter(object sender, EventArgs e)
        {
            ((MaskedTextBox)sender).BackColor = Color.LightBlue;
        }

        private void MaskedBox_Leave(object sender, EventArgs e)
        {
            ((MaskedTextBox)sender).BackColor = Color.White;
        }
        private void BtnKayitAra_Click(object sender, EventArgs e)
        {
            VeriAra();
        }
    }
}
