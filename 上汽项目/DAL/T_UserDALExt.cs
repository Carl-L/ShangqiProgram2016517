using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 上汽项目.Model;
using System.Data;
using System.Data.SqlClient;

namespace 上汽项目.DAL
{
    partial class T_UserDAL
    {
        // DataTable DataRow只应该在DAL中出现，DAL返回的应该是Model
        public T_User GetByUserName(string username)
        {
            DataTable dt = SqlHelper.ExecuteDataTable(
                "select * from T_User where UserName=@UserName", 
                new SqlParameter("UserName", username));
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else if (dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                T_User user = new T_User();
                user.Id = (int)row["Id"];
                user.UserName = (string)row["UserName"];
                user.Password = (string)row["Password"];
                return user;
            }
            else
            {
                throw new Exception("出现重复的用户名");
            }
        }
    }
}
