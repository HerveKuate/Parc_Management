using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Parc_Management
{
    class main
    {
        private static List<Attraction> attractions = new List<Attraction>();
        private static List<Personnel> personnels = new List<Personnel>();
        private static List<Sorcier> sorciers = new List<Sorcier>();
        private static List<Monstre> monstres = new List<Monstre>();
        private static List<Demon> demons = new List<Demon>();
        private static List<fantome> fantomes = new List<fantome>();
        private static List<Loup_Garou> loupGarou = new List<Loup_Garou>();
        private static List<Vampire> vampire = new List<Vampire>();
        private static List<Zombies> zombies = new List<Zombies>();
        private static List<Barbe_a_papa> barbe_a_papa= new List<Barbe_a_papa>();
        private static List<Boutique> boutiques = new List<Boutique>();
        private static List<DarkRides> darkrides = new List<DarkRides>();
        private static List<RollerCoaster> rollerCoasters = new List<RollerCoaster>();
        private static List<Spectacles> spectacles = new List<Spectacles>();


        private static int choix, choix2, choix3, typePersonnel, var;
        private static double var2 = 0.0;

        private static Boolean boolean=false;
        private static string str = "";

        static void Menu()
        {
            int choix,value, type = 0;
            int identifiant;
            string property;
            Console.WriteLine("Que souhaitez vous faire? \n 1. Ajouter attractions-personnel 2. evoluer attractions-personnel 3.Recherche\n 4.Trie Element 5.modifier cagnotte\n0.Exit"); choix = Int32.Parse(Console.ReadLine());
            switch (choix)
            {
                case 1:
                    Console.WriteLine("1.Attraction 2. personnel"); choix = Int32.Parse(Console.ReadLine());
                    switch (choix)
                    {
                        case 1:
                            ajoutAttraction();
                            break;
                        case 2:
                            ajoutPersonnel();
                            break;
                        default:
                            ajoutAttraction();
                            break;
                    }

                    break;
                case 2:
                    evoluerAttractionPersonnel();
                    break;
                case 3:
                    rechercher();
                    break;
                case 4:
                    trierElement();
                    break;
                case 5:
                    modifierCagnotteMonstres();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;


            }
        }

        static void modifierCagnotteMonstres()
        {
            Console.WriteLine("Voici la liste des monstres");
            foreach (Personnel input in Parc.personnel)
            {
                if (input.GetType() == typeof(Monstre))
                    personnels.Add(input);
            }
            foreach (Monstre input in personnels)
            {
                monstres.Add(input);
            }
            foreach (Monstre input in monstres)
            {
                Console.WriteLine(input);
            }
            Console.WriteLine("Entrer le matricule du monstre concerné");
            choix2 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Entrer la valeur de la nouvelle cagnotte");
            choix = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < Parc.personnel.Count; i++)
            {
                if (Parc.personnel.ElementAt(i).getMatricule() == choix2)
                {
                    Monstre a = Parc.personnel.ElementAt(i) as Monstre;
                    a.setCagnotte(choix);
                    if (choix < 50)
                    {
                        Console.WriteLine("Ce monstre doit aussitot être viré dans une barbe à papa");
                        foreach (Attraction input in Parc.attractions)
                        {
                            if (input.GetType() == typeof(Barbe_a_papa))
                            {

                                attractions.Add(input);
                            }
                        }
                        foreach (Barbe_a_papa input2 in attractions)
                        {
                            Console.WriteLine(input2);
                        }
                        Console.WriteLine("Entrer le matricule de la barbe à papa à l'affecter");
                        choix3 = Int32.Parse(Console.ReadLine());
                        a.Affectation = choix3;
                    }
                }
                foreach (Monstre input in monstres)
                {
                    Console.WriteLine(input);
                }

            }
        }

        static void trierElement()
        {
            personnels.Clear();
            attractions.Clear();
            Console.WriteLine("Type du personnel");
            Console.WriteLine("1. Sorcier  2. Monstre 3.Demon 4. Fantome 5. LoupGarou 6. Vampire 7. Zombie");
            typePersonnel = Int32.Parse(Console.ReadLine());
            switch (typePersonnel)
            {
                case 1:
                    Console.WriteLine("Trie par grade");
                    Console.WriteLine("0. Novice 1.Mega 2.Giga 3.Strate ");
                    choix = Int32.Parse(Console.ReadLine());
                    foreach (Personnel input in Parc.personnel)
                    {
                        if (input.GetType() == typeof(Sorcier))
                            personnels.Add(input);
                    }
                    foreach (Sorcier input in personnels)
                    {
                        if (input.getGrade() == choix)
                            sorciers.Add(input);
                    }
                    foreach (Sorcier input in sorciers)
                    {
                        Console.WriteLine(input);
                    }
                    break;

                case 2:
                    Console.WriteLine("Trie par Cagnotte");
                    Console.WriteLine("1. Cagnotte supérieur ");
                    Console.WriteLine("2. Cagnotte inférieur ");
                    choix2 = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("2. Valeur cagnotte ");
                    choix = Int32.Parse(Console.ReadLine());
                    switch (choix2)
                    {
                        case 1:
                            foreach (Personnel input in Parc.personnel)
                            {
                                if (input.GetType() == typeof(Monstre))
                                    personnels.Add(input);
                            }
                            foreach (Monstre input in personnels)
                            {
                                if (input.getCagnotte() >= choix)
                                    monstres.Add(input);
                            }
                            foreach (Monstre input in monstres)
                            {
                                Console.WriteLine(input);
                            }
                            break;

                        case 2:
                            foreach (Personnel input in Parc.personnel)
                            {
                                if (input.GetType() ==typeof(Monstre))
                                    personnels.Add(input);
                            }
                            foreach (Monstre input in personnels)
                            {
                                if (input.getCagnotte() <= choix)
                                    monstres.Add(input);
                            }
                            foreach (Monstre input in monstres)
                            {
                                Console.WriteLine(input);
                            }
                            break;
                    }
                    break;

                case 3:
                    Console.WriteLine("1.Trie par Cagnotte  2.Trie par force");
                    choix3 = Int32.Parse(Console.ReadLine());
                    switch (choix3)
                    {
                        case 1:
                            Console.WriteLine("Trie par Cagnotte");
                            Console.WriteLine("1. Cagnotte supérieur ");
                            Console.WriteLine("2. Cagnotte inférieur ");
                            choix2 = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("2. Valeur cagnotte ");
                            choix = Int32.Parse(Console.ReadLine());
                            switch (choix2)
                            {
                                case 1:
                                    foreach (Personnel input in Parc.personnel)
                                    {
                                        if (input.GetType() == typeof(Demon))
                                            personnels.Add(input);
                                    }
                                    foreach (Demon input in personnels)
                                    {
                                        if (input.getCagnotte() >= choix)
                                            demons.Add(input);
                                    }
                                    foreach (Demon input in demons)
                                    {
                                        Console.WriteLine(input);
                                    }
                                    break;

                                case 2:
                                    foreach (Personnel input in Parc.personnel)
                                    {
                                        if (input.GetType() == typeof(Demon))
                                            personnels.Add(input);
                                    }
                                    foreach (Demon input in personnels)
                                    {
                                        if (input.getCagnotte() <= choix)
                                            demons.Add(input);
                                    }
                                    foreach (Demon input in demons)
                                    {
                                        Console.WriteLine(input);
                                    }
                                    break;
                            }
                            break;


                        case 2:
                            Console.WriteLine("Trie par force");
                            Console.WriteLine("1. force supérieur ");
                            Console.WriteLine("2. force inférieur ");
                            choix2 = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("2. Valeur force ");
                            choix = Int32.Parse(Console.ReadLine());
                            switch (choix2)
                            {
                                case 1:
                                    foreach (Personnel input in Parc.personnel)
                                    {
                                        if (input.GetType() == typeof(Demon))
                                            personnels.Add(input);
                                    }
                                    foreach (Demon input in personnels)
                                    {
                                        if (input.getForce() >= choix)
                                            demons.Add(input);
                                    }
                                    foreach (Demon input in demons)
                                    {
                                        Console.WriteLine(input);
                                    }
                                    break;

                                case 2:
                                    foreach (Personnel input in Parc.personnel)
                                    {
                                        if (input.GetType() == typeof(Demon))
                                            personnels.Add(input);
                                    }
                                    foreach (Demon input in personnels)
                                    {
                                        if (input.getForce() <= choix)
                                            demons.Add(input);
                                    }
                                    foreach (Demon input in demons)
                                    {
                                        Console.WriteLine(input);
                                    }
                                    break;
                            }
                            break;
                    }
                    break;

                case 7:
                    Console.WriteLine("Trie par Cagnotte");
                    Console.WriteLine("1. Cagnotte supérieur ");
                    Console.WriteLine("2. Cagnotte inférieur ");
                    choix2 = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("2. Valeur cagnotte ");
                    choix = Int32.Parse(Console.ReadLine());
                    switch (choix2)
                    {
                        case 1:
                            foreach (Personnel input in Parc.personnel)
                            {
                                if (input.GetType() == typeof(Zombies))
                                    personnels.Add(input);
                            }
                            foreach (Zombies input in personnels)
                            {
                                if (input.getCagnotte() >= choix)
                                    zombies.Add(input);
                            }
                            foreach (Zombies input in zombies)
                            {
                                Console.WriteLine(input);
                            }
                            break;

                        case 2:
                            foreach (Personnel input in Parc.personnel)
                            {
                                if (input.GetType() == typeof(Zombies))
                                    personnels.Add(input);
                            }
                            foreach (Zombies input in personnels)
                            {
                                if (input.getCagnotte() <= choix)
                                    zombies.Add(input);
                            }
                            foreach (Zombies input in zombies)
                            {
                                Console.WriteLine(input);
                            }
                            break;
                    }
                    break;
            }
        }


        static void evoluerAttractionPersonnel()
        {
            int choix, value, type = 0;
            int identifiant;
            string property;

            Console.WriteLine("1.Attraction 2. personnel");
            choix = Int32.Parse(Console.ReadLine());
            switch (choix)
            {
                case 1:
                    Console.WriteLine("\n1.boutique 2.DarkRides 3.RollerCoaster 4.Spectacle");
                    value = Int32.Parse(Console.ReadLine());
                    switch (value)
                    {
                        case 1:
                            foreach (Attraction input in Parc.attractions)
                            {
                                if (input.GetType() == typeof(Nourriture) || input.GetType() == typeof(Barbe_a_papa) || input.GetType() == typeof(souvenirs))
                                    attractions.Add(input);
                            }
                            foreach (Boutique input in attractions)
                            {
                                boutiques.Add(input);
                            }
                            foreach (Boutique input in boutiques)
                            {
                                Console.WriteLine(input);
                            }
                            Console.WriteLine("Entrer l'identifiant de la boutique à évoluer");
                            choix2 = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Que souhaitez-vous évoluer");
                            Console.WriteLine("1. Min Monstre  2. Besoin Spécifique  3.Type de besoin ");
                            choix3 = Int32.Parse(Console.ReadLine());
                            switch (choix3)
                            {
                                case 1:
                                    Console.WriteLine("Entrer la nouvelle valeur de monstre minimum");
                                    var = Int32.Parse(Console.ReadLine());
                                    for (int i = 0; i < boutiques.Count; i++)
                                    {
                                        if (boutiques.ElementAt(i).Identifiant == choix2)
                                        {
                                            boutiques.ElementAt(i).Nombre_monstre = var;
                                        }
                                    }
                                    foreach (Boutique input in boutiques)
                                    {
                                        Console.WriteLine(input);
                                    }
                                    break;

                                case 2:
                                    Console.WriteLine("Entrer la nouvelle valeur du besoin spécifique");
                                    str = Console.ReadLine();
                                    if (str.ToLower() == "true" || str.ToLower() == "1")
                                        boolean = true;
                                    for (int i = 0; i < boutiques.Count; i++)
                                    {
                                        if (boutiques.ElementAt(i).Identifiant == choix2)
                                        {
                                            boutiques.ElementAt(i).Besoinspecifique = boolean;
                                        }
                                    }
                                    foreach (Boutique input in boutiques)
                                    {
                                        Console.WriteLine(input);
                                    }
                                    break;

                                case 3:
                                    Console.WriteLine("Entrer la nouvelle valeur du type de besoin");
                                    str = Console.ReadLine();
                                    for (int i = 0; i < boutiques.Count; i++)
                                    {
                                        if (boutiques.ElementAt(i).Identifiant == choix2)
                                        {
                                            boutiques.ElementAt(i).Typedebesoin = str;
                                        }
                                    }
                                    foreach (Boutique input in boutiques)
                                    {
                                        Console.WriteLine(input);
                                    }
                                    break;
                            }
                            break;

                        case 2:
                            foreach (Attraction input in Parc.attractions)
                            {
                                if (input.GetType() == typeof(DarkRides))
                                    attractions.Add(input);
                            }
                            foreach (DarkRides input in attractions)
                            {
                                darkrides.Add(input);
                            }
                            foreach (DarkRides input in darkrides)
                            {
                                Console.WriteLine(input);
                            }
                            Console.WriteLine("Entrer l'identifiant de la darkRides à évoluer");
                            choix2 = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Que souhaitez-vous évoluer");
                            Console.WriteLine("1. Min Monstre  2. Besoin Spécifique  3.Type de besoin 4.duree  5.vehicule");
                            choix3 = Int32.Parse(Console.ReadLine());
                            switch (choix3)
                            {
                                case 1:
                                    Console.WriteLine("Entrer la nouvelle valeur de monstre minimum");
                                    var = Int32.Parse(Console.ReadLine());
                                    for (int i = 0; i < darkrides.Count; i++)
                                    {
                                        if (darkrides.ElementAt(i).Identifiant == choix2)
                                        {
                                            darkrides.ElementAt(i).Nombre_monstre = var;
                                        }
                                    }
                                    foreach (DarkRides input in darkrides)
                                    {
                                        Console.WriteLine(input);
                                    }
                                    break;

                                case 2:
                                    Console.WriteLine("Entrer la nouvelle valeur du besoin spécifique");
                                    str = Console.ReadLine();
                                    if (str.ToLower() == "true" || str.ToLower() == "1")
                                        boolean = true;
                                    for (int i = 0; i < darkrides.Count; i++)
                                    {
                                        if (darkrides.ElementAt(i).Identifiant == choix2)
                                        {
                                            darkrides.ElementAt(i).Besoinspecifique = boolean;
                                        }
                                    }
                                    foreach (DarkRides input in darkrides)
                                    {
                                        Console.WriteLine(input);
                                    }
                                    break;

                                case 3:
                                    Console.WriteLine("Entrer la nouvelle valeur du type de besoin");
                                    str = Console.ReadLine();
                                    for (int i = 0; i < darkrides.Count; i++)
                                    {
                                        if (darkrides.ElementAt(i).Identifiant == choix2)
                                        {
                                            darkrides.ElementAt(i).Typedebesoin = str;
                                        }
                                    }
                                    foreach (DarkRides input in darkrides)
                                    {
                                        Console.WriteLine(input);
                                    }
                                    break;

                                case 4:
                                    Console.WriteLine("Entrer la nouvelle valeur de la durée");
                                    double.TryParse(Console.ReadLine(), out var2);
                                    for (int i = 0; i < darkrides.Count; i++)
                                    {
                                        if (darkrides.ElementAt(i).Identifiant == choix2)
                                        {
                                            darkrides.ElementAt(i).Duree = var2;
                                        }
                                    }
                                    foreach (DarkRides input in darkrides)
                                    {
                                        Console.WriteLine(input);
                                    }
                                    break;

                                case 5:
                                    Console.WriteLine("Entrer la nouvelle valeur véhicule true ou no || 0 ou 1");
                                    str = Console.ReadLine();
                                    if (str.ToLower() == "true" || str.ToLower() == "1")
                                        boolean = true;
                                    for (int i = 0; i < darkrides.Count; i++)
                                    {
                                        if (darkrides.ElementAt(i).Identifiant == choix2)
                                        {
                                            darkrides.ElementAt(i).Vehicule = boolean;
                                        }
                                    }
                                    foreach (DarkRides input in darkrides)
                                    {
                                        Console.WriteLine(input);
                                    }
                                    break;
                            }
                            break;

                        case 3:
                            foreach (Attraction input in Parc.attractions)
                            {
                                if (input.GetType() == typeof(RollerCoaster))
                                    attractions.Add(input);
                            }
                            foreach (RollerCoaster input in attractions)
                            {
                                rollerCoasters.Add(input);
                            }
                            foreach (RollerCoaster input in rollerCoasters)
                            {
                                Console.WriteLine(input);
                            }
                            Console.WriteLine("Entrer l'identifiant de la rollerCoaster à évoluer");
                            choix2 = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Que souhaitez-vous évoluer");
                            Console.WriteLine("1. Min Monstre  2. Besoin Spécifique  3.Type de besoin 4.Categorie 5.Age 6.Taille");
                            choix3 = Int32.Parse(Console.ReadLine());
                            switch (choix3)
                            {
                                case 1:
                                    Console.WriteLine("Entrer la nouvelle valeur de monstre minimum");
                                    var = Int32.Parse(Console.ReadLine());
                                    for (int i = 0; i < rollerCoasters.Count; i++)
                                    {
                                        if (rollerCoasters.ElementAt(i).Identifiant == choix2)
                                        {
                                            rollerCoasters.ElementAt(i).Nombre_monstre = var;
                                        }
                                    }
                                    foreach (RollerCoaster input in rollerCoasters)
                                    {
                                        Console.WriteLine(input);
                                    }
                                    break;

                                case 2:
                                    Console.WriteLine("Entrer la nouvelle valeur du besoin spécifique");
                                    str = Console.ReadLine();
                                    if (str.ToLower() == "true" || str.ToLower() == "1")
                                        boolean = true;
                                    for (int i = 0; i < rollerCoasters.Count; i++)
                                    {
                                        if (rollerCoasters.ElementAt(i).Identifiant == choix2)
                                        {
                                            rollerCoasters.ElementAt(i).Besoinspecifique = boolean;
                                        }
                                    }
                                    foreach (RollerCoaster input in rollerCoasters)
                                    {
                                        Console.WriteLine(input);
                                    }
                                    break;

                                case 3:
                                    Console.WriteLine("Entrer la nouvelle valeur du type de besoin");
                                    str = Console.ReadLine();
                                    for (int i = 0; i < rollerCoasters.Count; i++)
                                    {
                                        if (rollerCoasters.ElementAt(i).Identifiant == choix2)
                                        {
                                            rollerCoasters.ElementAt(i).Typedebesoin = str;
                                        }
                                    }
                                    foreach (RollerCoaster input in rollerCoasters)
                                    {
                                        Console.WriteLine(input);
                                    }
                                    break;

                                case 4:
                                    Console.WriteLine("Entrer la nouvelle valeur de categorie");
                                    var = Int32.Parse(Console.ReadLine());
                                    for (int i = 0; i < rollerCoasters.Count; i++)
                                    {
                                        if (rollerCoasters.ElementAt(i).Identifiant == choix2)
                                        {
                                            rollerCoasters.ElementAt(i).Categorie = var;
                                        }
                                    }
                                    foreach (RollerCoaster input in rollerCoasters)
                                    {
                                        Console.WriteLine(input);
                                    }
                                    break;


                                case 5:
                                    Console.WriteLine("Entrer la nouvelle valeur de age minimum");
                                    var = Int32.Parse(Console.ReadLine());
                                    for (int i = 0; i < rollerCoasters.Count; i++)
                                    {
                                        if (rollerCoasters.ElementAt(i).Identifiant == choix2)
                                        {
                                            rollerCoasters.ElementAt(i).Age_mininum = var;
                                        }
                                    }
                                    foreach (RollerCoaster input in rollerCoasters)
                                    {
                                        Console.WriteLine(input);
                                    }
                                    break;


                                case 6:
                                    Console.WriteLine("Entrer la nouvelle valeur de taille minimum");
                                    double.TryParse(Console.ReadLine(), out var2);
                                    for (int i = 0; i < rollerCoasters.Count; i++)
                                    {
                                        if (rollerCoasters.ElementAt(i).Identifiant == choix2)
                                        {
                                            rollerCoasters.ElementAt(i).Taille_minimun = var;
                                        }
                                    }
                                    foreach (RollerCoaster input in rollerCoasters)
                                    {
                                        Console.WriteLine(input);
                                    }
                                    break;

                            }
                            break;

                        case 4:
                            foreach (Attraction input in Parc.attractions)
                            {
                                if (input.GetType() == typeof(Spectacles))
                                    attractions.Add(input);
                            }
                            foreach (Spectacles input in attractions)
                            {
                                spectacles.Add(input);
                            }
                            foreach (Spectacles input in spectacles)
                            {
                                Console.WriteLine(input);
                            }
                            Console.WriteLine("Entrer l'identifiant de la rollerCoaster à évoluer");
                            choix2 = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Que souhaitez-vous évoluer");
                            Console.WriteLine("1. Min Monstre  2. Besoin Spécifique  3.Type de besoin 4.Categorie 5.Age 6.Taille");
                            choix3 = Int32.Parse(Console.ReadLine());
                            switch (choix3)
                            {
                                case 1:
                                    Console.WriteLine("Entrer la nouvelle valeur de monstre minimum");
                                    var = Int32.Parse(Console.ReadLine());
                                    for (int i = 0; i < spectacles.Count; i++)
                                    {
                                        if (spectacles.ElementAt(i).Identifiant == choix2)
                                        {
                                            spectacles.ElementAt(i).Nombre_monstre = var;
                                        }
                                    }
                                    foreach (Spectacles input in spectacles)
                                    {
                                        Console.WriteLine(input);
                                    }
                                    break;

                                case 2:
                                    Console.WriteLine("Entrer la nouvelle valeur du besoin spécifique");
                                    str = Console.ReadLine();
                                    if (str.ToLower() == "true" || str.ToLower() == "1")
                                        boolean = true;
                                    for (int i = 0; i < spectacles.Count; i++)
                                    {
                                        if (spectacles.ElementAt(i).Identifiant == choix2)
                                        {
                                            spectacles.ElementAt(i).Besoinspecifique = boolean;
                                        }
                                    }
                                    foreach (Spectacles input in spectacles)
                                    {
                                        Console.WriteLine(input);
                                    }
                                    break;

                                case 3:
                                    Console.WriteLine("Entrer la nouvelle valeur du type de besoin");
                                    str = Console.ReadLine();
                                    for (int i = 0; i < spectacles.Count; i++)
                                    {
                                        if (spectacles.ElementAt(i).Identifiant == choix2)
                                        {
                                            spectacles.ElementAt(i).Typedebesoin = str;
                                        }
                                    }
                                    foreach (Spectacles input in spectacles)
                                    {
                                        Console.WriteLine(input);
                                    }
                                    break;

                                case 4:
                                    Console.WriteLine("Entrer la nouvelle valeur du type de besoin");
                                    str = Console.ReadLine();
                                    for (int i = 0; i < spectacles.Count; i++)
                                    {
                                        if (spectacles.ElementAt(i).Identifiant == choix2)
                                        {
                                            spectacles.ElementAt(i).Typedebesoin = str;
                                        }
                                    }
                                    foreach (Spectacles input in spectacles)
                                    {
                                        Console.WriteLine(input);
                                    }
                                    break;




                            }
                            break;
                    }
                    break;

                case 2:
                    Console.WriteLine("\n1.Sorcier 2.Monstre 3.Demon 4.Fantome 5.Loup Garou 6.Vampire 7.Zombie");
                    value = Int32.Parse(Console.ReadLine());
                    switch (value)
                    {
                        case 1:
                            foreach (Personnel input in Parc.personnel)
                            {
                                if (input.GetType() == typeof(Sorcier))
                                    personnels.Add(input);
                            }
                            foreach (Sorcier input in personnels)
                            {
                                sorciers.Add(input);
                            }
                            foreach (Personnel input in sorciers)
                            {
                                Console.WriteLine(input);
                            }
                            Console.WriteLine("Entrer le matricule du sorcier à évoluer");
                            choix2 = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Que souhaitez-vous évoluer");
                            Console.WriteLine("1.Fonction 2.Grade 3.Pouvoir ");
                            choix3 = Int32.Parse(Console.ReadLine());
                            switch (choix3)
                            {
                                case 1:
                                    Console.WriteLine("Entrer la nouvelle fonction");
                                    str = Console.ReadLine();
                                    for (int i = 0; i < sorciers.Count; i++)
                                    {
                                        if (sorciers.ElementAt(i).Matricule == choix2)
                                        {
                                            sorciers.ElementAt(i).Fonction = str;
                                        }
                                    }
                                    foreach (Personnel input in personnels)
                                    {
                                        Console.WriteLine(input);
                                    }
                                    break;

                                case 2:
                                    Console.WriteLine("0.Novice 1.Mega 2.Giga 3.Strata");
                                    var = Int32.Parse(Console.ReadLine());
                                    for (int i = 0; i < sorciers.Count; i++)
                                    {
                                        if (sorciers.ElementAt(i).Matricule == choix2)
                                        {
                                            sorciers.ElementAt(i).Grade = var;
                                        }
                                    }
                                    foreach (Sorcier input in sorciers)
                                    {
                                        Console.WriteLine(input);
                                    }
                                    break;

                                case 3:
                                    Console.WriteLine("Entrer sa nouvelle liste de pouvoir séparer par des espace vides ( )");
                                    str = Console.ReadLine();
                                    for (int i = 0; i < sorciers.Count; i++)
                                    {
                                        if (sorciers.ElementAt(i).Matricule == choix2)
                                        {
                                            sorciers.ElementAt(i).Pouvoirs.Clear();

                                            List<String> Pouvoirs = new List<string>();
                                            var pourvoir_full = str.Split(' ');
                                            foreach (string output in pourvoir_full)
                                            {
                                                Pouvoirs.Add(output);
                                            }
                                            sorciers.ElementAt(i).Pouvoirs = Pouvoirs;

                                        }
                                    }
                                    foreach (Sorcier input in sorciers)
                                    {
                                        Console.WriteLine(input);
                                    }
                                    break;
                            }
                            break;

                        case 2:
                            foreach (Personnel input in Parc.personnel)
                            {
                                if (input.GetType() == typeof(Monstre))
                                    personnels.Add(input);
                            }
                            foreach (Monstre input in personnels)
                            {
                                monstres.Add(input);
                            }
                            foreach (Personnel input in monstres)
                            {
                                Console.WriteLine(input);
                            }
                            Console.WriteLine("Entrer le matricule du monstre à évoluer");
                            choix2 = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Que souhaitez-vous évoluer");
                            Console.WriteLine("1.Fonction 2.Cagnotte 3.Affectation ");
                            choix3 = Int32.Parse(Console.ReadLine());
                            switch (choix3)
                            {
                                case 1:
                                    Console.WriteLine("Entrer la nouvelle fonction");
                                    str = Console.ReadLine();
                                    for (int i = 0; i < monstres.Count; i++)
                                    {
                                        if (monstres.ElementAt(i).Matricule == choix2)
                                        {
                                            monstres.ElementAt(i).Fonction = str;
                                        }
                                    }
                                    foreach (Personnel input in personnels)
                                    {
                                        Console.WriteLine(input);
                                    }
                                    break;

                                case 2:
                                    Console.WriteLine("Entrer la nouvelle cagnotte");
                                    var = Int32.Parse(Console.ReadLine());
                                    for (int i = 0; i < monstres.Count; i++)
                                    {
                                        if (monstres.ElementAt(i).Matricule == choix2)
                                        {
                                            monstres.ElementAt(i).Cagnotte = var;
                                            if (var < 50)
                                            {
                                                attractions.Clear();
                                                Console.WriteLine("Ce monstre doit aussitot être viré dans une barbe à papa");
                                                foreach (Attraction input in Parc.attractions)
                                                {
                                                    if (input.GetType() == typeof(Barbe_a_papa))
                                                    {
                                                        attractions.Add(input);
                                                    }
                                                }
                                                foreach (Barbe_a_papa input2 in attractions)
                                                {
                                                    Console.WriteLine(input2);
                                                }
                                                Console.WriteLine("Entrer le matricule de la barbe à papa à l'affecter");
                                                choix3 = Int32.Parse(Console.ReadLine());
                                                monstres.ElementAt(i).Affectation = choix3;
                                            }
                            
                    }
                                    }
                                    foreach (Monstre input in monstres)
                                    {
                                        Console.WriteLine(input);
                                    }
                                    break;

                                case 3:
                                    Console.WriteLine("Entrer la nouvelle affectation");
                                    var = Int32.Parse(Console.ReadLine());
                                    for (int i = 0; i < monstres.Count; i++)
                                    {
                                        if (monstres.ElementAt(i).Matricule == choix2)
                                        {
                                            monstres.ElementAt(i).Affectation = var;
                                        }
                                    }
                                    foreach (Monstre input in monstres)
                                    {
                                        Console.WriteLine(input);
                                    }
                                    break;
                            }
                            break;

                    }
                    break;

            

                    

            }
        }
        static void rechercher()
        {
            int choix, value, type = 0;
            int identifiant;
            string property;

            Console.WriteLine("1.Attraction 2. personnel"); choix = Int32.Parse(Console.ReadLine());
            switch(choix)
            {
                case 1:
            Console.WriteLine("1.boutique 2.DarkRides 3.RollerCoaster 4.Spectacle"); choix = Int32.Parse(Console.ReadLine());
                switch (choix)
                {
                            case 1:
                                getAllBoutique();
                                break;
                            case 2:
                                getAllDarkRides();
                                break;
                            case 3:
                                getAllRollerCoaster();
                                break;
                            case 4:
                                getAllSpectacles();
                                break;

                }
            break;
                case 2:
                    Console.WriteLine("\n 1.Sorcier  2.Monstre 3.Demon 4.Fantome 5.LoupGarou 6.Vampire 7.Zombie"); int typePersonnel = Int32.Parse(Console.ReadLine());
                    switch(typePersonnel)
                    {
                        case 1:
                            getAllSorcier();
                            break;
                        case 2:
                            getAllMonstre();
                            break;
                        case 3:
                            getAllDemon();
                            break;
                        case 4:
                            getAllFantome();
                            break;
                        case 5:
                            getAllLoupGarou();
                            break;
                        case 6:
                            getAllVampire();
                            break;
                        case 7:
                            getAllZombie();
                            break;
                    }
                    break;
            }
    }
        static void getAllSorcier()
        {
            foreach (Personnel input in Parc.personnel)
            {
                if (input.GetType() == typeof(Sorcier))
                    personnels.Add(input);
            }
            foreach (Sorcier personnel  in personnels)
            {
                Console.WriteLine(personnel);
            }
            personnels.Clear();
        }

        static void getAllMonstre()
        {
            foreach (Personnel input in Parc.personnel)
            {
                if (input.GetType() == typeof(Monstre))
                    personnels.Add(input);
            }
            foreach (Monstre personnel in personnels)
            {
                Console.WriteLine(personnel);
            }
            personnels.Clear();
        }

        static void getAllDemon()
        {
            foreach (Personnel input in Parc.personnel)
            {
                if (input.GetType() == typeof(Demon))
                    personnels.Add(input);
            }
            foreach (Demon personnel in personnels)
            {
                Console.WriteLine(personnel);
            }
            personnels.Clear();
        }

        static void getAllFantome()
        {
            foreach (Personnel input in Parc.personnel)
            {
                if (input.GetType() == typeof(fantome))
                    personnels.Add(input);
            }
            foreach (fantome personnel in personnels)
            {
                Console.WriteLine(personnel);
            }
            personnels.Clear();
        }

        static void getAllLoupGarou()
        {
            foreach (Personnel input in Parc.personnel)
            {
                if (input.GetType() == typeof(Loup_Garou))
                    personnels.Add(input);
            }
            foreach (Loup_Garou personnel in personnels)
            {
                Console.WriteLine(personnel);
            }
            personnels.Clear();
        }

        static void getAllVampire()
        {
            foreach (Personnel input in Parc.personnel)
            {
                if (input.GetType() == typeof(Vampire))
                    personnels.Add(input);
            }
            foreach (Vampire personnel in personnels)
            {
                Console.WriteLine(personnel);
            }
            personnels.Clear();
        }

        static void getAllZombie()
        {
            foreach (Personnel input in Parc.personnel)
            {
                if (input.GetType() == typeof(Zombies))
                    personnels.Add(input);
            }
            foreach (Zombies personnel in personnels)
            {
                Console.WriteLine(personnel);
            }
            personnels.Clear();
        }



        static void getAllBoutique()
        {
            foreach (Attraction input in Parc.attractions)
            {
                if (input.GetType() == typeof(Boutique))
                    attractions.Add(input);
            }
            foreach (Boutique boutique in attractions)
            {
                Console.WriteLine(boutique);
            }
            attractions.Clear();
        }

        static void getAllDarkRides()
        {
            foreach (Attraction input in Parc.attractions)
            {
                if (input.GetType() == typeof(DarkRides))
                    attractions.Add(input);
            }
            foreach (DarkRides darkRides in attractions)
            {
                Console.WriteLine(darkRides);
            }
            attractions.Clear();
        }

        static void getAllRollerCoaster()
        {
            foreach (Attraction input in Parc.attractions)
            {
                if (input.GetType() == typeof(RollerCoaster))
                    attractions.Add(input);
            }
            foreach (RollerCoaster rollerCoaster in attractions)
            {
                Console.WriteLine(rollerCoaster);
            }
            attractions.Clear();
        }

        static void getAllSpectacles()
        {
            foreach (Attraction input in Parc.attractions)
            {
                if (input.GetType() == typeof(Spectacles))
                    attractions.Add(input);
            }
            foreach (Spectacles spectacles in attractions)
            {
                Console.WriteLine(spectacles);
            }
            attractions.Clear();
        }

        static void ajoutPersonnel()
        {
            int typePersonnel = 1;
            int matricule = 0;
            string nom = "";
            string prenom = "";
            int sexe = 2;
            string fonction, affectation = "";
            bool licensiment = false;
            int grade = 0;
            string pouvoir = "";
            int cagnotte = 0;
            int force = 0;
            double indiceCruaute = 0.0;
            double indiceLuninosité = 0.0;
            string color = "";
            int degreeDecomposition = 0;

            Console.WriteLine("Choississez le type du nouveau personnel \n 1. Sorcier  2. Monstre 3.Demon 4. Fantome 5. LoupGarou 6. Vampire 7. Zombie");typePersonnel = Int32.Parse(Console.ReadLine());
            switch (typePersonnel)
            {
                case 1: //il s'agit d'un sorcier
                    Console.WriteLine("Entrer son matricule"); matricule = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Entrer son nom"); nom = Console.ReadLine();
                    Console.WriteLine("Entrer son prénom"); prenom = Console.ReadLine();
                    Console.WriteLine("Entre son sexe /n 0. Pour male 1. femelle 2.inconnu"); sexe = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Entrer sa fonction"); fonction = Console.ReadLine();
                    Console.WriteLine("Choississez son grade \n 0.novice 1.mega 2.giga 3.strata"); grade = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Entrer ces pouvoir (format xxx-xxx-xxx"); pouvoir = Console.ReadLine();

                    Parc.personnel.Add(new Sorcier(nom, prenom, sexe, fonction, matricule, false, grade, pouvoir));
                    break;

                case 2: //il s'agit d'un monstre
                    Console.WriteLine("Entrer son matricule"); matricule = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Entrer son nom"); nom = Console.ReadLine();
                    Console.WriteLine("Entrer son prénom"); prenom = Console.ReadLine();
                    Console.WriteLine("Entre son sexe /n 0. Pour male 1. femelle 2.inconnu"); sexe = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Entrer sa fonction"); fonction = Console.ReadLine();
                    Console.WriteLine("Entrer sa cagnotte"); cagnotte = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Entrer le matricule de l'attraction auquel il est affecté ou 0 s'il n'est pas affecté"); /*Parc.afficherListeAttraction();*/affectation = Console.ReadLine();
                    Parc.personnel.Add(new Monstre(nom, prenom, sexe, fonction, matricule, false, cagnotte, affectation));

                    break;
                    

                case 3: //il s'agit d'un demon
                    Console.WriteLine("Entrer son matricule"); matricule = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Entrer son nom"); nom = Console.ReadLine();
                    Console.WriteLine("Entrer son prénom"); prenom = Console.ReadLine();
                    Console.WriteLine("Entre son sexe /n 0. Pour male 1. femelle 2.inconnu"); sexe = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Entrer sa fonction"); fonction = Console.ReadLine();
                    Console.WriteLine("Entrer sa cagnotte"); cagnotte = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Entrer le matricule de l'attraction auquel il est affecté ou 0 s'il n'est pas affecté"); /*Parc.afficherListeAttraction();*/affectation = Console.ReadLine();
                    Console.WriteLine("Entrer sa force"); force = Int32.Parse(Console.ReadLine());
                    Parc.personnel.Add(new Demon(nom, prenom, sexe, fonction, matricule, false, cagnotte, force, affectation));

                    break;

                case 4: //il s'agit d'un fantome
                    Console.WriteLine("Entrer son matricule"); matricule = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Entrer son nom"); nom = Console.ReadLine();
                    Console.WriteLine("Entrer son prénom"); prenom = Console.ReadLine();
                    Console.WriteLine("Entre son sexe /n 0. Pour male 1. femelle 2.inconnu"); sexe = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Entrer sa fonction"); fonction = Console.ReadLine();
                    Console.WriteLine("Entrer sa cagnotte"); cagnotte = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Entrer le matricule de l'attraction auquel il est affecté ou 0 s'il n'est pas affecté"); /*Parc.afficherListeAttraction();*/affectation = Console.ReadLine();
                    Parc.personnel.Add(new fantome(nom, prenom, sexe, fonction, matricule, false, cagnotte, affectation));

                    break;

                case 5: //il s'agit d'un LoupGarou
                    Console.WriteLine("Entrer son matricule"); matricule = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Entrer son nom"); nom = Console.ReadLine();
                    Console.WriteLine("Entrer son prénom"); prenom = Console.ReadLine();
                    Console.WriteLine("Entre son sexe /n 0. Pour male 1. femelle 2.inconnu"); sexe = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Entrer sa fonction"); fonction = Console.ReadLine();
                    Console.WriteLine("Entrer sa cagnotte"); cagnotte = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Entrer le matricule de l'attraction auquel il est affecté ou 0 s'il n'est pas affecté"); /*Parc.afficherListeAttraction();*/affectation = Console.ReadLine();
                    Console.WriteLine("Quel est son indice de cruauté"); double.TryParse(Console.ReadLine(), out indiceCruaute);
                    Parc.personnel.Add(new Loup_Garou(nom, prenom, sexe, fonction, matricule, false, cagnotte, indiceCruaute, affectation));

                    break;

                case 6: //il s'agit d'un vampire
                    Console.WriteLine("Entrer son matricule"); matricule = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Entrer son nom"); nom = Console.ReadLine();
                    Console.WriteLine("Entrer son prénom"); prenom = Console.ReadLine();
                    Console.WriteLine("Entre son sexe /n 0. Pour male 1. femelle 2.inconnu"); sexe = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Entrer sa fonction"); fonction = Console.ReadLine();
                    Console.WriteLine("Entrer sa cagnotte"); cagnotte = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Entrer le matricule de l'attraction auquel il est affecté ou 0 s'il n'est pas affecté"); /*Parc.afficherListeAttraction();*/affectation = Console.ReadLine();
                    Console.WriteLine("Entrer son indice de luninosité"); double.TryParse(Console.ReadLine(), out indiceLuninosité);
                    Parc.personnel.Add(new Vampire(nom, prenom, sexe, fonction, matricule, false, cagnotte, indiceLuninosité, affectation));

                    break;

                case 7: //il s'agit d'un zombie
                    Console.WriteLine("Entrer son matricule"); matricule = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Entrer son nom"); nom = Console.ReadLine();
                    Console.WriteLine("Entrer son prénom"); prenom = Console.ReadLine();
                    Console.WriteLine("Entre son sexe /n 0. Pour male 1. femelle 2.inconnu"); sexe = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Entrer sa fonction"); fonction = Console.ReadLine();
                    Console.WriteLine("Entrer sa cagnotte"); cagnotte = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Entrer le matricule de l'attraction auquel il est affecté ou 0 s'il n'est pas affecté"); /*Parc.afficherListeAttraction();*/affectation = Console.ReadLine();
                    Console.WriteLine("Entrer son teint");color = Console.ReadLine();
                    Console.WriteLine("Entrer son degre de decomposition"); degreeDecomposition = Int32.Parse(Console.ReadLine());
                    Parc.personnel.Add(new Zombies(nom, prenom, sexe, fonction, matricule, false, cagnotte, color, degreeDecomposition, affectation));

                    break;
            }

            Console.WriteLine("liste personnel ajouté: /n" + Parc.personnel.Last());
        }
            static void ajoutAttraction()
        {
            double duree=0.0;
            bool vehicule, besoinSPecifique = false;
            string nom,boolean, typeDeBesoin, nomSalle, horaire = "";
            int identifiant,choixType, monstre,categorie,ageMin,tailemin,nombrePlace, choixCategorie = 0;
            int choixBoutique=1;


            Console.WriteLine("S'agit-il de : \n 1. boutique 2. Darkside 3. RollerCoaster 4.Spectacle"); choixType = Int32.Parse(Console.ReadLine());

            switch (choixType) {
                case 1:
                    Console.WriteLine("Son identifiant est:");  identifiant = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Son nom est"); nom = Console.ReadLine();
                    Console.WriteLine("Combien de monstres minimal possède t-il?"); monstre = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("A t-il un besoin spécifique? \n o. oui n. non"); boolean = Console.ReadLine(); if (boolean.ToLower() == "o") besoinSPecifique = true; else besoinSPecifique = false;
                    Console.WriteLine("Quelle est son type de besoin"); typeDeBesoin = Console.ReadLine();
                    Console.WriteLine("De quelle type de boutique s'agit-il \n 1. Nourriture 2. Barbe a papa 3. Souvenirs"); choixBoutique= Int32.Parse(Console.ReadLine());
                    Parc.attractions.Add(new Nourriture(identifiant, nom, monstre, besoinSPecifique, typeDeBesoin, choixBoutique));
                    break;
                case 2:
                    Console.WriteLine("Son identifiant est:"); identifiant = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Son nom est");  nom = Console.ReadLine();
                    Console.WriteLine("Combien de monstres minimal possède t-il?"); monstre = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("A t-il un besoin spécifique? \n o. oui n. non"); boolean = Console.ReadLine();if (boolean.ToLower() == "o") besoinSPecifique = true; else besoinSPecifique = false;
                    Console.WriteLine("Quelle est son type de besoin"); typeDeBesoin = Console.ReadLine();
                    Console.WriteLine("Entrer la duree");duree = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("possède t-il un véhicule? \n o. oui  n. non"); boolean = Console.ReadLine(); if (boolean.ToLower() == "o") vehicule = true; else vehicule = false;
                    Parc.attractions.Add(new DarkRides(identifiant, nom, monstre, besoinSPecifique, typeDeBesoin, duree, vehicule));
                    break;

                case 3:
                    Console.WriteLine("Son identifiant est:");  identifiant = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Son nom est");  nom = Console.ReadLine();
                    Console.WriteLine("Combien de monstres minimal possède t-il?"); monstre = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("A t-il un besoin spécifique? \n o. oui n. non"); boolean = Console.ReadLine(); if (boolean.ToLower() == "o") besoinSPecifique = true; else besoinSPecifique = false;
                    Console.WriteLine("Quelle est son type de besoin"); typeDeBesoin = Console.ReadLine();
                    Console.WriteLine("Choississez sa catégorie \n 0. assisse 1. inversé 2.bobsleigh"); categorie = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Entrer l'age minimum"); ageMin = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Entrer la taile minimum"); tailemin = Int32.Parse(Console.ReadLine());                    
                    Parc.attractions.Add(new RollerCoaster(identifiant, nom, monstre, besoinSPecifique, typeDeBesoin, categorie, ageMin, tailemin));
                    break;



                case 4:
                    Console.WriteLine("Son identifiant est:");  identifiant = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Son nom est");  nom = Console.ReadLine();
                    Console.WriteLine("Combien de monstres minimal possède t-il?"); monstre = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("A t-il un besoin spécifique? \n o. oui n. non"); boolean = Console.ReadLine(); if (boolean.ToLower() == "o") besoinSPecifique = true; else besoinSPecifique = false;
                    Console.WriteLine("Quelle est son type de besoin"); typeDeBesoin = Console.ReadLine();
                    Console.WriteLine("Entrer le nom de la salle");nomSalle = Console.ReadLine();
                    Console.WriteLine("Entrer le nombre de place");nombrePlace = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Entrer la liste d'horaires ; format: hh:mm hh:mm ...."); horaire = Console.ReadLine();
                    Parc.attractions.Add(new Spectacles(identifiant, nom, monstre, besoinSPecifique, typeDeBesoin, nomSalle, nombrePlace, horaire));
                    break;
            }
            
        }

        static void Main(string[] args)
        {
            new Parc();
            Console.WriteLine("/***************Bienvenu dans le gestionnaire de parc****************");
            while (true)
            {
                personnels.Clear();
                sorciers.Clear();
                attractions.Clear();
                demons.Clear();
                fantomes.Clear(); 
                loupGarou.Clear();
                vampire.Clear();
                zombies.Clear();

                boutiques.Clear();
                darkrides.Clear();
                rollerCoasters.Clear();
                spectacles.Clear();

                choix=choix2 = choix3 = typePersonnel = var=0;
                choix2 = 0;

                var2 = 0.0;

                boolean = false;
                str = "";


                Menu();
            

            // Keep the console window open in debug mode.
        }
    }

    }

}
