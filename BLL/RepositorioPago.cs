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
    public class RepositorioPago : Repositorio<Pago>
    {
        public override bool Guardar(Pago pago)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Pago.Add(pago) != null)
                {
                    contexto.Persona.Find(pago.PersonaId).Deuda -= pago.Monto;

                    contexto.SaveChanges();
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


        public override bool Modificar(Pago pago)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            Repositorio<Pago> repositorio = new Repositorio<Pago>();
            Repositorio<Persona> repository = new Repositorio<Persona>();
            try
            {
                Pago PagoAnt = repositorio.Buscar(pago.PagoId);

                if (PagoAnt.PersonaId != pago.PersonaId)
                {
                    ModificarBien(pago, PagoAnt);
                }

                int modificado = pago.Monto - PagoAnt.Monto;

                var Persona = contexto.Persona.Find(pago.PersonaId);
                Persona.Deuda += modificado;
                repository.Modificar(Persona);

                //Limpiando el Contexto.
                contexto = new Contexto();
                contexto.Entry(pago).State = EntityState.Modified;
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


        public override bool Eliminar(int id)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                Pago pago = contexto.Pago.Find(id);

                contexto.Persona.Find(pago.PersonaId).Deuda += pago.Monto;

                contexto.Pago.Remove(pago);

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


        public override Pago Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Pago pago = new Pago();

            try
            {
                pago = contexto.Pago.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return pago;
        }


        public override List<Pago> GetList(Expression<Func<Pago, bool>> expression)
        {
            List<Pago> pagos = new List<Pago>();
            Contexto contexto = new Contexto();

            try
            {
                pagos = contexto.Pago.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return pagos;
        }

        public static void ModificarBien(Pago pago, Pago PagoAnterior)
        {
            Contexto contexto = new Contexto();
            var Persona = contexto.Persona.Find(pago.PersonaId);
            var PersonaAnterior = contexto.Persona.Find(PagoAnterior.PersonaId);
            Repositorio<Persona> repositorio = new Repositorio<Persona>();
            Repositorio<Persona> repository = new Repositorio<Persona>();

            Persona.Deuda += pago.Monto;
            PersonaAnterior.Deuda -= PagoAnterior.Monto;
            repositorio.Modificar(Persona);
            repository.Modificar(PersonaAnterior);
        }
    }
}
