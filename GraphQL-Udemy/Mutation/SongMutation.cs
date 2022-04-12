using GraphQL;
using GraphQL.Types;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Models;
using GraphQL_Udemy.Type;

namespace GraphQL_Udemy.Mutation
{
    public class SongMutation : ObjectGraphType
    {
        public SongMutation(ISong songService)
        {
            Field<SongType>("createSong",
                arguments: new QueryArguments(new QueryArgument<SongInputType> {Name = "song"}),
                resolve: context =>
                {
                    return songService.CreateSong(context.GetArgument<Song>("song"));
                });
            
            Field<SongType>("updateSong", arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}, new QueryArgument<SongInputType> {Name = "song"}),
                resolve: context => { return songService.UpdateSong(context.GetArgument<int>("id"), context.GetArgument<Song>("song")); });
            
            Field<StringGraphType>("deleteSong", arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context =>
                {
                    var songId = context.GetArgument<int>("id");
                    songService.DeleteSong(songId);
                    return $"Deleted Song @ id:{songId}";
                });
        }
    }
}