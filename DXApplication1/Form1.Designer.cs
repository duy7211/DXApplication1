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
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.barbtnLop = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnphong = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnMH = new DevExpress.XtraBars.BarButtonItem();
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
            this.barbtnMH});
            this.ribbonControl1.LargeImages = this.imageCollection1;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 11;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2});
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
            this.ribbonPageGroup2.ItemLinks.Add(this.gv);
            this.ribbonPageGroup2.ItemLinks.Add(this.barbtnLop);
            this.ribbonPageGroup2.ItemLinks.Add(this.barbtnphong);
            this.ribbonPageGroup2.ItemLinks.Add(this.barbtnMH);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // documentManager1
            // 
            this.documentManager1.MdiParent = this;
            this.documentManager1.MenuManager = this.ribbonControl1;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(942, 509);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "Form1";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
    }
}

