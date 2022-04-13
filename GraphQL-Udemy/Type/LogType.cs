using GraphQL.Types;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Models;

namespace GraphQL_Udemy.Type
{
    public class LogType : ObjectGraphType<Log>
    {
        public LogType(ILog logService)
        {
            Field(l => l.Id);
            Field(l => l.DateTime);
            Field(l => l.Message);
            
        }

    }
}