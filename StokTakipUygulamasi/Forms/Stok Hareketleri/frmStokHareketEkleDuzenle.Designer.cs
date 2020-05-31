namespace StokTakipUygulamasi.Forms.Stok_Hareketleri
{
    partial class frmStokHareketEkleDuzenle
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtFisNumarasi = new DevExpress.XtraEditors.TextEdit();
            this.lookUpUrun = new DevExpress.XtraEditors.LookUpEdit();
            this.dtpKayitTarihi = new DevExpress.XtraEditors.DateEdit();
            this.btnKapat = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtMiktar = new DevExpress.XtraEditors.TextEdit();
            this.lookUpDurum = new DevExpress.XtraEditors.LookUpEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDuzenle = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtFisNumarasi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpUrun.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpKayitTarihi.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpKayitTarihi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMiktar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDurum.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(21, 31);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(67, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Fiş Numarası :";
            // 
            // txtFisNumarasi
            // 
            this.txtFisNumarasi.Location = new System.Drawing.Point(93, 28);
            this.txtFisNumarasi.Name = "txtFisNumarasi";
            this.txtFisNumarasi.Size = new System.Drawing.Size(176, 20);
            this.txtFisNumarasi.TabIndex = 0;
            this.txtFisNumarasi.Leave += new System.EventHandler(this.txtFisNumarasi_Leave);
            // 
            // lookUpUrun
            // 
            this.lookUpUrun.Location = new System.Drawing.Point(95, 57);
            this.lookUpUrun.Name = "lookUpUrun";
            this.lookUpUrun.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpUrun.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StokKodu", "Stok Kodu"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StokAdi", "Stok Adı")});
            this.lookUpUrun.Properties.NullText = "Ürün Seçiniz";
            this.lookUpUrun.Size = new System.Drawing.Size(174, 20);
            this.lookUpUrun.TabIndex = 1;
            // 
            // dtpKayitTarihi
            // 
            this.dtpKayitTarihi.EditValue = null;
            this.dtpKayitTarihi.Location = new System.Drawing.Point(95, 136);
            this.dtpKayitTarihi.Name = "dtpKayitTarihi";
            this.dtpKayitTarihi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpKayitTarihi.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpKayitTarihi.Size = new System.Drawing.Size(174, 20);
            this.dtpKayitTarihi.TabIndex = 4;
            // 
            // btnKapat
            // 
            this.btnKapat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnKapat.Location = new System.Drawing.Point(187, 176);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(82, 31);
            this.btnKapat.TabIndex = 7;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(93, 176);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(82, 31);
            this.btnKaydet.TabIndex = 5;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(28, 143);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Kayıt Tarihi :";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(50, 112);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(38, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Durum :";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(58, 60);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(30, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Ürün :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(52, 86);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Miktar :";
            // 
            // txtMiktar
            // 
            this.txtMiktar.Location = new System.Drawing.Point(95, 83);
            this.txtMiktar.Name = "txtMiktar";
            this.txtMiktar.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtMiktar.Size = new System.Drawing.Size(174, 20);
            this.txtMiktar.TabIndex = 2;
            // 
            // lookUpDurum
            // 
            this.lookUpDurum.Location = new System.Drawing.Point(95, 109);
            this.lookUpDurum.Name = "lookUpDurum";
            this.lookUpDurum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpDurum.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HareketTipi", "Hareket Tipi")});
            this.lookUpDurum.Properties.NullText = "Giriş/Çıkış Durumu Seçiniz";
            this.lookUpDurum.Size = new System.Drawing.Size(174, 20);
            this.lookUpDurum.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDuzenle);
            this.groupBox1.Controls.Add(this.lookUpDurum);
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Controls.Add(this.lookUpUrun);
            this.groupBox1.Controls.Add(this.txtFisNumarasi);
            this.groupBox1.Controls.Add(this.dtpKayitTarihi);
            this.groupBox1.Controls.Add(this.txtMiktar);
            this.groupBox1.Controls.Add(this.btnKapat);
            this.groupBox1.Controls.Add(this.labelControl2);
            this.groupBox1.Controls.Add(this.btnKaydet);
            this.groupBox1.Controls.Add(this.labelControl5);
            this.groupBox1.Controls.Add(this.labelControl4);
            this.groupBox1.Controls.Add(this.labelControl3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 233);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.Location = new System.Drawing.Point(93, 176);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(82, 31);
            this.btnDuzenle.TabIndex = 6;
            this.btnDuzenle.Text = "Düzenle";
            this.btnDuzenle.Visible = false;
            this.btnDuzenle.Click += new System.EventHandler(this.btnDuzenle_Click);
            // 
            // frmStokHareketEkleDuzenle
            // 
            this.AcceptButton = this.btnKaydet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnKapat;
            this.ClientSize = new System.Drawing.Size(322, 262);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStokHareketEkleDuzenle";
            this.Text = "Yeni Stok Hareketi Ekle";
            ((System.ComponentModel.ISupportInitialize)(this.txtFisNumarasi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpUrun.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpKayitTarihi.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpKayitTarihi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMiktar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDurum.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtFisNumarasi;
        private DevExpress.XtraEditors.DateEdit dtpKayitTarihi;
        private DevExpress.XtraEditors.SimpleButton btnKapat;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtMiktar;
        private DevExpress.XtraEditors.LookUpEdit lookUpUrun;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LookUpEdit lookUpDurum;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btnDuzenle;
    }
}