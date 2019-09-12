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
    public partial class rAnalisis : System.Web.UI.Page
    {
        public Analisis analisis = new Analisis();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                LlenaCombo();
                ViewState["Detalle"] = new Analisis().Detalle;
            }
        }

        private void LlenaCombo()
        {
            Repositorio<Persona> repositorio = new Repositorio<Persona>();
            Repositorio<TipoAnalisis> repo = new Repositorio<TipoAnalisis>();

            PersonaDropDownList.DataSource = repositorio.GetList(t => true);
            PersonaDropDownList.DataValueField = "PersonaId";
            PersonaDropDownList.DataTextField = "Nombres";
            PersonaDropDownList.DataBind();

            TipoAnalisisDropDownList.DataSource = repo.GetList(t => true);
            TipoAnalisisDropDownList.DataValueField = "TipoId";
            TipoAnalisisDropDownList.DataTextField = "Descripcion";
            TipoAnalisisDropDownList.DataBind();
        }

        public Analisis LlenarClase()
        {
            Analisis anali = new Analisis();

            anali.AnalisisId = Utils.ToInt(IdTextBox.Text);
            bool resultado = DateTime.TryParse(fechaTextBox.Text, out DateTime fecha);
            anali.Fecha = fecha;
            anali.PersonaId = Utils.ToIntObjetos(PersonaDropDownList.SelectedValue);
            anali.Balance = Utils.ToInt(BalanceTextBox.Text);

            anali.Detalle = (List<AnalisisDetalle>)ViewState["Detalle"];

            return anali;
        }

        public void LlenarCampos(Analisis anali)
        {
            List<AnalisisDetalle> detalles = anali.Detalle;
            ViewState["Detalle"] = detalles;
            fechaTextBox.Text = anali.Fecha.ToString("yyyy-MM-dd");
            PersonaDropDownList.SelectedValue = anali.PersonaId.ToString();
            detalleGridView.DataSource = ViewState["Detalle"];
            detalleGridView.DataBind();
            BalanceTextBox.Text = anali.Balance.ToString();
        }

        protected void Limpiar()
        {
            IdTextBox.Text = "0";
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            PersonaDropDownList.SelectedIndex = 0;
            TipoAnalisisDropDownList.SelectedIndex = 0;
            ResultadoTextBox.Text = "0";
            BalanceTextBox.Text = "";
            detalleGridView.DataSource = null;
            detalleGridView.DataBind();
        }

        private bool Validar()
        {
            bool estato = false;

            if (detalleGridView.Rows.Count == 0)
            {
                Utils.ShowToastr(this, "Debe agregar.", "Error", "error");
                estato = true;
            }
            if (Utils.ToIntObjetos(PersonaDropDownList.SelectedValue) < 1)
            {
                Utils.ShowToastr(this, "Todavía no hay un Cliente guardado.", "Error", "error");
                estato = true;
            }
            if (Utils.ToIntObjetos(TipoAnalisisDropDownList.SelectedValue) < 1)
            {
                Utils.ShowToastr(this, "Todavía no hay un Producto guardado.", "Error", "error");
                estato = true;
            }
            if (String.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                Utils.ShowToastr(this, "Debe tener un Id para guardar", "Error", "error");
                estato = true;
            }
            return estato;
        }

        private void ContarAnalisis()
        {
            int cantidad = 0;
            List<AnalisisDetalle> lista = (List<AnalisisDetalle>)ViewState["Detalle"];
            cantidad = detalleGridView.Rows.Count;

            BalanceTextBox.Text = cantidad.ToString();
        }

        private void Prueba()
        {
            int cantidad = 0;
            List<AnalisisDetalle> lista = (List<AnalisisDetalle>)ViewState["Detalle"];
            foreach (var item in lista)
            {

            }
        }

        private void LlenaBalance()
        {
            int balance = 0;
            List<AnalisisDetalle> lista = (List<AnalisisDetalle>)ViewState["Detalle"];
            foreach (var item in lista)
            {
                balance += item.Precio;
            }
            
            BalanceTextBox.Text = balance.ToString();
        }

        private void LlenaPrecio()
        {
            int id = Utils.ToInt(TipoAnalisisDropDownList.SelectedValue);
            Repositorio<TipoAnalisis> repositorio = new Repositorio<TipoAnalisis>();
            List<TipoAnalisis> lista = repositorio.GetList(c => c.TipoId == id);
            foreach (var item in lista)
            {
                PrecioTextBox.Text = item.Precio.ToString();
            }
        }

        protected void agregarButton_Click(object sender, EventArgs e)
        {
            List<AnalisisDetalle> detalles = new List<AnalisisDetalle>();
            if (IsValid)
            {
                DateTime date = DateTime.Now.Date;

                int tipoId = Utils.ToIntObjetos(TipoAnalisisDropDownList.SelectedValue);
                string descripcion = Utils.Descripcion(tipoId);
                string resultado = ResultadoTextBox.Text;
                int precio = Utils.ToInt(PrecioTextBox.Text);
                if (String.IsNullOrWhiteSpace(ResultadoTextBox.Text))
                {
                    Utils.ShowToastr(this, "Debe escribir un Resultado para agregar", "Error", "error");
                    return;
                }
                else
                {
                    if (detalleGridView.Rows.Count != 0)
                    {
                        analisis.Detalle = (List<AnalisisDetalle>)ViewState["Detalle"];
                    }

                    AnalisisDetalle detalle = new AnalisisDetalle();
                    analisis.Detalle.Add(new AnalisisDetalle(0, detalle.AnalisisId, tipoId, descripcion, precio, resultado));

                    ViewState["Detalle"] = analisis.Detalle;
                    detalleGridView.DataSource = ViewState["Detalle"];
                    detalleGridView.DataBind();
                    LlenaBalance();
                }
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Analisis> repositorio = new Repositorio<Analisis>();

            var analis = repositorio.Buscar(Utils.ToInt(IdTextBox.Text));
            if (analis != null)
            {
                Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
                LlenarCampos(analis);
            }
            else
            {
                Limpiar();
                Utils.ShowToastr(this, "No existe la Factura especificada", "Error", "error");
            }
        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void guadarButton_Click(object sender, EventArgs e)
        {
            RepositorioAnalisis repositorio = new RepositorioAnalisis();
            //Repositorio<Analisis> repositorio = new Repositorio<Analisis>();
            bool estado = false;
            Analisis analis = new Analisis();

            if (Validar())
            {
                return;
            }
            else
            {
                analis = LlenarClase();

                if (Convert.ToInt32(IdTextBox.Text) == 0)
                {
                    estado = repositorio.Guardar(analis);
                    Utils.ShowToastr(this, "Guardado", "Exito", "success");
                    Limpiar();
                }
                else
                {
                    RepositorioAnalisis repo = new RepositorioAnalisis();
                    //Repositorio<Analisis> repo = new Repositorio<Analisis>();
                    int id = Convert.ToInt32(IdTextBox.Text);
                    Analisis anali = new Analisis();
                    anali = repo.Buscar(id);

                    if (anali != null)
                    {
                        estado = repo.Modificar(LlenarClase());
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

        protected void eliminarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Analisis> repositorio = new Repositorio<Analisis>();
            int id = Utils.ToInt(IdTextBox.Text);

            var Analisis = repositorio.Buscar(id);

            if (Analisis != null)
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

        protected void TipoAnalisisDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenaPrecio();
        }
    }
}