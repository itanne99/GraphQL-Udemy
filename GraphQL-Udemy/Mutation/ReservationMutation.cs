using GraphQL;
using GraphQL.Types;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Models;
using GraphQL_Udemy.Type;

namespace GraphQL_Udemy.Mutation
{
    public class ReservationMutation : ObjectGraphType
    {
        public ReservationMutation(IReservation reservationService)
        {
            Field<ReservationType>("createReservation",
                arguments: new QueryArguments(new QueryArgument<ReservationInputType> {Name = "reservation"}),
                resolve: context =>
                {
                    return reservationService.AddReservation(context.GetArgument<Reservation>("reservation"));
                });
        }
    }
}