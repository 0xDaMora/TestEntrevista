using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestTrabajo.Controllers;

namespace TestTrabajo
{
    public partial class Addtosql : System.Web.UI.Page
    {
        //Uso el modelo de entity framework de la bd de sql server local.
        private TestEntrevistaEntities db = new TestEntrevistaEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }


        //Boton para Guardar Registros en la tabla "registros" de la bd "TestEntrevista"
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            //Utilizo el controlador creado con Entity Framework
            registrosController controller = new registrosController();

            // Crear instancia del modelo registros
            registros nuevoRegistro = new registros();

            // Asignar valores ingresados por el usuario a las propiedades del modelo
            nuevoRegistro.nombre = TxNombre.Text;
            nuevoRegistro.idioma = DdlIdioma.SelectedValue;
            nuevoRegistro.descripcion = TxDescripcion.Text;

            // Agregar la instancia al contexto de la base de datos
            controller.Create(nuevoRegistro);

           

            // Actualizar la tabla en la vista
            GridRegistros.DataSource = db.registros.ToList();
            GridRegistros.DataBind();
        }


    }
}