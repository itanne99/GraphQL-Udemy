using GraphQL_Udemy.Mutation;
using GraphQL_Udemy.Query;

namespace GraphQL_Udemy.Schema
{
    public class ProductSchema : GraphQL.Types.Schema
    {
        public ProductSchema(ProductQuery productQuery, ProductMutation productMutation)
        {
            Query = productQuery;
            Mutation = productMutation;
        }
    }
}