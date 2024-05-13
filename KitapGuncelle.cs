using System;
using System.Linq;
using System.Windows.Forms;

namespace kütüphane_modelFirst
{
    public partial class KitapGuncelle : Form
    {
        public KitapGuncelle()
        {
            InitializeComponent();
        }

        Kutuphane_ProjeEntities1 connection = new Kutuphane_ProjeEntities1();

        private void button1_Click(object sender, System.EventArgs e) // güncelle kitap
        {
            int kitapno = Convert.ToInt32(textBox1.Text);
            var guncelle = connection.Kitaplars.Where(x => x.KitapNo == kitapno).FirstOrDefault();
            guncelle.KitapAdi = textBox2.Text;
            guncelle.Yazar = textBox3.Text;
            guncelle.BasimYili = Convert.ToInt32(textBox4.Text);
            connection.SaveChanges();
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }
    }
}
