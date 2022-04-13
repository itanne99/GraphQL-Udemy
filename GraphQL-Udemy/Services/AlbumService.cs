using System.Collections.Generic;
using System.Linq;
using GraphQL_Udemy.Data;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Models;

namespace GraphQL_Udemy.Services
{
    public class AlbumService : IAlbum
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

        public AlbumService(GraphQLDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public Album CreateAlbum(Album album)
        {
            _logger.CreateLog(NewLog($"Added {album.Name} to db"));
            _dbContext.Albums.Add(album);
            _dbContext.SaveChanges();
            return album;
        }

        public List<Album> GetAlbums()
        {
            _logger.CreateLog(NewLog($"Generated full list of albums"));
            return _dbContext.Albums.ToList();
        }

        public Album GetAlbum(int id)
        {
            _logger.CreateLog(NewLog($"Got album @ id:{id}"));
            return _dbContext.Albums.First(x => x.Id == id);
        }

        public Album GetAlbum(string name)
        {
            _logger.CreateLog(NewLog($"Got album @ name:{name}"));
            return _dbContext.Albums.First(x => x.Name == name);
        }

        public List<Album> GetAlbumsByArtist(int id)
        {
            _logger.CreateLog(NewLog($"Got album @ artist_id:{id}"));
            return _dbContext.Albums.Where(x => x.ArtistId == id).ToList();
        }

        public List<Song> GetSongsFromAlbum(int id)
        {
            _logger.CreateLog(NewLog($"Got album @ album_id:{id}"));
            return _dbContext.Songs.Where(x => x.Album.Id == id).ToList();
        }
        
        public List<Song> GetSongsFromAlbum(string name)
        {
            _logger.CreateLog(NewLog($"Got songs from album_name:{name}"));
            return _dbContext.Songs.Where(x => x.Album.Name == name).ToList();
        }

        public List<Album> GetAlbumsByYear(int year)
        {
            _logger.CreateLog(NewLog($"Got albums from year:{year}"));
            return _dbContext.Albums.Where(x => x.Year == year).ToList();
        }

        public Album UpdateAlbum(int id, Album album)
        {
            var albumObject = _dbContext.Albums.Find(id);
            _logger.CreateLog(NewLog($"Updated album from {albumObject.Name} to {album.Name}"));
            albumObject.Name = album.Name;
            _dbContext.SaveChanges();
            return album;

        }

        public void DeleteAlbum(int id)
        {
            _logger.CreateLog(NewLog($"Deleted album @ id:{id}"));
            var albumObject = _dbContext.Albums.Find(id);
            _dbContext.Albums.Remove(albumObject);
            _dbContext.SaveChanges();
        }
    }
}