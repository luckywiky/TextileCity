using System.Configuration;

namespace TextileCity.DBUtility
{
    public class PublicConstant
    {
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                //if (_connectionString == string.Empty || _connectionString == null)
                //{
                //    _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                //}
                //string ConStringEncrypt = ConfigurationManager.AppSettings["ConnStringEncrypt"];
                //if (ConStringEncrypt == "true")
                //{
                //    _connectionString = DESEncrypt.Decrypt(_connectionString);
                //}
                return _connectionString;
            }
        }

        /// <summary>
        /// 得到web.config里配置项的数据库连接字符串。
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string configName)
        {
            string connectionString = ConfigurationManager.AppSettings[configName];
            //string ConStringEncrypt = ConfigurationManager.AppSettings["ConnStringEncrypt"];
            //if (ConStringEncrypt == "true")
            //{
            //    connectionString = DESEncrypt.Decrypt(connectionString);
            //}
            return connectionString;
        }

    }
}
