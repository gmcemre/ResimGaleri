using ResimGaleri.ORM.Entity;
using ResimGaleri.ORM.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResimGaleri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Urunlers.Listele();
        }

        private void resimEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;
            int id = (int)dataGridView1.CurrentRow.Cells["UrunID"].Value;
            openFileDialog1.Title = "Resim Seç";
            openFileDialog1.Filter = "Jpg | *.jpg | Png | *.png";
            DialogResult sonuc = openFileDialog1.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);

                BinaryReader br = new BinaryReader(fs);
                byte[] resim = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();

                UrunResim ur = new UrunResim();
                ur.UrunID = id;
                ur.Resim = resim;

                if (UrunResimler.Ekle(ur))
                {
                    dataGridView1.DataSource = Urunlers.Listele();
                    MessageBox.Show("Ürüne resim ekleme başarılı.");
                }
                else
                {
                    MessageBox.Show("Ürüne resim ekleme başarısız.");
                }
            }
        }

        private void resimleriGösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;
            int id = (int)dataGridView1.CurrentRow.Cells["UrunID"].Value;

            ResimlerForm rf = new ResimlerForm();
            rf.UrunID = id;
            rf.ShowDialog();
        }
    }
}
