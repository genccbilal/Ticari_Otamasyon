﻿
namespace Ticari_Otamasyon
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnUrunler = new DevExpress.XtraBars.BarButtonItem();
            this.btnStoklar = new DevExpress.XtraBars.BarButtonItem();
            this.btnMusteri = new DevExpress.XtraBars.BarButtonItem();
            this.btnFırmalar = new DevExpress.XtraBars.BarButtonItem();
            this.btnAnaSayfa = new DevExpress.XtraBars.BarButtonItem();
            this.btnPersonel = new DevExpress.XtraBars.BarButtonItem();
            this.btnGiderler = new DevExpress.XtraBars.BarButtonItem();
            this.btnKasa = new DevExpress.XtraBars.BarButtonItem();
            this.btnNotlar = new DevExpress.XtraBars.BarButtonItem();
            this.btnBankalar = new DevExpress.XtraBars.BarButtonItem();
            this.btnRehber = new DevExpress.XtraBars.BarButtonItem();
            this.btnFaturalar = new DevExpress.XtraBars.BarButtonItem();
            this.btnAyarlar = new DevExpress.XtraBars.BarButtonItem();
            this.btnHareketler = new DevExpress.XtraBars.BarButtonItem();
            this.btnRaporlar = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.barButtonItem1,
            this.btnUrunler,
            this.btnStoklar,
            this.btnMusteri,
            this.btnFırmalar,
            this.btnAnaSayfa,
            this.btnPersonel,
            this.btnGiderler,
            this.btnKasa,
            this.btnNotlar,
            this.btnBankalar,
            this.btnRehber,
            this.btnFaturalar,
            this.btnAyarlar,
            this.btnHareketler,
            this.btnRaporlar});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 18;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1532, 183);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.ActAsDropDown = true;
            this.barButtonItem1.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barButtonItem1.Caption = "ÜRÜNLER";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnUrunler
            // 
            this.btnUrunler.Caption = "ÜRÜNLER";
            this.btnUrunler.Id = 3;
            this.btnUrunler.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUrunler.ImageOptions.Image")));
            this.btnUrunler.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnUrunler.ImageOptions.LargeImage")));
            this.btnUrunler.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUrunler.ItemAppearance.Normal.Options.UseFont = true;
            this.btnUrunler.Name = "btnUrunler";
            this.btnUrunler.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUrunler_ItemClick);
            // 
            // btnStoklar
            // 
            this.btnStoklar.Caption = "STOKLAR";
            this.btnStoklar.Id = 4;
            this.btnStoklar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnStoklar.ImageOptions.Image")));
            this.btnStoklar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnStoklar.ImageOptions.LargeImage")));
            this.btnStoklar.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStoklar.ItemAppearance.Normal.Options.UseFont = true;
            this.btnStoklar.Name = "btnStoklar";
            this.btnStoklar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStoklar_ItemClick);
            // 
            // btnMusteri
            // 
            this.btnMusteri.Caption = "MÜŞTERİLER";
            this.btnMusteri.Id = 5;
            this.btnMusteri.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMusteri.ImageOptions.Image")));
            this.btnMusteri.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnMusteri.ImageOptions.LargeImage")));
            this.btnMusteri.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMusteri.ItemAppearance.Normal.Options.UseFont = true;
            this.btnMusteri.Name = "btnMusteri";
            this.btnMusteri.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMusteri_ItemClick);
            // 
            // btnFırmalar
            // 
            this.btnFırmalar.Caption = "FIRMALAR";
            this.btnFırmalar.Id = 6;
            this.btnFırmalar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnFırmalar.ImageOptions.Image")));
            this.btnFırmalar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnFırmalar.ImageOptions.LargeImage")));
            this.btnFırmalar.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFırmalar.ItemAppearance.Normal.Options.UseFont = true;
            this.btnFırmalar.Name = "btnFırmalar";
            this.btnFırmalar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFırmalar_ItemClick);
            // 
            // btnAnaSayfa
            // 
            this.btnAnaSayfa.Caption = "ANA SAYFA";
            this.btnAnaSayfa.Id = 7;
            this.btnAnaSayfa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAnaSayfa.ImageOptions.Image")));
            this.btnAnaSayfa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAnaSayfa.ImageOptions.LargeImage")));
            this.btnAnaSayfa.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAnaSayfa.ItemAppearance.Normal.Options.UseFont = true;
            this.btnAnaSayfa.Name = "btnAnaSayfa";
            this.btnAnaSayfa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAnaSayfa_ItemClick);
            // 
            // btnPersonel
            // 
            this.btnPersonel.Caption = "PERSONEL";
            this.btnPersonel.Id = 8;
            this.btnPersonel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPersonel.ImageOptions.Image")));
            this.btnPersonel.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPersonel.ImageOptions.LargeImage")));
            this.btnPersonel.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnPersonel.ItemAppearance.Normal.Options.UseFont = true;
            this.btnPersonel.Name = "btnPersonel";
            this.btnPersonel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPersonel_ItemClick);
            // 
            // btnGiderler
            // 
            this.btnGiderler.Caption = "GİDERLER";
            this.btnGiderler.Id = 9;
            this.btnGiderler.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGiderler.ImageOptions.Image")));
            this.btnGiderler.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGiderler.ImageOptions.LargeImage")));
            this.btnGiderler.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGiderler.ItemAppearance.Normal.Options.UseFont = true;
            this.btnGiderler.Name = "btnGiderler";
            this.btnGiderler.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGiderler_ItemClick);
            // 
            // btnKasa
            // 
            this.btnKasa.Caption = "KASA";
            this.btnKasa.Id = 10;
            this.btnKasa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKasa.ImageOptions.Image")));
            this.btnKasa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnKasa.ImageOptions.LargeImage")));
            this.btnKasa.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKasa.ItemAppearance.Normal.Options.UseFont = true;
            this.btnKasa.Name = "btnKasa";
            this.btnKasa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKasa_ItemClick);
            // 
            // btnNotlar
            // 
            this.btnNotlar.Caption = "NOTLAR";
            this.btnNotlar.Id = 11;
            this.btnNotlar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNotlar.ImageOptions.Image")));
            this.btnNotlar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNotlar.ImageOptions.LargeImage")));
            this.btnNotlar.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnNotlar.ItemAppearance.Normal.Options.UseFont = true;
            this.btnNotlar.Name = "btnNotlar";
            this.btnNotlar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNotlar_ItemClick);
            // 
            // btnBankalar
            // 
            this.btnBankalar.Caption = "BANKALAR";
            this.btnBankalar.Id = 12;
            this.btnBankalar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBankalar.ImageOptions.Image")));
            this.btnBankalar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBankalar.ImageOptions.LargeImage")));
            this.btnBankalar.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBankalar.ItemAppearance.Normal.Options.UseFont = true;
            this.btnBankalar.Name = "btnBankalar";
            this.btnBankalar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBankalar_ItemClick);
            // 
            // btnRehber
            // 
            this.btnRehber.Caption = "REHBER";
            this.btnRehber.Id = 13;
            this.btnRehber.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRehber.ImageOptions.Image")));
            this.btnRehber.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRehber.ImageOptions.LargeImage")));
            this.btnRehber.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRehber.ItemAppearance.Normal.Options.UseFont = true;
            this.btnRehber.Name = "btnRehber";
            this.btnRehber.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRehber_ItemClick);
            // 
            // btnFaturalar
            // 
            this.btnFaturalar.Caption = "FATURALAR";
            this.btnFaturalar.Id = 14;
            this.btnFaturalar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnFaturalar.ImageOptions.Image")));
            this.btnFaturalar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnFaturalar.ImageOptions.LargeImage")));
            this.btnFaturalar.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFaturalar.ItemAppearance.Normal.Options.UseFont = true;
            this.btnFaturalar.Name = "btnFaturalar";
            this.btnFaturalar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFaturalar_ItemClick);
            // 
            // btnAyarlar
            // 
            this.btnAyarlar.Caption = "AYARLAR";
            this.btnAyarlar.Id = 15;
            this.btnAyarlar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAyarlar.ImageOptions.Image")));
            this.btnAyarlar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAyarlar.ImageOptions.LargeImage")));
            this.btnAyarlar.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAyarlar.ItemAppearance.Normal.Options.UseFont = true;
            this.btnAyarlar.Name = "btnAyarlar";
            this.btnAyarlar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAyarlar_ItemClick);
            // 
            // btnHareketler
            // 
            this.btnHareketler.Caption = "HAREKETLER";
            this.btnHareketler.Id = 16;
            this.btnHareketler.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHareketler.ImageOptions.Image")));
            this.btnHareketler.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnHareketler.ImageOptions.LargeImage")));
            this.btnHareketler.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.btnHareketler.ItemAppearance.Normal.Options.UseFont = true;
            this.btnHareketler.Name = "btnHareketler";
            this.btnHareketler.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // btnRaporlar
            // 
            this.btnRaporlar.Caption = "RAPORLAR";
            this.btnRaporlar.Id = 17;
            this.btnRaporlar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRaporlar.ImageOptions.Image")));
            this.btnRaporlar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRaporlar.ImageOptions.LargeImage")));
            this.btnRaporlar.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRaporlar.ItemAppearance.Normal.Options.UseFont = true;
            this.btnRaporlar.Name = "btnRaporlar";
            this.btnRaporlar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRaporlar_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "TİCARİ OTAMASYON";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAnaSayfa);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnUrunler);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnStoklar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnMusteri);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnFırmalar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPersonel);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnGiderler);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNotlar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRehber);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnFaturalar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnHareketler);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnBankalar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRaporlar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnKasa);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAyarlar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1532, 1055);
            this.Controls.Add(this.ribbonControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TİCARİ OTOMASYON";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnUrunler;
        private DevExpress.XtraBars.BarButtonItem btnStoklar;
        private DevExpress.XtraBars.BarButtonItem btnMusteri;
        private DevExpress.XtraBars.BarButtonItem btnFırmalar;
        private DevExpress.XtraBars.BarButtonItem btnAnaSayfa;
        private DevExpress.XtraBars.BarButtonItem btnPersonel;
        private DevExpress.XtraBars.BarButtonItem btnGiderler;
        private DevExpress.XtraBars.BarButtonItem btnKasa;
        private DevExpress.XtraBars.BarButtonItem btnNotlar;
        private DevExpress.XtraBars.BarButtonItem btnBankalar;
        private DevExpress.XtraBars.BarButtonItem btnRehber;
        private DevExpress.XtraBars.BarButtonItem btnFaturalar;
        private DevExpress.XtraBars.BarButtonItem btnAyarlar;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarButtonItem btnHareketler;
        private DevExpress.XtraBars.BarButtonItem btnRaporlar;
    }
}

