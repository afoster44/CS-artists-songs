using System;
using System.Collections.Generic;
using artists_MC.Models;
using artists_MC.Repositories;

namespace artists_MC.Services
{
    public class SongsService
    {
        public readonly SongsRepository _repo;

        public SongsService(SongsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Song> Get()
        {
            return _repo.Get();
        }

        internal Song Get(int id)
        {
            Song artist = _repo.Get(id);
            if (artist == null)
            {
                throw new Exception("Invalid Id");
            }
            return artist;
        }

        internal Song Create(Song song)
        {
            return _repo.Create(song);
        }

        internal object Edit(int id, Song song)
        {
            Song editable = Get(id);

            editable.Title = song.Title != null ? song.Title : editable.Title;
            editable.Description = song.Description != null ? song.Description : editable.Description;
            editable.Year = song.Year != null ? song.Year : editable.Year;

            return (_repo.Edit(editable));


        }

        internal string Delete(int id)
        {
            Song song = Get(id);
            _repo.Delete(id);
            return "deleted";
        }

        internal IEnumerable<Song> GetSongsByArtist(int id)
        {
            return _repo.GetSongsByArtist(id);
        }
    }
}