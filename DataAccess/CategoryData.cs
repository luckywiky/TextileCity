using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TextileCity.DBUtility;
using System.Data;
using TextileCity.Entity;

namespace TextileCity.DataAccess
{
    public class CategoryData
    {
        public CategoryData()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from category");
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
		public bool Add(TextileCity.Entity.Category model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into category(");
			strSql.Append("parentid,name,type,order_index)");
			strSql.Append(" values (");
			strSql.Append("?parentid,?name,?type,?order_index)");
			MySqlParameter[] parameters = {
					new MySqlParameter("?parentid", MySqlDbType.Int32,10),
					new MySqlParameter("?name", MySqlDbType.VarChar,50),
					new MySqlParameter("?type", MySqlDbType.Enum),
					new MySqlParameter("?order_index", MySqlDbType.Int32,10)};
			parameters[0].Value = model.ParentID;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Type;
			parameters[3].Value = model.OrderIndex;

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
		public bool Update(TextileCity.Entity.Category model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update category set ");
			strSql.Append("parentid=?parentid,");
			strSql.Append("name=?name,");
			strSql.Append("type=?type,");
			strSql.Append("order_index=?order_index");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?parentid", MySqlDbType.Int32,10),
					new MySqlParameter("?name", MySqlDbType.VarChar,50),
					new MySqlParameter("?type", MySqlDbType.Enum),
					new MySqlParameter("?order_index", MySqlDbType.Int32,10),
					new MySqlParameter("?id", MySqlDbType.Int32,10)};
			parameters[0].Value = model.ParentID;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Type;
			parameters[3].Value = model.OrderIndex;
			parameters[4].Value = model.CategoryID;

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
			strSql.Append("delete from category ");
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
			strSql.Append("delete from category ");
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
		public TextileCity.Entity.Category GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,parentid,name,type,order_index from category ");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)
			};
            
			parameters[0].Value = id;

			TextileCity.Entity.Category model=new TextileCity.Entity.Category();
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
		public TextileCity.Entity.Category DataRowToModel(DataRow row)
		{
			TextileCity.Entity.Category model=new TextileCity.Entity.Category();

			if (row != null)
			{
                foreach (DataColumn col in row.Table.Columns)
                {
                    if (row[col] != null && row[col].ToString() != "")
                    {
                        switch (col.ColumnName)
                        {
                            case "id":
                                model.CategoryID = int.Parse(row[col].ToString());
                                break;
                            case "parentid":
                                model.ParentID = int.Parse(row["parentid"].ToString());
                                break;
                            case "name":
                                model.Name = row["name"].ToString();
                                break;
                            case "type":
                                model.Type = row["type"].ToString();
                                break;
                            case "order_index":
                                model.OrderIndex = int.Parse(row["order_index"].ToString());
                                break;
                        }
                    }
                    //if (row["id"] != null && row["id"].ToString() != "")
                    //{
                    //    model.CategoryID = int.Parse(row["id"].ToString());
                    //}
                    //if (row["parentid"] != null && row["parentid"].ToString() != "")
                    //{
                    //    model.ParentID = int.Parse(row["parentid"].ToString());
                    //}
                    //if (row["name"] != null)
                    //{
                    //    model.Name = row["name"].ToString();
                    //}
                    //if (row["type"] != null)
                    //{
                    //    model.Type = row["type"].ToString();
                    //}
                    //if (row["order_index"] != null && row["order_index"].ToString() != "")
                    //{
                    //    model.OrderIndex = int.Parse(row["order_index"].ToString());
                    //}
                }
			}
			return model;
		}


        public DataSet GetParents(string categoryType)
        {
            DataSet dsResult = new DataSet();
            StringBuilder sql = new StringBuilder();
            string where = " where parentid=0  ";
            sql.Append("select id,name,type ");
            sql.Append(" FROM category ");
            switch (categoryType)
            {
                case CategoryType.All:
                    break;
                case CategoryType.Fabric:
                     where += string.Format(" and type = 1 ");    
                //where += string.Format(" and type = '{0}' ", CategoryType.Fabric);
                    break;
                case CategoryType.Accessory:
                    where += string.Format(" and type = 2 ");
                    //where += string.Format(" and type = '{0}' ", CategoryType.Accessory);
                    break;
                default:
                    break;
            }
            sql.Append(where);
            sql.Append(" order by order_index asc ");
            dsResult = MysqlHelper.ExecuteDataSet(sql.ToString());
            return dsResult;
        }

        public DataSet GetChilds(string categoryType)
        {
            DataSet dsResult = new DataSet();
            StringBuilder sql = new StringBuilder();
            string where = " where category.parentid!=0  ";
            sql.Append("select category.id,category.name,category.type,category.parentid ");
            sql.Append(" FROM category LEFT JOIN  category as ptable ");
            sql.Append(" ON category.parentid = ptable.id ");
            switch (categoryType)
            {
                case CategoryType.All:
                    break;
                case CategoryType.Fabric:
                    where += string.Format(" and category.type = 1 ", CategoryType.Fabric);
                    //where += string.Format(" and category.type = '{0}' ", CategoryType.Fabric);
                    break;
                case CategoryType.Accessory:
                    where += string.Format(" and category.type = 2 ", CategoryType.Fabric);
                    //where += string.Format(" and category.type = '{0}' ", CategoryType.Accessory);
                    break;
                default:
                    break;
            }
            sql.Append(where);
            sql.Append(" ORDER BY ptable.order_index asc , category.order_index asc ");
            return MysqlHelper.ExecuteDataSet(sql.ToString());
        }

        public DataSet GetChilds(int parentid)
        {
            DataSet dsResult = new DataSet();
            StringBuilder sql = new StringBuilder();
            string where = string.Format(" WHERE category.parentid={0} ", parentid);
            sql.Append("SELECT category.id,category.name,category.type,category.parentid ");
            sql.Append(" FROM category LEFT JOIN  category as ptable ");
            sql.Append(" ON category.parentid = ptable.id ");      
            sql.Append(where);
            sql.Append(" ORDER BY ptable.order_index asc , category.order_index asc ");
            return MysqlHelper.ExecuteDataSet(sql.ToString());
        }

        public DataSet GetChilds()
        {
            return GetChilds(CategoryType.All);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,parentid,name,type,order_index ");
			strSql.Append(" FROM category ");
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
			strSql.Append("select count(1) FROM category ");
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
			strSql.Append(")AS Row, T.*  from category T ");
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
			parameters[0].Value = "category";
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
