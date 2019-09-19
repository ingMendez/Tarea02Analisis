using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public static void ModificarBien(Analisis analisis, Analisis AnalisisAnteriores)
        {
            Contexto contexto = new Contexto();
            Repositorio<Persona> repositorio = new Repositorio<Persona>();
            Repositorio<Persona> repository = new Repositorio<Persona>();
            var Persona = contexto.Persona.Find(analisis.PersonaId);
            var PersonaAnterior = contexto.Persona.Find(AnalisisAnteriores.PersonaId);

            Persona.Deuda += analisis.Balance;
            PersonaAnterior.Deuda -= AnalisisAnteriores.Balance;
            repositorio.Modificar(Persona);
            repository.Modificar(PersonaAnterior);

        }    

        public override bool Modificar(Analisis analisis)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            Repositorio<Analisis> repositorio = new Repositorio<Analisis>();
            try
            {
                var AnalisisAnt = contexto.Analisis.Find(analisis.AnalisisId);

                if (analisis.PersonaId != AnalisisAnt.PersonaId)
                {
                    ModificarBien(analisis, AnalisisAnt);
                }

                if (analisis != null)
                {
                    foreach (var item in AnalisisAnt.Detalle)
                    {
                        contexto.TipoAnalisis.Find(item.TipoId).CantidadHechos += 1;

                        if (!analisis.Detalle.ToList().Exists(v => v.Id == item.Id))
                        {
                            item.TipoId = 0;
                            contexto.Entry(item).State = EntityState.Deleted;
                        }
                    }
                    //Limpiando el Contexto.
                    contexto = new Contexto();

                    foreach (var item in analisis.Detalle)
                    {
                        contexto.TipoAnalisis.Find(item.TipoId).CantidadHechos -= 1;
                        var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                        contexto.Entry(item).State = estado;
                    }
                    //Limpiando el Contexto.
                    //repositorio.Modificar(factura);
                    contexto.Entry(analisis).State = EntityState.Modified;
                }
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
                    EliminInventario.CantidadHechos -= 1;
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
