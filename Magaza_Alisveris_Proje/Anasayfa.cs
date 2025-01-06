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
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kategoriler fr = new Kategoriler();
            fr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Urunler fr = new Urunler();
            fr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Istatistik fr = new Istatistik();
            fr.Show();
        }
    }
}
