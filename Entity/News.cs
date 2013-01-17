using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextileCity.Entity
{
   [Serializable]
	public partial class News
	{
		public News()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _type=NewsType.Text;
		private string _content;
		private string _images;
		private string _main_image;
		private DateTime _add_time;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
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
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Images
		{
			set{ _images=value;}
			get{return _images;}
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
        public DateTime AddTime
		{
			set{ _add_time=value;}
			get{return _add_time;}
		}
		#endregion Model

	}

   public class NewsType
   {
       public const string Image = "Image";
       public const string Text = "Text";
   }
}
