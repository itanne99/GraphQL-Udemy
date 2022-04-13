using System.Collections.Generic;
using System.Linq;
using GraphQL_Udemy.Data;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Models;

namespace GraphQL_Udemy.Services
{
    public class ArtistService : IArtist
    {
        private GraphQLDbContext _dbContext;
        private ILog _logger;

        public ArtistService(GraphQLDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public Artist CreateArtist(Artist artist)
        {
            _dbContext.Artists.Add(artist);
            _dbContext.SaveChanges();
            return artist;
        }

        public List<Artist> GetArtists()
        {
            return _dbContext.Artists.ToList();
        }

        public Artist GetArtist(int id)
        {
            return _dbContext.Artists.First(x => x.Id == id);
        }

        public Artist GetArtist(string name)
        {
            return _dbContext.Artists.First(x => x.Name == name);
        }

        public Artist UpdateArtist(int id, Artist artist)
        {
            var artistObject = _dbContext.Artists.Find(id);
            artistObject.Name = artist.Name;
            _dbContext.SaveChanges();
            return artist;

        }

        public void DeleteArtist(int id)
        {
            var artistObject = _dbContext.Artists.Find(id);
            _dbContext.Artists.Remove(artistObject);
            _dbContext.SaveChanges();
        }
    }
}