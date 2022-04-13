using GraphQL;
using GraphQL.Types;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Type;

namespace GraphQL_Udemy.Query
{
    public class ArtistQuery : ObjectGraphType
    {
        ILog logger;
        public ArtistQuery(IArtist artistService, ILog logger)
        {
            this.logger = logger;
            
            //Get all
            Field<ListGraphType<ArtistType>>("artists",
                resolve: context =>
                {
                    logger.CreateLog("Got list of all artists");
                    return artistService.GetArtists();
                });

            //Get by ID
            Field<ArtistType>("artistById",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context =>
                {
                    logger.CreateLog($"Got artist @ id:{context.GetArgument<int>("id")}");
                    return artistService.GetArtist(context.GetArgument<int>("id"));
                });
            
            //Get by Name
            Field<ArtistType>("artistByName",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> {Name = "name"}),
                resolve: context =>
                {
                    logger.CreateLog($"Got artist @ name:{context.GetArgument<string>("name")}");
                    return artistService.GetArtist(context.GetArgument<string>("name"));
                });
        }
    }
}