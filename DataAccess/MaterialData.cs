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

    /// <summary>
    /// 数据访问类:material
    /// </summary>
    public partial class MaterialData
    {
        public MaterialData()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from material");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
            parameters[0].Value = id;

            return MysqlHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(TextileCity.Entity.Material model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into material(");
            strSql.Append("category_id,type,name,price,price_high,price_fancy,styles,intro,main_image,images)");
            strSql.Append(" values (");
            strSql.Append("@category_id,@type,@name,@price,@price_high,@price_fancy,@styles,@intro,@main_image,@images)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@category_id", MySqlDbType.Int32,10),
					new MySqlParameter("@type", MySqlDbType.Enum),
					new MySqlParameter("@name", MySqlDbType.VarChar,200),
					new MySqlParameter("@price", MySqlDbType.Decimal,12),
					new MySqlParameter("@price_high", MySqlDbType.Decimal,12),
					new MySqlParameter("@price_fancy", MySqlDbType.Decimal,12),
					new MySqlParameter("@styles", MySqlDbType.Text),
					new MySqlParameter("@intro", MySqlDbType.VarChar,500),
					new MySqlParameter("@main_image", MySqlDbType.VarChar,500),
					new MySqlParameter("@images", MySqlDbType.Text)};
            parameters[0].Value = model.CategoryID;
            parameters[1].Value = model.CategoryType;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.Price;
            parameters[4].Value = model.PriceHigh;
            parameters[5].Value = model.PriceFancy;
            parameters[6].Value = model.StylesList;
            parameters[7].Value = model.Intro;
            parameters[8].Value = model.MainImage;
            parameters[9].Value = model.Images;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(TextileCity.Entity.Material model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update material set ");
            strSql.Append("category_id=@category_id,");
            strSql.Append("type=@type,");
            strSql.Append("name=@name,");
            strSql.Append("price=@price,");
            strSql.Append("price_high=@price_high,");
            strSql.Append("price_fancy=@price_fancy,");
            strSql.Append("styles=@styles,");
            strSql.Append("intro=@intro,");
            strSql.Append("main_image=@main_image,");
            strSql.Append("images=@images");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@category_id", MySqlDbType.Int32,10),
					new MySqlParameter("@type", MySqlDbType.Enum),
					new MySqlParameter("@name", MySqlDbType.VarChar,200),
					new MySqlParameter("@price", MySqlDbType.Decimal,12),
					new MySqlParameter("@price_high", MySqlDbType.Decimal,12),
					new MySqlParameter("@price_fancy", MySqlDbType.Decimal,12),
					new MySqlParameter("@styles", MySqlDbType.Text),
					new MySqlParameter("@intro", MySqlDbType.VarChar,500),
					new MySqlParameter("@main_image", MySqlDbType.VarChar,500),
					new MySqlParameter("@images", MySqlDbType.Text),
					new MySqlParameter("@id", MySqlDbType.Int32,10)};
            parameters[0].Value = model.CategoryID;
            parameters[1].Value = model.CategoryType;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.Price;
            parameters[4].Value = model.PriceHigh;
            parameters[5].Value = model.PriceFancy;
            parameters[6].Value = model.StylesList;
            parameters[7].Value = model.Intro;
            parameters[8].Value = model.MainImage;
            parameters[9].Value = model.Images;
            parameters[10].Value = model.MaterialID;

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from material ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
            parameters[0].Value = id;

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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from material ");
            strSql.Append(" where id in (" + idlist + ")  ");
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
        public TextileCity.Entity.Material GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,category_id,type,name,price,price_high,price_fancy,styles,intro,main_image,images from material ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
            parameters[0].Value = id;

            TextileCity.Entity.Material model = new TextileCity.Entity.Material();
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
        public TextileCity.Entity.Material DataRowToModel(DataRow row)
        {
            TextileCity.Entity.Material model = new TextileCity.Entity.Material();
            if (row != null)
            {
                foreach (DataColumn col in row.Table.Columns)
                {
                    if (row[col] != null && row[col].ToString() != "")
                    {
                        switch (col.ColumnName)
                        {
                            case "id":
                                model.MaterialID = int.Parse(row[col].ToString());                               
                                break;
                            case "category_id":
                                model.CategoryID = int.Parse(row[col].ToString());
                                break;
                            case "type":
                                model.CategoryType = row[col].ToString();
                                break;
                            case "name":
                                model.Name = row[col].ToString();
                                break;
                            case "price":
                                model.Price = decimal.Parse(row[col].ToString());
                                break;
                            case "price_high":
                                model.PriceHigh = decimal.Parse(row[col].ToString());
                                break;
                            case "price_fancy":
                                model.PriceFancy = decimal.Parse(row[col].ToString());
                                break;
                            case "styles":
                                model.StylesList = row[col].ToString();
                                break;
                            case "intro":
                                model.Intro = row[col].ToString();
                                break;
                            case "main_image":
                                model.MainImage = row[col].ToString();
                                break;
                            case "images":
                                model.Images = row[col].ToString();
                                break;
                        }
                    }
                }
            }
            return model;
        }

        public DataSet GetMaterialsMin(int categoryID, int pageIndex, int pageSize, out int count)
        {
            count = 0;
            StringBuilder strSql = new StringBuilder();           
            string strSqlCount = string.Format("select count(id) from material WHERE category_id = {0} ", categoryID);
            strSql.Append("select id,name,main_image ");
            strSql.Append(" FROM material ");
            strSql.AppendFormat(" WHERE category_id = {0} ", categoryID);
            int offset = 0;
            if (pageIndex > 1)
            {
                offset = (pageIndex - 1) * pageSize;
            }
            strSql.AppendFormat(" LIMIT {0},{1} ", offset, pageSize);

            object objCount = MysqlHelper.ExecuteScalar(strSqlCount);
            if (objCount != null)
            {
                int.TryParse(objCount.ToString(),out count);
            }
            DataSet ds = MysqlHelper.ExecuteDataSet(strSql.ToString());
            return ds;
        }

        public DataSet GetMaterialsMin(List<int> categoryIDs, int pageIndex, int pageSize, out int count)
        {
            count = 0;
            StringBuilder strSql = new StringBuilder();
            string ids = string.Empty;
            foreach (int cid in categoryIDs)
            {
                ids += string.Format("{0},", cid);
            }
            if (ids.Length > 0)
            {
                ids = ids.Remove(ids.Length - 1, 1);
            }
            string strSqlCount = string.Format("select count(id) from material WHERE category_id in ({0}) ", ids);
            strSql.Append("select id,name,main_image ");
            strSql.Append(" FROM material ");
            strSql.AppendFormat(" WHERE category_id in ({0}) ", ids);
            int offset = 0;
            if (pageIndex > 1)
            {
                offset = (pageIndex - 1) * pageSize;
            }
            strSql.AppendFormat(" LIMIT {0},{1} ", offset, pageSize);

            object objCount = MysqlHelper.ExecuteScalar(strSqlCount);
            if (objCount != null)
            {
                int.TryParse(objCount.ToString(), out count);
            }
            DataSet ds = MysqlHelper.ExecuteDataSet(strSql.ToString());
            return ds;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,category_id,type,name,price,price_high,price_fancy,styles,intro,main_image,images ");
            strSql.Append(" FROM material ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return MysqlHelper.ExecuteDataSet(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM material ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from material T ");
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
                    new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("@PageSize", MySqlDbType.Int32),
                    new MySqlParameter("@PageIndex", MySqlDbType.Int32),
                    new MySqlParameter("@IsReCount", MySqlDbType.Bit),
                    new MySqlParameter("@OrderType", MySqlDbType.Bit),
                    new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "material";
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
