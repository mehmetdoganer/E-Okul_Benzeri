using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BonusProje
{
    public partial class FrmÖğrenci : Form
    {
        public FrmÖğrenci()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-A53JT4E\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");

        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        private void FrmÖğrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.ÖğrenciListesi();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TBLKULUPLER", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbKulüp.DisplayMember = "KULUPAD";
            CmbKulüp.ValueMember= "KULUPID";
            CmbKulüp.DataSource= dt;
            baglanti.Close();   
        }

        string c = "";
        private void BtnEkle_Click(object sender, EventArgs e)
        {
            
            
            ds.OgrenciEkle(TxtAd.Text,TxtSoyad.Text,byte.Parse(CmbKulüp.SelectedValue.ToString()),c);
            MessageBox.Show("Öğrenci Eklendi");
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.ÖğrenciListesi();
        }

        private void CmbKulüp_SelectedIndexChanged(object sender, EventArgs e)
        {
            Txtıd.Text = CmbKulüp.SelectedValue.ToString(); 
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenicSil(int.Parse(Txtıd.Text));
            MessageBox.Show("Öğrenci Silindi!");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Txtıd.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            CmbKulüp.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            c = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            if (c == "KIZ")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            if (c == "ERKEK")
            {
                radioButton2.Checked = true;
                radioButton1.Checked = false;
            }


        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.OgrenciGuncelle(TxtAd.Text, TxtSoyad.Text, byte.Parse(CmbKulüp.SelectedValue.ToString()), c, int.Parse(Txtıd.Text));


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                c = "KIZ";
            }
          
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                c = "ERKEK";
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciGetir(TxtAra.Text); 
        }
    }
}
