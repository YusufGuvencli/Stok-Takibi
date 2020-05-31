namespace StokTakipUygulamasi.Forms.Stok_Karti
{
    partial class frmStokKartlari
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.stokKartıEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DuzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kapatToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStokKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStokAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKdv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFiyat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnKapat = new DevExpress.XtraEditors.SimpleButton();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stokKartıEkleToolStripMenuItem,
            this.DuzenleToolStripMenuItem,
            this.silToolStripMenuItem,
            this.kapatToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // stokKartıEkleToolStripMenuItem
            // 
            this.stokKartıEkleToolStripMenuItem.Image = global::StokTakipUygulamasi.Properties.Resources.add;
            this.stokKartıEkleToolStripMenuItem.Name = "stokKartıEkleToolStripMenuItem";
            this.stokKartıEkleToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.stokKartıEkleToolStripMenuItem.Text = "Yeni Stok";
            this.stokKartıEkleToolStripMenuItem.Click += new System.EventHandler(this.stokKartıEkleToolStripMenuItem_Click);
            // 
            // DuzenleToolStripMenuItem
            // 
            this.DuzenleToolStripMenuItem.Image = global::StokTakipUygulamasi.Properties.Resources.edit;
            this.DuzenleToolStripMenuItem.Name = "DuzenleToolStripMenuItem";
            this.DuzenleToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.DuzenleToolStripMenuItem.Text = "Düzenle";
            this.DuzenleToolStripMenuItem.Click += new System.EventHandler(this.DuzenleToolStripMenuItem_Click);
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.Image = global::StokTakipUygulamasi.Properties.Resources.delete;
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.silToolStripMenuItem.Text = "Sil";
            this.silToolStripMenuItem.Click += new System.EventHandler(this.silToolStripMenuItem_Click);
            // 
            // kapatToolStripMenuItem1
            // 
            this.kapatToolStripMenuItem1.Name = "kapatToolStripMenuItem1";
            this.kapatToolStripMenuItem1.Size = new System.Drawing.Size(49, 20);
            this.kapatToolStripMenuItem1.Text = "Kapat";
            this.kapatToolStripMenuItem1.Click += new System.EventHandler(this.kapatToolStripMenuItem1_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 24);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(784, 606);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStokKodu,
            this.colStokAdi,
            this.colKdv,
            this.colFiyat,
            this.colAciklama});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = " ";
            this.gridView1.Name = "gridView1";
            // 
            // colStokKodu
            // 
            this.colStokKodu.Caption = "Stok Kodu";
            this.colStokKodu.FieldName = "stokKodu";
            this.colStokKodu.Name = "colStokKodu";
            this.colStokKodu.OptionsColumn.AllowEdit = false;
            this.colStokKodu.Visible = true;
            this.colStokKodu.VisibleIndex = 0;
            // 
            // colStokAdi
            // 
            this.colStokAdi.Caption = "Stok Adı";
            this.colStokAdi.FieldName = "StokAdi";
            this.colStokAdi.Name = "colStokAdi";
            this.colStokAdi.OptionsColumn.AllowEdit = false;
            this.colStokAdi.Visible = true;
            this.colStokAdi.VisibleIndex = 1;
            // 
            // colKdv
            // 
            this.colKdv.Caption = "KDV";
            this.colKdv.FieldName = "Kdv";
            this.colKdv.Name = "colKdv";
            this.colKdv.OptionsColumn.AllowEdit = false;
            this.colKdv.Visible = true;
            this.colKdv.VisibleIndex = 2;
            // 
            // colFiyat
            // 
            this.colFiyat.Caption = "Fiyat";
            this.colFiyat.FieldName = "Fiyat";
            this.colFiyat.Name = "colFiyat";
            this.colFiyat.OptionsColumn.AllowEdit = false;
            this.colFiyat.Visible = true;
            this.colFiyat.VisibleIndex = 3;
            // 
            // colAciklama
            // 
            this.colAciklama.Caption = "Aciklama";
            this.colAciklama.FieldName = "Aciklama";
            this.colAciklama.Name = "colAciklama";
            this.colAciklama.OptionsColumn.AllowEdit = false;
            this.colAciklama.Visible = true;
            this.colAciklama.VisibleIndex = 4;
            // 
            // btnKapat
            // 
            this.btnKapat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnKapat.Location = new System.Drawing.Point(711, 27);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(45, 23);
            this.btnKapat.TabIndex = 2;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Visible = false;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // frmStokKartlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnKapat;
            this.ClientSize = new System.Drawing.Size(784, 630);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmStokKartlari";
            this.Text = "Stok Kartları";
            this.Load += new System.EventHandler(this.frmStokKartlari_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem stokKartıEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DuzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kapatToolStripMenuItem1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colStokKodu;
        private DevExpress.XtraGrid.Columns.GridColumn colStokAdi;
        private DevExpress.XtraGrid.Columns.GridColumn colKdv;
        private DevExpress.XtraGrid.Columns.GridColumn colFiyat;
        private DevExpress.XtraGrid.Columns.GridColumn colAciklama;
        private DevExpress.XtraEditors.SimpleButton btnKapat;
    }
}