using System;
using System.Collections.Generic;
using System.Text;

namespace HL.MyAirport.EF
{
  
        public class Bagage
        {
            public int BagageId { get; set; }
            public int? VolId { get; set; }
            public string CodeIATA { get; set; }
            public DateTime DateCreation { get; set; }
            public string Classe { get; set; }
            public bool Prioritaire { get; set; }
            public string Sta { get; set; }
            public string Ssur { get; set; }
            public string Destination { get; set; }
            public string Escale { get; set; }
            //public Vol vol { get; set; }

        public Bagage()
        {
           
        }
        public Bagage(string CodeIATA, DateTime dateCreation)
        {
            CodeIATA = CodeIATA;
            DateCreation = dateCreation;
        }
        public virtual Vol? Vol { get; set; }
    }


    
}
