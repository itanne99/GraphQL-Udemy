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

        Song GetSong(int id);

        Song GetSong(string name);

        List<Song> GetSongByArtist(int id);

        List<Song> GetSongByAlbum(int id);

        //Update
        Song UpdateSong(int id, Song song);

        //Delete
        void DeleteSong(int id);
    }
}