using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextileCity.Entity
{
    [Serializable]
    public class Material
    {
        #region Model
		private int _id;
		private int _category_id;
		private string _type;
		private string _name;
		private decimal _price;
		private decimal _price_high;
		private decimal _price_fancy;
		private string _styles;
		private string _intro;
		private string _main_image;
		private string _images;
		/// <summary>
		/// auto_increment
		/// </summary>
        public int MaterialID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CategoryID
		{
			set{ _category_id=value;}
			get{return _category_id;}
		}
		/// <summary>
		/// 
		/// </summary>
        public string CategoryType
		{
			set{ _type=value;}
			get{return _type;}
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
		public decimal PriceHigh
		{
			set{ _price_high=value;}
			get{return _price_high;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal PriceFancy
		{
			set{ _price_fancy=value;}
			get{return _price_fancy;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StylesList
		{
			set{ _styles=value;}
			get{return _styles;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Intro
		{
			set{ _intro=value;}
			get{return _intro;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MainImage
		{
			set{ _main_image=value;}
			get{return _main_image;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Images
		{
			set{ _images=value;}
			get{return _images;}
		}
		#endregion Model
    }
}
