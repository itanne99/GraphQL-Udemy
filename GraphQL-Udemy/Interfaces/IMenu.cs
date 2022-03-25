using System.Collections.Generic;
using GraphQL_Udemy.Models;

namespace GraphQL_Udemy.Interfaces
{
    public interface IMenu
    {
        List<Menu> GetMenus();

        Menu AddMenu(Menu menu);
    }
}