namespace MusicSystem.Client.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Data;
    using Model;
    using Models;

    [RoutePrefix("api/Albums")]
    public class AlbumController : BaseApiController
    {
        private MusicSystemDbContext context = new MusicSystemDbContext();

        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAllAlbums()
        {
            var albums = context.Albums.ToList();

            if (!albums.Any())
            {
                return NotFound();
            }

            return this.Ok(albums);
        }

        [Route("GetByName")]
        [HttpGet]
        public IHttpActionResult GetByName([FromUri]AlbumsGetBundingModel model)
        {
            var album = context.Albums.Where(a => (a.Id == model.Id) || (a.Title == model.Title)).FirstOrDefault();

            if (album == null)
            {
                return this.NotFound();
            }

            return this.Ok(album);
        }

        [Route("CreateAlbum")]
        [HttpPost]
        public IHttpActionResult CreateAlbum([FromUri]AlbumsCreateBindingModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            Album album = new Album()
            {
                Title = model.Title,
                Producer = model.Producer,
                Year = model.Year
            };

            context.Albums.Add(album);
            context.SaveChanges();

            return Ok(album);
        }

        [Route("UpdateAlbum")]
        [HttpPut]
        public IHttpActionResult UpdateAlbum([FromUri]AlbumUpdateBindingModel model)
        {
            var album = context.Albums.Where(a => (a.Title == model.Title) || (a.Id == model.Id)).FirstOrDefault();

            if (model == null)
            {
                return BadRequest();
            }
            if (album == null)
            {
                return NotFound();
            }
            album.Title = model.Title;
            album.Producer = (model.Producer ?? album.Producer);
            album.Year = (model.Year ?? album.Year);
            context.SaveChanges();

            return Ok(album);
        }

        [Route("DeleteAlbum")]
        [HttpDelete]
        public IHttpActionResult DeleteAlbum([FromUri]AlbumUpdateBindingModel model)
        {
            var album = context.Albums.Where(a => (a.Title == model.Title) || (a.Id == model.Id)).FirstOrDefault();
            if (album == null)
            {
                return NotFound();
            }

            context.Albums.Remove(album);
            context.SaveChanges();

            return this.Ok(album);
        }
    }
}
