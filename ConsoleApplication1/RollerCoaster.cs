using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parc_Management
{
    public class RollerCoaster : Attraction
    {
        private int categorie;
        private int age_mininum;
        private double taille_minimun;

        public int Categorie
        {
            get
            {
                return categorie;
            }

            set
            {
                categorie = value;
            }
        }

        public int Age_mininum
        {
            get
            {
                return age_mininum;
            }

            set
            {
                age_mininum = value;
            }
        }

        public double Taille_minimun
        {
            get
            {
                return taille_minimun;
            }

            set
            {
                taille_minimun = value;
            }
        }

        public RollerCoaster(int _identifiant, string _nom, int _nombre_monstre, bool _besoinspecifique, string _typedebesoin, int _categorie, int _age_minimum, double _taille_minimun) : base(_identifiant, _nom, _nombre_monstre, _besoinspecifique, _typedebesoin)
        {
            Identifiant = _identifiant;
            Nom = _nom;
            Nombre_monstre = _nombre_monstre;
            Besoinspecifique = _besoinspecifique;
            Typedebesoin = _typedebesoin;
            Taille_minimun = _taille_minimun;
            Age_mininum = _age_minimum;
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