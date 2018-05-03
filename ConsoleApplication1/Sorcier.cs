using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parc_Management
{
    public class Sorcier : Personnel
    {
        private int grade;
        private List<string> pouvoirs;

        public int Grade
        {
            get
            {
                return grade;
            }

            set
            {
                grade = value;
            }
        }

        public List<string> Pouvoirs
        {
            get
            {
                return pouvoirs;
            }

            set
            {
                pouvoirs = value;
            }
        }

        public Sorcier(string _nom, string _prenom, int _sexe, string _fonction, int _matricule, bool _licenciement, int _grade, string _pourvoirs) : base(_nom, _prenom, _sexe, _fonction, _matricule, _licenciement)
        {
            Nom = _nom;
            Fonction = _fonction;
            Prenom = _prenom;
            Sexe = _sexe;
            Fonction = _fonction;
            Matricule = _matricule;
            Licenciement = _licenciement;
            Matricule = _matricule;
            Grade = _grade;

            Pouvoirs = new List<string>();
            var pourvoir_full = _pourvoirs.Split('-');
            foreach (string output in pourvoir_full)
            {
                Pouvoirs.Add(output);
            }
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
                case 3: //grade
                    this.Grade = Int32.Parse( property);
                    break;
                case 4://pourvoir
                    Pouvoirs = new List<string>();
                    var pourvoir_full = property.Split('-');
                    foreach (string output in pourvoir_full)
                    {
                        Pouvoirs.Add(output);
                    }
                    break;


            }
        }

        public override string ToString()
        {

            return "Matricule: " + Matricule + "Nom : " + Nom + "Prenom:" + Prenom + " Sexe:" + Sexe + "fonction :" + Fonction+" Grade :"+ grade+" Pouvoir :"+ pouvoirs.ElementAt(0)+"   "+pouvoirs.ElementAt(1); ;
        }
        public int getGrade()
        {
            return this.Grade;
        }
    }
}