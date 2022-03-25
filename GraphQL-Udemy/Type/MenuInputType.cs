using GraphQL.Types;

namespace GraphQL_Udemy.Type
{
    public class MenuInputType : InputObjectGraphType
    {
        public MenuInputType()
        {
            Field<IntGraphType>("id");
            Field<StringGraphType>("name");
            Field<StringGraphType>("imageURL");
        }
    }
}

// TODO: REMOVE