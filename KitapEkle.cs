using System;
using System.Windows.Forms;

namespace kütüphane_modelFirst
{
    public partial class KitapEkle : Form
    {
        public KitapEkle()
        {
            InitializeComponent();
        }

        Kutuphane_ProjeEntities1 connection = new Kutuphane_ProjeEntities1();

        private void button2_Click(object sender, System.EventArgs e) // kapat butonu
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void button1_Click(object sender, System.EventArgs e) // kitap kaydet 
        {
            Kitaplar kitapEkle = new Kitaplar();
            kitapEkle.KitapNo = Convert.ToInt32(textBox1.Text);
            kitapEkle.KitapAdi = textBox2.Text;
            kitapEkle.Yazar = textBox3.Text;
            kitapEkle.BasimYili = Convert.ToInt32(textBox4.Text);
            connection.Kitaplars.Add(kitapEkle);
            connection.SaveChanges();

        }
    }
}
