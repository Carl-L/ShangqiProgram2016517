using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 上汽项目.BLL;
using 上汽项目.Model;

namespace 上汽项目
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = this.txtUserName.Text;
            string userPwd = this.txtPwd.Text;
            //string userType = this.cboUserType.Text;
            if (userName == "")
            {
                MessageBox.Show("用户名不能为空");
            }
            else if (userPwd == "")
            {
                MessageBox.Show("用户密码不能为空");
            }
            //else if (userType == "")
            //{
            //    MessageBox.Show("请输入用户类型");
            //}
            else if (new T_UserBLL().ValidateUser(txtUserName.Text, txtPwd.Text))// && this.cboUserType.Text == "一般用户")
            {
                T_User user = new T_UserBLL().GetByUserName(userName);
                Globals.CurrentUserId = user.Id;
                //Close();
                //MessageBox.Show("OK");
                DialogResult = DialogResult.OK;
            }
            else
            {
                //DialogResult = DialogResult.Cancel;
                MessageBox.Show("输入信息有误");
            }
            //if (txtUserName.Text == "admin" && txtPwd.Text == "888888")
            //{
            //    FormMain fm = new FormMain();
            //    //fm.Show();
            //    fm.ShowDialog();          
            //}
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            Login_Load();
        }

        private void Login_Load()
        { 
            // 添加权限管理
            //string[] UserType = {"一般用户", "管理员"};
            //foreach (string ut in UserType)
            //{
            //    cboUserType.Items.Add(ut);
            //}
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
