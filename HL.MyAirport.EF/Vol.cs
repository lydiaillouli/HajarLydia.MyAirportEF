using System;
using System.Collections.Generic;
using System.Text;

namespace HL.MyAirport.EF
{
    /// <summary>
    /// Classe représentant les Vols 
    /// </summary>
    public class Vol
    {
        /// <summary>
        /// CLés primaire de ma classe Vol
        /// </summary>
        public int VolId { get; set; }
        /// <summary>
        /// Num de ligne du Vol
        /// </summary>
        public string Ligne { get; set; }
        /// <summary>
        /// Compagnie du vol
        /// </summary>
        public string Compagnie { get; set; }
        /// <summary>
        /// DErnier horaire connu, horaire du départ du vol
        /// </summary>
        public DateTime Dhc { get; set; }
        /// <summary>
        /// Nombre de passagers dans le vol
        /// </summary>
        public short? NbPassgers { get; set; }
        public string Parking { get; set; }
        /// <summary>
        /// Numéro d'immatriculation de l'avion 
        /// </summary>
        public string Immatriculation { get; set; }
        /// <summary>
        /// Ville de destination final du vol 
        /// </summary>
        public string Destination { get; set; }
        /// <summary>
        /// Propriétés de naviguation
        /// </summary>
        public IEnumerable<Bagage> Bagages { get; set; }
        //Je veux ma liste des vols avec ou sans la liste des bagages
        /// <summary>
        /// Constructeur d'une instance Vol
        /// </summary>
        /// <param name="compagnie">Nom sur 3char de la compagnie</param>
        /// <param name="ligne"></param>
        /// <param name="dhc"></param>
        public Vol(string compagnie, string ligne, DateTime dhc)
        {
            Compagnie = compagnie;
            Ligne = ligne;
            Dhc = dhc;
 //           Bagages = null; // new List<Bagage>();
        }
        public Vol()
        {

        }
        

        
}
}
