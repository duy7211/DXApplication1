using DXApplication1.QLLopHoc;
using DXApplication1.QLMonHoc;
using DXApplication1.QlPhong;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

    
      

        private void changepw_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Changepw cp = new Changepw();
            cp.MdiParent = this;
            cp.Show();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Session.Id = "";
            Session.Username = "";
            this.Hide();
            login lg = new login();
            lg.ShowDialog();
            this.Close();
        }

        private void qltk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            QuanlyTK tk = new QuanlyTK();
            tk.MdiParent = this;
            tk.Show();
        }

        private void gv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            QuanlyGV gv = new QuanlyGV();
            gv.MdiParent = this;
            gv.Show();
        }

        private void barbtnLop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            QuanlyLop l = new QuanlyLop();
            l.MdiParent = this;
            l.Show();
        }

        private void barbtnphong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            QuanlyPhong p = new QuanlyPhong();
            p.MdiParent = this;
            p.Show();
        }

        private void barbtnMH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            QuanLyMonHoc mh = new QuanLyMonHoc();
            mh.MdiParent = this;
            mh.Show();
        }
    }
}
