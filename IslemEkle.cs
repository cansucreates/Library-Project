using System;
using System.Windows.Forms;

namespace kütüphane_modelFirst
{
    public partial class IslemEkle : Form
    {
        public IslemEkle()
        {
            InitializeComponent();
        }

        Kutuphane_ProjeEntities1 connection = new Kutuphane_ProjeEntities1();

        private void button3_Click(object sender, System.EventArgs e)// Kapat butonu
        {
            this.Close();
        }

        private void button2_Click(object sender, System.EventArgs e) // Seç butonu
        {
            Sec sec = new Sec();
            sec.Show();
            this.Hide();
        }

        private void button1_Click(object sender, System.EventArgs e) // işlem kaydet
        {
            Islemler islemKaydet = new Islemler();
            islemKaydet.UyeTc = Convert.ToInt32(textBox1.Text);
            islemKaydet.KitapNo = Convert.ToInt32(textBox2.Text);
            islemKaydet.AlimTarihi = Convert.ToDateTime(textBox3.Text);
            islemKaydet.TeslimTarihi = Convert.ToDateTime(textBox4.Text);
            connection.Islemlers.Add(islemKaydet);
            connection.SaveChanges();

        }
    }
}
