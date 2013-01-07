using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextileCity.Entity;
using TextileCity.Operation;

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

        public void Add(DetailItem item)
        {
            orderList.Add(item);
        }

        public bool Delet(string id)
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
                total += item.Price;
            }
            return total;
        }

        public bool RefreshPrice()
        {
            bool change = false;

            foreach (DetailItem item in orderList)
            {
                
            }
            return change;
        }


    }


}
