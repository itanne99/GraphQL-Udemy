using GraphQL.Types;
using GraphQL_Udemy.Models;

namespace GraphQL_Udemy.Type
{
    public class ReservationType : ObjectGraphType<Reservation>
    {
        public ReservationType()
        {
            Field(m => m.Id);
            Field(m => m.Name);
            Field(m => m.Date);
            Field(m => m.Email);
            Field(m => m.Phone);
            Field(m => m.Time);
            Field(m => m.TotalPeople);
        }
    }
}

// TODO: REMOVE