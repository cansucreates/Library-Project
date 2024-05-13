using System;
using System.Windows.Forms;

namespace kütüphane_modelFirst
{
    public partial class UyeEkle : Form
    {
        public UyeEkle()
        {
            InitializeComponent();
        }

        // box temizleme metodu. Her form kaydedildikten sonra formu temizle.
        public void Temizle()
        {
            /*  foreach (Control item in this.Controls)
             {
                 item.Text = "";
             } */

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();


        }



        Kutuphane_ProjeEntities1 connection = new Kutuphane_ProjeEntities1(); // Bağlantı


        private void button2_Click(object sender, System.EventArgs e) // Kapat butonu
        {
            Form1 form = new Form1();
            form.Show(); // form1'i yeniden açacak yeni yapılan kayıtları listelemek için.
            this.Close();
        }

        private void button1_Click(object sender, System.EventArgs e) // Kaydet butonu
        {
            Uyeler uyeKaydet = new Uyeler();
            uyeKaydet.Tc = Convert.ToInt32(textBox1.Text);
            uyeKaydet.AdSoyad = textBox2.Text;
            uyeKaydet.DTarihi = Convert.ToDateTime(textBox3.Text);
            uyeKaydet.Adres = textBox4.Text;
            uyeKaydet.Telefon = textBox5.Text;
            connection.Uyelers.Add(uyeKaydet);
            connection.SaveChanges();
            MessageBox.Show("İşlem Başarılı");
            Temizle();
        }
    }
}
