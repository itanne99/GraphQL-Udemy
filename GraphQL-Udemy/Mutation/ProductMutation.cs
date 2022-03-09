using GraphQL;
using GraphQL.Types;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Models;
using GraphQL_Udemy.Type;

namespace GraphQL_Udemy.Mutation
{
    public class ProductMutation : ObjectGraphType
    {
        public ProductMutation(IProduct productService)
        {
            Field<ProductType>("createProduct", arguments: new QueryArguments(new QueryArgument<ProductInputType> {Name = "product"}),
                resolve: context => { return productService.AddProduct(context.GetArgument<Product>("product")); });
            
            Field<ProductType>("updateProduct", arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}, new QueryArgument<ProductInputType> {Name = "product"}),
                resolve: context => { return productService.UpdateProduct(context.GetArgument<int>("id"), context.GetArgument<Product>("product")); });
            
            Field<StringGraphType>("deleteProduct", arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context =>
                {
                    var productId = context.GetArgument<int>("id");
                    productService.DeleteProduct(productId);
                    return $"Deleted Product @ id:{productId}";
                });
            
        }
    }
}