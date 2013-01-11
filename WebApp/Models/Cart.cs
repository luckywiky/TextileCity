using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextileCity.Entity;
using TextileCity.Operation;
using System.Web;

namespace TextileCity.Models
{
    public class Cart
    {
        private List<DetailItem> orderList = new List<DetailItem>();

        public List<DetailItem> Orders
        {
            get { return orderList; }
            set { orderList = value; }
        }

        private int uid = 0;

        public int Uid
        {
            get { return uid; }
            set { uid = value; }
        }

        public string Address
        {
            get;
            set;
        }

        public string Phone
        {
            get;
            set;
        }

        public string LinkMan
        {
            get;
            set;
        }

        public string Remark
        {
            get;
            set;
        }

        public decimal TotalPrice
        {
            get
            {
                return GetTotal();
            }
        }

        public Cart(int uid)
        {
            this.uid = uid;
            
        }

        public Cart()
            : this(0)
        {
        }

        public DetailItem GetItem(string id)
        {
            DetailItem itemResult = null;
            foreach (DetailItem item in orderList)
            {
                if (item.ID == id)
                {
                    itemResult = item;
                    break;
                }
            }
            return itemResult;
        }

        public void Add(DetailItem item)
        {
            orderList.Add(item);
        }

        public bool Delete(string id)
        {
            bool result = false;
            foreach (DetailItem item in orderList)
            {
                if (item.ID == id)
                {
                    orderList.Remove(item);
                    result = true;
                    break;
                }
            }
            return result;
        }

        public List<DetailItem> FabricItems()
        {
            List<DetailItem> fabricItems = new List<DetailItem>();
            foreach (DetailItem item in orderList)
            {
                if (item.Type == CategoryType.Fabric)
                {
                    fabricItems.Add(item.Clone());
                }
            }
            return fabricItems;
        }

        public List<DetailItem> AccessoryItems()
        {
            List<DetailItem> accessoryItems = new List<DetailItem>();
            foreach (DetailItem item in orderList)
            {
                if (item.Type == CategoryType.Accessory)
                {
                    accessoryItems.Add(item.Clone());
                }
            }
            return accessoryItems;
        }

        public decimal GetTotal()
        {
            decimal total = 0;
            foreach (DetailItem item in orderList)
            {
                total += (item.Price+item.StylePrice)*item.Count;
            }
            return total;
        }

        public bool RefreshDbData()
        {
            bool change = true;
            if (orderList.Count <= 0)
            {
                return false;
            }
            Dictionary<int, Material> models = new Dictionary<int, Material>();
            Dictionary<int, Style> stylePrices = new Dictionary<int, Style>();
            Dictionary<int, Craft> craftPrices = new Dictionary<int, Craft>();
            List<int> ids = new List<int>();
            List<int> styleIDs = new List<int>();
            List<int> craftIDs = new List<int>();

            foreach (DetailItem item in orderList)
            {
                ids.Add(item.MaterialID);
                if (item.Type == CategoryType.Accessory)
                {
                    styleIDs.Add(item.Style);
                }
                else
                {
                    craftIDs.Add(item.Craft);
                }
            }

            MaterialOperation mop = new MaterialOperation();
            List<Material> materials = mop.GetList(ids);
            foreach (Material material in materials)
            {
                models.Add(material.MaterialID, material);
            }

            StyleOperation sop = new StyleOperation();
            List<Style> styles = sop.GetList(styleIDs);
            foreach (Style s in styles)
            {
                stylePrices.Add(s.StyleID, s);
            }

            CraftOperation cop = new CraftOperation();
            List<Craft> crafts = cop.GetMinList(craftIDs);
            foreach (Craft c in crafts)
            {
                craftPrices.Add(c.CraftID, c);
            }

            foreach (DetailItem item in orderList)
            {
                Material m = models[item.MaterialID];
                item.Image = m.MainImage;
                item.Name = m.Name;
                if (item.Type == CategoryType.Fabric)
                {
                    Craft craftObj = craftPrices[item.Craft];
                    item.StylePrice = craftObj.Price;
                    item.CraftName = craftObj.Name;
                    switch (item.Style)
                    {
                        case 1:
                            item.Price = m.Price;
                            item.StyleName = "本色";
                            break;
                        case 2:
                            item.Price = m.PriceHigh;
                            item.StyleName = "高色";
                            break;
                        case 3:
                            item.Price = m.PriceFancy;
                            item.StyleName = "多彩";
                            break;
                    }
                }
                else
                {
                    item.Price = 0.00m;
                    Style styleObj = stylePrices[item.Style];
                    item.StylePrice = styleObj.Price;
                    item.StyleName = styleObj.Name;
                }
            }
            return change;
        }

        public bool SaveToDB()
        {
            if (uid <= 0)
                return false;
            if (orderList.Count <= 0)
                return false;
            Order order = new Order();
            order.Uid = uid;
            order.OrderState = OrderState.MakingUp;
            DateTime now = DateTime.Now;
            order.Number = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}", uid, now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, now.Millisecond);
            order.Total = TotalPrice;
            order.Address = Address;
            order.AddTime = DateTime.Now;
            order.LinkMan = LinkMan;
            order.Phone = Phone;

            OrderOperation orderop = new OrderOperation();
            int orderid = orderop.Add(order);
            int rows =0;
            bool result =false;
            if (orderid > 0)
            {
                List<OrderItem> orderItems = new List<OrderItem>();
                foreach (DetailItem detail in orderList)
                {
                    OrderItem item = detail.ToOrderItem(orderid);
                    orderItems.Add(item);
                }
                OrderItemOperation oiop = new OrderItemOperation();
                rows = oiop.AddList(orderItems);
                if (rows > 0)
                {
                    result = true;
                }
                else
                {
                    orderop.Delete(orderid);
                }
            }
            return result;
        }
    }


}
