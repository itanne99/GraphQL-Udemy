using GraphQL.Types;
using GraphQL_Udemy.Models;

namespace GraphQL_Udemy.Type
{
    public class MenuType : ObjectGraphType<Menu>
    {
        public MenuType()
        {
            Field(m => m.Id);
            Field(m => m.Name);
            Field(m => m.ImageURL);
            // Note we do not add the One-to-Many column
        }
    }
}