using System;
using GraphQL;
using GraphQL.Types;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Type;

namespace GraphQL_Udemy.Query
{
    public class LogQuery : ObjectGraphType
    {
        public LogQuery(ILog logService)
        {
            //Get All
            Field<ListGraphType<LogType>>("logs",
                resolve: context =>
                {
                    return logService.GetLogs();
                });

            //Get by ID
            Field<LogType>("logById",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context => { return logService.GetLog(context.GetArgument<int>("id")); }
            );

            //Get by DateTime
            Field<ListGraphType<LogType>>("logsByDateTime",
                arguments: new QueryArguments(new QueryArgument<DateTimeGraphType> {Name = "timestamp"}),
                resolve: context => { return logService.GetLogs(context.GetArgument<DateTime>("timestamp")); }
            );

        }
    }
}