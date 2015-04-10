using BlogSystem.Data;
using BlogSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BlogSystem.Client.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace BlogSystem.Client.Controllers
{
    [RoutePrefix("api/Posts")]
    public class PostsController : BaseController
    {
        public PostsController()
            : this (new BlogSystemData(new BlogSystemDbContext()))
        {
        }
        public PostsController(IBlogSystemData data)
        {
            this.data = data;
        }

        [Route("GetAll")]
        [HttpGet]
        public IEnumerable<Post> GetAll()
        {
            var postsQuery = this.Data.Posts.All().Select(p => p);
            var result = Serialize(postsQuery);
            return result;
        }

        [Route("GetByUserName")]
        [HttpGet]
        public IEnumerable<Post> GetByUserName([FromUri]string username)
        {
            var postsQuery = this.Data.Posts.AllPostsByAutor(username);
            var result = Serialize(postsQuery);
            return result;
        }

        [Route("GetById")]
        [HttpGet]
        public Post GetById([FromUri]int id)
        {
            var postsQuery = this.Data.Posts.GetById(id);
            var post = new Post()
            {
                Title = postsQuery.Title,
                UserId = postsQuery.User.Id,
                Content = postsQuery.Content
            };
            return post;
        }

        [Route("CreateNewPost")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateNewPost(PostBindingModels.PostBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var post = new Post()
            {
                Title = model.Title,
                UserId = this.User.Identity.GetUserId(),
                Content = model.Content
            };

            this.Data.Posts.Add(post);
            this.Data.SaveChanges();

            return Ok(post);
        }


        [Route("DeletePost")]
        [HttpDelete]
        public IHttpActionResult DeletePost(int postId)
        {
            var post = this.Data.Posts.GetById(postId);
            if (postId == null)
            {
                return this.BadRequest("Post Id cant be null.");
            }
            else if (post == null)
            {
                return this.NotFound();
            }
            this.Data.Posts.Delete(post);
            this.Data.SaveChanges();
            return Ok(post);
        }

        [Route("UpdatePost")]
        [HttpPut]
        public IHttpActionResult UpdatePost(PostBindingModels.PostBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var post = new Post()
            {
                Id = model.Id,
                Title = model.Title,
                UserId = this.User.Identity.GetUserId(),
                Content = model.Content
            };

            this.Data.Posts.Update(post);
            this.Data.SaveChanges();

            return Ok(post);
        }

        private List<Post> Serialize(IQueryable<Post> postsQuery)
        {
            List<Post> result = new List<Post>();
            foreach (var post in postsQuery.ToList())
            {
                result.Add(
                    new Post()
                    {
                        Title = post.Title,
                        UserId = post.UserId,
                        Content = post.Content,
                        User = new User()
                        {
                            UserName = post.User.UserName,
                            Gender = post.User.Gender  
                        }
                    }
                );
            }

            return result;
        }
    }
}
