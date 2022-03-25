using GraphQL.Types;
using GraphQL_Udemy.Models;

namespace GraphQL_Udemy.Type
{
    public class GenreType : ObjectGraphType<Genre>
    {
        public GenreType()
        {
            Field(g => g.Id);
            Field(g => g.Name);
        }
    }
}