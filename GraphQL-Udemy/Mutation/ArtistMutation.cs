using GraphQL;
using GraphQL.Types;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Models;
using GraphQL_Udemy.Type;

namespace GraphQL_Udemy.Mutation
{
    public class ArtistMutation : ObjectGraphType
    {
        private ILog logger;
        public ArtistMutation(IArtist artistService, ILog logger)
        {
            this.logger = logger;
            Field<ArtistType>("createArtist",
                arguments: new QueryArguments(new QueryArgument<ArtistInputType> {Name = "artist"}),
                resolve: context =>
                {
                    logger.CreateLog($"Added artist @ {context.GetArgument<Artist>("artist")}");
                    return artistService.CreateArtist(context.GetArgument<Artist>("artist"));
                });
            
            Field<ArtistType>("updateArtist", arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}, new QueryArgument<ArtistInputType> {Name = "artist"}),
                resolve: context =>
                {
                    logger.CreateLog($"Updated artist @ id:{context.GetArgument<int>("id")}");
                    return artistService.UpdateArtist(context.GetArgument<int>("id"), context.GetArgument<Artist>("artist"));
                });
            
            Field<StringGraphType>("deleteArtist", arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context =>
                {
                    var artistId = context.GetArgument<int>("id");
                    artistService.DeleteArtist(artistId);
                    logger.CreateLog($"Deleted artist @ id:{context.GetArgument<int>("id")}");
                    return $"Deleted Artist @ id:{artistId}";
                });
        }
    }
}