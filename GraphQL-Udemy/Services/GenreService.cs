using System.Collections.Generic;
using System.Linq;
using GraphQL_Udemy.Data;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Models;

namespace GraphQL_Udemy.Services
{
    public class GenreService : IGenre
    {
        private GraphQLDbContext _dbContext;

        public GenreService(GraphQLDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public Genre AddGenre(Genre genre)
        {
            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();
            return genre;
        }

        public List<Genre> GetGenres()
        {
            return _dbContext.Genres.ToList();
        }

        public Genre GetGenre(int id)
        {
            return _dbContext.Genres.First(x => x.Id == id);
        }

        public Genre GetGenre(string name)
        {
            return _dbContext.Genres.First(x => x.Name == name);
        }

        public Genre UpdateGenre(int id, Genre genre)
        {
            var genreObject = _dbContext.Genres.Find(id);
            genreObject.Name = genre.Name;
            _dbContext.SaveChanges();
            return genre;

        }

        public void DeleteGenre(int id)
        {
            var genreObject = _dbContext.Genres.Find(id);
            _dbContext.Genres.Remove(genreObject);
            _dbContext.SaveChanges();
        }
    }
}