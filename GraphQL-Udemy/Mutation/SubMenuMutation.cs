using GraphQL;
using GraphQL.Types;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Models;
using GraphQL_Udemy.Type;

namespace GraphQL_Udemy.Mutation
{
    public class SubMenuMutation : ObjectGraphType
    {
        public SubMenuMutation(ISubMenu subMenuService)
        {
            Field<SubMenuType>("createSubMenu",
                arguments: new QueryArguments(new QueryArgument<SubMenuInputType> {Name = "subMenu"}),
                resolve: context =>
                {
                    return subMenuService.AddSubMenu(context.GetArgument<SubMenu>("subMenu"));
                });
        }
    }
}