using EndPointConnector.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EndPointConnector.Context
{
	public class postContext:DbContext
	{
		public DbSet<post> Posts { get; set; }
	}
}