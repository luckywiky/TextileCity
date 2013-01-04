using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextileCity.Entity
{
    [Serializable]
    public class Category
    {
        public static readonly int PeakParentID = 0;

        public Category()
        { }
        #region Model
        private int _id;
        private int _parentid = 0;
        private string _name;
        private string _type = CategoryType.Fabric;
        private int _order_index = 99;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int CategoryID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OrderIndex
        {
            set { _order_index = value; }
            get { return _order_index; }
        }
        #endregion Model
    }
}
