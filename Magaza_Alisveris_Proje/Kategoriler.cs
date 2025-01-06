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
    public partial class Kategoriler : Form
    {
        public Kategoriler()
        {
            InitializeComponent();
        }
        EntityProjeDbEntities db= new EntityProjeDbEntities();
        void KategoriListele()
        {
            var kategoriler = db.Tbl_Kategori.ToList(); 
            dataGridView1.DataSource = kategoriler;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            KategoriListele();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            Tbl_Kategori t = new Tbl_Kategori();
            t.KategoriAd = TxtKategoriAd.Text;
            db.Tbl_Kategori.Add(t);
            db.SaveChanges();
            MessageBox.Show("kategori eklendi");
            KategoriListele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            var kategoriIdBul = db.Tbl_Kategori.Find(int.Parse(TxtKategoriID.Text));
            db.Tbl_Kategori.Remove(kategoriIdBul);
            db.SaveChanges();
            MessageBox.Show("kategori silindi");
            KategoriListele();

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var kategoriIdBul = db.Tbl_Kategori.Find(int.Parse(TxtKategoriID.Text));
            kategoriIdBul.KategoriAd = TxtKategoriAd.Text;
            db.SaveChanges();
            MessageBox.Show("kategori güncellendi");
            KategoriListele();
        }
    }
}
