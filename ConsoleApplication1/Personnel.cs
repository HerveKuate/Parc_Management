using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parc_Management
{
    public class Personnel
    {
        private string fonction;
        private int matricule;
        public string nom;
        private string prenom;
        private int sexe;
        private bool licenciement;

        public string Fonction
        {
            get
            {
                return fonction;
            }

            set
            {
                fonction = value;
            }
        }

        public int Matricule
        {
            get
            {
                return matricule;
            }

            set
            {
                matricule = value;
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

        public string Prenom
        {
            get
            {
                return prenom;
            }

            set
            {
                prenom = value;
            }
        }

        public int Sexe
        {
            get
            {
                return sexe;
            }

            set
            {
                sexe = value;
            }
        }

        protected bool Licenciement
        {
            get
            {
                return licenciement;
            }

            set
            {
                licenciement = value;
            }
        }

        public Personnel(string _nom, string _prenom, int _sexe, string _fonction, int _matricule, bool _licenciement)
        {
            Nom = _nom;
            Fonction = _fonction;
            Prenom = _prenom;
            Sexe = _sexe;
            Fonction = _fonction;
            Matricule = _matricule;
            Licenciement = _licenciement;
            Matricule = _matricule;
        }

        public virtual void update(int type, string property)
        {
            switch (type)
            {
                case 1:
                    this.Fonction = property;
                    break;
                case 2:
                    if (property == "o") this.Licenciement = true; else this.Licenciement = false;

                    break;
                
            }
        }

        public void ajouter(string nom, string prenom, char sexe)
        {

            throw new System.NotImplementedException();
        }

        public void retirer()
        {
            throw new System.NotImplementedException();
        }
        public override string ToString()
        {
            return "Matricule: " + Matricule + "Nom : " + Nom+ "Prenom:"+Prenom+" Sexe:"+Sexe+"fonction :"+Fonction;
        }

        public int getMatricule()
        {
            return this.matricule;
        }
    }
}