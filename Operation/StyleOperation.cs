using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextileCity.DataAccess;
using TextileCity.Entity;

namespace TextileCity.Operation
{
    public class StyleOperation
    {
        private readonly StyleData dal = new StyleData();
            public StyleOperation()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int styleid)
		{
			return dal.Exists(styleid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Style model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Style model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int styleid)
		{
			
			return dal.Delete(styleid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string styleidlist )
		{
			return dal.DeleteList(styleidlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Style GetModel(int styleid)
		{
			
			return dal.GetModel(styleid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        //public Style GetModelByCache(int styleid)
        //{
			
        //    string CacheKey = "StyleModel-" + styleid;
        //    object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(styleid);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (Style)objModel;
        //}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        public List<Style> GetList(List<int> ids)
        {
            List<Style> styles = new List<Style>();
            DataSet ds = dal.GetList(ids);
            if (ds != null && ds.Tables.Count > 0)
            {
                styles = DataTableToList(ds.Tables[0]);
            }
            return styles;
        }

        public List<Style> GetStyles(int materialID)
        {
            DataSet ds = dal.GetStyles(materialID);
            List<Style> styles = new List<Style>();
            if (ds != null && ds.Tables.Count > 0)
            {
                styles = DataTableToList(ds.Tables[0]);
            }
            return styles;
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Style> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Style> DataTableToList(DataTable dt)
		{
			List<Style> modelList = new List<Style>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Style model;
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
