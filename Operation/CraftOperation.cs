﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextileCity.DataAccess;
using TextileCity.Entity;

namespace TextileCity.Operation
{
    public class CraftOperation
    {
        private readonly CraftData dal=new CraftData();
		public CraftOperation()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Craft model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Craft model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			return dal.Delete(id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Craft GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        //public Craft GetModelByCache(int id)
        //{
			
        //    string CacheKey = "CraftDataModel-" + id;
        //    object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(id);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (Craft)objModel;
        //}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

       


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Craft> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Craft> DataTableToList(DataTable dt)
		{
			List<Craft> modelList = new List<Craft>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Craft model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

        public List<Craft> GetMinList(List<int> ids)
        {
            List<Craft> crafts = new List<Craft>();
            DataSet ds = dal.GetMinList(ids);
            if (ds != null && ds.Tables.Count > 0)
            {
                crafts = DataTableToList(ds.Tables[0]);
            }
            return crafts;
        }


        public List<Craft> GetMinList()
        {
            string CacheKey = "CraftListCache";
            object objModel = Common.DataCache.GetCache(CacheKey);
            List<Craft> crafts = new List<Craft>();
            if (objModel == null)
            {
                try
                {
                    DataSet ds = dal.GetMinList();
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        crafts = DataTableToList(ds.Tables[0]);
                        Common.DataCache.SetCache(CacheKey, crafts, Common.DataCache.DefaultTime);
                    }
                }
                catch
                {

                }
            }
            else
            {
                crafts = objModel as List<Craft>;
            }
            return crafts;
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
