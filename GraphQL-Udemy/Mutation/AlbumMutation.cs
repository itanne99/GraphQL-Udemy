using GraphQL;
using GraphQL.Types;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Models;
using GraphQL_Udemy.Type;

namespace GraphQL_Udemy.Mutation
{
    public class AlbumMutation : ObjectGraphType
    {
        public AlbumMutation(IAlbum albumService)
        {
            Field<AlbumType>("createAlbum",
                arguments: new QueryArguments(new QueryArgument<AlbumInputType> {Name = "album"}),
                resolve: context =>
                {
                    return albumService.CreateAlbum(context.GetArgument<Album>("album"));
                });
            
            Field<AlbumType>("updateAlbum", arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}, new QueryArgument<AlbumInputType> {Name = "album"}),
                resolve: context => { return albumService.UpdateAlbum(context.GetArgument<int>("id"), context.GetArgument<Album>("album")); });
            
            Field<StringGraphType>("deleteAlbum", arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context =>
                {
                    var albumId = context.GetArgument<int>("id");
                    albumService.DeleteAlbum(albumId);
                    return $"Deleted Album @ id:{albumId}";
                });
        }
    }
}