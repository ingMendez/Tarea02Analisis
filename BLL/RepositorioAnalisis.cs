using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioAnalisis : Repositorio<Analisis>
    {
        public override bool Guardar(Analisis analisis)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Analisis.Add(analisis) != null)

                    foreach (var item in analisis.Detalle)
                    {
                        contexto.TipoAnalisis.Find(item.TipoId).CantidadHechos += 1;
                    }
                contexto.Persona.Find(analisis.PersonaId).Deuda += analisis.Balance;
                contexto.SaveChanges();
                paso = true;

                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
    }
}
