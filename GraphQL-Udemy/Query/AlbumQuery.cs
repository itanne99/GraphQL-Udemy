using GraphQL;
using GraphQL.Types;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Type;

namespace GraphQL_Udemy.Query
{
    public class AlbumQuery : ObjectGraphType
    {
        ILog logger;
        public AlbumQuery(IAlbum albumService, ILog logger)
        {
            this.logger = logger;
            
            //Get all
            Field<ListGraphType<AlbumType>>("albums",
                resolve: context =>
                {
                    logger.CreateLog("Got List of all albums");
                    return albumService.GetAlbums();
                });

            //Get by ID
            Field<AlbumType>("albumById",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context =>
                {
                    logger.CreateLog($"Got Album @ id:{context.GetArgument<int>("id")}");
                    return albumService.GetAlbum(context.GetArgument<int>("id"));
                });
            
            //Get by Name
            Field<AlbumType>("albumByName",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> {Name = "name"}),
                resolve: context =>
                {
                    logger.CreateLog($"Got Album @ name:{context.GetArgument<string>("name")}");
                    return albumService.GetAlbum(context.GetArgument<string>("name"));
                });
            
            //Get by Year
            Field<ListGraphType<AlbumType>>("albumByYear",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "year"}),
                resolve: context =>
                {
                    logger.CreateLog($"Got album @ year:{context.GetArgument<int>("year")}");
                    return albumService.GetAlbumsByYear(context.GetArgument<int>("year"));
                });
            
        }
    }
}