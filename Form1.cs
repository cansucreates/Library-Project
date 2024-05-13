using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;

namespace kütüphane_modelFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Kutuphane_ProjeEntities1 connection = new Kutuphane_ProjeEntities1();

        private void button3_Click(object sender, System.EventArgs e) // Kitap ekle + butonu
        {
            KitapEkle kitaplar = new KitapEkle();
            kitaplar.Show();
            this.Hide();
        }

        private void button6_Click(object sender, System.EventArgs e) // Üye ekle butonu
        {
            UyeEkle uyeler = new UyeEkle();
            uyeler.Show();
            this.Hide();
        }

        private void button1_Click(object sender, System.EventArgs e) // İşlem ekle butonu
        {
            IslemEkle islemler = new IslemEkle();
            islemler.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, System.EventArgs e) // formun load eventi (form acıldıgında)
        {
            dataGridView1.DataSource = connection.Kitaplars.ToList();
            dataGridView2.DataSource = connection.Uyelers.ToList();
            dataGridView3.DataSource = connection.Islemlers.ToList();

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e) // üyelerin datagridview'in cell click eventi
        {
            DataGridViewRow satir = dataGridView2.CurrentRow;
            textBox10.Text = satir.Cells["Tc"].Value.ToString();
            textBox9.Text = satir.Cells["AdSoyad"].Value.ToString();
            textBox8.Text = satir.Cells["DTarihi"].Value.ToString();
            textBox7.Text = satir.Cells["Adres"].Value.ToString();
            textBox11.Text = satir.Cells["Telefon"].Value.ToString();
        }

        private void button8_Click(object sender, System.EventArgs e) // Üye Güncelle
        {
            int uyetc = Convert.ToInt32(textBox10.Text);  // tc'yi alıyoruz
            var guncelle = connection.Uyelers.Where(x => x.Tc == uyetc).FirstOrDefault();
            guncelle.AdSoyad = textBox9.Text;
            guncelle.DTarihi = Convert.ToDateTime(textBox8.Text);
            guncelle.Adres = textBox7.Text;
            guncelle.Telefon = textBox11.Text;
            connection.SaveChanges();
            dataGridView2.DataSource = connection.Uyelers.ToList();
        }

        private void button7_Click(object sender, EventArgs e) // Üye Sil
        {
            int uyetc = Convert.ToInt32(textBox10.Text);  // tc'yi alıyoruz
            var sil = connection.Uyelers.Where(x => x.Tc == uyetc).FirstOrDefault();
            connection.Uyelers.Remove(sil);
            connection.SaveChanges();
            dataGridView2.DataSource = connection.Uyelers.ToList();
            // Temizle metodu gerek. Ödev.
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) // kitap listi cell clicki. e = objeye yapılan eylemleri gözetleme parametresi
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            if (e.ColumnIndex == 0) // güncelle
            {
                KitapGuncelle kitapGuncelle = new KitapGuncelle();
                kitapGuncelle.textBox1.Text = satir.Cells["KitapNo"].Value.ToString();
                kitapGuncelle.textBox2.Text = satir.Cells["KitapAdi"].Value.ToString();
                kitapGuncelle.textBox3.Text = satir.Cells["Yazar"].Value.ToString();
                kitapGuncelle.textBox4.Text = satir.Cells["BasimYili"].Value.ToString();
                kitapGuncelle.Show();
                this.Hide();
            }
            if (e.ColumnIndex == 1) // sil 
            {
                KitapSil kitapSil = new KitapSil();
                kitapSil.label1.Tag = satir.Cells["KitapNo"].Value.ToString();
                kitapSil.label1.Text = satir.Cells["KitapAdi"].Value.ToString();
                kitapSil.Show();
                this.Hide();
            }
        }

        ArrayList secili = new ArrayList();

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e) // işlemler datagridview
        {
            DataGridViewRow satir = dataGridView3.CurrentRow;
            textBox14.Tag = satir.Cells["Id"].Value.ToString();
            textBox14.Text = satir.Cells["UyeTc"].Value.ToString();
            textBox12.Text = satir.Cells["KitapNo"].Value.ToString();
            textBox13.Text = satir.Cells["AlimTarihi"].Value.ToString();
            textBox15.Text = satir.Cells["TeslimTarihi"].Value.ToString();

            // combobox'ta satırların seçilip seçilmediğini kontrol et

            for(int i = 0; i < dataGridView3.RowCount; i++)
            {
                if (e.ColumnIndex == 0)
                {
                    secili.Add(satir.Cells["Id"].Value.ToString());
                }
            }
        }

        private void button12_Click(object sender, EventArgs e) // celldeki seçilenleri toplu silme butonu
        {
            foreach (string item in secili)
            {
                int id = Convert.ToInt32(item);
                var sil = connection.Islemlers.Where(x => x.Id == id).FirstOrDefault();
                connection.Islemlers.Remove(sil);
                connection.SaveChanges();
                dataGridView3.DataSource = connection.Islemlers.ToList();
                // array listi güncelle/sil
                secili.Clear(); // arraylistteki idleri sil
            }
        }
    }
}
