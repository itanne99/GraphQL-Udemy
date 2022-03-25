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
        }
        
    }
}