using System.Collections.Generic;

namespace GraphQL_Udemy.Models
{
    public class Artist
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public ICollection<Song> Songs { get; set; }
        
        public ICollection<Album> Albums { get; set; }
    }
}