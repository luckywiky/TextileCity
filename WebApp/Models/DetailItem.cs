using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextileCity.Entity;

namespace TextileCity.Models
{
    public class DetailItem
    {

        private string id;
        public string ID
        {
            get
            {
                return id;
            }
        }
        public int MaterialID
        {
            get;
            set;
        }

        public decimal Price
        {
            get;
            set;
        }

        public int Count
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }

        public int Style
        {
            get;
            set;
        }

        public decimal StylePrice
        {
            get;
            set;
        }

        public int Craft
        {
            get;
            set;
        }

        public string Image
        {
            get;
            set;
        }

        public string Remark
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string StyleName
        {
            get;
            set;
        }

        public string CraftName
        {
            get;
            set;
        }

        public DetailItem()
        {
            id =  Guid.NewGuid().ToString("N");
            Price = 0.00m;
            StylePrice = 0.00m;
        }

        public DetailItem Clone()
        {
            DetailItem itemNew = new DetailItem();
            itemNew.id = id;
            itemNew.MaterialID = MaterialID;
            itemNew.Count = Count;
            itemNew.Craft = Craft;
            itemNew.Remark = Remark;
            itemNew.Style = Style;
            itemNew.Type = Type;
            itemNew.Price = Price;
            itemNew.Image = Image;
            itemNew.StylePrice = StylePrice;
            itemNew.Name = Name;
            itemNew.StyleName = StyleName;
            itemNew.CraftName = CraftName;
            return itemNew;
        }

        /// <summary>
        /// 样式和物品的单价
        /// </summary>
        public decimal TotalPrice
        {
            get
            {
                return Price + StylePrice;
            }
        }

        /// <summary>
        /// 总价
        /// </summary>
        public decimal Total
        {
            get
            {
                return (Price + StylePrice) * Count;
            }
        }


        public OrderItem ToOrderItem(int orderid)
        {
            OrderItem orderItem = new OrderItem();
            orderItem.OrderID = orderid;
            orderItem.AddTime = DateTime.Now;
            orderItem.Count = Count;
            orderItem.CraftID = Craft;
            orderItem.MaterialID = MaterialID;
            //orderItem.Remark = Remark;
            orderItem.State = OrderItemState.MakingUp;
            orderItem.StyleID = Style;
            orderItem.Type = Type;
            orderItem.StyleName = StyleName;
            orderItem.Total = Total;
            return orderItem;
        }
    }
}
