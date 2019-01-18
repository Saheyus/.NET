using System;
using System.Collections.Generic;
using Appli_Intranet.View;
using System.IO;
using System.Linq;
using Appli_Intranet.Model;
using System.Text;
using System.Threading.Tasks;

namespace Appli_Intranet.Controller
{
    class Commercial : Personne
    {
        public Commercial()
        {


        }

      
        private string cheminFichier;
        private string nomFichier;
        private string cheminDossier;
        private string resultatRecherche;
        private int indexRecherche;
        private string oldLine;
        private string newLine;
        
        List<string> contenuFichier = new List<string>();

        public string CheminFichier { get => cheminFichier; set => cheminFichier = value; }
        public string NomFichier { get => nomFichier; set => nomFichier = value; }
        public string CheminDossier { get => cheminDossier; set => cheminDossier = value; }
        public string ResultatRecherche { get => resultatRecherche; set => resultatRecherche = value; }
        public int IndexRecherche { get => indexRecherche; set => indexRecherche = value; }
        public string OldLine { get => oldLine; set => oldLine = value; }
        public string NewLine { get => newLine; set => newLine = value; }




        //METHODE POUR CONSULTER CONTENU FICHIER TXT CLIENT/VOYAGE (en fonction du menu en cours)
        public void Consulter()
        {

            int i = 1;

 
            Console.WriteLine("\r\n\tVoici le contenu du fichier :\r\n");


            foreach (string line in File.ReadLines(CheminFichier))
            {
                Console.WriteLine("\t\t" + i++ + ") " + line);
            }

        }


        //METHODE POUR CONSULTER LA LISTE DES FICHIERS DANS DOSSIER VISÉ (dossier clients, dossier voyages)
        public void ConsulterDossier()
        {
            int i = 1;


            Console.WriteLine("\r\n\tVoici le contenu du dossier :\r\n");


            List<string> fichiers = new List<string>(Directory.GetFiles(CheminDossier));

            foreach (string line in fichiers)
            {
                Console.WriteLine("\t\t" + i + ") " + Path.GetFileName(line));
                i++;
            }

        }


