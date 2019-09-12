using BLL;
using Entidades;
using ProyectoAnalisis.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAnalisis.Registros
{
    public partial class rPago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                LlenaCombo();
            }
        }

        private void LlenaCombo()
        {
            Repositorio<Persona> repositorio = new Repositorio<Persona>();
            PersonaDropDownList.DataSource = repositorio.GetList(c => true);
            PersonaDropDownList.DataValueField = "PersonaId";
            PersonaDropDownList.DataTextField = "Nombres";
            PersonaDropDownList.DataBind();
        }

        private Pago LlenaClase()
        {
            Pago pago = new Pago();

            pago.PagoId = Utils.ToInt(IdTextBox.Text);
            bool resultado = DateTime.TryParse(fechaTextBox.Text, out DateTime fecha);
            pago.Fecha = fecha;
            pago.PersonaId = Utils.ToInt(PersonaDropDownList.SelectedValue);
            pago.Monto = Utils.ToInt(montoTextBox.Text);

            return pago;
        }

        private void Limpiar()
        {
            IdTextBox.Text = "0";
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            PersonaDropDownList.SelectedIndex = 0;
            montoTextBox.Text = "0";
        }

        public void LlenaCampos(Pago pago)
        {
            Limpiar();
            IdTextBox.Text = pago.PagoId.ToString();
            fechaTextBox.Text = pago.Fecha.ToString("yyyy-MM-dd");
            PersonaDropDownList.SelectedValue = pago.PersonaId.ToString();
            montoTextBox.Text = pago.Monto.ToString();
        }

        private bool Validar()
        {
            bool estado = false;
            if (Utils.ToIntObjetos(PersonaDropDownList.SelectedValue) < 1)
            {
                Utils.ShowToastr(this, "Debe tener al menos un Cliente guardado", "Error", "error");
                estado = true;
            }
            if (String.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                Utils.ShowToastr(this, "Debe tener un Id para guardar", "Error", "error");
                estado = true;
            }
            return estado;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioPago repositorio = new RepositorioPago();

            var pago = repositorio.Buscar(Utils.ToInt(IdTextBox.Text));
            if (pago != null)
            {
                LlenaCampos(pago);
                Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
            }
            else
            {
                Limpiar();
                Utils.ShowToastr(this, "No Hay Resultado", "Error", "error");
            }
        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void guardarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            RepositorioPago repositorio = new RepositorioPago();
            Pago pago = new Pago();

            if (Validar())
            {
                return;
            }
            else
            {
                pago = LlenaClase();

                if (IdTextBox.Text == "0")
                {
                    paso = repositorio.Guardar(pago);
                    Utils.ShowToastr(this, "Guardado", "Exito", "success");
                    Limpiar();
                }
                else
                {
                    RepositorioPago repository = new RepositorioPago();
                    int id = Utils.ToInt(IdTextBox.Text);
                    pago = repository.Buscar(id);

                    if (pago != null)
                    {
                        paso = repository.Modificar(LlenaClase());
                        Utils.ShowToastr(this, "Modificado", "Exito", "success");
                    }
                    else
                        Utils.ShowToastr(this, "Id no existe", "Error", "error");
                }
            }

            if (paso)
            {
                Limpiar();
            }
            else
                Utils.ShowToastr(this, "No se pudo guardar", "Error", "error");
        }

        protected void eliminarutton_Click(object sender, EventArgs e)
        {
            RepositorioPago repositorio = new RepositorioPago();
            int id = Utils.ToInt(IdTextBox.Text);

            var pago = repositorio.Buscar(id);

            if (pago != null)
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