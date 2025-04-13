using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace KutuphaneYonetimSistemi
{
    public static class DatabaseHelper
    {
        // BAĞLANTI AYARI (BURAYI KENDİ VERİTABANINIZA GÖRE DÜZENLEYİN)
        // EĞER ÇALIŞMAZSA:
        private static string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Kutuphane-Proje.mdb;";


        // BAĞLANTIYI TEST ETME METODU
        public static bool TestConnection()
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı hatası: " + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // TABLO VERİLERİNİ ÇEKEN METOD
        public static DataTable GetTable(string tableName)
        {
            DataTable dt = new DataTable();
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    string query = "SELECT * FROM " + tableName;
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
                    conn.Open();
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri çekme hatası: " + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }
    }
}