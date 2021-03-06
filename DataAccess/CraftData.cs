﻿using MySql.Data.MySqlClient;
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
   public partial class CraftData
	{
		public CraftData()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from craft");
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
		public bool Add(Craft model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into craft(");
			strSql.Append("name,price,intro)");
			strSql.Append(" values (");
			strSql.Append("?name,?price,?intro)");
			MySqlParameter[] parameters = {
					new MySqlParameter("?name", MySqlDbType.VarChar,50),
					new MySqlParameter("?price", MySqlDbType.Decimal,12),
					new MySqlParameter("?intro", MySqlDbType.Text)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Price;
			parameters[2].Value = model.Intro;

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
		public bool Update(Craft model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update craft set ");
			strSql.Append("name=?name,");
			strSql.Append("price=?price,");
			strSql.Append("intro=?intro");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?name", MySqlDbType.VarChar,50),
					new MySqlParameter("?price", MySqlDbType.Decimal,12),
					new MySqlParameter("?intro", MySqlDbType.Text),
					new MySqlParameter("?id", MySqlDbType.Int32,10)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Price;
			parameters[2].Value = model.Intro;
			parameters[3].Value = model.CraftID;

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
			strSql.Append("delete from craft ");
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
			strSql.Append("delete from craft ");
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
		public Craft GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,name,price,intro from craft ");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			Craft model=new Craft();
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


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Craft DataRowToModel(DataRow row)
		{
			Craft model=new Craft();
			if (row != null)
			{
                foreach (DataColumn col in row.Table.Columns)
                {
                    if (row[col] != null && row[col].ToString() != "")
                    {
                        switch (col.ColumnName)
                        {
                            case "id":
                                model.CraftID = int.Parse(row[col].ToString());
                                break;
                            case "name":
                                model.Name = row[col].ToString();
                                break;
                            case "price":
                                model.Price = decimal.Parse(row[col].ToString());
                                break;
                            case "intro":
                                model.Intro = row[col].ToString();
                                break;
                        }
                    }
                }			
			}
			return model;
		}


        public DataSet GetMinList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,name,price ");
            strSql.Append(" FROM craft ");
            return MysqlHelper.ExecuteDataSet(strSql.ToString());
        }



        public DataSet GetMinList(List<int> ids)
        {
            DataSet ds = null;
            if (ids.Count > 0)
            {
                string strids = "";
                foreach (int id in ids)
                {
                    strids += string.Format("{0},", id);
                }
                strids = strids.Remove(strids.Length - 1, 1);
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select id,name,price ");
                strSql.Append(" FROM craft ");
                strSql.AppendFormat(" WHERE id in ({0}) ", strids);
                ds = MysqlHelper.ExecuteDataSet(strSql.ToString());
            }
            return ds;
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
        /// 

		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,name,price,intro ");
			strSql.Append(" FROM craft ");
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
			strSql.Append("select count(1) FROM craft ");
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
			strSql.Append(")AS Row, T.*  from craft T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return MysqlHelper.ExecuteDataSet(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("?tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("?fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("?PageSize", MySqlDbType.Int32),
					new MySqlParameter("?PageIndex", MySqlDbType.Int32),
					new MySqlParameter("?IsReCount", MySqlDbType.Bit),
					new MySqlParameter("?OrderType", MySqlDbType.Bit),
					new MySqlParameter("?strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "craft";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return MysqlHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}
