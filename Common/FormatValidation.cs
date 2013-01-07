using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common
{
    public abstract class FormatValidation
    {
        /// <summary>
        /// 检查邮箱格式是否正确
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool VerifyEmail(string email)
        {
            bool result = false;
            if (email.Length > 50 || string.IsNullOrEmpty(email))
            {
                return result;
            }
            else
            {
                Regex regex = new Regex(@"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$");
                result = regex.IsMatch(email);
                return result;
            }
        }

        public static bool VerifyName(string userName)
        {
            bool result = false;
            if (userName.Length > 20 || string.IsNullOrEmpty(userName))
            {
                return result;
            }
            else
            {
                Regex regex = new Regex(@"^[A-Za-z][A-Za-z0-9_]{4,19}");
                result = regex.IsMatch(userName);
            }
            return result;
        }

        public static bool VerifyPassword(string password)
        {
            bool result = false;
            if (password.Length > 20 || password.Length < 5)
            {
                return false;
            }
            else
            {
                Regex regex = new Regex(@"^[\@A-Za-z0-9\!\#\$\%\^\&\*\.\~\-\+\=\'\:\,\[\]\{\}\(\)\?\/\<\>\`\""]{4,19}");
                result = regex.IsMatch(password);
                return result;
            }
        }
    }
}
