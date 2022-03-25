using GraphQL.Types;
using GraphQL_Udemy.Models;

namespace GraphQL_Udemy.Type
{
    public class ArtistType : ObjectGraphType<Artist>
    {
        public ArtistType()
        {
            Field(g => g.Id);
            Field(g => g.Name);
            //Add Songs
            //Add Albums
        }
    }
}