        //METHODE POUR AJOUTER UN CLIENT/VOYAGE DANS LES FICHIERS TXT (en fonction du menu en cours)
        public void Ajouter()
        {
            
            Client nouveauClient = new Client();
            Voyage nouveauVoyage = new Voyage();

           
            //ATTRIBUER UN NUMERO UNIQUE PAR LIGNE
            int intNombre = 0;
            int idUnique = 1;

            List<string> contenuFichier = new List<string>(File.ReadAllLines(CheminFichier));

            foreach (string line in contenuFichier)
            {

                string[] nombre = line.Trim().Split(new[] { ';' }, StringSplitOptions.None);

                if (line == null || line == "" || line == Environment.NewLine)
                {
                    //rien ne se passe : pour éviter les erreurs de lignes vides
                }
                else
                {
                    intNombre = Int32.Parse(nombre[0]);
                    if (idUnique <= intNombre)
                    {
                        idUnique = intNombre + 1;
                    }
                }
            }
            

            StreamWriter sw = new StreamWriter(CheminFichier, true);

            if (NomFichier == "clients.txt")
            {

                try
                {
                    Console.WriteLine("\tVeuillez entrer les informations suivantes séparés par un point virgule: ");
                    Console.WriteLine(
                        "\r\n\t\t" + "1) Civilite" +
                        "\r\n\t\t" + "2) NOM" +
                        "\r\n\t\t" + "3) Prenom" +
                        "\r\n\t\t" + "4) Date de Naissance (jj/mm/aaaa)" +
                        "\r\n\t\t" + "5) Adresse" +
                        "\r\n\t\t" + "6) Telephone (001122334455)" +
                        "\r\n\t\t" + "7) Coordonnées Bancaires (0000111122223333)\r\n");

                    string[] informations = Console.ReadLine().Trim().Split(new[] { ';' }, StringSplitOptions.None);

                    nouveauClient.Civilite = informations[0].Trim();
                    nouveauClient.Nom = informations[1].Trim();
                    nouveauClient.Prenom = informations[2].Trim();
                    nouveauClient.DateDeNaissance = DateTime.Parse(informations[3].Trim());
                    nouveauClient.Adresse = informations[4].Trim();
                    nouveauClient.Telephone = informations[5].Trim();
                    nouveauClient.CoordonneesBancaires = informations[6].Trim();

                    sw.WriteLine("" + idUnique + ';' + nouveauClient.Civilite + ';' + nouveauClient.Nom + ';' + nouveauClient.Prenom + ';' + nouveauClient.DateDeNaissance.ToShortDateString() + ';' + nouveauClient.Adresse + ';' + nouveauClient.Telephone + ';' + nouveauClient.CoordonneesBancaires);

                    Console.WriteLine("\r\n\t***********************************************\r\n\tJ'ai bien ajouté les informations au fichier " + NomFichier + " \r\n");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("\r\n\tAjout de client annulé car tous les champs n'ont pas été renseignés.\r\n");
                }
                catch (FormatException)
                {
                    Console.WriteLine("\r\n\tAjout de client annulé car les consignes de remplissage des champs n'ont pas été correctement appliquées.\r\n");
                }

            }
            else if (NomFichier == "voyages.txt")
            {

                try
                {
      
                    Console.WriteLine("\r\n\tVeuillez entrer les informations suivantes séparés par un point virgule: ");
                    Console.WriteLine(
                        "\r\n\t\t" + "1) Prenom NOM du Client" +
                        "\r\n\t\t" + "2) Destination" +
                        "\r\n\t\t" + "3) Date Aller (jj/mm/aaaa)" +
                        "\r\n\t\t" + "4) Date Retour (jj/mm/aaaa)" +
                        "\r\n\t\t" + "5) Nombre de voyageurs (9max)" +
                        "\r\n\t\t" + "6) Nombre de places disponibles restantes\r\n");

                    string[] informations = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.None);

                    nouveauVoyage.Client = informations[0].Trim();
                    nouveauVoyage.Destination = informations[1].Trim();
                    nouveauVoyage.DateAller = DateTime.Parse(informations[2].Trim());
                    nouveauVoyage.DateRetour = DateTime.Parse(informations[3].Trim());
                    nouveauVoyage.NbVoyageur = Int32.Parse(informations[4].Trim());
                    nouveauVoyage.NbPlace = Int32.Parse(informations[5].Trim());

                    sw.WriteLine("" + idUnique + ';' + nouveauVoyage.Client + ';' + nouveauVoyage.Destination + ';' + nouveauVoyage.DateAller.ToShortDateString() + ';' + nouveauVoyage.DateRetour.ToShortDateString() + ';' + nouveauVoyage.NbVoyageur + ';' + nouveauVoyage.NbPlace);

                    Console.WriteLine("\r\n\t***********************************************\r\n\tJ'ai bien ajouté les informations au fichier " + NomFichier + " \r\n");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("\r\n\tAjout de voyage annulé car tous les champs n'ont pas été renseignés.\r\n");
                }
                catch (FormatException)
                {
                    Console.WriteLine("\r\n\tAjout de voyage annulé car les consignes de remplissage des champs n'ont pas été correctement appliquées.\r\n");
                }

            }
            else
            {
                Console.WriteLine("\r\n\tLe chemin d'accès n'est pas connu.\r\n");
            }
            
            sw.Close();

        }


