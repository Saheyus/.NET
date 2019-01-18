using System;
using System.Data;
using System.Data.SqlClient;
using Appli_Intranet.Controller;
using System.IO;
using Appli_Intranet.Model;
using Appli_Intranet.View;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Security.Policy;
using System.Threading.Tasks;


namespace Appli_Intranet.Controller
{
    class Program 
    {
        
        static void Main(string[] args)
        {

            Affichage affichage = new Affichage();
            
            //affichage.Authentification();

            affichage.Menu();

            affichage.Actions();
            
            Environment.Exit(0);

        }

    }

}


//     LISTE DES AMELIORATIONS A VENIR
//
//     - Lien entre les différentes classes à faire
//     - Methodes affichages à bien classer dans View
//     - Methodes stockage à bien classer dans Model
//     - Possibilité de cumuler des fichiers texte "client" et "voyage"
//     - Possibilité de modifier le contenu et le nom des fichiers texte "client" et "voyage"
//     - Possibilité de switcher entre le menu "Client" et le menu "Voyage"
//     
//
//