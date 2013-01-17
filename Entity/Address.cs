using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextileCity.Entity
{

    /// <summary>
	/// Address:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class MyAddress
	{
        public MyAddress()
		{}
		#region Model
		private int _addressid;
		private int _uid;
		private string _address;
		private string _linkname;
		private string _phone;
		private DateTime _addtime;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int AddressID
		{
			set{ _addressid=value;}
			get{return _addressid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Uid
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LinkName
		{
			set{ _linkname=value;}
			get{return _linkname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}

		/// <summary>
		/// 
		/// </summary>
		public DateTime AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}

        
		#endregion Model

    }
}
