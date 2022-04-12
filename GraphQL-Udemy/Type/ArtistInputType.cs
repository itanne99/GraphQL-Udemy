using GraphQL.Types;

namespace GraphQL_Udemy.Type
{
    public class ArtistInputType : InputObjectGraphType
    {
        public ArtistInputType()
        {
            Field<IntGraphType>("id");
            Field<StringGraphType>("name");
        }
    }
}
