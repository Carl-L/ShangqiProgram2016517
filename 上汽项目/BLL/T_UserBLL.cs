using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 上汽项目.Model;
using 上汽项目.DAL;
namespace 上汽项目.BLL
{
partial class T_UserBLL{
public int AddNew(T_User model){
return new T_UserDAL().AddNew(model);}
public bool Delete(int id){
return new T_UserDAL().Delete(id);}
public bool Update(T_User model){
return new T_UserDAL().Update(model);}
public T_User Get(int id){
return new T_UserDAL().Get(id);}
public IEnumerable<T_User> ListAll(){
return new T_UserDAL().ListAll();}
}}
