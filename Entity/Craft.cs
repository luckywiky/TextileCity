using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextileCity.Entity
{
    [Serializable]
    public partial class Craft
    {
        public Craft()
        { }
        #region Model
        private int _id;
        private string _name;
        private decimal _price = 0.00M;
        private string _intro=string.Empty;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int CraftID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// 
        
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Intro
        {
            set { _intro = value; }
            get { return _intro; }
        }
        #endregion Model

    }
}
