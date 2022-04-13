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
        private ILog _logger;

        private Log NewLog(string message)
        {
            var log = new Log
            {
                Message = message
            };
            return log;
        }

        public SongService(GraphQLDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public Song CreateSong(Song song)
        {
            _logger.CreateLog(NewLog($"Added {song.Name} by {song.Artist} to database"));
            _dbContext.Songs.Add(song);
            _dbContext.SaveChanges();
            return song;
        }

        public List<Song> GetSongs()
        {
            _logger.CreateLog(NewLog("Pulled full song list"));
            return _dbContext.Songs.ToList();
        }

        public Song GetSong(int id)
        {
            _logger.CreateLog(NewLog($"Got song @ id:{id}"));
            return _dbContext.Songs.First(x => x.Id == id);
        }

        public Song GetSong(string name)
        {
            _logger.CreateLog(NewLog($"Got song @ name:{name}"));
            return _dbContext.Songs.First(x => x.Name == name);
        }

        public List<Song> GetSongByArtist(int id)
        {
            _logger.CreateLog(NewLog($"Got songs @ artist_id:{id}"));
            return _dbContext.Songs.Where(x => x.ArtistId == id).ToList();
        }

        public List<Song> GetSongByAlbum(int id)
        {
            _logger.CreateLog(NewLog($"Got songs @ album_id:{id}"));
            return _dbContext.Songs.Where(x => x.AlbumId == id).ToList();
        }
        
        public Song UpdateSong(int id, Song song)
        {
            var songObject = _dbContext.Songs.Find(id);
            _logger.CreateLog(NewLog($"Updated song @ id:{id} from {songObject.Name} to {song.Name} "));
            songObject.Name = song.Name;
            _dbContext.SaveChanges();
            return song;

        }

        public void DeleteSong(int id)
        {
            var songObject = _dbContext.Songs.Find(id);
            _logger.CreateLog(NewLog($"Updated song @ id:{id}"));
            _dbContext.Songs.Remove(songObject);
            _dbContext.SaveChanges();
        }
    }
}