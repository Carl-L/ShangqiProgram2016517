using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 上汽项目.DAL;
using System.Data;
using 上汽项目.Model;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace 上汽项目.BLL
{
    partial class T_UserBLL
    {
        public static string GetMD5(string sDataIn)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bytValue, bytHash;
            bytValue = System.Text.Encoding.UTF8.GetBytes(sDataIn);
            bytHash = md5.ComputeHash(bytValue);
            md5.Clear();
            string sTemp = "";
            for (int i = 0; i < bytHash.Length; i++)
            {
                sTemp += bytHash[i].ToString("X").PadLeft(2, '0');
            }
            return sTemp.ToLower();
        }

        // BLL可以有负责的判断操作
        public bool ValidateUser(string username, string password)
        {
            T_UserDAL dal = new T_UserDAL();
            T_User user = dal.GetByUserName(username);
            if (user == null)
            {
                // 不要在BLL中MessageBox
                return false;
            }
            if (GetMD5(password) != user.Password)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public T_User GetByUserName(string username)
        {
            return new T_UserDAL().GetByUserName(username);
        }

        public void ChangePassword(int id, string oldpwd, string newpwd)
        {
            T_UserDAL userDAL = new T_UserDAL();
            T_User user = userDAL.Get(id);
            if (user == null)
            {
                throw new Exception("不存在的UserId");
            }
            if (GetMD5(oldpwd) != user.Password)
            {
                throw new Exception("旧密码错误");
            }
            user.Password = GetMD5(newpwd);
            userDAL.Update(user);
        }


        public Double Median(Double[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            int endIndex = array.Length / 2;

            for (int i = 0; i <= endIndex; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j + 1] < array[j])
                    {
                        Double temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }
            }

            if (array.Length % 2 != 0)
            {
                return array[endIndex];
            }

            return (array[endIndex - 1] + array[endIndex]) / 2;
        }
    }
}
