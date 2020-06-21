using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DXApplication1.QLLopHoc;
using DXApplication1.QLMonHoc;
using DXApplication1.PCCongViec;
using DXApplication1.XepTKB;
using DXApplication1.Lichlamviec;
using DXApplication1.Lichhoc;

namespace DXApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
