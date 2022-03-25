using GraphQL.Types;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Models;

namespace GraphQL_Udemy.Type
{
    public class SongType : ObjectGraphType<Song>
    {
        public SongType(IArtist artistService, IAlbum albumService, IGenre genreService)
        {
            Field(g => g.Id);
            Field(g => g.Name);
            //Add Artist
            Field<ArtistType>("artist",
                resolve: context => { return artistService.GetArtist(context.Source.ArtistId); });
            //Add Album
            Field<AlbumType>("album",
                resolve: context => { return albumService.GetAlbum(context.Source.AlbumId); });
            //Add Genre
            Field<GenreType>("genre",
                resolve: context => { return genreService.GetGenre(context.Source.GenreId); });
        }
    }
}