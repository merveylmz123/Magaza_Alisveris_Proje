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
    public partial class Istatistik : Form
    {
        public Istatistik()
        {
            InitializeComponent();
        }

        EntityProjeDbEntities db = new EntityProjeDbEntities();
        private void Istatistik_Load(object sender, EventArgs e)
        {
            label2.Text = db.Tbl_Kategori.Count().ToString();

            label3.Text = db.Tbl_Urun.Count().ToString();

            label5.Text = db.Tbl_Musteri.Count(x => x.Durum == true).ToString();
                
            label7.Text = db.Tbl_Musteri.Count(x => x.Durum == false).ToString();

            label13.Text = db.Tbl_Urun.Sum(y => y.Stok).ToString(); 

            label21.Text = db.Tbl_Satis.Sum(z => z.Fiyat).ToString() + " TL";

            var enYuksekFiyatliUrun = db.Tbl_Urun.Max(x => x.Fiyat);
            label11.Text = db.Tbl_Urun.Where(x => x.Fiyat == enYuksekFiyatliUrun).Select(y => y.UrunAd).FirstOrDefault().ToString();

            var enDusukFiyatliUrun = db.Tbl_Urun.Min(x => x.Fiyat);
            label9.Text = db.Tbl_Urun.Where(x => x.Fiyat == enDusukFiyatliUrun).Select(y => y.UrunAd).FirstOrDefault().ToString();

            label15.Text = db.Tbl_Urun.Count(x => x.UruniD == 1).ToString();

            label23.Text = db.Tbl_Musteri.Select(x => x.Sehir).Distinct().Count().ToString();

            var enFazlaUrunMarka = db.Tbl_Urun.Max(x => x.Stok);
            label19.Text = db.Tbl_Urun.Where(x => x.Stok == enFazlaUrunMarka).Select(y => y.Marka).FirstOrDefault().ToString();

            var enAzUrunMarka = db.Tbl_Urun.Min(x => x.Stok);
            label17.Text = db.Tbl_Urun.Where(x => x.Stok == enAzUrunMarka).Select(y => y.Marka).FirstOrDefault().ToString();

        }
    }
}
