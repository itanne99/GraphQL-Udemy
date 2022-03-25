using GraphQL.Types;
using GraphQL_Udemy.Models;

namespace GraphQL_Udemy.Type
{
    public class SongType : ObjectGraphType<Song>
    {
        public SongType()
        {
            Field(g => g.Id);
            Field(g => g.Name);
            //Add Artist
            //Add Album
            //Add Genre
        }
    }
}