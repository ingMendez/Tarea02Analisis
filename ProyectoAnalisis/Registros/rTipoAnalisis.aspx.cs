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
    public partial class rTipoAnalisis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private TipoAnalisis LlenaClase()
        {
            TipoAnalisis tipo = new TipoAnalisis();

            tipo.TipoId = Convert.ToInt32(TipoIdTextBox.Text);
            tipo.Descripcion = DescripcionTextBox.Text;
            tipo.Precio = Convert.ToInt32(PrecioTextBox.Text);
            tipo.CantidadHechos = 0;

            return tipo;
        }

        private void Limpiar()
        {
            TipoIdTextBox.Text = "0";
            DescripcionTextBox.Text = "";
            PrecioTextBox.Text = "";
            RealizadosTextBox.Text = "";
        }

        private bool Validar()
        {
            bool estado = false;

            if (String.IsNullOrWhiteSpace(TipoIdTextBox.Text))
            {
                Utils.ShowToastr(this, "Id fuera de rango", "Error", "error");
                estado = true;
            }
            else if (!String.IsNullOrWhiteSpace(TipoIdTextBox.Text))
            {
                if (Convert.ToInt32(TipoIdTextBox.Text) < 0 )
                {
                    Utils.ShowToastr(this, "Id fuera de rango", "Error", "error");
                    estado = true;
                }
            }                

            if (String.IsNullOrWhiteSpace(DescripcionTextBox.Text))
            {
                Utils.ShowToastr(this, "No puede estar vacio", "Error", "error");
                estado = true;
            }

            return estado;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Repositorio<TipoAnalisis> repositorio = new Repositorio<TipoAnalisis>();
            int id = Convert.ToInt32(TipoIdTextBox.Text);
            TipoAnalisis tipo = repositorio.Buscar(id);

            if (tipo != null)
            {
                Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
                DescripcionTextBox.Text = tipo.Descripcion;
                PrecioTextBox.Text = tipo.Precio.ToString();
                RealizadosTextBox.Text = tipo.CantidadHechos.ToString();
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
            Repositorio<TipoAnalisis> repositorio = new Repositorio<TipoAnalisis>();
            bool estado = false;
            TipoAnalisis tipo = new TipoAnalisis();

            if (Validar())
            {
                return;
            }
            else
            {
                tipo = LlenaClase();

                if (Convert.ToInt32(TipoIdTextBox.Text) == 0)
                {
                    estado = repositorio.Guardar(tipo);
                    Utils.ShowToastr(this, "Guardado", "Exito", "success");
                    Limpiar();
                }
                else
                {
                    Repositorio<TipoAnalisis> repo = new Repositorio<TipoAnalisis>();
                    int id = Convert.ToInt32(TipoIdTextBox.Text);
                    TipoAnalisis tiposAnalisis = new TipoAnalisis();
                    tiposAnalisis = repo.Buscar(id);

                    if (tiposAnalisis != null)
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
            Repositorio<TipoAnalisis> repositorio = new Repositorio<TipoAnalisis>();
            int id = Utils.ToInt(TipoIdTextBox.Text);

            var Tipo = repositorio.Buscar(id);

            if (Tipo != null)
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