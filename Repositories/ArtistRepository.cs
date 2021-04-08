using System;
using System.Collections.Generic;
using System.Data;
using artists_MC.Models;
using Dapper;

namespace artists_MC.Repositories
{
    public class ArtistRepository
    {
        public readonly IDbConnection _db;

        public ArtistRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Artist> Get()
        {
            string sql = "SELECT * FROM artists;";
            return _db.Query<Artist>(sql);

        }

        internal Artist Get(int id)
        {
            string sql = "SELECT * FROM artists WHERE id = @id;";
            return _db.QueryFirstOrDefault<Artist>(sql, new { id });
        }

        internal Artist Create(Artist artist)
        {
            string sql = @"
            INSERT INTO artists
            (name, description, birthyear)
            VALUES
            (@NAME, @DESCRIPTION, @BIRTHYEAR);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, artist);
            artist.Id = id;
            return artist;
        }

        internal Artist Edit(Artist editable)
        {
            string sql = @"
            UPDATE artists
            SET
                name = @NAME,
                description = @DESCRIPTION,
                birthyear = @BIRTHYEAR
            WHERE id = @Id;
            SELECT * FROM artists WHERE id = @Id;";
            Artist toReturn = _db.QueryFirstOrDefault<Artist>(sql, editable);
            return toReturn;
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM artists WHERE id = @id;";
            _db.Execute(sql, new { id });
        }
    }
}