using System.Collections.Generic;
using System.Linq;
using GraphQL_Udemy.Data;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Models;

namespace GraphQL_Udemy.Services
{
    public class SongService : ISong
    {
        private GraphQLDbContext _dbContext;

        public SongService(GraphQLDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public Song CreateSong(Song song)
        {
            _dbContext.Songs.Add(song);
            _dbContext.SaveChanges();
            return song;
        }

        public List<Song> GetSongs()
        {
            return _dbContext.Songs.ToList();
        }
        
        public List<Song> GetSongs(int id)
        {
            return _dbContext.Songs.Where(x=>x.Album.Id == id).ToList();
        }

        public Song GetSong(int id)
        {
            return _dbContext.Songs.First(x => x.Id == id);
        }

        public Song GetSong(string name)
        {
            return _dbContext.Songs.First(x => x.Name == name);
        }

        public Song UpdateSong(int id, Song song)
        {
            var songObject = _dbContext.Songs.Find(id);
            songObject.Name = song.Name;
            _dbContext.SaveChanges();
            return song;

        }

        public void DeleteSong(int id)
        {
            var songObject = _dbContext.Songs.Find(id);
            _dbContext.Songs.Remove(songObject);
            _dbContext.SaveChanges();
        }
    }
}