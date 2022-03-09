using System.Collections.Generic;
using GraphQL_Udemy.Models;

namespace GraphQL_Udemy.Interfaces
{
    public interface IProduct
    {
        List<Product> GetAllProducts();
        
        Product AddProduct(Product product);
        
        Product UpdateProduct(int id, Product product);

        void DeleteProduct(int id);

        Product GetProductById(int id);
    }
}