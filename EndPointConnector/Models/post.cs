﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndPointConnector.Models
{
	public class post
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string Title { get; set; }
		public string Body { get; set; }
	}
}