using EndPointConnector.Context;
using EndPointConnector.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace EndPointConnector.Controllers
{
	public class postController : ApiController
	{
		postContext PostContext;

		public postController()
		{

			PostContext = new postContext();
		}

		[HttpGet]
		[Route("api/post/GetAllPosts")]
		public IEnumerable<post> GetAllPosts()
		{
			return PostContext.Posts.ToList();
		}

		[HttpGet]
		[Route("api/post/id")]
		public post GetPost(int id)
		{
			post p = PostContext.Posts.SingleOrDefault(c => c.Id == id);

			if (p == null)
				throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
			return p;
		}

		[HttpPost]
		[Route("api/post/CreatePost")]
		public post CreatePost(post post1)
		{
			if (!ModelState.IsValid)
				throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);

			PostContext.Posts.Add(post1);
			PostContext.SaveChanges();

			return post1;
		}

		[HttpPut]
		[Route("api/post/UpdatePost/id")]
		public void UpdatePost(int id, post post1)
		{
			if (!ModelState.IsValid)
				throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);

			post dbpost = PostContext.Posts.SingleOrDefault(p => p.Id == id);

			if (dbpost == null)
				throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);

			dbpost.Body = post1.Body;
			dbpost.Title = post1.Title;
			dbpost.UserId = post1.UserId;

			PostContext.SaveChanges();
		}

		[HttpDelete]
		[Route("api/post/DeletePost/id")]
		public void DeletePost(int id)
		{
			if (!ModelState.IsValid)
				throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);

			post dbpost = PostContext.Posts.SingleOrDefault(p => p.Id == id);

			if (dbpost == null)
				throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);

			PostContext.Posts.Remove(dbpost);
			PostContext.SaveChanges();
		}
	}
}
