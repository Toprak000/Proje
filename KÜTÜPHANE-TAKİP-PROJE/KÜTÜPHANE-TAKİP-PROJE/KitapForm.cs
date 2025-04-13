using KutuphaneYonetimSistemi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KÜTÜPHANE_TAKİP_PROJE
{
    public partial class KitapForm : Form
    {
        public KitapForm()
        {
            InitializeComponent();
        }

        private void KitapForm_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {


        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (DatabaseHelper.TestConnection())
            {
                MessageBox.Show("Veritabanına bağlantı başarılı!");

                // Kitaplar tablosunu DataGridView'e yükleme
                dataGridView1.DataSource = DatabaseHelper.GetTable("Kitaplar");
            }
        }
    }
}
