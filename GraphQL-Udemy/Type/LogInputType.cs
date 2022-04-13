using GraphQL.Types;

namespace GraphQL_Udemy.Type
{
    public class LogInputType : InputObjectGraphType
    {
        public LogInputType()
        {
            Field<IntGraphType>("id");
            Field<DateTimeGraphType>("datetime");
            Field<StringGraphType>("message");
        }
    }
}