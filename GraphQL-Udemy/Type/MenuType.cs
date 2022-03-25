using GraphQL.Types;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Models;

namespace GraphQL_Udemy.Type
{
    public class MenuType : ObjectGraphType<Menu>
    {
        public MenuType(ISubMenu subMenuService)
        {
            Field(m => m.Id);
            Field(m => m.Name);
            Field(m => m.ImageURL);
            Field<ListGraphType<SubMenuType>>("submenus",
                resolve: context => { return subMenuService.GetSubMenus(context.Source.Id); });
        }
    }
}