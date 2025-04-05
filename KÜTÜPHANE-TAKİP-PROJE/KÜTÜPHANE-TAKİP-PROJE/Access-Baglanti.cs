using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KÜTÜPHANE_TAKİP_PROJE
{
    class VtBaglantisi
    {
        public OleDbConnection baglan()
        {
            OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; " +
                "Data Source = Kutuphane-Proje.accdb; Persist Security Info = False;");
            baglanti.Open();
            return (baglanti);
        }
    }
}
