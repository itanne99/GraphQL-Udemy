using GraphQL;
using GraphQL.Types;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Models;
using GraphQL_Udemy.Type;

namespace GraphQL_Udemy.Mutation
{
    public class MenuMutation : ObjectGraphType
    {
        public MenuMutation(IMenu menuService)
        {
            Field<MenuType>("createMenu",
                arguments: new QueryArguments(new QueryArgument<MenuInputType> {Name = "menu"}),
                resolve: context =>
                {
                    return menuService.AddMenu(context.GetArgument<Menu>("menu"));
                });
        }
    }
}