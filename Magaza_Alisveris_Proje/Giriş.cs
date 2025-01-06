using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magaza_Alisveris_Proje
{
    public partial class Giriş : Form
    {
        public Giriş()
        {
            InitializeComponent();
        }
        EntityProjeDbEntities db = new EntityProjeDbEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            var sorgu = from x in db.Tbl_Admin
                        where x.Kullanici == textBox1.Text & x.Sifre == textBox2.Text
                        select x;

            if (sorgu.Any())
            {
                Anasayfa fr = new Anasayfa();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş");
            }
        }
    }
}
