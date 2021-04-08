using System.Collections.Generic;
using artists_MC.Models;
using artists_MC.Services;
using Microsoft.AspNetCore.Mvc;

namespace artists_MC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongsController : ControllerBase
    {
        public readonly SongsService _service;

        public SongsController(SongsService service)
        {
            _service = service;
        }

        [HttpGet]

        public ActionResult<IEnumerable<Song>> Get()
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
        public ActionResult<Song> Get(int id)
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
        public ActionResult<Song> Create([FromBody] Song song)
        {
            try
            {
                return Ok(_service.Create(song));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{Id}")]
        public ActionResult<Song> Edit(int Id, [FromBody] Song song)
        {
            try
            {
                return Ok(_service.Edit(Id, song));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{Id}")]
        public ActionResult<Song> Delete(int Id)
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
    }
}