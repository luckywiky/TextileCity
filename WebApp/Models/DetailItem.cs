using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int Craft
        {
            get;
            set;
        }

        public string Remark
        {
            get;
            set;
        }

        public DetailItem()
        {
            id = new Guid().ToString("N");
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
            return itemNew;
        }
    }
}
