using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market_Programı
{
    public partial class Form1: Form
    {
        List<marketci> stok = new List<marketci>();
        marketci stok1 = new marketci();
        List<satis> satislar = new List<satis>();
        satis satis1 = new satis();

        public Form1()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = "Kayıt Sayısı: " + dataGridView1.Rows.Count.ToString();
            toolStripStatusLabel2.Text = "Kayıt Sayısı: " + dataGridView2.Rows.Count.ToString();
            veriDoldur();
            stoklistele();
            satislistele();
            dataGridView1.Refresh();
            
        }

        void veriDoldur()
        {
            stok1 = new marketci { urunNo = 1, urunAdi = "Makarna", urunTipi = "Gıda", urunMarka = "Filiz Makarna", urunOzellikleri = "Burgulu", urunMiktari = 30, urunFiyati = 20 };
            stok.Add(stok1);
            stok1 = new marketci { urunNo = 2, urunAdi = "Deterjan", urunTipi = "Temizlik", urunMarka = "Tursil", urunOzellikleri = "Renkliler için", urunMiktari = 10, urunFiyati=220 };
            stok.Add(stok1);
            satislistele();
        }

        void stoklistele()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = stok;
            dataGridView1.Refresh();
            foreach(marketci s in stok)
            {
                comboBox2.Items.Add(s.urunAdi);
            }
        }
        void satislistele()
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = satislar;
            dataGridView2.Refresh();
           
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            marketci stok2 = new marketci();
            stok2.urunNo = int.Parse(textBox1.Text);
            stok2.urunAdi = textBox2.Text;
            stok2.urunTipi = comboBox1.Text;
            stok2.urunMarka = textBox3.Text;
            stok2.urunOzellikleri = textBox4.Text;
            stok2.urunMiktari = int.Parse(textBox5.Text);
            stok2.urunFiyati = float.Parse(textBox6.Text);
            stok.Add(stok2);

            stoklistele();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count>0)
            {
                marketci stok2 = (marketci)dataGridView1.SelectedRows[0].DataBoundItem;

                textBox1.Text = stok2.urunNo.ToString();
                textBox2.Text = stok2.urunAdi;
                comboBox1.Text = stok2.urunTipi;
                textBox3.Text = stok2.urunMarka;
                textBox4.Text = stok2.urunOzellikleri;
                textBox5.Text = Convert.ToString(stok2.urunMiktari);
                textBox6.Text = Convert.ToString(stok2.urunFiyati);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count>0)
            {
                marketci stok2 = (marketci)dataGridView1.SelectedRows[0].DataBoundItem;
                stok2.urunNo = int.Parse(textBox1.Text);
                stok2.urunAdi = textBox2.Text;
                stok2.urunTipi = comboBox1.Text;
                stok2.urunMarka = textBox3.Text;
                stok2.urunOzellikleri = textBox4.Text;
                stok2.urunMiktari = int.Parse(textBox5.Text);
                stok2.urunFiyati = float.Parse(textBox6.Text);
                stoklistele();

            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count>0)
            {
                marketci stok2 = (marketci)dataGridView1.SelectedRows[0].DataBoundItem;

                DialogResult sonuc = MessageBox.Show(stok2.urunAdi + " Bu ürünü silmek istediğinize emin misiniz ?" + MessageBoxButtons.YesNo);
                if(sonuc==DialogResult.Yes)
                {
                    stok.Remove(stok2);
                    stoklistele();
                }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            stoklistele();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = stok.Where(ad => ad.urunAdi.Contains(toolStripTextBox1.Text)).ToList();
            dataGridView1.Refresh();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            comboBox1.Text = "";
            textBox1.Focus();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(marketci s in stok)
            {
                if(s.urunAdi==comboBox2.Text)
                {
                    textBox7.Text = s.urunNo.ToString();
                    textBox8.Text = s.urunFiyati.ToString();
                    textBox9.Text = s.urunMiktari.ToString();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            comboBox2.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            foreach(marketci s in stok)
            {
                if(s.urunAdi==comboBox2.Text)
                {
                    if(s.urunMiktari<int.Parse(textBox9.Text))
                    {
                        MessageBox.Show("Yeteri Kadar Ürün yok!");
                    }
                    else
                    {
                        s.urunMiktari -= int.Parse(textBox9.Text);
                        satis1 = new satis();
                        satis1.urunNo = int.Parse(textBox7.Text);
                        satis1.urunAdi = comboBox2.Text;
                        satis1.tarih = dateTimePicker1.Value;
                        satis1.fiyati = float.Parse(textBox8.Text);
                        satis1.miktari = int.Parse(textBox9.Text);                       
                        satislar.Add(satis1);
                        satislistele();
                    }
                }
            }
            

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if(dataGridView2.SelectedRows.Count>0)
            {
                satis1 = (satis)dataGridView2.SelectedRows[0].DataBoundItem;

                satis1.urunNo = int.Parse(textBox7.Text);
                satis1.urunAdi = comboBox2.Text;
                satis1.tarih = dateTimePicker1.Value;
                satis1.fiyati = float.Parse(textBox8.Text);
                satis1.miktari = int.Parse(textBox9.Text);

                satislistele();
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if(dataGridView2.SelectedRows.Count>0)
            {
                satis1 = (satis)dataGridView2.SelectedRows[0].DataBoundItem;

                DialogResult sonuc= MessageBox.Show(satis1.urunAdi + "adlı kayıt silinsin mi ?","Kayıt Sil", MessageBoxButtons.YesNo);

                if(sonuc==DialogResult.Yes)
                {
                    satislar.Remove(satis1);
                    satislistele();
                    
                }
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            satislistele();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = satislar.Where(ad => ad.urunAdi.Contains(toolStripTextBox2.Text)).ToList();
            dataGridView2.Refresh();

            toolStripStatusLabel2.Text = "Kayıt Sayısı: " + dataGridView2.Rows.Count.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(marketci s in stok)
            {
                if(s.urunAdi==comboBox2.Text)
                {
                    if(s.urunMiktari<int.Parse(textBox9.Text))
                    {
                        MessageBox.Show(s.urunAdi + " isimli üründen stokta " + s.urunMiktari + " adet kalmıştır");
                        textBox9.Clear();
                        textBox9.Focus();

                    }
                    else
                    {
                        MessageBox.Show("Stok uygun.");
                    }
                }
            }
        }
    }
}
