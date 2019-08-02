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
    public partial class FrmKayitSil : Form
    {
        private readonly DataClasses1DataContext dc;
        ChangeSet changeSet;

        public FrmKayitSil()
        {
            InitializeComponent();
            dc = new DataClasses1DataContext();
            DataGridDoldur();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
        }

        private void BtnKayitSil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtID.Text))
            {                
                DialogResult soru = MessageBox.Show("Silme işlemi için Datagrid'den silinecek kaydı seçmelisiniz !", "Dikkat !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            VeriSil();
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

        private void VeriSil()
        {
            int deger = Convert.ToInt32(txtID.Text);
            var sil = dc.musteriler_tbls.Where(w => w.musteriID == deger).FirstOrDefault();

            DialogResult soru = MessageBox.Show("Müşteriyi silmek istiyor musunuz ?", "Silme işlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (soru == DialogResult.Yes)
            {
                dc.musteriler_tbls.DeleteOnSubmit(sil);
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
            txtID.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            this.txtAdi.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoyadi.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            mskTelefon.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtUlke.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtSehir.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void FrmKayitSil_Load(object sender, EventArgs e)
        {
            NesneleriTemizle();
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
            dataGridView1.MultiSelect = false;
        }

        private void FrmKayitSil_FormClosing(object sender, FormClosingEventArgs e)
        {
            dc.Dispose();
        }
    }
}
