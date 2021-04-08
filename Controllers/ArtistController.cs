using System.Collections.Generic;
using artists_MC.Models;
using artists_MC.Services;
using Microsoft.AspNetCore.Mvc;

namespace artists_MC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistController : ControllerBase
    {
        public readonly ArtistService _service;

        public readonly SongsService _songservice;

        public ArtistController(ArtistService service, SongsService songservice)
        {
            _service = service;
            _songservice = songservice;
        }

        [HttpGet]

        public ActionResult<IEnumerable<Artist>> Get()
        {
            try
            {
                return Ok(_service.Get());
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Artist> Get(int id)
        {
            try
            {
                return Ok(_service.Get(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public ActionResult<Artist> Create([FromBody] Artist artist)
        {
            try
            {
                return Ok(_service.Create(artist));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{Id}")]
        public ActionResult<Artist> Edit(int Id, [FromBody] Artist artist)
        {
            try
            {
                return Ok(_service.Edit(Id, artist));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{Id}")]
        public ActionResult<Artist> Delete(int Id)
        {
            try
            {
                return Ok(_service.Delete(Id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{Id}/songs")]
        public ActionResult<IEnumerable<Song>> GetSongsByArtist(int Id)
        {
            try
            {
                return Ok(_songservice.GetSongsByArtist(Id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

    }
}