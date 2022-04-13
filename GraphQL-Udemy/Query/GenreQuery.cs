using GraphQL;
using GraphQL.Types;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Type;

namespace GraphQL_Udemy.Query
{
    public class GenreQuery : ObjectGraphType
    {
        ILog logger;
        public GenreQuery(IGenre genreService, ILog logger)
        {
            this.logger = logger;
            
            //Get all
            Field<ListGraphType<GenreType>>("genres",
                resolve: context =>
                {
                    logger.CreateLog("Got List of Genres");
                    return genreService.GetGenres();
                });

            //Get by ID
            Field<GenreType>("genreById",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context =>
                {
                    logger.CreateLog($"Got genre @ id:{context.GetArgument<int>("id")}");
                    return genreService.GetGenre(context.GetArgument<int>("id"));
                });
            
            //Get by Name
            Field<GenreType>("genreByName",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> {Name = "name"}),
                resolve: context =>
                {
                    logger.CreateLog($"Got genre @ name:{context.GetArgument<string>("name")}");
                    return genreService.GetGenre(context.GetArgument<string>("name"));
                });
        }
    }
}