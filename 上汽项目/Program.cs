using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace 上汽项目
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormLogin formlogin = new FormLogin();
            //Application.Run(new FormMain());
            if (formlogin.ShowDialog() == DialogResult.OK)
            {
                // Application.Run启动的是主窗口，主窗口被关闭就退出了
                Application.Run(new FormMain());
            }
        }
    }
}
