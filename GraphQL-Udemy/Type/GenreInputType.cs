using GraphQL.Types;

namespace GraphQL_Udemy.Type
{
    public class GenreInputType : InputObjectGraphType
    {
        public GenreInputType()
        {
            Field<IntGraphType>("id");
            Field<StringGraphType>("name");
        }
    }
}
