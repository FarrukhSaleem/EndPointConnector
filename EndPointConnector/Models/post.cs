using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EndPointConnector.Models
{
	public class post
	{
		[Key]
		public int Id { get; set; }
		public int UserId { get; set; }
		public string Title { get; set; }
		public string Body { get; set; }
	}
}