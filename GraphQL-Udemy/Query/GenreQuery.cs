using GraphQL;
using GraphQL.Types;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Type;

namespace GraphQL_Udemy.Query
{
    public class GenreQuery : ObjectGraphType
    {
        public GenreQuery(IGenre genreService)
        {
            //Get all
            Field<ListGraphType<GenreType>>("genres",
                resolve: context => { return genreService.GetGenres(); });

            //Get by ID
            Field<GenreType>("genreById",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context => { return genreService.GetGenre(context.GetArgument<int>("id")); });
            
            //Get by Name
            Field<GenreType>("genreByName",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> {Name = "name"}),
                resolve: context => { return genreService.GetGenre(context.GetArgument<string>("name")); });
        }
    }
}