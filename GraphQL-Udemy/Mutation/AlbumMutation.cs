using GraphQL;
using GraphQL.Types;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Models;
using GraphQL_Udemy.Type;

namespace GraphQL_Udemy.Mutation
{
    public class AlbumMutation : ObjectGraphType
    {
        private ILog logger;
        public AlbumMutation(IAlbum albumService, ILog logger)
        {
            this.logger = logger;
            Field<AlbumType>("createAlbum",
                arguments: new QueryArguments(new QueryArgument<AlbumInputType> {Name = "album"}),
                resolve: context =>
                {
                    logger.CreateLog($"Added {context.GetArgument<Album>("album")} to db");
                    return albumService.CreateAlbum(context.GetArgument<Album>("album"));
                });
            
            Field<AlbumType>("updateAlbum", arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}, new QueryArgument<AlbumInputType> {Name = "album"}),
                resolve: context =>
                {
                    logger.CreateLog($"Updated album from @ id:{context.GetArgument<int>("id")}");
                    return albumService.UpdateAlbum(context.GetArgument<int>("id"), context.GetArgument<Album>("album"));
                });
            
            Field<StringGraphType>("deleteAlbum", arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context =>
                {
                    var albumId = context.GetArgument<int>("id");
                    albumService.DeleteAlbum(albumId);
                    logger.CreateLog($"Deleted Album @ id:{albumId}");
                    return $"Deleted Album @ id:{albumId}";
                });
        }
    }
}