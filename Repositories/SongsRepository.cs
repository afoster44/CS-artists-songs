using System;
using System.Collections.Generic;
using System.Data;
using artists_MC.Models;
using Dapper;

namespace artists_MC.Repositories
{
    public class SongsRepository
    {
        public readonly IDbConnection _db;

        public SongsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Song> Get()
        {
            string sql = "SELECT * FROM songs;";
            return _db.Query<Song>(sql);

        }

        internal Song Get(int id)
        {
            string sql = "SELECT * FROM songs WHERE id = @id;";
            return _db.QueryFirstOrDefault<Song>(sql, new { id });
        }

        internal Song Create(Song song)
        {
            string sql = @"
            INSERT INTO songs
            (title, description, year, artistId)
            VALUES
            (@TITLE, @DESCRIPTION, @YEAR, @ARTISTID);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, song);
            song.Id = id;
            return song;
        }

        internal Song Edit(Song editable)
        {
            string sql = @"
            UPDATE songs
            SET
                title = @TITLE,
                description = @DESCRIPTION,
                year = @YEAR
            WHERE id = @Id;
            SELECT * FROM songs WHERE id = @Id;";
            Song toReturn = _db.QueryFirstOrDefault<Song>(sql, editable);
            return toReturn;
        }

        internal IEnumerable<Song> GetSongsByArtist(int id)
        {
            string sql = @"
      SELECT 
      p.*,
      a.*
      FROM songs p
      JOIN artists a ON p.artistId = a.id
      WHERE artistId = @id;";

            return _db.Query<Song, Artist, Song>(sql, (song, artist) =>
            {
                song.Artist = artist;
                return song;
            }, new { id }, splitOn: "id");
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM songs WHERE id = @id;";
            _db.Execute(sql, new { id });
        }
    }
}