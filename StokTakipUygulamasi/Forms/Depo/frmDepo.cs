using StokTakibi.BLL.Business_Operations;
using StokTakibi.Helper.Form_Helpers;
using StokTakibi.Entities.Depo;
using System;
using StokTakibi.Helper.Enums;
using DevExpress.Data.Utils;
using System.Linq;

namespace StokTakipUygulamasi.Forms.Depo
{
    public partial class frmDepo : DevExpress.XtraEditors.XtraForm
    {
        DepoBll bllDepo;
        DepoDto dtoDepo;
        public frmDepo()
        {
            InitializeComponent();
            DepolariGetir();
            bllDepo = new DepoBll();
        }

        #region Methods 
        private void DepolariGetir()
        {
            DepoBll depoBLL = new DepoBll();
            gridControl1.DataSource = depoBLL.DepolariGetir().ToList();
            txtDepoKodu.Focus();
        }

        private void DepoDuzenle()
        {
            bllDepo = new DepoBll();
            dtoDepo.DepoAdi = txtDepoAdi.Text;
            dtoDepo.DepoKodu = txtDepoKodu.Text;
            CudEnums enums = bllDepo.DepoDuzenle(dtoDepo);
            FormHelpers.ShowMessage(enums);
            DepolariGetir();
            FormHelpers.ClearTextboxes(this.Controls);
        }

        public void DepoKaydet()
        {
            bllDepo = new DepoBll();
            DepoDto depoDto = new DepoDto()
            {
                DepoAdi = txtDepoAdi.Text,
                DepoKodu = txtDepoKodu.Text,
                AktifMi = true
            };
            CudEnums enums = bllDepo.DepoEkle(depoDto);

            FormHelpers.ShowMessage(enums);
            DepolariGetir();
            FormHelpers.ClearTextboxes(this.Controls);
        }

        private void DepoSil()
        {
            dtoDepo = new DepoDto();
            dtoDepo = (DepoDto)gridView1.GetRow(gridView1.FocusedRowHandle);
            CudEnums enums = bllDepo.DepoSil(dtoDepo);
            FormHelpers.ShowMessage(enums);
            DepolariGetir();
        }
        #endregion
       
        private void DepoForm_Load(object sender, System.EventArgs e)
        {
            DepolariGetir();
        }

        private void kaydetToolStripMenuItem_Click_1(object sender, System.EventArgs e)
        {
            DepoKaydet();            
        }

        private void DuzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dtoDepo = new DepoDto();
            if (gridView1.SelectedRowsCount == 1)
            {
                düzenlemeyiKaydetToolStripMenuItem.Visible = true;
                dtoDepo = (DepoDto)gridView1.GetRow(gridView1.FocusedRowHandle);
                txtDepoAdi.Text = dtoDepo.DepoAdi;
                txtDepoKodu.Text = dtoDepo.DepoKodu;
            }
            else if (gridView1.SelectedRowsCount > 1)
            {
                FormHelpers.ShowWarning("Aynı anda tek satırda düzenleme yapabilirsiniz!");
            }
            else
            {
                FormHelpers.ShowWarning("Düzenlemek istediğiniz depoyu seçiniz!");
            }
        }
        private void düzenlemeyiKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DepoDuzenle();
            düzenlemeyiKaydetToolStripMenuItem.Visible = false;
        }

        private void silToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DepoSil();
        }
    }
}