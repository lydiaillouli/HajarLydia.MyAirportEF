using System;
using System.Collections.Generic;
using System.Text;

namespace HL.MyAirport.EF
{
    public class Vol
    {
        public int VolId { get; set; }
        public string Ligne { get; set; }
        public string Compagnie { get; set; }
        public DateTime Dhc { get; set; }
        public short? NbPassgers { get; set; }
        public string Parking { get; set; }
        public string Immatriculation { get; set; }
        public string Destination { get; set; }

        ///public IEnumerable<Bagage>? Bagages { get; set; }
        //Je veux ma liste des vols avec ou sans la liste des bagages
        public Vol(string compagnie, string ligne, DateTime dhc)
        {
            Compagnie = compagnie;
            Ligne = ligne;
            Dhc = dhc;
 //           Bagages = null; // new List<Bagage>();
        }
}
}
