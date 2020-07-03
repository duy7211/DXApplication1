namespace DXApplication1
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
            this.changepw = new DevExpress.XtraBars.BarButtonItem();
            this.qltk = new DevExpress.XtraBars.BarButtonItem();
            this.gv = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnLop = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnphong = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnMH = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnTKB = new DevExpress.XtraBars.BarButtonItem();
            this.barbtn_lich_lv = new DevExpress.XtraBars.BarButtonItem();
            this.barbtn_lich_hoc = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnPC = new DevExpress.XtraBars.BarButtonItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.btnCa = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.barButtonItem1,
            this.changepw,
            this.qltk,
            this.gv,
            this.barbtnLop,
            this.barbtnphong,
            this.barbtnMH,
            this.barbtnTKB,
            this.barbtn_lich_lv,
            this.barbtn_lich_hoc,
            this.barBtnPC,
            this.btnCa});
            this.ribbonControl1.LargeImages = this.imageCollection1;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 16;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2,
            this.ribbonPage3});
            this.ribbonControl1.Size = new System.Drawing.Size(942, 158);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Đăng xuất";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.ImageOptions.LargeImageIndex = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // changepw
            // 
            this.changepw.Caption = "Đổi mật khẩu";
            this.changepw.Id = 5;
            this.changepw.ImageOptions.LargeImageIndex = 2;
            this.changepw.Name = "changepw";
            this.changepw.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.changepw_ItemClick);
            // 
            // qltk
            // 
            this.qltk.Caption = "Quản lý tài khoản";
            this.qltk.Id = 6;
            this.qltk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("qltk.ImageOptions.Image")));
            this.qltk.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("qltk.ImageOptions.LargeImage")));
            this.qltk.Name = "qltk";
            this.qltk.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.qltk_ItemClick);
            // 
            // gv
            // 
            this.gv.Caption = "Giảng Viên";
            this.gv.Id = 7;
            this.gv.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gv.ImageOptions.Image")));
            this.gv.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("gv.ImageOptions.LargeImage")));
            this.gv.Name = "gv";
            this.gv.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.gv_ItemClick);
            // 
            // barbtnLop
            // 
            this.barbtnLop.Caption = "Lớp";
            this.barbtnLop.Id = 8;
            this.barbtnLop.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barbtnLop.ImageOptions.Image")));
            this.barbtnLop.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barbtnLop.ImageOptions.LargeImage")));
            this.barbtnLop.Name = "barbtnLop";
            this.barbtnLop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnLop_ItemClick);
            // 
            // barbtnphong
            // 
            this.barbtnphong.Caption = "Phòng";
            this.barbtnphong.Id = 9;
            this.barbtnphong.ImageOptions.LargeImageIndex = 3;
            this.barbtnphong.Name = "barbtnphong";
            this.barbtnphong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnphong_ItemClick);
            // 
            // barbtnMH
            // 
            this.barbtnMH.Caption = "Môn học";
            this.barbtnMH.Id = 10;
            this.barbtnMH.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barbtnMH.ImageOptions.Image")));
            this.barbtnMH.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barbtnMH.ImageOptions.LargeImage")));
            this.barbtnMH.Name = "barbtnMH";
            this.barbtnMH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnMH_ItemClick);
            // 
            // barbtnTKB
            // 
            this.barbtnTKB.Caption = "Sắp thời khóa biểu";
            this.barbtnTKB.Id = 11;
            this.barbtnTKB.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barbtnTKB.ImageOptions.Image")));
            this.barbtnTKB.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barbtnTKB.ImageOptions.LargeImage")));
            this.barbtnTKB.Name = "barbtnTKB";
            this.barbtnTKB.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnTKB_ItemClick);
            // 
            // barbtn_lich_lv
            // 
            this.barbtn_lich_lv.Caption = "Lịch làm việc";
            this.barbtn_lich_lv.Id = 12;
            this.barbtn_lich_lv.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barbtn_lich_lv.ImageOptions.Image")));
            this.barbtn_lich_lv.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barbtn_lich_lv.ImageOptions.LargeImage")));
            this.barbtn_lich_lv.Name = "barbtn_lich_lv";
            this.barbtn_lich_lv.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtn_lich_lv_ItemClick);
            // 
            // barbtn_lich_hoc
            // 
            this.barbtn_lich_hoc.Caption = "Lịch Học";
            this.barbtn_lich_hoc.Id = 13;
            this.barbtn_lich_hoc.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barbtn_lich_hoc.ImageOptions.Image")));
            this.barbtn_lich_hoc.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barbtn_lich_hoc.ImageOptions.LargeImage")));
            this.barbtn_lich_hoc.Name = "barbtn_lich_hoc";
            this.barbtn_lich_hoc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtn_lich_hoc_ItemClick);
            // 
            // barBtnPC
            // 
            this.barBtnPC.Caption = "Phân công giảng dạy";
            this.barBtnPC.Id = 14;
            this.barBtnPC.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnPC.ImageOptions.Image")));
            this.barBtnPC.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnPC.ImageOptions.LargeImage")));
            this.barBtnPC.Name = "barBtnPC";
            this.barBtnPC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnPC_ItemClick);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "logout.png");
            this.imageCollection1.Images.SetKeyName(1, "teacher.png");
            this.imageCollection1.Images.SetKeyName(2, "pw.png");
            this.imageCollection1.Images.SetKeyName(3, "classroom.png");
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Hệ Thống";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.changepw);
            this.ribbonPageGroup1.ItemLinks.Add(this.qltk);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Dữ Liệu";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barBtnPC);
            this.ribbonPageGroup2.ItemLinks.Add(this.gv);
            this.ribbonPageGroup2.ItemLinks.Add(this.barbtnLop);
            this.ribbonPageGroup2.ItemLinks.Add(this.barbtnphong);
            this.ribbonPageGroup2.ItemLinks.Add(this.barbtnMH);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnCa);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "Lịch";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barbtnTKB);
            this.ribbonPageGroup3.ItemLinks.Add(this.barbtn_lich_lv);
            this.ribbonPageGroup3.ItemLinks.Add(this.barbtn_lich_hoc);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // documentManager1
            // 
            this.documentManager1.MdiParent = this;
            this.documentManager1.MenuManager = this.ribbonControl1;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // btnCa
            // 
            this.btnCa.Caption = "Ca";
            this.btnCa.Id = 15;
            this.btnCa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCa.ImageOptions.Image")));
            this.btnCa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCa.ImageOptions.LargeImage")));
            this.btnCa.Name = "btnCa";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(942, 665);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "Form1";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.BarButtonItem changepw;
        private DevExpress.XtraBars.BarButtonItem qltk;
        private DevExpress.XtraBars.BarButtonItem gv;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem barbtnLop;
        private DevExpress.XtraBars.BarButtonItem barbtnphong;
        private DevExpress.XtraBars.BarButtonItem barbtnMH;
        private DevExpress.XtraBars.BarButtonItem barbtnTKB;
        private DevExpress.XtraBars.BarButtonItem barbtn_lich_lv;
        private DevExpress.XtraBars.BarButtonItem barbtn_lich_hoc;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem barBtnPC;
        private DevExpress.XtraBars.BarButtonItem btnCa;
    }
}

