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
    public class UserOperation
    {
        private readonly UserData dal = new UserData();
        public UserOperation()
		{}
		
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
		public bool Add(User model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(User model)
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
		public User GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

        public User Login(string login, string password, out int result)
        {
            //// result
            //// -3:账号格式不正确
            //// -2:密码格式不正确
            //// -1:用户不存在或者密码不正确
            ////  0:用户封禁
            ////  1:正常
            User user = null;
            result = -1;
            if (Common.FormatValidation.VerifyEmail(login))
            {
                if (Common.FormatValidation.VerifyPassword(password))
                {
                    user = dal.GetModelByEmail(login, password);
                    if (user != null)
                    {
                        if (user.State == 1)
                        {
                            result = 1;
                        }
                        else
                        {
                            result = 0;
                        }
                    }
                    else
                    {
                        result = -1;
                    }
                }
                else
                {
                    result = -2;
                }
            }
            else if (Common.FormatValidation.VerifyName(login))
            {
                if (Common.FormatValidation.VerifyPassword(password))
                {
                    user = dal.GetModel(login, password);
                    if (user != null)
                    {
                        if (user.State == 1)
                        {
                            result = 1;
                        }
                        else
                        {
                            result = 0;
                        }
                    }
                    else
                    {
                        result = -1;
                    }
                }
                else
                {
                    result = -2;
                }
            }
            else
            {
                result = -3;
            }
            return user;
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        //public User GetModelByCache(int id)
        //{
			
        //    string CacheKey = "userModel-" + id;
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
        //    return (User)objModel;
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
		public List<User> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<User> DataTableToList(DataTable dt)
		{
			List<User> modelList = new List<User>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				User model;
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
    }
}
