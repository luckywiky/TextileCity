using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextileCity.Entity
{
    [Serializable]
    public partial class Order
    {
        public Order()
        { }
        #region Model
        private int _id;
        private int _uid;
        private string _number = string.Empty;
        private decimal _total_price = 0.00M;
        private string _address = string.Empty;
        private string _phone = string.Empty;
        private string _linkman = string.Empty;
        private DateTime _add_time=DateTime.Now;
        private DateTime _delivery_time;
        private string _remark=string.Empty;
        private string _delivery=DeliveryType.Take;
        private string _state = string.Empty;

        public string OrderState
        {
            get { return _state; }
            set { _state = value; }
        }
        /// <summary>
        /// auto_increment
        /// </summary>
        public int OrderID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Uid
        {
            set { _uid = value; }
            get { return _uid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Number
        {
            set { _number = value; }
            get { return _number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Total
        {
            set { _total_price = value; }
            get { return _total_price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LinkMan
        {
            set { _linkman = value; }
            get { return _linkman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime
        {
            set { _add_time = value; }
            get { return _add_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime DeliveryTime
        {
            set { _delivery_time = value; }
            get { return _delivery_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Delivery
        {
            set { _delivery = value; }
            get { return _delivery; }
        }
        #endregion Model

    }
}
