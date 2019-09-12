using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class TipoAnalisis
    {
        [Key]

        public int TipoId { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int CantidadHechos { get; set; }

        public TipoAnalisis()
        {
            this.TipoId = 0;
            this.Descripcion = string.Empty;
            this.Precio = 0;
            this.CantidadHechos = 0;
        }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
