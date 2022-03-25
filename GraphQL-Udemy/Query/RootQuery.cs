using GraphQL.Types;

namespace GraphQL_Udemy.Query
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery()
        {
            Field<MenuQuery>("menuQuery", resolve: context => new { }); // TODO: REMOVE
            Field<SubMenuQuery>("subMenuQuery", resolve: context => new { }); // TODO: REMOVE
            Field<ReservationQuery>("reservationQuery", resolve: context => new { }); // TODO: REMOVE
            Field<GenreQuery>("genreQuery", resolve: context => new { });
            Field<ArtistQuery>("artistQuery", resolve: context => new { });
            Field<AlbumQuery>("albumQuery", resolve: context => new { });
            Field<SongQuery>("songQuery", resolve: context => new { });
        }
        
    }
}