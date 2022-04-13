using GraphQL;
using GraphQL.Types;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Models;
using GraphQL_Udemy.Type;

namespace GraphQL_Udemy.Mutation
{
    public class GenreMutation : ObjectGraphType
    {
        private ILog logger;
        public GenreMutation(IGenre genreService, ILog logger)
        {
            this.logger = logger;
            Field<GenreType>("createGenre",
                arguments: new QueryArguments(new QueryArgument<GenreInputType> {Name = "genre"}),
                resolve: context =>
                {
                    logger.CreateLog($"Added Genre {context.GetArgument<Genre>("genre")}");
                    return genreService.AddGenre(context.GetArgument<Genre>("genre"));
                });
            
            Field<GenreType>("updateGenre", arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}, new QueryArgument<GenreInputType> {Name = "genre"}),
                resolve: context =>
                {
                    logger.CreateLog($"Updated genere @ id:{context.GetArgument<int>("id")}");
                    return genreService.UpdateGenre(context.GetArgument<int>("id"), context.GetArgument<Genre>("genre"));
                });
            
            Field<StringGraphType>("deleteGenre", arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context =>
                {
                    var genreId = context.GetArgument<int>("id");
                    genreService.DeleteGenre(genreId);
                    logger.CreateLog($"Deleted Genre @ id:{genreId}");
                    return $"Deleted Genre @ id:{genreId}";
                });
        }
    }
}