        public void Modifier()
        {
            

            Rechercher();

            Console.WriteLine("\tQue voulez-vous modifier ?");

            OldLine = Console.ReadLine().ToUpper();

            Console.WriteLine("\tFaites votre modification");

            NewLine = Console.ReadLine().ToUpper();

            string nouvelleLigne = ResultatRecherche.Replace(OldLine, NewLine);
            
            List<string> Lines = File.ReadAllLines(CheminFichier).ToList();
            
            /*
            List<string> LinesMaj = new List<string>();
            foreach (string line in Lines)
            {
                //LinesMaj = line.ToUpper().ToList();
            }
            */

            Lines.Insert(IndexRecherche + 1, nouvelleLigne);
            Lines.RemoveAt(IndexRecherche);

            Console.WriteLine("\tVariables modifiees :{0}'{1}'", Environment.NewLine, nouvelleLigne);


            StreamWriter newFile = new StreamWriter(CheminFichier); 

            foreach (string line in Lines) 
            {
                newFile.WriteLine("" + line);
                
            }
            
            newFile.Close();


            Console.WriteLine("\tNous avons bien modifié la ligne.");
            

            //int 0 = Int32.Parse(Console.ReadLine()) - 1;
            /*
            List<string> Lines = File.ReadAllLines(CheminFichier).ToList();

            foreach (string line in Lines)
            {

            }
            Lines(lineToDelete, modification);

 
            Console.WriteLine("Voulez-vous vraiment supprimer ?");
            string choix = Console.ReadLine();

            if (choix == "oui")
            {
                File.WriteAllLines(CheminFichier, Lines.ToArray());
            }
            */
        }
        

        //METHODE POUR MODIFIER UN CHAMP DE CLIENT/VOYAGE DANS LES FICHIERS TXT (en fonction du menu en cours)
        public void Rechercher()
        {
            ResultatRecherche = "";
            IndexRecherche = 0;

            if (File.Exists(CheminFichier))
            {
                
                List<string> contenuFichier = new List<string>(File.ReadAllLines(CheminFichier));
                Console.WriteLine("\tLe contenu du fichier est : ");

                foreach (string line in contenuFichier)
                {

                    Console.WriteLine(line);
                    
                }

                Console.WriteLine("\tVeuillez saisir votre recherche : ");

                string saisie = Console.ReadLine();


                foreach (string line in contenuFichier)
                {

                    if (line.ToUpper().Contains(saisie.ToUpper()))
                    {
                        Console.WriteLine(""+ "\t" + line + "   -----  situé à l'index = " + contenuFichier.IndexOf(line));
                        IndexRecherche = contenuFichier.IndexOf(line);
                        ResultatRecherche = line;
                    }
                }
                    
            }
            else
            {
                Console.WriteLine("Le fichier n'a pas été trouvé.");
            }
        }

        
        //METHODE POUR SUPPRIMER UN VOYAGE
        public void Supprimer()
        {

            if (File.Exists(CheminFichier))
            {
   
                Consulter();
                Console.WriteLine("\r\n\tQuelle ligne de voyage voulez-vous supprimer ?\r\n");

                int lineToDelete = Int32.Parse(Console.ReadLine()) - 1;
                List<string> Lines = File.ReadAllLines(CheminFichier).ToList();
                Lines.RemoveAt(lineToDelete);
                
                Console.WriteLine("Voulez-vous vraiment supprimer ?");
                string choix = Console.ReadLine();

                if (choix == "oui")
                {
                    File.WriteAllLines(CheminFichier, Lines.ToArray());
                }

            }
            else
            {
                Console.WriteLine("Le fichier n'a pas été trouvé.");
            }
            
        }
        

        //METHODE POUR VERIFIER LA SOLVABILITE CLIENT
        public void VerifierSolvabilite()
        {

            Console.WriteLine("\r\n\t***********************************************\r\n\tFonctionnalité à venir.\r\n");


        }
    

        //METHODE POUR VERIFIER LE NOMBRE PLACES DISPONIBLE
        public void VerifierNbPlaces()
        {


            Console.WriteLine("\r\n\t***********************************************\r\n\tFonctionnalité à venir.\r\n");

        }

    }

}
