using GraphQL.Types;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Models;

namespace GraphQL_Udemy.Type
{
    public class AlbumType : ObjectGraphType<Album>
    {
        public AlbumType(IArtist artistService,ISong songService)
        {
            Field(g => g.Id);
            Field(g => g.Name);
            Field(g => g.Year);
            //Add Artist
            Field<ArtistType>("artist",
                resolve: context => { return artistService.GetArtist(context.Source.ArtistId); });
            //Add Songs
            Field<ListGraphType<SongType>>("songs",
                resolve: context => { return songService.GetSongByAlbum(context.Source.Id); });
        }
    }
}