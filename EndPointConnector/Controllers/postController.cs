﻿using EndPointConnector.Context;
using EndPointConnector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace EndPointConnector.Controllers
{
    public class postController : ApiController
    {
        postContext PostContext;
        [HttpGet]
        [Route("api/post/GetAllPosts")]
        public List<post> GetAllPosts()
        {
            PostContext = new postContext();
            List<post> posts = new List<post>();
            posts = PostContext.Posts.ToList();

            return posts;
        }
        [HttpPost]
        [Route("api/post/CreatePost")]
        public int CreatePost(post post1)
        {
            int id = -1;
            PostContext = new postContext();
            //post post1 = new post
            //{
            //    Title=title
            //};
            post newItem = PostContext.Posts.Add(post1);
            PostContext.SaveChanges();
            id = newItem.Id;
            return id;
        }
    }
}
