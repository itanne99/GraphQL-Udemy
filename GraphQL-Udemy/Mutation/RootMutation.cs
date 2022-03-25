using GraphQL.Types;

namespace GraphQL_Udemy.Mutation
{
    public class RootMutation : ObjectGraphType
    {
        public RootMutation()
        {
            Field<MenuMutation>("menuMutation", resolve: context => new { }); // TODO: REMOVE
            Field<SubMenuMutation>("subMenuMutation", resolve: context => new { }); // TODO: REMOVE
            Field<ReservationMutation>("reservationMutation", resolve: context => new { }); // TODO: REMOVE
        }
    }
}