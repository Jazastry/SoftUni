namespace MusicSystem.Client.Controllers
{
    using System.Web.Http;
    using System.Data.Entity;
    using Data;

    public class BaseApiController : ApiController
    {
        protected MusicSystemDbContext data;

        public BaseApiController()
            : this (new MusicSystemDbContext())
        {
            
        }

        public BaseApiController(MusicSystemDbContext data)
        {
            this.data = data;
        }

        public DbContext Data 
        {
            get
            {
                return this.data;
            }
        }
    }
}
