using System;
using System.Collections.Generic;
using artists_MC.Models;
using artists_MC.Repositories;

namespace artists_MC.Services
{
    public class ArtistService
    {
        public readonly ArtistRepository _repo;

        public ArtistService(ArtistRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Artist> Get()
        {
            return _repo.Get();
        }

        internal Artist Get(int id)
        {
            Artist artist = _repo.Get(id);
            if (artist == null)
            {
                throw new Exception("Invalid Id");
            }
            return artist;
        }

        internal Artist Create(Artist artist)
        {
            return _repo.Create(artist);
        }

        internal object Edit(int id, Artist artist)
        {
            Artist editable = Get(id);

            editable.Name = artist.Name != null ? artist.Name : editable.Name;
            editable.Description = artist.Description != null ? artist.Description : editable.Description;
            editable.BirthYear = artist.BirthYear != null ? artist.BirthYear : editable.BirthYear;

            return (_repo.Edit(editable));


        }

        internal string Delete(int id)
        {
            Artist artist = Get(id);
            _repo.Delete(id);
            return "deleted";
        }
    }
}