namespace StokTakipUygulamasi.Forms.Stok_Hareketleri
{
    partial class frmStokHareketleri
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
            this.hareketEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kapatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grdStokHareketleri = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStokHareketleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hareketEkleToolStripMenuItem,
            this.düzenleToolStripMenuItem,
            this.silToolStripMenuItem,
            this.kapatToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(488, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hareketEkleToolStripMenuItem
            // 
            this.hareketEkleToolStripMenuItem.Image = global::StokTakipUygulamasi.Properties.Resources.add;
            this.hareketEkleToolStripMenuItem.Name = "hareketEkleToolStripMenuItem";
            this.hareketEkleToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.hareketEkleToolStripMenuItem.Text = "Hareket Ekle";
            this.hareketEkleToolStripMenuItem.Click += new System.EventHandler(this.hareketEkleToolStripMenuItem_Click);
            // 
            // düzenleToolStripMenuItem
            // 
            this.düzenleToolStripMenuItem.Image = global::StokTakipUygulamasi.Properties.Resources.edit;
            this.düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            this.düzenleToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.düzenleToolStripMenuItem.Text = "Düzenle";
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.Image = global::StokTakipUygulamasi.Properties.Resources.delete;
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.silToolStripMenuItem.Text = "Sil";
            // 
            // kapatToolStripMenuItem
            // 
            this.kapatToolStripMenuItem.Name = "kapatToolStripMenuItem";
            this.kapatToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.kapatToolStripMenuItem.Text = "Kapat";
            // 
            // grdStokHareketleri
            // 
            this.grdStokHareketleri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStokHareketleri.Location = new System.Drawing.Point(0, 24);
            this.grdStokHareketleri.MainView = this.gridView1;
            this.grdStokHareketleri.Name = "grdStokHareketleri";
            this.grdStokHareketleri.Size = new System.Drawing.Size(488, 448);
            this.grdStokHareketleri.TabIndex = 1;
            this.grdStokHareketleri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdStokHareketleri;
            this.gridView1.GroupPanelText = " ";
            this.gridView1.Name = "gridView1";
            // 
            // frmStokHareketleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 472);
            this.Controls.Add(this.grdStokHareketleri);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmStokHareketleri";
            this.Text = "Stok Hareketleri";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStokHareketleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hareketEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kapatToolStripMenuItem;
        private DevExpress.XtraGrid.GridControl grdStokHareketleri;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}