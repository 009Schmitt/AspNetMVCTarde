using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteDaTarde.Models
{
    public class Cachorro
    {
        public string Nome { get; set; }
        public string NomeDoDono { get; set; }
        public int Idade { get; set; }        
        public bool IsDocil { get; set; }
    }
}
