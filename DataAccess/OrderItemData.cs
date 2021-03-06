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
    public class OrderItemData
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from order_item");
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
        public bool Add(OrderItem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into order_item(");
            strSql.Append("order_id,material_id,count,state,type,total_price,style_id,style_name,craft,add_time,delivery_time,remark,delivery_remark)");
            strSql.Append(" values (");
            strSql.Append("?order_id,?material_id,?count,?state,?type,?total_price,?style_id,?style_name,?craft,?add_time,?delivery_time,?remark,?delivery_remark)");
            MySqlParameter[] parameters = {
					new MySqlParameter("?order_id", MySqlDbType.Int32,10),
					new MySqlParameter("?material_id", MySqlDbType.Int32,10),
					new MySqlParameter("?count", MySqlDbType.Int32,10),
					new MySqlParameter("?state", MySqlDbType.Enum),
					new MySqlParameter("?type", MySqlDbType.Enum),
					new MySqlParameter("?total_price", MySqlDbType.Decimal,12),
					new MySqlParameter("?style_id", MySqlDbType.Int32,11),
					new MySqlParameter("?style_name", MySqlDbType.VarChar,50),
					new MySqlParameter("?craft", MySqlDbType.Int32,10),
					new MySqlParameter("?add_time", MySqlDbType.DateTime),
					new MySqlParameter("?delivery_time", MySqlDbType.DateTime),
					new MySqlParameter("?remark", MySqlDbType.Text),
					new MySqlParameter("?delivery_remark", MySqlDbType.Text)};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.MaterialID;
            parameters[2].Value = model.Count;
            parameters[3].Value = model.State;
            parameters[4].Value = model.Type;
            parameters[5].Value = model.Total;
            parameters[6].Value = model.StyleID;
            parameters[7].Value = model.StyleName;
            parameters[8].Value = model.CraftID;
            parameters[9].Value = model.AddTime;
            parameters[10].Value = model.DeliveryTime;
            parameters[11].Value = model.Remark;
            parameters[12].Value = model.DeliveryRemark;

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
        public bool Update(OrderItem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update order_item set ");
            strSql.Append("order_id=?order_id,");
            strSql.Append("material_id=?material_id,");
            strSql.Append("count=?count,");
            strSql.Append("state=?state,");
            strSql.Append("type=?type,");
            strSql.Append("total_price=?total_price,");
            strSql.Append("style_id=?style_id,");
            strSql.Append("style_name=?style_name,");
            strSql.Append("craft=?craft,");
            strSql.Append("add_time=?add_time,");
            strSql.Append("delivery_time=?delivery_time,");
            strSql.Append("remark=?remark,");
            strSql.Append("delivery_remark=?delivery_remark");
            strSql.Append(" where id=?id");
            MySqlParameter[] parameters = {
					new MySqlParameter("?order_id", MySqlDbType.Int32,10),
					new MySqlParameter("?material_id", MySqlDbType.Int32,10),
					new MySqlParameter("?count", MySqlDbType.Int32,10),
					new MySqlParameter("?state", MySqlDbType.Enum),
					new MySqlParameter("?type", MySqlDbType.Enum),
					new MySqlParameter("?total_price", MySqlDbType.Decimal,12),
					new MySqlParameter("?style_id", MySqlDbType.Int32,11),
					new MySqlParameter("?style_name", MySqlDbType.VarChar,50),
					new MySqlParameter("?craft", MySqlDbType.Int32,10),
					new MySqlParameter("?add_time", MySqlDbType.DateTime),
					new MySqlParameter("?delivery_time", MySqlDbType.DateTime),
					new MySqlParameter("?remark", MySqlDbType.Text),
					new MySqlParameter("?delivery_remark", MySqlDbType.Text),
					new MySqlParameter("?id", MySqlDbType.Int32,10)};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.MaterialID;
            parameters[2].Value = model.Count;
            parameters[3].Value = model.State;
            parameters[4].Value = model.Type;
            parameters[5].Value = model.Total;
            parameters[6].Value = model.StyleID;
            parameters[7].Value = model.StyleName;
            parameters[8].Value = model.CraftID;
            parameters[9].Value = model.AddTime;
            parameters[10].Value = model.DeliveryTime;
            parameters[11].Value = model.Remark;
            parameters[12].Value = model.DeliveryRemark;
            parameters[13].Value = model.ItemID;

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
            strSql.Append("delete from order_item ");
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
            strSql.Append("delete from order_item ");
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
        public OrderItem GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,order_id,material_id,count,state,type,total_price,style_id,style_name,craft,add_time,delivery_time,remark,delivery_remark from order_item ");
            strSql.Append(" where id=?id");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)
			};
            parameters[0].Value = id;

            OrderItem model = new OrderItem();
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
        public OrderItem DataRowToModel(DataRow row)
        {
            OrderItem model = new OrderItem();
            if (row != null)
            {
                foreach (DataColumn col in row.Table.Columns)
                {
                    if (row[col] != null && row[col].ToString() != "")
                    {
                        switch (col.ColumnName)
                        {
                            case "id":
                                model.ItemID = int.Parse(row[col].ToString());
                                break;
                            case "order_id":
                                model.OrderID = int.Parse(row[col].ToString());
                                break;
                            case "material_id":
                                model.MaterialID =  int.Parse(row[col].ToString());
                                break;
                            case "material_name":
                                model.MaterialName = row[col].ToString();
                                break;
                            case "count":
                                model.Count = int.Parse(row[col].ToString());
                                break;
                            case "state":
                                model.State = row[col].ToString();
                                break;
                            case "type":
                                  model.Type = row[col].ToString();
                                break;
                            case "total_price":
                                model.Total = decimal.Parse(row[col].ToString());
                                break;
                            case "style_id":
                                model.StyleID =  int.Parse(row[col].ToString());
                                break;
                            case "style_name":
                                model.StyleName = row[col].ToString();
                                break;
                            case "craft":
                                model.CraftID = int.Parse(row[col].ToString());
                                break;
                            case "add_time":
                                 model.AddTime = DateTime.Parse(row[col].ToString());
                                break;
                            case "delivery_time":
                                 model.DeliveryTime = DateTime.Parse(row[col].ToString());
                                break;
                            case "remark":
                                 model.Remark =row[col].ToString();
                                break;
                            case "delivery_remark":
                                 model.DeliveryRemark = row[col].ToString();
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,order_id,material_id,count,state,type,total_price,style_id,style_name,craft,add_time,delivery_time,remark,delivery_remark ");
            strSql.Append(" FROM order_item ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return MysqlHelper.ExecuteDataSet(strSql.ToString());
        }

        public DataSet GetItems(int orderId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select order_item.id,material_id,count,state,order_item.type,total_price,style_id,style_name,craft,material.`name` as material_name ");
            strSql.Append(" FROM order_item left JOIN material ON order_item.material_id = material.id  ");
            strSql.AppendFormat(" where order_id={0} " ,orderId);
            strSql.Append(" order by add_time desc ");
            return MysqlHelper.ExecuteDataSet(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM order_item ");
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
            strSql.Append(")AS Row, T.*  from order_item T ");
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
