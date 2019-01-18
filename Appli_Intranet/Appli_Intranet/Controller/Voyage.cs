using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appli_Intranet.Controller
{
    class Voyage
    {

        public Voyage()
        {

        }

        private DateTime dateAller;
        private DateTime dateRetour;
        private int nbVoyageur;
        private string client;
        private string destination;
        private int nbPlace;

        public DateTime DateAller { get => dateAller; set => dateAller = value; }
        public DateTime DateRetour { get => dateRetour; set => dateRetour = value; }
        public int NbVoyageur { get => nbVoyageur; set => nbVoyageur = value; }
        public string Client { get => client; set => client = value; }
        public string Destination { get => destination; set => destination = value; }
        public int NbPlace { get => nbPlace; set => nbPlace = value; }

    }
}
