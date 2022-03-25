using GraphQL;
using GraphQL.Types;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Type;

namespace GraphQL_Udemy.Query
{
    public class AlbumQuery : ObjectGraphType
    {
        public AlbumQuery(IAlbum albumService)
        {
            //Get all
            Field<ListGraphType<AlbumType>>("albums",
                resolve: context => { return albumService.GetAlbums(); });

            //Get by ID
            Field<AlbumType>("albumById",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context => { return albumService.GetAlbum(context.GetArgument<int>("id")); });
            
            //Get by Name
            Field<AlbumType>("albumByName",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> {Name = "name"}),
                resolve: context => { return albumService.GetAlbum(context.GetArgument<string>("name")); });
            
            //TODO: Get by Year
            
        }
    }
}