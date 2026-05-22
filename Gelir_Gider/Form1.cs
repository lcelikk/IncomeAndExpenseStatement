using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GelirGiderTakip
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti = new SqlConnection(
            "Server=DESKTOP-2T9GGTI\\SQLEXPRESS;Database=GelirGiderDB;Trusted_Connection=True;"
        );

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbTur.Items.Clear();

            cmbTur.Items.Add("Gelir");

            cmbTur.Items.Add("Gider");
            


            Listele();
            ToplamlariHesapla();

        }

        void KategorileriGetir()
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM Kategoriler",
                baglanti
            );

            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbKategori.DisplayMember = "KategoriAdi";
            cmbKategori.ValueMember = "KategoriID";
            cmbKategori.DataSource = dt;
        }

        void Listele()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT 
                I.IslemID,
                I.Tur,
                I.Tutar,
                K.KategoriAdi,
                I.Tarih,
                I.Aciklama
              FROM Islemler I
              LEFT JOIN Kategoriler K
              ON I.KategoriID = K.KategoriID",
                    baglanti
                );

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Listeleme hatası: " + ex.Message);
            }
        }

        void ToplamlariHesapla()
        {
            baglanti.Open();

            SqlCommand cmdGelir = new SqlCommand(
                "SELECT ISNULL(SUM(Tutar),0) FROM Islemler WHERE Tur='Gelir'",
                baglanti
            );

            SqlCommand cmdGider = new SqlCommand(
                "SELECT ISNULL(SUM(Tutar),0) FROM Islemler WHERE Tur='Gider'",
                baglanti
            );

            lblToplamGelir.Text =
                "Toplam Gelir: " + cmdGelir.ExecuteScalar().ToString() + " TL";

            lblToplamGider.Text =
                "Toplam Gider: " + cmdGider.ExecuteScalar().ToString() + " TL";
            decimal bakiye = (decimal)cmdGelir.ExecuteScalar() - (decimal)cmdGider.ExecuteScalar();
            lblBakiye.Text = "Güncel Bakiye: " + bakiye + " TL";

            baglanti.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
          
            try
            {
                // 1. Boş alan kontrolü
                if (string.IsNullOrWhiteSpace(txtTutar.Text) ||
                    string.IsNullOrWhiteSpace(cmbTur.Text) ||
                    cmbKategori.SelectedValue == null)
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun!");
                    return;
                }

                // 2. Tutar kontrolü (decimal güvenli parse)
                if (!decimal.TryParse(txtTutar.Text, out decimal tutar))
                {
                    MessageBox.Show("Tutar geçerli bir sayı olmalı!");
                    return;
                }

                // 3. Bağlantı aç
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();

                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO Islemler
              (Tur, Tutar, KategoriID, Tarih, Aciklama)
              VALUES
              (@tur, @tutar, @kategori, @tarih, @aciklama)",
                    baglanti
                );

                cmd.Parameters.AddWithValue("@tur", cmbTur.Text);
                cmd.Parameters.AddWithValue("@tutar", tutar);
                cmd.Parameters.AddWithValue("@kategori", cmbKategori.SelectedValue);
                cmd.Parameters.AddWithValue("@tarih", dtTarih.Value);
                cmd.Parameters.AddWithValue("@aciklama",
                    string.IsNullOrWhiteSpace(txtAciklama.Text) ? "" : txtAciklama.Text
                );

                cmd.ExecuteNonQuery();

                baglanti.Close();

                MessageBox.Show("İşlem başarıyla eklendi!");

                // 4. Ekranı güncelle
                Listele();
                ToplamlariHesapla();
            }
            catch (Exception ex)
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();

                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(
                dataGridView1.CurrentRow.Cells["IslemID"].Value
            );

            baglanti.Open();

            SqlCommand cmd = new SqlCommand(
                "DELETE FROM Islemler WHERE IslemID=@id",
                baglanti
            );

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            baglanti.Close();

            MessageBox.Show("Kayıt Silindi");

            Listele();
            ToplamlariHesapla();
        }

        private void btnEkle_Click_1(object sender, EventArgs e)
        {

        }
        private void cmbTur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTur.SelectedIndex == -1) return;

            cmbKategori.DataSource = null;
            cmbKategori.Items.Clear();

            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT KategoriID, KategoriAdi FROM Kategoriler WHERE Tur=@tur",
                baglanti
            );

            da.SelectCommand.Parameters.AddWithValue("@tur", cmbTur.Text);

            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbKategori.DisplayMember = "KategoriAdi";
            cmbKategori.ValueMember = "KategoriID";

            cmbKategori.DataSource = dt;
        }

    }
}