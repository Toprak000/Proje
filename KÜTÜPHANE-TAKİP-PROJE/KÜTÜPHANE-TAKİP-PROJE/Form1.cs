using System.Data;
using System.Data.OleDb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KÜTÜPHANE_TAKİP_PROJE
{
    

    public partial class AnaForm : Form
    {
        KitapForm kitapForm = new KitapForm();

        UyelerForm uyelerForm = new UyelerForm();

        public AnaForm()
        {
            InitializeComponent();
            kitapForm.TopMost = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {

            
            kitapForm.Show();




        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            IsMdiContainer = true;
            kitapForm.MdiParent = this;  // Form1'i ana form olarak ayarla
            kitapForm.TopMost = true; // Diğer her şeyin üstünde tut
            kitapForm.Show();
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {

        }
    }
}
