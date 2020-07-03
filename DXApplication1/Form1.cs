using DXApplication1.Lichhoc;
using DXApplication1.Lichlamviec;
using DXApplication1.PCCongViec;
using DXApplication1.QLLopHoc;
using DXApplication1.QLMonHoc;
using DXApplication1.QlPhong;
using DXApplication1.XepTKB;
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
            if (Application.OpenForms[cp.Name] == null)
            {
                cp.MdiParent = this;
                cp.Show();
            }
            else
            {
                Application.OpenForms[cp.Name].Focus();
            }

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
            if (Application.OpenForms[tk.Name] == null)
            {
                tk.MdiParent = this;
                tk.Show();
            }
            else
            {
                Application.OpenForms[tk.Name].Focus();
            }
        }

        private void gv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            QuanlyGV gv = new QuanlyGV();
            if (Application.OpenForms[gv.Name] == null)
            {
                gv.MdiParent = this;
                gv.Show();
            }
            else
            {
                Application.OpenForms[gv.Name].Focus();
            }
            
        }

        private void barbtnLop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            QuanlyLop l = new QuanlyLop();
            if (Application.OpenForms[l.Name] == null)
            {
                l.MdiParent = this;
                l.Show();
            }
            else
            {
                Application.OpenForms[l.Name].Focus();
            }
        }

        private void barbtnphong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            QuanlyPhong p = new QuanlyPhong();
            if (Application.OpenForms[p.Name] == null)
            {
                p.MdiParent = this;
                p.Show();
            }
            else
            {
                Application.OpenForms[p.Name].Focus();
            }
        }

        private void barbtnMH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            QuanLyMonHoc mh = new QuanLyMonHoc();
            if (Application.OpenForms[mh.Name] == null)
            {
                mh.MdiParent = this;
                mh.Show();
            }
            else
            {
                Application.OpenForms[mh.Name].Focus();
            }
        }

        private void barbtnTKB_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrXepTKB tkb = new FrXepTKB();
            if (Application.OpenForms[tkb.Name] == null)
            {
                tkb.MdiParent = this;
                tkb.Show();
            }
            else
            {
                Application.OpenForms[tkb.Name].Focus();
            }
        }

        private void barbtn_lich_lv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Lichlv lich = new Lichlv();
            if (Application.OpenForms[lich.Name] == null)
            {
                lich.MdiParent = this;
                lich.Show();
            }
            else
            {
                Application.OpenForms[lich.Name].Focus();
            }
        }

        private void barbtn_lich_hoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LichHoc lh = new LichHoc();
            if (Application.OpenForms[lh.Name] == null)
            {
                lh.MdiParent = this;
                lh.Show();
            }
            else
            {
                Application.OpenForms[lh.Name].Focus();
            }
        }

        private void barBtnPC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PhanCongCV pc = new PhanCongCV();
            if (Application.OpenForms[pc.Name] == null)
            {
                pc.MdiParent = this;
                pc.Show();
            }
            else
            {
                Application.OpenForms[pc.Name].Focus();
            }
        }
    }
}
