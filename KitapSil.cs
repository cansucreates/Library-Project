using System;
using System.Linq;
using System.Windows.Forms;

namespace kütüphane_modelFirst
{
    public partial class KitapSil : Form
    {
        public KitapSil()
        {
            InitializeComponent();
        }

        Kutuphane_ProjeEntities1 connection = new Kutuphane_ProjeEntities1();

        private void button1_Click(object sender, System.EventArgs e) // sil butonu evet
        {
            int kitapno = Convert.ToInt32(label1.Tag);
            var sil = connection.Kitaplars.Where(x => x.KitapNo == kitapno).FirstOrDefault();
            connection.Kitaplars.Remove(sil);
            connection.SaveChanges();
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e) // hayır butonu
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }
    }
}
