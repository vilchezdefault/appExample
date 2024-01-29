using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using appEmpresaHH.Data;



namespace appEmpresaHH
{
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConsultarClientes();
        }

        public void Mensaje(string pMensaje)
        {
            Type cstype = this.GetType();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = Page.ClientScript;

            // Check to see if the startup script is already registered.
            if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
            {
                String cstext = "alert('" + pMensaje + "');";
                cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
            }
        }

        public void ConsultarClientes()
        {


            //Para inicializar el web service
           // empresaHH es el nombre de mi web service
            wsEmpresaHH.EmpresaHH ws = new wsEmpresaHH.EmpresaHH();


            //Crear la lista de productos 
            List<clCliente> lista = new List<clCliente>();

            //Obtenemos un array de clsCliente 
            wsEmpresaHH.clCliente[] wsClientes = ws.ConsultarClienteS();

            foreach (wsEmpresaHH.clCliente item in wsClientes)
            {
                lista.Add(new clCliente
                {
                    id_cliente_prop = item.id_cliente_prop,
                    nombre_completo_prop = item.nombre_completo_prop,
                    apellido_prop = item.apellido_prop,
                    apellido2_prop = item.apellido2_prop,
                    tipo_identificacion_prop = item.tipo_identificacion_prop,
                    numero_identificacion_prop = item.numero_identificacion_prop,                  
                    idUsuarioRGT_prop = item.idUsuarioRGT_prop,
                    fecha_registro_prop = item.fecha_registro_prop,
                    id_usuarioMDC_prop = item.id_usuarioMDC_prop,
                    fecha_modificacion_prop = item.fecha_modificacion_prop


                });
            }

            grdClientes.DataSource = null;
            grdClientes.DataBind();
            grdClientes.DataSource = lista;
            grdClientes.DataBind();

        }


        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            ViewState["vsModo"] = "I";
            txtid_cliente_prop.Text = "";
            txtnombre_completo_prop.Text = "";
            txtapellido_prop.Text = "";
            txtapellido2_prop.Text = "";
            txttipo_identificacion_prop.Text = "";
            txtnumero_identificacion_prop.Text = "";
            
            txtidUsuarioRGT_prop.Text = "";
            txtfecha_registro_prop.Text = "";
            txtid_usuarioMDC_prop.Text = "";
            txtfecha_modificacion_prop.Text = "";
            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string vModo = Convert.ToString(ViewState["vsModo"]);

            if (vModo == "I")
            {
                //Validar cada uno de los campos, los que no vengan nulos 
                RegistrarClienteS();
            }
            else
            {
                //Validar cada uno de los campos, los que no vengan nulos 
                ModificarClientes();
            }
        }

        protected void btnEliminarUsuario_Click(object sender, EventArgs e)
        {

            if (txtid_usuarioMDC_prop.Text == null || txtid_usuarioMDC_prop.Text == "")
            {
                Mensaje("Error para eliminar un usuario debe seleccionar el registro a eliminar");
            }
            else
            {
                EliminarClientes();
            }

        }

        protected void grdClientes_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                ViewState["vsModo"] = "M";

                clCliente vClienteSeleccionado = new clCliente();
                GridViewRow row = grdClientes.SelectedRow;

                vClienteSeleccionado.id_cliente_prop = Convert.ToInt32(row.Cells[0].Text);
                vClienteSeleccionado.nombre_completo_prop = row.Cells[1].Text;
                vClienteSeleccionado.apellido_prop = row.Cells[2].Text;
                vClienteSeleccionado.apellido2_prop = row.Cells[3].Text;
                vClienteSeleccionado.tipo_identificacion_prop = row.Cells[4].Text;
                vClienteSeleccionado.numero_identificacion_prop = row.Cells[5].Text;
                
                vClienteSeleccionado.idUsuarioRGT_prop = Convert.ToInt32(row.Cells[6].Text);
                vClienteSeleccionado.fecha_registro_prop = Convert.ToDateTime(row.Cells[7].Text);
                vClienteSeleccionado.id_usuarioMDC_prop = Convert.ToInt32(row.Cells[8].Text);
                vClienteSeleccionado.fecha_modificacion_prop = Convert.ToDateTime(row.Cells[9].Text);
                

                txtid_cliente_prop.Text = vClienteSeleccionado.id_cliente_prop.ToString();
                txtnombre_completo_prop.Text = vClienteSeleccionado.nombre_completo_prop.ToString();
                txtapellido_prop.Text = vClienteSeleccionado.apellido_prop.ToString();
                txtapellido2_prop.Text = vClienteSeleccionado.apellido2_prop.ToString();
                txttipo_identificacion_prop.Text = vClienteSeleccionado.tipo_identificacion_prop.ToString();
                txtnumero_identificacion_prop.Text = vClienteSeleccionado.numero_identificacion_prop.ToString();
                
                txtidUsuarioRGT_prop.Text = vClienteSeleccionado.idUsuarioRGT_prop.ToString();
                txtfecha_registro_prop.Text = vClienteSeleccionado.fecha_registro_prop.ToString();
                txtid_usuarioMDC_prop.Text = vClienteSeleccionado.id_usuarioMDC_prop.ToString();
                txtfecha_modificacion_prop.Text = vClienteSeleccionado.fecha_modificacion_prop.ToString();
               


            }
            catch (Exception)
            {

                throw;
            }
        }
        public void ModificarClientes()
        {
            //Para inicializar el web service
            wsEmpresaHH.EmpresaHH ws = new wsEmpresaHH.EmpresaHH();
            string vRespuesta = string.Empty;
            vRespuesta = ws.ModificarClienteS(Convert.ToInt32(txtid_cliente_prop.Text),
                                              txtnombre_completo_prop.Text,
                                              txtapellido_prop.Text,
                                              txtapellido2_prop.Text,
                                              txttipo_identificacion_prop.Text,
                                              txtnumero_identificacion_prop.Text,                                                                                
                                             Convert.ToInt32(txtid_usuarioMDC_prop.Text));
            ConsultarClientes();
            Mensaje(vRespuesta);
        }

        public void RegistrarClienteS()
        {
            //Para inicializar el web service
            wsEmpresaHH.EmpresaHH ws = new wsEmpresaHH.EmpresaHH();
            string vRespuesta = string.Empty;
            vRespuesta = ws.RegistrarClienteS(
                                              txtnombre_completo_prop.Text,
                                              txtapellido_prop.Text,
                                              txtapellido2_prop.Text,
                                              txttipo_identificacion_prop.Text,
                                              txtnumero_identificacion_prop.Text,                                           
                                              Convert.ToInt32(txtidUsuarioRGT_prop.Text));
            ConsultarClientes();
            Mensaje(vRespuesta);
        }


        public void EliminarClientes()
        {
            //Para inicializar el web service
            wsEmpresaHH.EmpresaHH ws = new wsEmpresaHH.EmpresaHH();
            string vRespuesta = string.Empty;
            vRespuesta = ws.EliminarClienteS(Convert.ToInt32(txtid_cliente_prop.Text),
                                             Convert.ToInt32(txtid_usuarioMDC_prop.Text));
            ConsultarClientes();
            Mensaje(vRespuesta);
        }
    }
}