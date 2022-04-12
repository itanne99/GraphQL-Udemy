using GraphQL;
using GraphQL.Types;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Models;
using GraphQL_Udemy.Type;

namespace GraphQL_Udemy.Mutation
{
    public class ArtistMutation : ObjectGraphType
    {
        public ArtistMutation(IArtist artistService)
        {
            Field<ArtistType>("createArtist",
                arguments: new QueryArguments(new QueryArgument<ArtistInputType> {Name = "artist"}),
                resolve: context =>
                {
                    return artistService.CreateArtist(context.GetArgument<Artist>("artist"));
                });
            
            Field<ArtistType>("updateArtist", arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}, new QueryArgument<ArtistInputType> {Name = "artist"}),
                resolve: context => { return artistService.UpdateArtist(context.GetArgument<int>("id"), context.GetArgument<Artist>("artist")); });
            
            Field<StringGraphType>("deleteArtist", arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context =>
                {
                    var artistId = context.GetArgument<int>("id");
                    artistService.DeleteArtist(artistId);
                    return $"Deleted Artist @ id:{artistId}";
                });
        }
    }
}