using System.Collections.Generic;

namespace GraphQL_Udemy.Models
{
    public class Menu
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageURL { get; set; }

        public ICollection<SubMenu> SubMenus { get; set; } // Creates a one-to-many relationship
        
    }
}

// TODO: REMOVE