using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appli_Intranet.Controller
{
    class Accompagnant : Personne
    {
        public Accompagnant()
        {

        }

        private string client;

        public string Client { get => client; set => client = value; }

    }
}
