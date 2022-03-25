using GraphQL.Types;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Models;

namespace GraphQL_Udemy.Type
{
    public class AlbumType : ObjectGraphType<Album>
    {
        public AlbumType(IArtist artistService, ISong songService)
        {
            Field(g => g.Id);
            Field(g => g.Name);
            Field(g => g.Year);
            Field<ListGraphType<ArtistType>>("artists",
                resolve: context => { return artistService.GetArtists(); }); 
            Field<ListGraphType<SongType>>("songs",
                resolve: context => { return songService.GetSongs(context.Source.Id); });
        }
    }
}