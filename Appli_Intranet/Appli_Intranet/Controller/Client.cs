using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appli_Intranet.Controller
{
    class Client : Personne
    {
        public Client()
        {

        }

        private string coordonneesBancaires;
        private string numeroSequentiel;
        private bool solvable;

        public string CoordonneesBancaires { get => coordonneesBancaires; set => coordonneesBancaires = value; }
        public string NumeroSequentiel { get => numeroSequentiel; set => numeroSequentiel = value; }
        public bool Solvable { get => solvable; set => solvable = value; }

    }
}
