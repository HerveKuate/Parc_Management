using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parc_Management
{
    public abstract class Attraction
    {
        private int identifiant;
        private string nom;
        private int nombre_monstre;
        private bool besoinspecifique;
        private string typedebesoin;

        private double fil_dattente;
        private bool ouverte_ferme;
        private int nombre_entrees;

        public int Identifiant
        {
            get
            {
                return identifiant;
            }

            set
            {
                identifiant = value;
            }
        }

        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        }

        public int Nombre_monstre
        {
            get
            {
                return nombre_monstre;
            }

            set
            {
                nombre_monstre = value;
            }
        }

        public bool Besoinspecifique
        {
            get
            {
                return besoinspecifique;
            }

            set
            {
                besoinspecifique = value;
            }
        }

        public string Typedebesoin
        {
            get
            {
                return typedebesoin;
            }

            set
            {
                typedebesoin = value;
            }
        }

        public double Fil_dattente
        {
            get
            {
                return fil_dattente;
            }

            set
            {
                fil_dattente = value;
            }
        }

        public bool Ouverte_ferme
        {
            get
            {
                return ouverte_ferme;
            }

            set
            {
                ouverte_ferme = value;
            }
        }

        public int Nombre_entrees
        {
            get
            {
                return nombre_entrees;
            }

            set
            {
                nombre_entrees = value;
            }
        }

        public Attraction(int _identifiant, string _nom, int _nombre_monstre, bool _besoinspecifique, string _typedebesoin)
        {
            Identifiant = _identifiant;
            Nom = _nom;
            Nombre_monstre= _nombre_monstre;
            Besoinspecifique = _besoinspecifique;
            Typedebesoin = _typedebesoin;


        }

        public virtual void update(int type, string property) {
            switch (type) { 
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

        public override string ToString()
        {
            return this.GetType().Name+"   Matricule: " + Identifiant + "Nom : " + Nom+"  Monstre : "+nombre_monstre+" Besoin spécifique :"+besoinspecifique+" Type de besoin: "+typedebesoin;
        }

        

    }
}