using System.Collections.Generic;
using GraphQL_Udemy.Models;

namespace GraphQL_Udemy.Interfaces
{
    public interface IAlbum
    {
        //Create
        Album CreateAlbum(Album album);

        //Read
        List<Album> GetAlbums();

        Album GetAlbum(int id);

        Album GetAlbum(string name);
        
        List<Album> GetAlbumsByArtist(int id);

        List<Song> GetSongsFromAlbum(int id);
        List<Song> GetSongsFromAlbum(string name);
        
        List<Album> GetAlbumsByYear(int year);

        //Update
        Album UpdateAlbum(int id, Album album);

        //Delete
        void DeleteAlbum(int id);
    }
}