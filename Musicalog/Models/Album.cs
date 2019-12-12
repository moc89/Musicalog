using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Musicalog.Models
{
	public class Album
	{
		int _albumID;
		string _albumName = "";
		string _artist = "";
		string _type = "";
		int _stock;

		[Display(Name ="AlbumID")]
		public int AlbumID
		{
			get { return _albumID; }
			set { _albumID = value; }
		}

		[Display(Name = "AlbumName")]
		public string AlbumName
		{
			get { return _albumName; }
			set { _albumName = value; }
		}

		[Display(Name = "Artist")]
		public string Artist
		{
			get { return _artist; }
			set { _artist = value; }
		}

		[Display(Name = "Type")]
		public string Type
		{
			get { return _type; }
			set { _type = value; }
		}

		[Display(Name = "Stock")]
		public int Stock
		{
			get { return _stock; }
			set { _stock = value; }
		}
	}
}