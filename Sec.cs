using System.Linq;
using System.Windows.Forms;

namespace kütüphane_modelFirst
{
    public partial class Sec : Form
    {
        public Sec()
        {
            InitializeComponent();
        }

        Kutuphane_ProjeEntities1 connection = new Kutuphane_ProjeEntities1();
        private void Sec_Load(object sender, System.EventArgs e) // form açılması
        {
            dataGridView1.DataSource = connection.Uyelers.ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) // sec'teki datagridin cell click eventi
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            IslemEkle islemEkle = new IslemEkle();
            islemEkle.textBox1.Text = satir.Cells["Tc"].Value.ToString();
            islemEkle.Show();
            this.Close();
        }
    }
}
