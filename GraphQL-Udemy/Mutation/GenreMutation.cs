using GraphQL;
using GraphQL.Types;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Models;
using GraphQL_Udemy.Type;

namespace GraphQL_Udemy.Mutation
{
    public class GenreMutation : ObjectGraphType
    {
        public GenreMutation(IGenre genreService)
        {
            Field<GenreType>("createGenre",
                arguments: new QueryArguments(new QueryArgument<GenreInputType> {Name = "genre"}),
                resolve: context =>
                {
                    return genreService.AddGenre(context.GetArgument<Genre>("genre"));
                });
            
            Field<GenreType>("updateGenre", arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}, new QueryArgument<GenreInputType> {Name = "genre"}),
                resolve: context => { return genreService.UpdateGenre(context.GetArgument<int>("id"), context.GetArgument<Genre>("genre")); });
            
            Field<StringGraphType>("deleteGenre", arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context =>
                {
                    var genreId = context.GetArgument<int>("id");
                    genreService.DeleteGenre(genreId);
                    return $"Deleted Genre @ id:{genreId}";
                });
        }
    }
}