﻿using System.Collections.Generic;
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
        

        //Update
        Album UpdateAlbum(int id, Album album);

        //Delete
        void DeleteAlbum(int id);
    }
}