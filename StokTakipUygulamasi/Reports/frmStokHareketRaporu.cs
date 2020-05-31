using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using StokTakibi.BLL.Business_Operations.Raporlar;
using DevExpress.XtraReports.UI;

namespace StokTakipUygulamasi.Reports
{
    public partial class frmStokHareketRaporu : DevExpress.XtraEditors.XtraForm
    {
        StokHareketRaporBll bllStokHareket;
        public frmStokHareketRaporu()
        {
            bllStokHareket = new StokHareketRaporBll();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rptStokHareket rpt = new rptStokHareket();
            rpt.DataSource = bllStokHareket.StokHareketRaporuGetir();
            
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptStokHareket rpt = new rptStokHareket();
            rpt.Print();
        }
    }
}
