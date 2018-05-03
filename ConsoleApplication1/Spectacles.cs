using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parc_Management
{
    public class Spectacles : Attraction
    {
        private Salles salle;

        public Spectacles(int _identifiant, string _nom, int _nombre_monstre, bool _besoinspecifique, string _typedebesoin, string _nomsalle, int _nombreplace, string _horaire) : base( _identifiant,  _nom,  _nombre_monstre,  _besoinspecifique,  _typedebesoin)
        {
            Identifiant = _identifiant;
            Nom = _nom;
            Nombre_monstre = _nombre_monstre;
            Besoinspecifique = _besoinspecifique;
            Typedebesoin = _typedebesoin;
            Salle = new Salles(_nomsalle, _nombreplace,_horaire);
        }

        protected Salles Salle
        {
            get
            {
                return salle;
            }

            set
            {
                salle = value;
            }
        }

        public override void update(int type, string property)
        {
            switch (type)
            {
                case 1:
                    this.Nombre_monstre = Int32.Parse(property);
                    break;
                case 2:
                    if (property == "o") this.Besoinspecifique = true; else this.Besoinspecifique = false;

                    break;
                case 3:
                    this.Typedebesoin = property;
                    break;
                }
        }

    }
}