using System.Collections.Generic;
using System.Linq;
using GraphQL_Udemy.Data;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Models;

namespace GraphQL_Udemy.Services
{
    public class MenuService : IMenu
    {
        private GraphQLDbContext _dbContext;

        public MenuService(GraphQLDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Menu> GetMenus()
        {
            return _dbContext.Menus.ToList();
        }

        public Menu AddMenu(Menu menu)
        {
            _dbContext.Menus.Add(menu);
            _dbContext.SaveChanges();
            return menu;
        }
    }
}