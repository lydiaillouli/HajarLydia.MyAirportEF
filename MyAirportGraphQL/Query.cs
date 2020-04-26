using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using HL.MyAirport.EF;
using MyAirport.GraphQL;

namespace MyAirportGraphQL
{
    public class AirportQuery : ObjectGraphType
    {
        public AirportQuery(MyAirportContext db)
        {
            Field<ListGraphType<BagageType>>(
                "bagages",
                resolve: context => db.Bagages.ToList());
        }
    }
}
