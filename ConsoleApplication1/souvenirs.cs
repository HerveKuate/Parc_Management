using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parc_Management
{
    public class souvenirs : Boutique
    {
        public souvenirs(int _identifiant, string _nom, int _nombre_monstre, bool _besoinspecifique, string _typedebesoin, int _type) : base( _identifiant,  _nom,  _nombre_monstre,  _besoinspecifique,  _typedebesoin, _type)
        {
            Identifiant = _identifiant;
            Nom = _nom;
            Nombre_monstre = _nombre_monstre;
            Besoinspecifique = _besoinspecifique;
            Typedebesoin = _typedebesoin;
            type = _type;
        }
    }
}