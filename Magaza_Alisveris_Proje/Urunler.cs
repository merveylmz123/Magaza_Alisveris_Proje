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
    public partial class Urunler : Form
    {
        public Urunler()
        {
            InitializeComponent();
        }

        EntityProjeDbEntities db = new EntityProjeDbEntities();
        void urunListesi()
        {
            dataGridView1.DataSource = (from x in db.Tbl_Urun select new
            {
                x.UruniD,
                x.UrunAd,
                x.Marka,
                x.Stok,
                x.Fiyat,
                x.Tbl_Kategori.KategoriAd,          
                x.Durum                  
            }).ToList();
        }
        void temizle()
        {
            TxtUrunid.Text = "";
            TxtUrunAd.Text = "";
            TxtUrunMarka.Text = "";
            TxtUrunStok.Text = "";
            TxtUrunFiyat.Text = "";
            TxtUrunDurum.Text = "";
            CmbUrunKategori.Text = "";
        }
        private void Urunler_Load(object sender, EventArgs e)
        {
            urunListesi();
            var kategoriler = (from x in db.Tbl_Kategori select new {x.KategoriID, x.KategoriAd}).ToList();
            CmbUrunKategori.ValueMember ="KategoriId";
            CmbUrunKategori.DisplayMember = "KategoriAd";
            CmbUrunKategori.DataSource = kategoriler;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            Tbl_Urun t = new Tbl_Urun();
            t.UrunAd = TxtUrunAd.Text;
            t.Fiyat = decimal.Parse(TxtUrunFiyat.Text);
            t.Marka = TxtUrunMarka.Text;
            t.Stok = short.Parse(TxtUrunStok.Text);
            t.Kategori = int.Parse(CmbUrunKategori.SelectedValue.ToString());
            t.Durum = true;
            db.Tbl_Urun.Add(t);
            db.SaveChanges();
            MessageBox.Show("ürün eklendi");
            urunListesi();
            temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            db.Tbl_Urun.Remove(db.Tbl_Urun.Find(int.Parse(TxtUrunid.Text)));
            db.SaveChanges();
            MessageBox.Show("ürün silindi");
            urunListesi();
            temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var urunGuncelle = db.Tbl_Urun.Find(int.Parse(TxtUrunid.Text));
            urunGuncelle.UrunAd = TxtUrunAd.Text;
            urunGuncelle.Fiyat = decimal.Parse(TxtUrunFiyat.Text);
            urunGuncelle.Marka = TxtUrunMarka.Text;
            urunGuncelle.Stok = short.Parse(TxtUrunStok.Text);
            urunGuncelle.Kategori = int.Parse(CmbUrunKategori.SelectedValue.ToString());
            urunGuncelle.Durum = true;
            db.SaveChanges();
            MessageBox.Show("ürün güncellendi");
            urunListesi();
            temizle();
        }
    }
}
