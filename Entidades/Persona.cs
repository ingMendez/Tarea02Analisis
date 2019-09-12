using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Persona
    {
        [Key]
        public int PersonaId { get; set; }
        public string Nombres { get; set; }
        public int Deuda { get; set; }

        public Persona()
        {
            PersonaId = 0;
            Nombres = string.Empty;
            Deuda = 0;
        }
    }
}
