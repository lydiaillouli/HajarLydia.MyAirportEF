using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using HL.MyAirport.EF;

namespace MyAirportGraphQL.GraphQLType
{
    public class VolType : ObjectGraphType<Vol>
    {
        public VolType()
        {
            Field(x => x.Bagages);
            Field(x => x.Compagnie);
            Field(x => x.Destination);
            Field(x => x.Dhc);
            Field(x => x.Immatriculation);
            Field(x => x.Ligne);
            Field(x => x.NbPassgers);
            Field(x => x.Parking);
            Field(x => x.VolId);
        }
    }
}
