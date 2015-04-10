using BlogSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogSystem.Client.Controllers
{
    public class BaseController : ApiController
    {
        protected IBlogSystemData data;

        public IBlogSystemData Data
        {
            get { return this.data; }
        }

        public BaseController()
            : this(new BlogSystemData(new BlogSystemDbContext()))
        {
        }
        public BaseController(IBlogSystemData data)
        {
            this.data = data;
        }
    }
}
