using BLL;
using Entidades;
using ProyectoAnalisis.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAnalisis.Regsitros
{
    public partial class rPersona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private Persona LlenaClase()
        {
            Persona persona = new Persona();

            persona.PersonaId = Convert.ToInt32(PersonaIdTextBox.Text);
            persona.Nombres = nombreTextBox.Text;
            persona.Deuda = 0;
            return persona;
        }

        private void Limpiar()
        {
            PersonaIdTextBox.Text = "0";
            nombreTextBox.Text = "";
        }

        private bool Validar()
        {
            bool estado = false;

            if (String.IsNullOrWhiteSpace(PersonaIdTextBox.Text))
            {
                Utils.ShowToastr(this, "Id fuera de rango", "Error", "error");
                estado = true;
            }
            else if (!String.IsNullOrWhiteSpace(PersonaIdTextBox.Text))
            {
                if (Convert.ToInt32(PersonaIdTextBox.Text) < 0)
                {
                    Utils.ShowToastr(this, "Id fuera de rango", "Error", "error");
                    estado = true;
                }
            }

            if (String.IsNullOrWhiteSpace(nombreTextBox.Text))
            {
                Utils.ShowToastr(this, "No puede estar vacio", "Error", "error");
                estado = true;
            }

            return estado;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Persona> repositorio = new Repositorio<Persona>();
            int id = Convert.ToInt32(PersonaIdTextBox.Text);
            Persona persona = repositorio.Buscar(id);

            if (persona != null)
            {
                Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
                nombreTextBox.Text = persona.Nombres;
                DeudaTextBox.Text = persona.Deuda.ToString();
            }
            else
                Utils.ShowToastr(this, "No se encontró", "Error", "error");
        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void guardarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Persona> repositorio = new Repositorio<Persona>();
            bool estado = false;
            Persona persona = new Persona();

            if (Validar())
            {
                return;
            }
            else
            {
                persona = LlenaClase();

                if (Convert.ToInt32(PersonaIdTextBox.Text) == 0)
                {
                    estado = repositorio.Guardar(persona);
                    Utils.ShowToastr(this, "Guardado", "Exito", "success");
                    Limpiar();
                }
                else
                {
                    Repositorio<Persona> repo = new Repositorio<Persona>();
                    int id = Convert.ToInt32(PersonaIdTextBox.Text);
                    Persona pers = new Persona();
                    pers = repo.Buscar(id);

                    if (pers != null)
                    {
                        estado = repo.Modificar(LlenaClase());
                        Utils.ShowToastr(this, "Modificado", "Exito", "success");
                    }
                    else
                        Utils.ShowToastr(this, "Id no existe", "Error", "error");
                }

                if (estado)
                {
                    Limpiar();
                }
                else
                    Utils.ShowToastr(this, "No se pudo guardar", "Error", "error");
            }
        }

        protected void eliminarutton_Click(object sender, EventArgs e)
        {
            Repositorio<Persona> repositorio = new Repositorio<Persona>();
            int id = Utils.ToInt(PersonaIdTextBox.Text);

            var Persona = repositorio.Buscar(id);

            if (Persona != null)
            {
                if (repositorio.Eliminar(id))
                {
                    Utils.ShowToastr(this, "Eliminado", "Exito", "success");
                    Limpiar();
                }
                else
                    Utils.ShowToastr(this, "No se pudo eliminar", "Error", "error");
            }
            else
                Utils.ShowToastr(this, "No existe", "Error", "error");
        }
    }
}