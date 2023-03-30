using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BonusProje
{
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.TBLDERSLERTableAdapter ds = new DataSet1TableAdapters.TBLDERSLERTableAdapter();
        private void FrmDersler_Load(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource= ds.DersListesi();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            ds.DersEkle(TxtDersAd.Text);
            MessageBox.Show("Ders Eklendi");
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            ds.DersSil(byte.Parse(TxtDersıd.Text));
            MessageBox.Show("Ders Silindi","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information );
            
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.DersGüncelle(TxtDersAd.Text, byte.Parse(TxtDersıd.Text) );
        }

   

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtDersıd.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtDersAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
