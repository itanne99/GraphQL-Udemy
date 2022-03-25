using GraphQL.Types;
using GraphQL_Udemy.Models;

namespace GraphQL_Udemy.Type
{
    public class AlbumType : ObjectGraphType<Album>
    {
        public AlbumType()
        {
            Field(g => g.Id);
            Field(g => g.Name);
            Field(g => g.Year);
            //Add Artist 
            //Add Songs
        }
    }
}