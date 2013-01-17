using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TextileCity.DBUtility;
using TextileCity.Entity;

namespace TextileCity.DataAccess
{
    public class NewsData
    {
       
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from news");
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
		public bool Add(News model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into news(");
			strSql.Append("title,type,content,images,main_image,add_time)");
			strSql.Append(" values (");
			strSql.Append("?title,?type,?content,?images,?main_image,?add_time)");
			MySqlParameter[] parameters = {
					new MySqlParameter("?title", MySqlDbType.VarChar,50),
					new MySqlParameter("?type", MySqlDbType.Enum),
					new MySqlParameter("?content", MySqlDbType.Text),
					new MySqlParameter("?images", MySqlDbType.Text),
					new MySqlParameter("?main_image", MySqlDbType.VarChar,500),
					new MySqlParameter("?add_time", MySqlDbType.DateTime)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.Type;
			parameters[2].Value = model.Content;
			parameters[3].Value = model.Images;
			parameters[4].Value = model.MainImage;
			parameters[5].Value = model.AddTime;

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
		public bool Update(News model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update news set ");
			strSql.Append("title=?title,");
			strSql.Append("type=?type,");
			strSql.Append("content=?content,");
			strSql.Append("images=?images,");
			strSql.Append("main_image=?main_image,");
			strSql.Append("add_time=?add_time");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?title", MySqlDbType.VarChar,50),
					new MySqlParameter("?type", MySqlDbType.Enum),
					new MySqlParameter("?content", MySqlDbType.Text),
					new MySqlParameter("?images", MySqlDbType.Text),
					new MySqlParameter("?main_image", MySqlDbType.VarChar,500),
					new MySqlParameter("?add_time", MySqlDbType.DateTime),
					new MySqlParameter("?id", MySqlDbType.Int32,10)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.Type;
			parameters[2].Value = model.Content;
			parameters[3].Value = model.Images;
			parameters[4].Value = model.MainImage;
			parameters[5].Value = model.AddTime;
			parameters[6].Value = model.ID;

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
			strSql.Append("delete from news ");
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
			strSql.Append("delete from news ");
			strSql.Append(" where id in ("+idlist + ")  ");
            int rows = MysqlHelper.ExecuteNonQuery(strSql.ToString());
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
		public News GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,title,type,content,images,main_image,add_time from news ");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			News model=new News();
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
		public News DataRowToModel(DataRow row)
		{
			News model=new News();
			if (row != null)
			{
                foreach (DataColumn col in row.Table.Columns)
                {
                    if (row[col] != null && row[col].ToString() != "")
                    {
                        switch (col.ColumnName)
                        {
                            case "id":
                                model.ID = int.Parse(row[col].ToString());
                                break;
                            case "title":
                                model.Title = row[col].ToString();
                                break;
                            case "type":
                                model.Type = row[col].ToString();
                                break;
                            case "content":
                                model.Content = row[col].ToString();
                                break;
                            case "images":
                                model.Images = row[col].ToString();
                                break;
                            case "main_image":
                                model.MainImage = row[col].ToString();
                                break;
                            case "add_time":
                                model.AddTime = DateTime.Parse(row[col].ToString());
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
			strSql.Append("select id,title,type,content,images,main_image,add_time ");
			strSql.Append(" FROM news ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return MysqlHelper.ExecuteDataSet(strSql.ToString());
		}

        public DataSet GetMinList(int page, int size, out int count)
        {
            count = 0;
            StringBuilder strSql = new StringBuilder();
            string strCountSql = "select count(id) from news ";
            strSql.Append("select id,title,add_time ");
            strSql.Append(" FROM news order by add_time desc ");
            int offset = 0;
            if (page > 1)
            {
                offset = (page - 1) * size;
            }
            strSql.AppendFormat(" LIMIT {0},{1} ", offset, size);
            object objCount = MysqlHelper.ExecuteScalar(strCountSql);
            if (objCount != null)
            {
                int.TryParse(objCount.ToString(), out count);
            }
            DataSet ds = MysqlHelper.ExecuteDataSet(strSql.ToString());
            return ds;
        }

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM news ");
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
		

	
    }
}
