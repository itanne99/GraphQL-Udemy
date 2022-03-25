using System.Collections.Generic;
using GraphQL_Udemy.Models;

namespace GraphQL_Udemy.Interfaces
{
    public interface IReservation
    {
        List<Reservation> GetReservation();

        Reservation AddReservation(Reservation reservation);
    }
}

// TODO: REMOVE