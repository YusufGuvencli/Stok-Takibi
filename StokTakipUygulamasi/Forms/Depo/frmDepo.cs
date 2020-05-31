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
        DepoBll depoBLL;
        DepoDto depoDto;
        public frmDepo()
        {
            InitializeComponent();
            DepolariGetir();
            depoBLL = new DepoBll();
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
            depoBLL = new DepoBll();
            depoDto.DepoAdi = txtDepoAdi.Text;
            depoDto.DepoKodu = txtDepoKodu.Text;
            CudEnums enums = depoBLL.DepoDuzenle(depoDto);
            FormHelpers.ShowMessage(enums);
            DepolariGetir();
            FormHelpers.ClearTextboxes(this.Controls);
        }

        public void DepoKaydet()
        {
            depoBLL = new DepoBll();
            DepoDto depoDto = new DepoDto()
            {
                DepoAdi = txtDepoAdi.Text,
                DepoKodu = txtDepoKodu.Text,
                AktifMi = true
            };
            CudEnums enums = depoBLL.DepoEkle(depoDto);

            FormHelpers.ShowMessage(enums);
            DepolariGetir();
            FormHelpers.ClearTextboxes(this.Controls);
        }

        private void DepoSil()
        {
            depoDto = new DepoDto();
            depoDto = (DepoDto)gridView1.GetRow(gridView1.FocusedRowHandle);
            CudEnums enums = depoBLL.DepoSil(depoDto);
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
            depoDto = new DepoDto();
            if (gridView1.SelectedRowsCount == 1)
            {
                düzenlemeyiKaydetToolStripMenuItem.Visible = true;
                depoDto = (DepoDto)gridView1.GetRow(gridView1.FocusedRowHandle);
                txtDepoAdi.Text = depoDto.DepoAdi;
                txtDepoKodu.Text = depoDto.DepoKodu;
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
        }

        private void silToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DepoSil();
        }
    }
}