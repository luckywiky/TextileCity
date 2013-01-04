using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextileCity.Entity
{
    public class CategoryCollection
    {
        public static string FabricKey
        {
            get { return "Fabric"; }
        }

        public static string AccessoryKey
        {
            get { return "Accessory"; }
        }

        private Dictionary<int, List<Category>> categories = new Dictionary<int, List<Category>>();

        public void Create(List<Category> parentCategories, List<Category> childCategories)
        {
            categories.Clear();
            categories.Add(Category.PeakParentID, parentCategories);
            foreach (Category parent in parentCategories)
            {
                var childs = from c in childCategories
                             where c.ParentID == parent.CategoryID
                             orderby c.OrderIndex
                             select c;
                List<Category> categoryList = new List<Category>();
                foreach(Category c in childs)
                {
                    categoryList.Add(c);
                }
                categories.Add(parent.CategoryID, categoryList);
            }
        }

        public List<Category> this[int parentID]
        {
            get
            {
                if (categories.ContainsKey(parentID))
                    return categories[parentID];
                else
                    return new List<Category>();
            }
        }

        public List<Category> ParentCategories
        {
            get
            {
                return categories[Category.PeakParentID];
            }
        }
    }
}
