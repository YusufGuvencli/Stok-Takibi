﻿namespace StokTakipUygulamasi.Forms
{
    partial class frmAna
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
            this.stokİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stokEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stokHareketleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.depoİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.depoEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raporlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stokHareketRaporuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stokDurumRaporuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stokİşlemleriToolStripMenuItem,
            this.depoİşlemleriToolStripMenuItem,
            this.raporlarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(867, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // stokİşlemleriToolStripMenuItem
            // 
            this.stokİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stokEkleToolStripMenuItem,
            this.stokHareketleriToolStripMenuItem});
            this.stokİşlemleriToolStripMenuItem.Name = "stokİşlemleriToolStripMenuItem";
            this.stokİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.stokİşlemleriToolStripMenuItem.Text = "Stok İşlemleri";
            // 
            // stokEkleToolStripMenuItem
            // 
            this.stokEkleToolStripMenuItem.Name = "stokEkleToolStripMenuItem";
            this.stokEkleToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.stokEkleToolStripMenuItem.Text = "Stok Kartları";
            this.stokEkleToolStripMenuItem.Click += new System.EventHandler(this.stokEkleToolStripMenuItem_Click);
            // 
            // stokHareketleriToolStripMenuItem
            // 
            this.stokHareketleriToolStripMenuItem.Name = "stokHareketleriToolStripMenuItem";
            this.stokHareketleriToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.stokHareketleriToolStripMenuItem.Text = "Stok Hareketleri";
            this.stokHareketleriToolStripMenuItem.Click += new System.EventHandler(this.stokHareketleriToolStripMenuItem_Click);
            // 
            // depoİşlemleriToolStripMenuItem
            // 
            this.depoİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.depoEkleToolStripMenuItem});
            this.depoİşlemleriToolStripMenuItem.Name = "depoİşlemleriToolStripMenuItem";
            this.depoİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.depoİşlemleriToolStripMenuItem.Text = "Depo İşlemleri";
            // 
            // depoEkleToolStripMenuItem
            // 
            this.depoEkleToolStripMenuItem.Name = "depoEkleToolStripMenuItem";
            this.depoEkleToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.depoEkleToolStripMenuItem.Text = "Depo Ekle";
            this.depoEkleToolStripMenuItem.Click += new System.EventHandler(this.depoEkleToolStripMenuItem_Click);
            // 
            // raporlarToolStripMenuItem
            // 
            this.raporlarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stokHareketRaporuToolStripMenuItem,
            this.stokDurumRaporuToolStripMenuItem});
            this.raporlarToolStripMenuItem.Name = "raporlarToolStripMenuItem";
            this.raporlarToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.raporlarToolStripMenuItem.Text = "Raporlar";
            // 
            // stokHareketRaporuToolStripMenuItem
            // 
            this.stokHareketRaporuToolStripMenuItem.Name = "stokHareketRaporuToolStripMenuItem";
            this.stokHareketRaporuToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.stokHareketRaporuToolStripMenuItem.Text = "Stok Hareket Raporu";
            this.stokHareketRaporuToolStripMenuItem.Click += new System.EventHandler(this.stokHareketRaporuToolStripMenuItem_Click);
            // 
            // stokDurumRaporuToolStripMenuItem
            // 
            this.stokDurumRaporuToolStripMenuItem.Name = "stokDurumRaporuToolStripMenuItem";
            this.stokDurumRaporuToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.stokDurumRaporuToolStripMenuItem.Text = "Stok Durum Raporu";
            this.stokDurumRaporuToolStripMenuItem.Click += new System.EventHandler(this.stokDurumRaporuToolStripMenuItem_Click);
            // 
            // frmAna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 497);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmAna";
            this.Text = "Stok Takip Programı";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AnaForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem stokİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem depoİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem depoEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokHareketleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raporlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokHareketRaporuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokDurumRaporuToolStripMenuItem;
    }
}