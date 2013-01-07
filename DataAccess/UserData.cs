using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextileCity.DBUtility;
using TextileCity.Entity;

namespace TextileCity.DataAccess
{
    public class UserData
    {
        public UserData()
		{}
		 
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from user");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			return MysqlHelper.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into user(");
			strSql.Append("account,email,password,state,name,phone,company,address,sex,register_time)");
			strSql.Append(" values (");
			strSql.Append("?account,?email,?password,?state,?name,?phone,?company,?address,?sex,?register_time)");
			MySqlParameter[] parameters = {
					new MySqlParameter("?account", MySqlDbType.VarChar,20),
					new MySqlParameter("?email", MySqlDbType.VarChar,50),
					new MySqlParameter("?password", MySqlDbType.VarChar,50),
					new MySqlParameter("?state", MySqlDbType.UInt16,4),
					new MySqlParameter("?name", MySqlDbType.VarChar,20),
					new MySqlParameter("?phone", MySqlDbType.VarChar,20),
					new MySqlParameter("?company", MySqlDbType.VarChar,200),
					new MySqlParameter("?address", MySqlDbType.VarChar,500),
					new MySqlParameter("?sex", MySqlDbType.Enum),
					new MySqlParameter("?register_time", MySqlDbType.DateTime)};
			parameters[0].Value = model.Account;
			parameters[1].Value = model.Email;
			parameters[2].Value = model.Password;
			parameters[3].Value = model.State;
			parameters[4].Value = model.Name;
			parameters[5].Value = model.Phone;
			parameters[6].Value = model.Company;
			parameters[7].Value = model.Address;
			parameters[8].Value = model.Sex;
			parameters[9].Value = model.RegisterTime;

			int rows=MysqlHelper.ExecuteNonQuery(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update user set ");
			strSql.Append("account=?account,");
			strSql.Append("email=?email,");
			strSql.Append("password=?password,");
			strSql.Append("state=?state,");
			strSql.Append("name=?name,");
			strSql.Append("phone=?phone,");
			strSql.Append("company=?company,");
			strSql.Append("address=?address,");
			strSql.Append("sex=?sex,");
			strSql.Append("register_time=?register_time");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?account", MySqlDbType.VarChar,20),
					new MySqlParameter("?email", MySqlDbType.VarChar,50),
					new MySqlParameter("?password", MySqlDbType.VarChar,50),
					new MySqlParameter("?state", MySqlDbType.Int16,4),
					new MySqlParameter("?name", MySqlDbType.VarChar,20),
					new MySqlParameter("?phone", MySqlDbType.VarChar,20),
					new MySqlParameter("?company", MySqlDbType.VarChar,200),
					new MySqlParameter("?address", MySqlDbType.VarChar,500),
					new MySqlParameter("?sex", MySqlDbType.Enum),
					new MySqlParameter("?register_time", MySqlDbType.DateTime),
					new MySqlParameter("?id", MySqlDbType.Int32,10)};
			parameters[0].Value = model.Account;
			parameters[1].Value = model.Email;
			parameters[2].Value = model.Password;
			parameters[3].Value = model.State;
			parameters[4].Value = model.Name;
			parameters[5].Value = model.Phone;
			parameters[6].Value = model.Company;
			parameters[7].Value = model.Address;
			parameters[8].Value = model.Sex;
			parameters[9].Value = model.RegisterTime;
			parameters[10].Value = model.Uid;

			int rows=MysqlHelper.ExecuteNonQuery(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from user ");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			int rows=MysqlHelper.ExecuteNonQuery(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from user ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=MysqlHelper.ExecuteNonQuery(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public User GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,account,email,password,state,name,phone,company,address,sex,register_time from user ");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			User model=new User();
			DataSet ds=MysqlHelper.ExecuteDataSet(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}

        public User GetModel(string account,string password)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,account,email,password,state,name,phone,company,address,sex from user ");
            strSql.Append(" where account=?account and password=?password");
            MySqlParameter[] parameters = {
					new MySqlParameter("?account", MySqlDbType.VarChar,50),
                    new MySqlParameter("?password", MySqlDbType.VarChar,50)
			};
            parameters[0].Value = account;
            parameters[1].Value = password;

            User model = new User();
            DataSet ds = MysqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public User GetModelByEmail(string email, string password)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,account,email,password,state,name,phone,company,address,sex from user ");
            strSql.Append(" where email=?email and password=?password");
            MySqlParameter[] parameters = {
					new MySqlParameter("?email", MySqlDbType.VarChar,50),
                    new MySqlParameter("?password", MySqlDbType.VarChar,50)
			};
            parameters[0].Value = email;
            parameters[1].Value = password;

            User model = new User();
            DataSet ds = MysqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public User DataRowToModel(DataRow row)
		{
			User model=new User();
			if (row != null)
			{
                foreach (DataColumn col in row.Table.Columns)
                {
                    if (row[col] != null && row[col].ToString() != "")
                    {
                        switch (col.ColumnName)
                        {
                            case "id":
                                model.Uid = int.Parse(row[col].ToString());
                                break;
                            case "account":
                                model.Account = row[col].ToString();
                                break;
                            case "email":
                                model.Email = row[col].ToString();
                                break;
                            case "password":
                                model.Password = row[col].ToString();
                                break;
                            case "state":
                                model.State = int.Parse(row[col].ToString());
                                break;
                            case "name":
                                model.Name = row[col].ToString();
                                break;
                            case "phone":
                                model.Phone = row[col].ToString();
                                break;
                            case "company":
                                model.Company = row[col].ToString();
                                break;
                            case "address":
                                model.Address = row[col].ToString();
                                break;
                            case "sex":
                                model.Sex = row[col].ToString();
                                break;
                            case "register_time":
                                model.RegisterTime = DateTime.Parse(row[col].ToString());
                                break;
                        }
                    }
                }				
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,account,email,password,state,name,phone,company,address,sex,register_time ");
			strSql.Append(" FROM user ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return MysqlHelper.ExecuteDataSet(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM user ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = MysqlHelper.ExecuteScalar(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from user T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return MysqlHelper.ExecuteDataSet(strSql.ToString());
		}
	
 
	 
    }
}
