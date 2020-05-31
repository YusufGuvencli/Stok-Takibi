namespace StokTakipUygulamasi.Forms.Depo
{
    partial class frmDepo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDepo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdDepoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdDepoKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdDepoAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDepoAdi = new DevExpress.XtraEditors.TextEdit();
            this.txtDepoKodu = new DevExpress.XtraEditors.TextEdit();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.kaydetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.düzenlemeyiKaydetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DuzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepoAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepoKodu.Properties)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Controls.Add(this.panelControl1);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(495, 490);
            this.panel1.TabIndex = 5;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 114);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(495, 376);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdDepoId,
            this.grdDepoKodu,
            this.grdDepoAdi});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = " ";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            // 
            // grdDepoId
            // 
            this.grdDepoId.Caption = "ID";
            this.grdDepoId.FieldName = "DepoId";
            this.grdDepoId.Name = "grdDepoId";
            this.grdDepoId.OptionsColumn.AllowEdit = false;
            this.grdDepoId.Visible = true;
            this.grdDepoId.VisibleIndex = 1;
            // 
            // grdDepoKodu
            // 
            this.grdDepoKodu.Caption = "Depo Kodu";
            this.grdDepoKodu.FieldName = "DepoKodu";
            this.grdDepoKodu.Name = "grdDepoKodu";
            this.grdDepoKodu.OptionsColumn.AllowEdit = false;
            this.grdDepoKodu.Visible = true;
            this.grdDepoKodu.VisibleIndex = 2;
            // 
            // grdDepoAdi
            // 
            this.grdDepoAdi.Caption = "Depo Adı";
            this.grdDepoAdi.FieldName = "DepoAdi";
            this.grdDepoAdi.Name = "grdDepoAdi";
            this.grdDepoAdi.OptionsColumn.AllowEdit = false;
            this.grdDepoAdi.Visible = true;
            this.grdDepoAdi.VisibleIndex = 3;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.txtDepoAdi);
            this.panelControl1.Controls.Add(this.txtDepoKodu);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(495, 90);
            this.panelControl1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Depo Kodu :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Depo Adı :";
            // 
            // txtDepoAdi
            // 
            this.txtDepoAdi.Location = new System.Drawing.Point(105, 47);
            this.txtDepoAdi.Name = "txtDepoAdi";
            this.txtDepoAdi.Size = new System.Drawing.Size(187, 20);
            this.txtDepoAdi.TabIndex = 1;
            // 
            // txtDepoKodu
            // 
            this.txtDepoKodu.Location = new System.Drawing.Point(105, 19);
            this.txtDepoKodu.Name = "txtDepoKodu";
            this.txtDepoKodu.Size = new System.Drawing.Size(187, 20);
            this.txtDepoKodu.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kaydetToolStripMenuItem,
            this.düzenlemeyiKaydetToolStripMenuItem,
            this.DuzenleToolStripMenuItem,
            this.silToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(495, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // kaydetToolStripMenuItem
            // 
            this.kaydetToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("kaydetToolStripMenuItem.Image")));
            this.kaydetToolStripMenuItem.Name = "kaydetToolStripMenuItem";
            this.kaydetToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.kaydetToolStripMenuItem.Text = "Kaydet";
            this.kaydetToolStripMenuItem.Click += new System.EventHandler(this.kaydetToolStripMenuItem_Click_1);
            // 
            // düzenlemeyiKaydetToolStripMenuItem
            // 
            this.düzenlemeyiKaydetToolStripMenuItem.Image = global::StokTakipUygulamasi.Properties.Resources.save;
            this.düzenlemeyiKaydetToolStripMenuItem.Name = "düzenlemeyiKaydetToolStripMenuItem";
            this.düzenlemeyiKaydetToolStripMenuItem.Size = new System.Drawing.Size(142, 20);
            this.düzenlemeyiKaydetToolStripMenuItem.Text = "Düzenlemeyi Kaydet";
            this.düzenlemeyiKaydetToolStripMenuItem.Visible = false;
            this.düzenlemeyiKaydetToolStripMenuItem.Click += new System.EventHandler(this.düzenlemeyiKaydetToolStripMenuItem_Click);
            // 
            // DuzenleToolStripMenuItem
            // 
            this.DuzenleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DuzenleToolStripMenuItem.Image")));
            this.DuzenleToolStripMenuItem.Name = "DuzenleToolStripMenuItem";
            this.DuzenleToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.DuzenleToolStripMenuItem.Text = "Düzenle";
            this.DuzenleToolStripMenuItem.Click += new System.EventHandler(this.DuzenleToolStripMenuItem_Click);
            // 
            // silToolStripMenuItem1
            // 
            this.silToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("silToolStripMenuItem1.Image")));
            this.silToolStripMenuItem1.Name = "silToolStripMenuItem1";
            this.silToolStripMenuItem1.Size = new System.Drawing.Size(47, 20);
            this.silToolStripMenuItem1.Text = "Sil";
            this.silToolStripMenuItem1.Click += new System.EventHandler(this.silToolStripMenuItem1_Click);
            // 
            // frmDepo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 490);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDepo";
            this.Text = "Depo Ekle";
            this.Load += new System.EventHandler(this.DepoForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepoAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepoKodu.Properties)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kaydetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DuzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtDepoAdi;
        private DevExpress.XtraEditors.TextEdit txtDepoKodu;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn grdDepoId;
        private DevExpress.XtraGrid.Columns.GridColumn grdDepoKodu;
        private DevExpress.XtraGrid.Columns.GridColumn grdDepoAdi;
        private System.Windows.Forms.ToolStripMenuItem düzenlemeyiKaydetToolStripMenuItem;
    }
}