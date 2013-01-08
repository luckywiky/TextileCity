using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextileCity.Entity
{
   [Serializable]
	public partial class Style
	{
		public Style()
		{}
		#region Model
		private int _styleid;
		private int _material_id;
		private string _name;
		private decimal _price=0.00M;
		private string _code=string.Empty;
		private string _rgb=string.Empty;
		private string _scheme=string.Empty;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int StyleID
		{
			set{ _styleid=value;}
			get{return _styleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int MaterialID
		{
			set{ _material_id=value;}
			get{return _material_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RGB
		{
			set{ _rgb=value;}
			get{return _rgb;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Scheme
		{
			set{ _scheme=value;}
			get{return _scheme;}
		}
		#endregion Model

	}
}
