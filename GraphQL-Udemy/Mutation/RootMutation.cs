using GraphQL.Types;

namespace GraphQL_Udemy.Mutation
{
    public class RootMutation : ObjectGraphType
    {
        public RootMutation()
        {
            
            Field<GenreMutation>("genreMutation", resolve: context => new { });
            Field<ArtistMutation>("artistMutation", resolve: context => new { });
            Field<AlbumMutation>("albumMutation", resolve: context => new { });
            Field<SongMutation>("songMutation", resolve: context => new { });
        }
    }
}