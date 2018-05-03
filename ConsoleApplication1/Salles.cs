using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parc_Management
{
    public class Salles
    {
        protected string nom;
        protected int nombre;
        private List<DateTime> horaire;



        public Salles(string _nom, int _nombre, string _horaire)
        {
            nom = _nom;
            nombre = _nombre;
            horaire = new List<DateTime>();

            var heure = _horaire.Split(' ');

            foreach (string output in heure)
            {
                horaire.Add(DateTime.ParseExact(output, "HH:mm", null));
            }
        }
    }
}