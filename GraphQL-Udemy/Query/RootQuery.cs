using GraphQL.Types;

namespace GraphQL_Udemy.Query
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery()
        {
            
            Field<GenreQuery>("genreQuery", resolve: context => new { });
            Field<ArtistQuery>("artistQuery", resolve: context => new { });
            Field<AlbumQuery>("albumQuery", resolve: context => new { });
            Field<SongQuery>("songQuery", resolve: context => new { });
        }
        
    }
}