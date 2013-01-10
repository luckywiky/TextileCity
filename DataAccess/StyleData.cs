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
    public class StyleData
    {
        public StyleData()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int styleid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from style");
			strSql.Append(" where styleid=?styleid");
			MySqlParameter[] parameters = {
					new MySqlParameter("?styleid", MySqlDbType.Int32)
			};
			parameters[0].Value = styleid;

			return MysqlHelper.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Style model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into style(");
			strSql.Append("material_id,name,price,code,rgb,scheme)");
			strSql.Append(" values (");
			strSql.Append("?material_id,?name,?price,?code,?rgb,?scheme)");
			MySqlParameter[] parameters = {
					new MySqlParameter("?material_id", MySqlDbType.Int32,10),
					new MySqlParameter("?name", MySqlDbType.VarChar,50),
					new MySqlParameter("?price", MySqlDbType.Decimal,12),
					new MySqlParameter("?code", MySqlDbType.VarChar,50),
					new MySqlParameter("?rgb", MySqlDbType.VarChar,50),
					new MySqlParameter("?scheme", MySqlDbType.Enum)};
			parameters[0].Value = model.MaterialID;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Price;
			parameters[3].Value = model.Code;
			parameters[4].Value = model.RGB;
			parameters[5].Value = model.Scheme;

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
		public bool Update(Style model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update style set ");
			strSql.Append("material_id=?material_id,");
			strSql.Append("name=?name,");
			strSql.Append("price=?price,");
			strSql.Append("code=?code,");
			strSql.Append("rgb=?rgb,");
			strSql.Append("scheme=?scheme");
			strSql.Append(" where styleid=?styleid");
			MySqlParameter[] parameters = {
					new MySqlParameter("?material_id", MySqlDbType.Int32,10),
					new MySqlParameter("?name", MySqlDbType.VarChar,50),
					new MySqlParameter("?price", MySqlDbType.Decimal,12),
					new MySqlParameter("?code", MySqlDbType.VarChar,50),
					new MySqlParameter("?rgb", MySqlDbType.VarChar,50),
					new MySqlParameter("?scheme", MySqlDbType.Enum),
					new MySqlParameter("?styleid", MySqlDbType.Int32,10)};
			parameters[0].Value = model.MaterialID;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Price;
			parameters[3].Value = model.Code;
			parameters[4].Value = model.RGB;
			parameters[5].Value = model.Scheme;
			parameters[6].Value = model.StyleID;

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
		public bool Delete(int styleid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from style ");
			strSql.Append(" where styleid=?styleid");
			MySqlParameter[] parameters = {
					new MySqlParameter("?styleid", MySqlDbType.Int32)
			};
			parameters[0].Value = styleid;

            int rows = MysqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);
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
		public bool DeleteList(string styleidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from style ");
			strSql.Append(" where styleid in ("+styleidlist + ")  ");
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
        public Style GetModel(int styleid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select styleid,material_id,name,price,`code`,rgb,scheme from style ");
            strSql.AppendFormat(" where styleid={0} ",styleid);
            Style model = new Style();
            DataSet ds = MysqlHelper.ExecuteDataSet(strSql.ToString());
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
		public Style DataRowToModel(DataRow row)
		{
			Style model=new Style();
			if (row != null)
			{
                foreach (DataColumn col in row.Table.Columns)
                {
                    if (row[col] != null && row[col].ToString() != "")
                    {
                        switch (col.ColumnName)
                        {
                            case "styleid":
                                model.StyleID = int.Parse(row[col].ToString());
                                break;
                            case "material_id":
                                model.MaterialID = int.Parse(row[col].ToString());
                                break;
                            case "name":
                                model.Name = row[col].ToString();
                                break;
                            case "price":
                                model.Price = decimal.Parse(row[col].ToString());
                                break;
                            case "code":
                                model.Code = row[col].ToString();
                                break;
                            case "rgb":
                                model.RGB = row[col].ToString();
                                break;
                            case "scheme":
                                model.Scheme = row[col].ToString();
                                break;
                        }
                    }
                }				
			}
			return model;
		}

        public DataSet GetList(List<int> ids)
        {
            DataSet ds = null;
            if (ids.Count > 0)
            {
                string strids = "";
                foreach (int id in ids)
                {
                    strids += string.Format("{0},",id);
                }
                strids = strids.Remove(strids.Length - 1, 1);
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select styleid,material_id,name,price,code,rgb,scheme ");
                strSql.Append(" FROM style ");
                strSql.AppendFormat(" WHERE styleid in ({0}) ", strids);
                ds = MysqlHelper.ExecuteDataSet(strSql.ToString());
            }
            return ds;
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select styleid,material_id,name,price,code,rgb,scheme ");
			strSql.Append(" FROM style ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return MysqlHelper.ExecuteDataSet(strSql.ToString());
		}

        public DataSet GetStyles(int materialID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select styleid,material_id,name,price,code,rgb,scheme ");
            strSql.AppendFormat(" FROM style where material_id={0} ", materialID);
            return MysqlHelper.ExecuteDataSet(strSql.ToString());
        }

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM style ");
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
				strSql.Append("order by T.styleid desc");
			}
			strSql.Append(")AS Row, T.*  from style T ");
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
			parameters[0].Value = "style";
			parameters[1].Value = "styleid";
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
