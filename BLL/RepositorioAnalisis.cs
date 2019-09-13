using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        public override bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                Analisis analisis = contexto.Analisis.Find(id);

                foreach (var item in analisis.Detalle)
                {
                    var EliminInventario = contexto.TipoAnalisis.Find(item.TipoId);
                    EliminInventario.CantidadHechos -=1;
                }

                contexto.Persona.Find(analisis.PersonaId).Deuda -= analisis.Balance;

                contexto.Analisis.Remove(analisis);

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        public override Analisis Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Analisis analisis = new Analisis();
            try
            {
                analisis = contexto.Analisis.Find(id);

                if (analisis != null)
                {
                    analisis.Detalle.Count();

                    foreach (var item in analisis.Detalle)
                    {
                        string s = item.TipoId.ToString();
                        string ss = item.AnalisisId.ToString();
                    }
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return analisis;
        }


        public override List<Analisis> GetList(Expression<Func<Analisis, bool>> expression)
        {
            List<Analisis> list = new List<Analisis>();
            Contexto contexto = new Contexto();
            try
            {
                list = contexto.Analisis.Where(expression).ToList();

                foreach (var item in list)
                {
                    item.Detalle.Count();
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }
    }
}
