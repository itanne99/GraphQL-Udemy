using GraphQL.Types;

namespace GraphQL_Udemy.Type
{
    public class SongInputType : InputObjectGraphType
    {
        public SongInputType()
        {
            Field<IntGraphType>("id");
            Field<StringGraphType>("name");
        }
    }
}
