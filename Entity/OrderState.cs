using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextileCity.Entity
{
    public abstract class OrderState
    {
        public const string MakingUp = "备货中";
        public const string Delivering = "配送中";
        public const string Delivered = "已送达";
        public const string Invalid = "无效";
    }

    public abstract class OrderItemState
    {
        public const string MakingUp = "备货";
        public const string Stockout = "缺货";
        public const string Delivered = "送达";
        public const string Invalid = "无效";
    }

}
