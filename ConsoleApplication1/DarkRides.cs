using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parc_Management
{
    public class DarkRides : Attraction
    {
        private double duree;
        private bool vehicule;

        public double Duree
        {
            get
            {
                return duree;
            }

            set
            {
                duree = value;
            }
        }

        public bool Vehicule
        {
            get
            {
                return vehicule;
            }

            set
            {
                vehicule = value;
            }
        }

        public DarkRides(int _identifiant, string _nom, int _nombre_monstre, bool _besoinspecifique, string _typedebesoin, double _duree, bool _vehicule) : base( _identifiant,  _nom,  _nombre_monstre,  _besoinspecifique,  _typedebesoin)
        {
            Identifiant = _identifiant;
            Nom = _nom;
            Nombre_monstre = _nombre_monstre;
            Besoinspecifique = _besoinspecifique;
            Typedebesoin = _typedebesoin;
            Duree = _duree;
            Vehicule = _vehicule;
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
                case 4:
                    this.Duree = Convert.ToDouble(property);
                    break;
                case 5:
                    if (property == "o") this.Vehicule = true; else this.Vehicule = false;
                    break;
            }
        }
    }
}