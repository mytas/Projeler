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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void BtnKayitEkle_Click(object sender, EventArgs e)
        {
            using (frmKayitEkle frm = new frmKayitEkle())
            {
                frm.ShowDialog();
            }
        }

        private void BtnKayitSil_Click(object sender, EventArgs e)
        {
            using (FrmKayitSil frmKayitSil = new FrmKayitSil())
            {
                frmKayitSil.ShowDialog();
            }
        
        }

        private void BtnKayitGuncelle_Click(object sender, EventArgs e)
        {
            FrmKayitGuncelle frmGuncelle = new FrmKayitGuncelle();
            frmGuncelle.ShowDialog();
        }

        private void BtnKayitAra_Click(object sender, EventArgs e)
        {
            FrmKayitAra frmKayitAra = new FrmKayitAra();
            frmKayitAra.ShowDialog();
        }
    }
}
