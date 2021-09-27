using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using BLL;
using System.Data.SqlClient;
using System.Data;


namespace Encode
{
    public partial class Index : System.Web.UI.Page
    {
        SuscriptorBLL suscriptorBLL = new SuscriptorBLL();
       
        int id = 0;
        bool nuevo = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{ }
            txtEstado.Enabled = false;
            DeshabilitarCampos();
            btnModificar.Enabled = false;
            btnRegistrarSuscripcion.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnNuevo.Enabled = false;
            btnBajaSuscripcion.Enabled = false;
        }

        public Suscriptor BuscarSuscriptor(string tipoDoc, string nroDoc)
        {
            Suscriptor suscriptor = suscriptorBLL.BuscarSuscriptor(tipoDoc, nroDoc);
            if (suscriptor == null)
            {    
                //FUNCION MODAL
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "funcionModal();", true);
                btnBuscar.Enabled = true;
                cboTipoDoc.Focus();
                return suscriptor;
            }

            if (tipoDoc == suscriptor.TipoDocumento && nroDoc == suscriptor.NumeroDocumento)
            {
                id = suscriptor.IdSuscriptor;
                ViewState["idSuscriptor"] = id;
                txtNombre.Text = suscriptor.NombreSuscriptor;
                txtApellido.Text = suscriptor.ApellidoSuscriptor;
                txtDireccion.Text = suscriptor.Direccion;
                txtEmail.Text = suscriptor.Email;
                txtTelefono.Text = suscriptor.NroTelefono;
                txtNombreUsuario.Text = suscriptor.NombreUsuario;
                txtContrasenia.Text = suscriptor.Contrasenia;

                DeshabilitarCampos();
                btnModificar.Enabled = true;
                return suscriptor;
            }
            else
            {
                return suscriptor;
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cboTipoDoc.SelectedIndex.Equals(0) || txtDocumento.Text.Equals(""))
            {
                /*ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe completar Tipo y Numero de Documento del suscriptor')", true);*/
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> swal('Atencion!', 'Debe completar Tipo y Numero de Documento del suscriptor', 'warning') </script>");
            }
            else
            {
                Suscriptor suscriptor = BuscarSuscriptor(cboTipoDoc.SelectedValue, txtDocumento.Text);
                if (suscriptor != null)
                   {
                    SuscripcionBLL suscripcion = new SuscripcionBLL();                    
                    if (suscripcion.VerificarSus(suscriptor))
                    {                       
                        ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> swal('Exito!', 'El suscriptor tiene una suscripción vigente.', 'success') </script>");
                        txtEstado.Text = "Suscripto";
                        btnRegistrarSuscripcion.Enabled = false;
                        btnNuevo.Enabled = false;
                        btnCancelar.Enabled = false;

                        //activar boton BAJA DE SUSCRIPTOR
                        btnBajaSuscripcion.Enabled = true;
                    }
                    else
                    {
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('No tiene Suscripcion')", true);
                        ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> swal('Atencion!', 'No hay una suscripción vigente.', 'warning') </script>");
                        txtEstado.Text = "No Suscripto";
                        btnRegistrarSuscripcion.Enabled = true;
                        btnNuevo.Enabled = false;
                    }                   
                    
                }
                else
                   {
                    //ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> swal('holaaaaaa!', 'No esta suscripto', 'warning') </script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('No tiene Suscripcion')", true);
                    btnRegistrarSuscripcion.Enabled = false;

                    LimpiarDatosSuscriptor();
                   }
                DeshabilitarCampos();
                
            }
            
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
            LimpiarDatosSuscriptor();
            txtNombre.Focus();
            btnGuardar.Enabled = true;
            btnNuevo.Enabled = false;
            nuevo = true;
            ViewState["variableNuevo"] = nuevo;
            btnRegistrarSuscripcion.Enabled = false;
            cboTipoDoc.Enabled = false;
            txtDocumento.Enabled = false;
            btnBuscar.Enabled = false;
            btnCancelar.Enabled = true;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Esta por modificar un suscriptor')", true);
            ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> swal('Atencion!', 'Esta por modificar un suscriptor!', 'info') </script>");
            cboTipoDoc.Enabled = false;
            txtDocumento.Enabled = false;
            HabilitarCampos();
            nuevo = false;
            ViewState["variableNuevo"] = nuevo;
            txtNombreUsuario.Enabled = false;
            btnGuardar.Enabled = true;
            btnNuevo.Enabled = false;
            btnCancelar.Enabled = true;
        }

        public bool Insertar(string nombre, string apellido, string numeroDocumento, string tipoDocumento, string direccion, string telefono, string email, string nombreUsuario, string pass)
        {
            SuscriptorBLL suscriptorBLL = new SuscriptorBLL();
            Suscriptor suscriptor = new Suscriptor();

            suscriptor.NombreSuscriptor = nombre;
            suscriptor.ApellidoSuscriptor = apellido;
            suscriptor.NumeroDocumento = numeroDocumento;
            suscriptor.TipoDocumento = tipoDocumento;
            suscriptor.Direccion = direccion;
            suscriptor.NroTelefono = telefono;
            suscriptor.Email = email;
            suscriptor.NombreUsuario = nombreUsuario;
            suscriptor.Contrasenia = pass;
            return suscriptorBLL.Insertar(suscriptor);
        }

        public bool Modificar(string nombre, string apellido, string nroDocumento, string direccion, string telefono, string email, string pass)
        {
            SuscriptorBLL suscriptorBLL = new SuscriptorBLL();
            Suscriptor suscriptor = new Suscriptor();

            suscriptor.NombreSuscriptor = nombre;
            suscriptor.ApellidoSuscriptor = apellido;
            suscriptor.NumeroDocumento = nroDocumento;
            suscriptor.Direccion = direccion;
            suscriptor.NroTelefono = telefono;
            suscriptor.Email = email;
            
            suscriptor.Contrasenia = pass;
            return suscriptorBLL.ModificarSuscriptor(suscriptor);

        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            
            string vacio = CamposVacios();
            if (vacio != "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Falta completar Datos:\\n" + vacio + "')", true);
                HabilitarCampos();
                btnGuardar.Enabled = true;
                btnCancelar.Enabled = true;
            }
            else
            {
                nuevo = (bool)ViewState["variableNuevo"];
                //almacena los datos sin enviar el formulario
                if (nuevo)
                {
                    if (suscriptorBLL.ValidarNombreUsuario(txtNombreUsuario.Text)>0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Este nombre de usuario ya existe!')", true);
                        HabilitarCampos();
                        btnGuardar.Enabled = true;
                        btnCancelar.Enabled = true;
                        //btnBuscar.Enabled = false;
                    }
                    else
                    {
                        Insertar(txtNombre.Text, txtApellido.Text, txtDocumento.Text, cboTipoDoc.Text, txtDireccion.Text, txtTelefono.Text, txtEmail.Text, txtNombreUsuario.Text, txtContrasenia.Text);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Datos cargados con exito!')", true);
                        btnGuardar.Enabled = true;
                        btnCancelar.Enabled = true;
                        btnRegistrarSuscripcion.Enabled = true;
                    }
                }
                else
                {
                    Modificar(txtNombre.Text, txtApellido.Text, txtDocumento.Text, txtDireccion.Text, txtTelefono.Text, txtEmail.Text, txtContrasenia.Text);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Modificacion con exito!')", true);
                    DeshabilitarCampos();
                    btnGuardar.Enabled = true;
                    btnCancelar.Enabled = true;
                    btnRegistrarSuscripcion.Enabled = true;
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            txtDocumento.Enabled = true;
            cboTipoDoc.Enabled = true;
            cboTipoDoc.Focus();
            DeshabilitarCampos();
            cboTipoDoc.SelectedItem.Equals(0);
            btnBuscar.Enabled = true;
        }

        public Suscripcion RegistrarSuscripcion()
        {
            Suscriptor suscriptor = suscriptorBLL.BuscarSuscriptor(cboTipoDoc.SelectedValue, txtDocumento.Text);
            Suscripcion suscripcion = new Suscripcion();
            SuscripcionBLL suscripcionBLL = new SuscripcionBLL();
            suscripcion.IdSuscriptor = suscriptor.IdSuscriptor;
            return suscripcionBLL.RegistrarSuscripcion(suscriptor);
        }

        protected void btnRegistrarSuscripcion_Click(object sender, EventArgs e)
        {
            RegistrarSuscripcion();
            //ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> swal('Hecho!', 'Suscripcion realizada con exito!', 'success') </script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Suscripcion realizada con exito!')", true);
            LimpiarCampos();
            cboTipoDoc.Focus();            

        }

        public bool BajaSuscripcion()
        {
            int idEliminar = Convert.ToInt32((ViewState["idSuscriptor"]).ToString());
            Suscriptor suscriptor = new Suscriptor();
            suscriptor.IdSuscriptor = idEliminar;
            
            //Suscripcion suscripcion = new Suscripcion();
            SuscripcionBLL suscripcionBLL = new SuscripcionBLL();
            return suscripcionBLL.BajaSuscripcion(suscriptor);
            
        }

        protected void btnBajaSuscripcion_Click(object sender, EventArgs e)
        {
            //BAJA SUSCRIPCION
            BajaSuscripcion();
            ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> swal('Exito!', 'Se elimino la suscripcion!', 'info') </script>");
            LimpiarCampos();
            cboTipoDoc.Focus();
        }

        public void DeshabilitarCampos()
        {
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtDireccion.Enabled = false;
            txtEmail.Enabled = false;
            txtTelefono.Enabled = false;
            txtNombreUsuario.Enabled = false;
            txtContrasenia.Enabled = false;
        }

        public void HabilitarCampos()
        {
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtDireccion.Enabled = true;
            txtEmail.Enabled = true;
            txtTelefono.Enabled = true;
            txtNombreUsuario.Enabled = true;
            txtContrasenia.Enabled = true;
        }

        public void LimpiarCampos()
        {
            cboTipoDoc.SelectedIndex = 0;
            txtDocumento.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            txtNombreUsuario.Text = "";
            txtContrasenia.Text = "";
        }

        public void LimpiarDatosSuscriptor()
        {            
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            txtNombreUsuario.Text = "";
            txtContrasenia.Text = "";
        }

        public string CamposVacios()
        {
            string faltanDatos = "";
            if (cboTipoDoc.SelectedItem.Equals(0))
            {
                faltanDatos += "Seleccionar tipo dni\\n";
                cboTipoDoc.Focus();
            }
            if (String.IsNullOrEmpty(txtDocumento.Text))
            {
                faltanDatos += "Debe completar numero de documento\\n";
                txtDocumento.Focus();
            }
            if (String.IsNullOrEmpty(txtNombre.Text))
            {
                faltanDatos += "Debe completar campo nombre\\n";
                txtNombre.Focus();
            }
            if (String.IsNullOrEmpty(txtApellido.Text))
            {
                faltanDatos += "Debe completar campo apellido\\n";
                txtApellido.Focus();
            }
            if (String.IsNullOrEmpty(txtDireccion.Text))
            {
                faltanDatos += "Debe completar campo direccion\\n";
                txtDireccion.Focus();
            }
            if (String.IsNullOrEmpty(txtEmail.Text))
            {
                faltanDatos += "Debe completar campo email\\n";
                txtEmail.Focus();
            }
            if (String.IsNullOrEmpty(txtTelefono.Text))
            {
                faltanDatos += "Debe completar campo telefono\\n";
                txtTelefono.Focus();
            }
            if (String.IsNullOrEmpty(txtNombreUsuario.Text))
            {
                faltanDatos += "Debe completar campo nombre usuario\\n";
                txtNombre.Focus();
            }
            if (String.IsNullOrEmpty(txtContrasenia.Text))
            {
                faltanDatos += "Debe completar campo contrasenia\\n";
                txtContrasenia.Focus();

            }
            return faltanDatos;
        }

        
    }
}