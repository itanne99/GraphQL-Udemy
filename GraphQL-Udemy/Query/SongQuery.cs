using GraphQL;
using GraphQL.Types;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Services;
using GraphQL_Udemy.Type;

namespace GraphQL_Udemy.Query
{
    public class SongQuery : ObjectGraphType
    {
        
        ILog logger;
        
        public SongQuery(ISong songService, ILog logger)
        {
            this.logger = logger;


            //Get all
            Field<ListGraphType<SongType>>("songs",
                resolve: context =>
                {
                    logger.CreateLog("Got List of Songs");
                    return songService.GetSongs();
                });

            //Get by ID
            Field<SongType>("songById",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context =>
                {
                    logger.CreateLog($"Got song @ id:{context.GetArgument<int>("id")}");
                    return songService.GetSong(context.GetArgument<int>("id"));
                });
            
            //Get by Name
            Field<SongType>("songByName",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> {Name = "name"}),
                resolve: context =>
                {
                    logger.CreateLog($"Got song @ name:{context.GetArgument<string>("name")}");
                    return songService.GetSong(context.GetArgument<string>("name"));
                });
        }
    }
}