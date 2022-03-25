using System;
using GraphQL.Utilities;
using GraphQL_Udemy.Query;

namespace GraphQL_Udemy.Schema
{
    public class RootSchema : GraphQL.Types.Schema
    {
        public RootSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<RootQuery>();
        }
    }
}