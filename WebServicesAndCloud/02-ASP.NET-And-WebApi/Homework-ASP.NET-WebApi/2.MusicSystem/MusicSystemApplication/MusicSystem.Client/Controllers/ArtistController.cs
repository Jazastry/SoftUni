namespace MusicSystem.Client.Controllers
{
    using System;
    using System.Web.Http;
    using Data;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using Model;
    using Models;

    [RoutePrefix("api/Artists")]
    public class ArtistController : BaseApiController
    {
        private MusicSystemDbContext context = new MusicSystemDbContext();
     
        public ArtistController()
            : this (new MusicSystemDbContext())
        {
        }

        public ArtistController(MusicSystemDbContext data)
        {
            this.data = data;
        }

        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAllArtists()
        {
            var artists = context.Artists.ToList();
            if (!artists.Any())
            {
                return this.ResponseMessage(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            return this.Ok(artists);
        }

        [Route("GetByName")]
        [HttpGet]
        public IHttpActionResult GetByName([FromUri]string name)
        {
            var artist = context.Artists.Where(a => a.Name == name).FirstOrDefault();

            if (artist == null)
            {
                return NotFound();
            }

            return Ok(artist);
        }

        [Route("CreateArtist")]
        [HttpPost]
        public IHttpActionResult CreateArtist([FromUri]ArtistCreationBindingModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            DateTime? date = null;

            if (model.BirthDay != null)
            {
                date = DateTime.Parse(model.BirthDay);
            }

            Artist newArtist = new Artist()
            {
                Name = model.Name,
                BirthDay = date,
                Country = model.Country
            };

            context.Artists.Add(newArtist);
            context.SaveChanges();

            return Ok(newArtist);
        }

        [Route("UpdateArtist")]
        [HttpPut]
        public IHttpActionResult UpdateArtist([FromUri]ArtistUpdateBindingModel model)
        {
            var artist = context.Artists.Where(a => (a.Name == model.Name) || (a.Id == model.Id)).FirstOrDefault();

            if (model == null)
            {
                return BadRequest();
            }
            else if (artist == null)
            {
                return NotFound();
            }
            artist.Name = model.Name;
            artist.BirthDay = (model.BirthDay ?? artist.BirthDay);
            artist.Country = (model.Country ?? artist.Country);                        
            context.SaveChanges();

            return Ok(artist);
        }

        [Route("DeleteArtist")]
        [HttpDelete]
        public IHttpActionResult DeleteArtist([FromUri]ArtistUpdateBindingModel model)
        {
            var artist = context.Artists.Where(a => (a.Name == model.Name) || (a.Id == model.Id)).FirstOrDefault();
            if (artist == null)
            {
                return NotFound();
            }

            context.Artists.Remove(artist);
            context.SaveChanges();

            return this.Ok(artist);
        }
    }
}
