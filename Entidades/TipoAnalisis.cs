using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoAnalisis
    {
        [Key]

        public int TipoId { get; set; }
        public string Descripcion { get; set; }

        public TipoAnalisis()
        {
            this.TipoId = 0;
            this.Descripcion = string.Empty;
        }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
