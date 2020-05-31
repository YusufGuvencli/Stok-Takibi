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
using DevExpress.XtraReports.UI;

namespace StokTakipUygulamasi.Reports
{
    public partial class frmStokDurumRaporu : DevExpress.XtraEditors.XtraForm
    {
        public frmStokDurumRaporu()
        {
            InitializeComponent();
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptStokDurum rpt = new rptStokDurum();
            rpt.Print();
        }
    }
}