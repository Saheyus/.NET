using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appli_Intranet.Controller
{
    class Personne
    {

        public Personne()
        {

        }

        private string civilite;
        private string nom;
        private string prenom;
        private DateTime dateDeNaissance;
        private string adresse;
        private string telephone;

        public string Civilite { get => civilite; set => civilite = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public DateTime DateDeNaissance { get => dateDeNaissance; set => dateDeNaissance = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        


    }
}
