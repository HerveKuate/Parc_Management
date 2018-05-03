using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parc_Management
{
    public class Squelette : Zombies
    {
        protected int[] decompositionlist = new int[10];
        
        public Squelette(string _nom, string _prenom, int _sexe, string _fonction, int _matricule, bool _licenciement, int _cagnotte, string _teint, int _decomposition, int[] _decompositionlist, string _affectation) : base( _nom,  _prenom,  _sexe,  _fonction,  _matricule,  _licenciement,  _cagnotte,   _teint,  _decomposition, _affectation)
        {
            
            decompositionlist = _decompositionlist;
        }
    }
}