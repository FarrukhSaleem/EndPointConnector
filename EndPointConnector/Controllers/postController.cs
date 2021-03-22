using EndPointConnector.Context;
using EndPointConnector.Models;
using System;
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
		public IHttpActionResult GetAllPosts()
		{
			return Ok(PostContext.Posts.ToList());
		}

		[HttpGet]
		[Route("api/post")]
		public IHttpActionResult GetPost(int id)
		{
			post p = PostContext.Posts.SingleOrDefault(c => c.Id == id);

			if (p == null)
				//throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
				return NotFound();
			return Ok(p);
		}

		[HttpPost]
		[Route("api/post/CreatePost")]
		public IHttpActionResult CreatePost(post post1)
		{
			if (!ModelState.IsValid)
				//throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
				return BadRequest();
			PostContext.Posts.Add(post1);
			PostContext.SaveChanges();

			return Created(new Uri(Request.RequestUri+"/"+post1.Id),post1);
		}

		[HttpPut]
		[Route("api/post/UpdatePost")]
		public IHttpActionResult UpdatePost(int id, post post1)
		{
			if (!ModelState.IsValid)
				//throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
				return BadRequest();
			post dbpost = PostContext.Posts.SingleOrDefault(p => p.Id == id);

			if (dbpost == null)
				//throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
				return NotFound();

			dbpost.Body = post1.Body;
			dbpost.Title = post1.Title;
			dbpost.UserId = post1.UserId;

			PostContext.SaveChanges();
			return Ok();
		}

		[HttpPut]
		[Route("api/post/UpdatePostTitle")]
		public IHttpActionResult UpdatePostTitle(post post1)
		{
			if (!ModelState.IsValid)
				//throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
				return BadRequest();
			post dbpost = PostContext.Posts.SingleOrDefault(p => p.Id == post1.Id);

			if (dbpost == null)
				//throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
				return NotFound();

			dbpost.Title = post1.Title;
			
			PostContext.SaveChanges();
			return Ok();
		}

		[HttpDelete]
		[Route("api/post/DeletePost")]
		public IHttpActionResult DeletePost(int id)
		{
			if (!ModelState.IsValid)
				//throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
				return BadRequest();
			post dbpost = PostContext.Posts.SingleOrDefault(p => p.Id == id);

			if (dbpost == null)
				//throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
				return NotFound();
			PostContext.Posts.Remove(dbpost);
			PostContext.SaveChanges();

			return Ok();
		}
	}
}
