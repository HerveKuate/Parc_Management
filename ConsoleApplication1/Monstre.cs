using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parc_Management
{
    public class Monstre : Personnel
    {

        private int cagnotte;
        private int affectation;

        public int Affectation
        {
            get
            {
                return affectation;
            }

            set
            {
                affectation = value;
            }
        }

        public int Cagnotte
        {
            get
            {
                return cagnotte;
            }

            set
            {
                cagnotte = value;
            }
        }

        public Monstre(string _nom, string _prenom, int _sexe, string _fonction, int _matricule, bool _licenciement, int _cagnotte, string _affectation) : base( _nom,  _prenom,  _sexe,  _fonction, _matricule,  _licenciement)
        {
            Nom = _nom;
            Fonction = _fonction;
            Prenom = _prenom;
            Sexe = _sexe;
            Fonction = _fonction;
            Matricule = _matricule;
            Licenciement = _licenciement;
            Matricule = _matricule;
            Cagnotte = _cagnotte;

            switch (_affectation) {
                case "":
                    Affectation = -1;
                    break;
                case "neant":
                    Affectation = -2;
                    break;
                case "parc":
                    Affectation = 0;
                    break;
                default:
                    Affectation = Int32.Parse(_affectation);
                    break;
            };
            
        }
        public override void update(int type, string property)
        {
            switch (type)
            {
                case 1:
                    this.Fonction = property;
                    break;
                case 2:
                    if (property == "o") this.Licenciement = true; else this.Licenciement = false;

                    break;
                case 3: //cagnote
                    this.Cagnotte = Int32.Parse(property);
                    break;
                case 4://affectation
                    this.Affectation = Int32.Parse(property);
                    break;


            }
        }


        public void incrementer()
        {
            throw new System.NotImplementedException();
        }

        public void decrementer()
        {
            throw new System.NotImplementedException();
        }

        public void setAffectation(string _affectation)
        {
            switch (_affectation)
            {
                case "":
                    Affectation = -1;
                    break;
                case "neant":
                    Affectation = -2;
                    break;
                case "parc":
                    Affectation = 0;
                    break;
                default:
                    Affectation = Int32.Parse(_affectation);
                    break;
            };
        }
        public int getCagnotte()
        {
            return this.Cagnotte;
        }
        public void setCagnotte(int _cagnotte)
        { this.Cagnotte = _cagnotte; }

        public override string ToString()
        {
            return "Matricule: " + Matricule + " Nom : " + Nom + " Prenom:" + Prenom + " Sexe:" + Sexe + "\nfonction :" + Fonction+" Cagnotte :"+ Cagnotte;
        }
    }
}