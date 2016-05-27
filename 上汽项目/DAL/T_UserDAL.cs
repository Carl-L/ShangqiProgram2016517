using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 上汽项目.Model;
using System.Data.SqlClient;
using System.Data;
namespace 上汽项目.DAL
{
partial class T_UserDAL
{
public int AddNew(T_User model){
string sql = "insert into T_User(UserName,Password,UserType) output inserted.id values(@UserName,@Password,@UserType)";
int id = (int)SqlHelper.ExecuteScalar(sql
,new SqlParameter("UserName", model.UserName)
,new SqlParameter("Password", model.Password)
,new SqlParameter("UserType", model.UserType)
);
return id;
}
public bool Update(T_User model){
string sql = "update T_User set UserName=@UserName,Password=@Password,UserType=@UserType where id=@id";
int rows = SqlHelper.ExecuteNonQuery(sql
,new SqlParameter("Id", model.Id)
,new SqlParameter("UserName", model.UserName)
,new SqlParameter("Password", model.Password)
,new SqlParameter("UserType", model.UserType)
);
return rows > 0;}
public bool Delete(int id){
int rows = SqlHelper.ExecuteNonQuery("delete from T_User where id=@id",
new SqlParameter("id",id));
return rows > 0;}
private static T_User ToModel(DataRow row){
T_User model = new T_User();
model.Id = (System.Int32)row["Id"];
model.UserName = (System.String)row["UserName"];
model.Password = (System.String)row["Password"];
model.UserType = (System.String)row["UserType"];
return model;}
public T_User Get(int id){
DataTable dt = SqlHelper.ExecuteDataTable("select * from T_User  where id=@id",
new SqlParameter("id",id));
if (dt.Rows.Count > 1)
{throw new Exception("more than 1 row was found");}
if (dt.Rows.Count <= 0){return null;}
DataRow row = dt.Rows[0];
T_User model = ToModel(row);
return model;}
public IEnumerable<T_User> ListAll(){
List<T_User> list = new List<T_User>();
DataTable dt = SqlHelper.ExecuteDataTable("select * from T_User");
foreach (DataRow row in dt.Rows){
list.Add(ToModel(row));}
return list;}
}
}
