using GraphQL.Types;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Models;

namespace GraphQL_Udemy.Type
{
    public class ArtistType : ObjectGraphType<Artist>
    {
        public ArtistType(ISong songService, IAlbum albumService)
        {
            Field(g => g.Id);
            Field(g => g.Name);
            //Add Songs
            Field<ListGraphType<SongType>>("songs",
                resolve: context => { return songService.GetSongByArtist(context.Source.Id);}
            );
            //Add Albums
            Field<ListGraphType<AlbumType>>("albums",
                resolve: context => { return albumService.GetAlbumsByArtist(context.Source.Id); }
                );
        }
    }
}