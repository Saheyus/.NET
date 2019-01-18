using System;
using Appli_Intranet.Controller;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appli_Intranet.View
{
    class Affichage
    {

        
        private string choix;
        private string action;

        public string Choix { get => choix; set => choix = value; }
        public string Action { get => action; set => action = value; }

        public Affichage()
        {


        }

        

        public void Authentification()
        {

            Console.WriteLine("");
            Console.WriteLine("\r\n\t***********************************************");
            Console.WriteLine("\tAUTH | Veuillez entrer vos identifiants :");


            Console.WriteLine("\tIdentifiant :");

            string nomDeCompte = Console.ReadLine().ToUpper();

            Console.WriteLine("\tMot de passe :");
            string mdp = Console.ReadLine();

            if (nomDeCompte == "ADMIN" && mdp == "admin")
            {
                
            }
            else
            {
                Console.WriteLine("Identifiants incorrects");
                Authentification();
            }


        }

        public void Deconnexion()
        {
            Console.WriteLine("Vous êtes déconnecté");
            Authentification();
        }

        public void Menu()
        {

            Choix = "";
        

            Console.WriteLine("");
            Console.WriteLine("\r\n\t***********************************************");
            Console.WriteLine("\tMENU | A quelle interface voulez-vous accéder ?");
            Console.WriteLine("\t     | Client, Voyage, Deconnexion, Quitter\r\n");

            
            Choix = Console.ReadLine();
            

            switch (Choix)
            {
                case "Voyage":
                    Choix = "Voyage";

                    break;

                case "Client":
                    Choix = "Client";
                    break;               

                case "Deconnexion":
                    Deconnexion();
                    break;

                case "Quitter":                    
                    Environment.Exit(0);
                    break;
            }

        }

        

        public void Actions()
        {

            Action = "";

            Console.WriteLine("");
            Console.WriteLine("\r\n\t***********************************************");
            Console.WriteLine("\tchoix | Que souhaitez-vous faire ?");
            Console.WriteLine("\t       | Rechercher, Modifier, Ajouter, Supprimer, RetourMenu, Deconnexion, Quitter\r\n");

            Action = Console.ReadLine();

            switch (Action)
            {
                
                case "Rechercher":
                    Action = "Rechercher";
                    break;

                case "Modifier":
                    Choix = "Modifier";
                    break;

                case "Ajouter":
                    Choix = "Ajouter";
                    break;

                case "Supprimer":
                    Choix = "Supprimer";
                    break;

                case "RetourMenu":
                    Menu();
                    break;

                case "Deconnexion":
                    Deconnexion();
                    break;

                case "Quitter":
                    Environment.Exit(1);
                    break;
            }



        }


    }
}
