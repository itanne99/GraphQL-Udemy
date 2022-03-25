using System.Collections.Generic;
using GraphQL_Udemy.Models;

namespace GraphQL_Udemy.Interfaces
{
    public interface ISubMenu
    {
        List<SubMenu> GetSubMenus();
        
        List<SubMenu> GetSubMenus(int menuId);

        SubMenu AddSubMenu(SubMenu subMenu);
    }
}

// TODO: REMOVE