using GraphQL.Types;

namespace GraphQL_Udemy.Type
{
    public class AlbumInputType : InputObjectGraphType
    {
        public AlbumInputType()
        {
            Field<IntGraphType>("id");
            Field<StringGraphType>("name");
            Field<StringGraphType>("year");
        }
    }
}
