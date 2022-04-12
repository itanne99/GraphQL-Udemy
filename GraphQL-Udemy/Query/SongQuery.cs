using GraphQL;
using GraphQL.Types;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Type;

namespace GraphQL_Udemy.Query
{
    public class SongQuery : ObjectGraphType
    {
        public SongQuery(ISong songService)
        {
            //Get all
            Field<ListGraphType<SongType>>("songs",
                resolve: context => { return songService.GetSongs(); });

            //Get by ID
            Field<SongType>("songById",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context => { return songService.GetSong(context.GetArgument<int>("id")); });
            
            //Get by Name
            Field<SongType>("songByName",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> {Name = "name"}),
                resolve: context => { return songService.GetSong(context.GetArgument<string>("name")); });
        }
    }
}