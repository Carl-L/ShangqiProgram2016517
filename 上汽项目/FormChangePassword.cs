using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 上汽项目.Model;
using 上汽项目.BLL;

namespace 上汽项目
{
    public partial class FormChangePassword : Form
    {
        public FormChangePassword()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string oldpwd = txtOldPwd.Text;
            string newpwd = txtNewPwd.Text;
            string newpwdrep = txtNewPwdRep.Text;
            if (newpwd != newpwdrep)
            {
                MessageBox.Show("两次输入的新密码不相等！");
                return;
            }
            T_UserBLL userBll = new T_UserBLL();
            try
            {
                userBll.ChangePassword(Globals.CurrentUserId, oldpwd, newpwd);
                MessageBox.Show("修改成功");
                Close();
            }
            catch (Exception ex)
            { 
                // ex.ToString()是包含错误信息、调用堆栈的东西
                MessageBox.Show("发生错误：" + ex.Message);
            }
        }
    }
}
