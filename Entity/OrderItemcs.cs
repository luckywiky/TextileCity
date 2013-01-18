using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextileCity.Entity
{
   [Serializable]
	public partial class OrderItem
	{
		public OrderItem()
		{}
		#region Model
		private int _id;
		private int _order_id;
		private int _material_id;
        
		private int _count;
		private string _state;
		private string _type;
		private decimal _total_price=0.00M;
		private int _style_id;
		private string _style_name;
		private int _craft;
		private DateTime _add_time;
		private DateTime _delivery_time;
		private string _remark;
		private string _delivery_remark;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int ItemID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int OrderID
		{
			set{ _order_id=value;}
			get{return _order_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int MaterialID
		{
			set{ _material_id=value;}
			get{return _material_id;}
		}

        public string MaterialName
        {
            get;
            set;
        }
		/// <summary>
		/// 
		/// </summary>
		public int Count
		{
			set{ _count=value;}
			get{return _count;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string State
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Total
		{
			set{ _total_price=value;}
			get{return _total_price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int StyleID
		{
			set{ _style_id=value;}
			get{return _style_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StyleName
		{
			set{ _style_name=value;}
			get{return _style_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CraftID
		{
			set{ _craft=value;}
			get{return _craft;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime AddTime
		{
			set{ _add_time=value;}
			get{return _add_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime DeliveryTime
		{
			set{ _delivery_time=value;}
			get{return _delivery_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DeliveryRemark
		{
			set{ _delivery_remark=value;}
			get{return _delivery_remark;}
		}
		#endregion Model

	}
}
