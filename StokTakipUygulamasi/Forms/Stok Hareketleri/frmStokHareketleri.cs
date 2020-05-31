using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using StokTakibi.BLL.Business_Operations;
using StokTakibi.Entities.Stok_Hareketleri;
using StokTakibi.Entities.SqlView;
using StokTakibi.Helper.Form_Helpers;
using StokTakibi.Helper.Enums;

namespace StokTakipUygulamasi.Forms.Stok_Hareketleri
{
    public partial class frmStokHareketleri : DevExpress.XtraEditors.XtraForm
    {
        StokHareketleriBLL stokHareketleriBLL;
        int kullaniciId;

        public frmStokHareketleri(int _kullaniciId)
        {
            InitializeComponent();
            stokHareketleriBLL = new StokHareketleriBLL();
            StokHareketleriniGetir();
            kullaniciId = _kullaniciId;
        }
        private void StokHareketleriniGetir()
        {
            grdStokHareketleri.DataSource = stokHareketleriBLL.StokHareketleriniGetir();
        }

        private void hareketEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStokHareketEkleDuzenle frmStokHareket = new frmStokHareketEkleDuzenle(kullaniciId);
            frmStokHareket.ShowDialog();
            StokHareketleriniGetir();
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StokHareketView stokHareketleri = new StokHareketView();
            stokHareketleri = (StokHareketView)gridView1.GetRow(gridView1.FocusedRowHandle);
            frmStokHareketEkleDuzenle frmStokHareket = new frmStokHareketEkleDuzenle(kullaniciId, stokHareketleri);
            frmStokHareket.ShowDialog();
            StokHareketleriniGetir();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StokHareketView stokHareketleri = new StokHareketView();
            if (gridView1.SelectedRowsCount == 1)
            {
                stokHareketleri = (StokHareketView)gridView1.GetRow(gridView1.FocusedRowHandle);
                StokHareketleriDto stokHareketleriDto = stokHareketleriBLL.StokHareketiBul(stokHareketleri.HareketId);
                CudEnums enums = stokHareketleriBLL.StokHareketiSil(stokHareketleriDto);
                FormHelpers.ShowMessage(enums);
                StokHareketleriniGetir();
            }
            else if (gridView1.SelectedRowsCount > 1)
            {
                FormHelpers.ShowWarning("Aynı anda tek kayıt silebilirsiniz.");
            }
            else
            {
                FormHelpers.ShowWarning("Lütfen silmek istediğiniz kaydı seçiniz!");
            }


        }
    }
}