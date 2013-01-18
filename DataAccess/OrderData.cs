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
    public class OrderData
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tc_order");
            strSql.Append(" where id=?id");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)
			};
            parameters[0].Value = id;

            return MysqlHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tc_order(");
            strSql.Append("uid,number,total_price,address,phone,linkman,add_time,delivery_time,remark,delivery,`state`)");
            strSql.Append(" values (");
            strSql.Append("?uid,?number,?total_price,?address,?phone,?linkman,?add_time,?delivery_time,?remark,?delivery,?state);");
            strSql.Append(" select LAST_INSERT_ID() ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?uid", MySqlDbType.Int32,10),
					new MySqlParameter("?number", MySqlDbType.VarChar,20),
					new MySqlParameter("?total_price", MySqlDbType.Decimal,12),
					new MySqlParameter("?address", MySqlDbType.Text),
					new MySqlParameter("?phone", MySqlDbType.VarChar,200),
					new MySqlParameter("?linkman", MySqlDbType.VarChar,50),
					new MySqlParameter("?add_time", MySqlDbType.DateTime),
					new MySqlParameter("?delivery_time", MySqlDbType.DateTime),
					new MySqlParameter("?remark", MySqlDbType.Text),
					new MySqlParameter("?delivery", MySqlDbType.Enum),
                    new MySqlParameter("?state", MySqlDbType.Enum)};
            parameters[0].Value = model.Uid;
            parameters[1].Value = model.Number;
            parameters[2].Value = model.Total;
            parameters[3].Value = model.Address;
            parameters[4].Value = model.Phone;
            parameters[5].Value = model.LinkMan;
            parameters[6].Value = model.AddTime;
            parameters[7].Value = model.DeliveryTime;
            parameters[8].Value = model.Remark;
            parameters[9].Value = model.Delivery;
            parameters[10].Value = model.OrderState;

            object obj = MysqlHelper.ExecuteScalar(strSql.ToString(), parameters);
            int id = 0;
            if (obj != null)
            {
                id = int.Parse(obj.ToString());
            }
            return id;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tc_order set ");
            strSql.Append("uid=?uid,");
            strSql.Append("number=?number,");
            strSql.Append("total_price=?total_price,");
            strSql.Append("address=?address,");
            strSql.Append("phone=?phone,");
            strSql.Append("linkman=?linkman,");
            strSql.Append("add_time=?add_time,");
            strSql.Append("delivery_time=?delivery_time,");
            strSql.Append("remark=?remark,");
            strSql.Append("delivery=?delivery");
            strSql.Append("`state`=?state");
            strSql.Append(" where id=?id");
            MySqlParameter[] parameters = {
					new MySqlParameter("?uid", MySqlDbType.Int32,10),
					new MySqlParameter("?number", MySqlDbType.VarChar,20),
					new MySqlParameter("?total_price", MySqlDbType.Decimal,12),
					new MySqlParameter("?address", MySqlDbType.Text),
					new MySqlParameter("?phone", MySqlDbType.VarChar,200),
					new MySqlParameter("?linkman", MySqlDbType.VarChar,50),
					new MySqlParameter("?add_time", MySqlDbType.DateTime),
					new MySqlParameter("?delivery_time", MySqlDbType.DateTime),
					new MySqlParameter("?remark", MySqlDbType.Text),
					new MySqlParameter("?delivery", MySqlDbType.Enum),
                     new MySqlParameter("?state", MySqlDbType.Enum),
					new MySqlParameter("?id", MySqlDbType.Int32,10)};
            parameters[0].Value = model.Uid;
            parameters[1].Value = model.Number;
            parameters[2].Value = model.Total;
            parameters[3].Value = model.Address;
            parameters[4].Value = model.Phone;
            parameters[5].Value = model.LinkMan;
            parameters[6].Value = model.AddTime;
            parameters[7].Value = model.DeliveryTime;
            parameters[8].Value = model.Remark;
            parameters[9].Value = model.Delivery;
            parameters[10].Value = model.OrderState;
            parameters[11].Value = model.OrderID;
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
            strSql.Append("delete from tc_order ");
            strSql.Append(" where id=?id");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)
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
            strSql.Append("delete from tc_order ");
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
        public Order GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,uid,`state`,number,total_price,address,phone,linkman,add_time,delivery_time,remark,delivery from tc_order ");
            strSql.Append(" where id=?id");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)
			};
            parameters[0].Value = id;

            Order model = new Order();
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
        public Order DataRowToModel(DataRow row)
        {
            Order model = new Order();
            if (row != null)
            {
                foreach (DataColumn col in row.Table.Columns)
                {
                    if (row[col] != null && row[col].ToString() != "")
                    {
                        switch (col.ColumnName)
                        {
                            case "id":
                                model.OrderID = int.Parse(row[col].ToString());
                                break;
                            case "uid":
                                model.Uid = int.Parse(row["uid"].ToString());
                                break;
                            case "number":
                                model.Number = row["number"].ToString();
                                break;
                            case "total_price":
                                model.Total = decimal.Parse(row["total_price"].ToString());
                                break;
                            case "state":
                                model.OrderState = row["state"].ToString();
                                break;
                            case "address":
                                model.Address = row["address"].ToString();
                                break;
                            case "phone":
                                model.Phone = row["phone"].ToString();
                                break;
                            case "linkman":
                                model.LinkMan = row["linkman"].ToString();
                                break;
                            case "add_time":
                                model.AddTime = DateTime.Parse(row["add_time"].ToString());
                                break;
                            case "delivery_time":
                                model.DeliveryTime = DateTime.Parse(row["delivery_time"].ToString());
                                break;
                            case "remark":
                                model.Remark = row["remark"].ToString();
                                break;
                            case "delivery":
                                model.Delivery = row["delivery"].ToString();
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
        /// 
        public DataSet GetMinOrders(int uid, int topCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  id,uid,`state`,number,total_price,add_time,delivery_time ");
            strSql.Append(" FROM tc_order ");
            strSql.AppendFormat(" where uid={0} and (add_time >='{1}' or state='{2}') order by add_time desc ,state asc",
                uid, DateTime.Now.AddMonths(-1), TextileCity.Entity.OrderState.MakingUp);
            strSql.AppendFormat(" LIMIT {0} ", topCount);
            return MysqlHelper.ExecuteDataSet(strSql.ToString());
        }

        public DataSet GetOrders(int uid, int page, int size, out int count)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,uid,`state`,number,total_price,add_time,delivery_time ");
            strSql.Append(" FROM tc_order ");
            strSql.AppendFormat(" where uid={0} order by add_time desc ,state asc", uid);
            int offset = 0;
            if (page > 1)
            {
                offset = (page - 1) * size;
            }
            strSql.AppendFormat(" LIMIT {0},{1} ", offset, size);
            StringBuilder strCountSql = new StringBuilder();
            strCountSql.Append("select Count(id) ");
            strCountSql.Append(" FROM tc_order ");
            strCountSql.AppendFormat(" where uid={0} ", uid);
            count = 0;
            object obj = MysqlHelper.ExecuteScalar(strCountSql.ToString());
            if (obj != null)
            {
                int.TryParse(obj.ToString(), out count);
            }
            return MysqlHelper.ExecuteDataSet(strSql.ToString());
        }

        public DataSet GetOrders(int uid, string state, int page, int size, out int count)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,uid,`state`,number,total_price,add_time,delivery_time ");
            strSql.Append(" FROM tc_order ");
            strSql.AppendFormat(" where uid={0} and state='{1}' order by add_time desc", uid, state);
            int offset = 0;
            if (page > 1)
            {
                offset = (page - 1) * size;
            }
            strSql.AppendFormat(" LIMIT {0},{1} ", offset, size);
            StringBuilder strCountSql = new StringBuilder();
            strCountSql.Append("select Count(id) ");
            strCountSql.Append(" FROM tc_order ");
            strCountSql.AppendFormat(" where uid={0} and state='{1}' ", uid, state);
            count = 0;
            object obj = MysqlHelper.ExecuteScalar(strCountSql.ToString());
            if (obj != null)
            {
                int.TryParse(obj.ToString(), out count);
            }
            return MysqlHelper.ExecuteDataSet(strSql.ToString());
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,uid,`state`,number,total_price,address,phone,linkman,add_time,delivery_time,remark,delivery ");
            strSql.Append(" FROM tc_order ");
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
            strSql.Append("select count(1) FROM tc_order ");
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

        public int GetRecordCount(DateTime date)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM tc_order ");
            strSql.Append(" where add_time>=?start and add_time<?end ");
            MySqlParameter[] parameters = {
                                new MySqlParameter("?start", MySqlDbType.DateTime),
                                new MySqlParameter("?end", MySqlDbType.DateTime)};
            parameters[0].Value = date.Date;
            parameters[1].Value = date.Date.AddDays(1);
            object obj = MysqlHelper.ExecuteScalar(strSql.ToString(),parameters);
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
            strSql.Append(")AS Row, T.*  from tc_order T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return MysqlHelper.ExecuteDataSet(strSql.ToString());
        }


        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
