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

        public AlbumService(GraphQLDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public Album CreateAlbum(Album album)
        {
            _dbContext.Albums.Add(album);
            _dbContext.SaveChanges();
            return album;
        }

        public List<Album> GetAlbums()
        {
            return _dbContext.Albums.ToList();
        }

        public Album GetAlbum(int id)
        {
            return _dbContext.Albums.First(x => x.Id == id);
        }

        public Album GetAlbum(string name)
        {
            return _dbContext.Albums.First(x => x.Name == name);
        }

        public Album UpdateAlbum(int id, Album album)
        {
            var albumObject = _dbContext.Albums.Find(id);
            albumObject.Name = album.Name;
            _dbContext.SaveChanges();
            return album;

        }

        public void DeleteAlbum(int id)
        {
            var albumObject = _dbContext.Albums.Find(id);
            _dbContext.Albums.Remove(albumObject);
            _dbContext.SaveChanges();
        }
    }
}