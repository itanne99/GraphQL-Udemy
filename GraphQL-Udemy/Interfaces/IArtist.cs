using System.Collections.Generic;
using GraphQL_Udemy.Models;

namespace GraphQL_Udemy.Interfaces
{
    public interface IArtist
    {
        //Create
        Artist CreateArtist(Artist artist);
        

        //Read
        List<Artist> GetArtists();

        Artist GetArtist(int id);

        Artist GetArtist(string name);

        //Update
        Artist UpdateArtist(int id, Artist artist);

        //Delete
        void DeleteArtist(int id);

    }
}