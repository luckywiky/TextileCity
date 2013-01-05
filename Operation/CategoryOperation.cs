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
    public class CategoryOperation
    {
        private readonly CategoryData dal = new CategoryData();
        public CategoryOperation()
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
		public bool Add(Category model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Category model)
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
		public Category GetModel(int id)
		{
			
			return dal.GetModel(id);
		}
        public TextileCity.Entity.Category GetTopParentModel(string categoryType)
        {
            return dal.GetTopParentModel(categoryType);
        }
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        //public Category GetModelByCache(int id)
        //{
			
        //    string CacheKey = "categoryModel-" + id;
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
        //    return (Category)objModel;
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
		public List<Category> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Category> DataTableToList(DataTable dt)
		{
			List<Category> modelList = new List<Category>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Category model;
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

        public Category FirstFabricParent()
        {
            return GetTopParentModel(CategoryType.Fabric);
        }

        public Category FirstAccessoryParent()
        {
            return GetTopParentModel(CategoryType.Accessory);
        }

        public List<Category> GetAllParents()
        {
            List<Category> parents = new List<Category>();
            DataSet  ds = dal.GetParents(CategoryType.All);
            if (ds != null && ds.Tables.Count > 0)
            {
                parents = DataTableToList(ds.Tables[0]);
            }
            return parents;
        }



        public List<Category> GetFabricParents()
        {
            List<Category> parents = new List<Category>();
            DataSet ds = dal.GetParents(CategoryType.Fabric);
            if (ds != null && ds.Tables.Count > 0)
            {
                parents = DataTableToList(ds.Tables[0]);
            }
            return parents;
        }

        public List<Category> GetAccessoryParents()
        {
            List<Category> parents = new List<Category>();
            DataSet ds = dal.GetParents(CategoryType.Accessory);
            if (ds != null && ds.Tables.Count > 0)
            {
                parents = DataTableToList(ds.Tables[0]);
            }
            return parents;
        }

        public List<Category> GetFabricChilds()
        {
            List<Category> Childs = new List<Category>();
            DataSet ds = dal.GetChilds(CategoryType.Fabric);
            if (ds != null && ds.Tables.Count > 0)
            {
                Childs = DataTableToList(ds.Tables[0]);
            }
            return Childs;
        }

        public List<Category> GetAccessoryChilds()
        {
            List<Category> Childs = new List<Category>();
            DataSet ds = dal.GetChilds(CategoryType.Accessory);
            if (ds != null && ds.Tables.Count > 0)
            {
                Childs = DataTableToList(ds.Tables[0]);
            }
            return Childs;
        }

        public CategoryCollection GetFabricCategories()
        {
            CategoryCollection categories = new CategoryCollection();
            object objModel = Common.DataCache.GetCache(CategoryCollection.FabricKey);
            if (objModel == null)
            {
                List<Category> parents = GetFabricParents();
                List<Category> childs = GetFabricChilds();
                categories.Create(parents, childs);
                Common.DataCache.SetCache(CategoryCollection.FabricKey, categories, Common.DataCache.DefaultTime);
            }
            else
            {
                categories = (CategoryCollection)objModel;
            }
            return categories;
        }

        public CategoryCollection GetAccessoryCategories()
        {
            CategoryCollection categories = new CategoryCollection();
            object objModel = Common.DataCache.GetCache(CategoryCollection.AccessoryKey);
            if (objModel == null)
            {
                List<Category> parents = GetAccessoryParents();
                List<Category> childs = GetAccessoryChilds();
                categories.Create(parents, childs);
                Common.DataCache.SetCache(CategoryCollection.AccessoryKey, categories, Common.DataCache.DefaultTime);
            }
            else
            {
                categories = (CategoryCollection)objModel;
            }
            return categories;
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
