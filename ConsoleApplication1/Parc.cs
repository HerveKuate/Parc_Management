using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Parc_Management
{
    public class Parc
    {
        public static List<Personnel> personnel = new List<Personnel>();
        public static List<Attraction> attractions = new List<Attraction>();
        public Parc()
        {
            using (var reader = new StreamReader(@"Listing.csv"))//on stocke tout le contenu du fichier excel dans la variable reader
            {

 
                while (!reader.EndOfStream)//on parcourt la variable reader
                {
                    var line = reader.ReadLine();//on récupère une ligne c'est à dire un personnel ou une attraction
                    var values = line.Split(';');//on précise que le ; signifie que la colone est fini, qu'on a atteint le dernier élément comme la cagnotte ou le nom d'un personnel

                    
                    //convert string maintenance to bool etat
                    bool besoinspecifique;
                    switch (values[4])//
                    {
                        case "FALSE":
                            besoinspecifique = false;
                            break;
                        case "TRUE":
                            besoinspecifique = true;
                            break;
                        default:
                            besoinspecifique = false;
                            break;
                    }

                    //enum sexe"
                    int sexe;
                    switch (values[4])
                    {
                        case "male":
                            sexe = 0;
                            break;
                        case "femelle":
                            sexe = 1;
                            break;
                        default:
                            sexe = 2; //inconnu
                            break;
                    }

                    //enum pour tatouage
                    int tatouage;
                    switch (values[6])
                    {
                        case "novice":
                            tatouage = 0;
                            break;
                        case "mega":
                            tatouage = 1;
                            break;
                        case "giga":
                            tatouage = 2;
                            break;
                        case "strata":
                            tatouage = 3;
                            break;
                        default:
                            tatouage = 0;
                            break;

                    }

                    switch (values[0])//si la valeur de value[0]=sorcier, alors on crée un sorcier avec new Sorcier, si c'est Monstre, on crée un monstre avec new monstre
                    {
                        //personnel list

                        case "Sorcier":
                            personnel.Add(new Sorcier(values[2], values[3], sexe, values[5], Int32.Parse(values[1]), false, tatouage, values[7]));
                            break;
                        case "Monstre":
                            personnel.Add(new Monstre(values[2], values[3], sexe, values[5], Int32.Parse(values[1]), false, Int32.Parse(values[6]),values[7]));
                            break;
                        case "Demon":
                            personnel.Add(new Demon(values[2], values[3], sexe, values[5], Int32.Parse(values[1]), false, Int32.Parse(values[6]), Int32.Parse(values[8]),values[7]));
                            break;
                        case "Fantome":
                            personnel.Add(new fantome(values[2], values[3], sexe, values[5], Int32.Parse(values[1]), false, Int32.Parse(values[6]), values[7]));
                            break;
                        case "LoupGarou":
                            personnel.Add(new Loup_Garou(values[2], values[3], sexe, values[5], Int32.Parse(values[1]), false, Int32.Parse(values[6]), Convert.ToDouble(values[8]), values[7]));
                            break;
                        case "Vampire":
                            personnel.Add(new Vampire(values[2], values[3], sexe, values[5], Int32.Parse(values[1]), false, Int32.Parse(values[6]), Convert.ToDouble(values[8]), values[7]));
                            break;
                        case "Zombie":

                            //convertion coleur fr to eng
                            string color;
                            switch (values[8])
                            {
                                case "grisatre":
                                    color = "Gray";
                                    break;
                                case "bleuatre":
                                    color = "Blue";
                                    break;
                                /*****ajouter d'autre couleur après********/
                                default:
                                    color = "Black";
                                    break;
                                /******************************************/
                            }
                            personnel.Add(new Zombies(values[2], values[3], sexe, values[5], Int32.Parse(values[1]), false, Int32.Parse(values[6]), color, Int32.Parse(values[9]),values[7]));
                            break;

                            //Attraction list
                        case "Boutique":
                            
                            switch (values[6])
                            {
                                case "souvenir":
                                    //Typeboutique = 0;
                                    attractions.Add(new souvenirs(Int32.Parse(values[1]), values[2], Int32.Parse(values[3]), besoinspecifique, values[5], 0));
                                    break;
                                case "barbeAPapa":
                                    //Typeboutique = 1;
                                    attractions.Add(new Barbe_a_papa(Int32.Parse(values[1]), values[2], Int32.Parse(values[3]), besoinspecifique, values[5], 1));
                                    break;
                                case "nourriture":
                                    //Typeboutique = 2;
                                    attractions.Add(new Nourriture(Int32.Parse(values[1]), values[2], Int32.Parse(values[3]), besoinspecifique, values[5], 2));
                                    break;
                            }
                            break;
                        case "DarkRide":
                            /*convert value7 in Darkride to bool value*/
                            bool vehicule;
                             
                            switch (values[7]) {
                                case "false":
                                    vehicule = false;
                                    break;
                                case "true":
                                    vehicule = true;
                                    break;
                                default:
                                    vehicule = false; ;
                                    break;
                            };
                            attractions.Add(new DarkRides(Int32.Parse(values[1]), values[2], Int32.Parse(values[3]), besoinspecifique, values[5], Convert.ToDouble(values[6]), vehicule));
                            break;
                        case "RollerCoaster":
                            //enum pour tatouage
                            int categorie;
                            switch (values[6])
                            {
                                case "assise":
                                    categorie = 0;
                                    break;
                                case "inversée":
                                    categorie = 1;
                                    break;
                                case "bobsleigh":
                                    categorie = 2;
                                    break;
                                default:
                                    categorie = 0;
                                    break;
                            }
                            attractions.Add(new RollerCoaster(Int32.Parse(values[1]), values[2], Int32.Parse(values[3]), besoinspecifique, values[5], categorie, Int32.Parse(values[7]), Convert.ToDouble(values[8])));

                            break;

                        case "Spectacle":
                            attractions.Add(new Spectacles(Int32.Parse(values[1]), values[2], Int32.Parse(values[3]), besoinspecifique, values[5], values[6], Int32.Parse(values[7]), values[8]));

                            break;


                    };
                }
            }
            Console.WriteLine("check variable.");
        }

        public Personnel Personnel
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Attraction Attraction
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public static void afficherListeAttraction()
        {
            foreach (Attraction element in attractions)
                Console.WriteLine(element);
        }

        
    }
}