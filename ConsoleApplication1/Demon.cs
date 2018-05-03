using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parc_Management
{
    public class Demon : Monstre
    {
        private int force;

        public Demon(string _nom, string _prenom, int _sexe, string _fonction, int _matricule, bool _licenciement, int _cagnotte, int _force, string _affectation) : base(_nom, _prenom, _sexe, _fonction, _matricule, _licenciement, _cagnotte, _affectation)
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
            force = _force;


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
                case 3:
                    this.Cagnotte = Int32.Parse(property);
                    break;
                case 4:
                    this.force = Int32.Parse(property);
                    break;
                case 5:
                    this.Affectation = Int32.Parse(property);
                    break;
            }
        }

        public int getForce()
        {
            return this.force;
        }
    }
}