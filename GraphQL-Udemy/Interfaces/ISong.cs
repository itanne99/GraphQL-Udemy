using System.Collections.Generic;
using GraphQL_Udemy.Models;

namespace GraphQL_Udemy.Interfaces
{
    public interface ISong
    {
        //Create
        Song CreateSong(Song song);

        //Read
        List<Song> GetSongs();
        
        

        //Update

        //Delete
    }
}