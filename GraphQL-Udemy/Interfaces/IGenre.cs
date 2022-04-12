using System.Collections.Generic;
using GraphQL_Udemy.Models;

namespace GraphQL_Udemy.Interfaces
{
    public interface IGenre
    {
        //Create
        Genre AddGenre(Genre genre);
        
        //Read
        List<Genre> GetGenres();

        Genre GetGenre(int id);

        Genre GetGenre(string name);
        
        //Update
        Genre UpdateGenre(int id, Genre genre);
        
        //Delete
        void DeleteGenre(int id);
    }
}