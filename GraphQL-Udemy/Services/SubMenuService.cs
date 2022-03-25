using System.Collections.Generic;
using System.Linq;
using GraphQL_Udemy.Data;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Models;

namespace GraphQL_Udemy.Services
{
    public class SubMenuService : ISubMenu
    {
        private GraphQLDbContext _dbContext;

        public SubMenuService(GraphQLDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public List<SubMenu> GetSubMenus()
        {
            return _dbContext.SubMenus.ToList();
        }

        public List<SubMenu> GetSubMenus(int menuId)
        {
            return _dbContext.SubMenus.Where(m => m.Id == menuId).ToList();
        }

        public SubMenu AddSubMenu(SubMenu subMenu)
        {
            _dbContext.SubMenus.Add(subMenu);
            _dbContext.SaveChanges();
            return subMenu;
        }
    }
}