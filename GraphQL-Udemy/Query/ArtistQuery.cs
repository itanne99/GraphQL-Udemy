using GraphQL;
using GraphQL.Types;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Type;

namespace GraphQL_Udemy.Query
{
    public class ArtistQuery : ObjectGraphType
    {
        public ArtistQuery(IArtist artistService)
        {
            //Get all
            Field<ListGraphType<ArtistType>>("artists",
                resolve: context => { return artistService.GetArtists(); });

            //Get by ID
            Field<ArtistType>("artistById",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context => { return artistService.GetArtist(context.GetArgument<int>("id")); });
            
            //Get by Name
            Field<ArtistType>("artistByName",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> {Name = "name"}),
                resolve: context => { return artistService.GetArtist(context.GetArgument<string>("name")); });
        }
    }
}