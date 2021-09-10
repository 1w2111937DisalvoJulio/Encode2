﻿using System;
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
            txtEstado.Enabled = false;
            DeshabilitarCampos();
            btnModificar.Enabled = false;
            btnRegistrarSuscripcion.Enabled = false;
            btnGuardar.Enabled = false;
        }



        public bool BuscarSuscriptor(string tipoDoc, string nroDoc)
        {
            Suscriptor suscriptor = suscriptorBLL.BuscarSuscriptor(tipoDoc, nroDoc);
            if (suscriptor == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('No se encontro suscriptor!\\n Revisar Tipo documento y Numero documento')", true);
                cboTipoDoc.Focus();
                return false;
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
                return true;
            }
            else
            {
                return false;
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cboTipoDoc.SelectedIndex.Equals(0) || txtDocumento.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe completar Tipo y Numero de Documento del suscriptor')", true);
            }
            else
            {
                BuscarSuscriptor(cboTipoDoc.SelectedValue, txtDocumento.Text);
                DeshabilitarCampos();
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
            LimpiarCampos();
            cboTipoDoc.Focus();
            btnGuardar.Enabled = true;
            btnNuevo.Enabled = false;
            nuevo = true;
            ViewState["variableNuevo"] = nuevo;
            btnRegistrarSuscripcion.Enabled = true;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Esta por modificar un suscriptor')", true);
            cboTipoDoc.Enabled = false;
            txtDocumento.Enabled = false;
            HabilitarCampos();
            nuevo = false;
            ViewState["variableNuevo"] = nuevo;
            txtNombreUsuario.Enabled = false;
            btnGuardar.Enabled = true;
            btnNuevo.Enabled = false;
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

            }
            else
            {
                nuevo = (bool)ViewState["variableNuevo"];//almacena los datos sin enviar el form
                if (nuevo)
                {
                    Insertar(txtNombre.Text, txtApellido.Text, txtDocumento.Text, cboTipoDoc.Text, txtDireccion.Text, txtTelefono.Text, txtEmail.Text, txtNombreUsuario.Text, txtContrasenia.Text);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Datos cargados con exito!')", true);
                }
                else
                {
                    Modificar(txtNombre.Text, txtApellido.Text, txtDocumento.Text, txtDireccion.Text, txtTelefono.Text, txtEmail.Text, txtContrasenia.Text);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Modificacion con exito!')", true);
                    DeshabilitarCampos();
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            txtDocumento.Enabled = true;
            cboTipoDoc.Focus();
            cboTipoDoc.Enabled = true;
            cboTipoDoc.SelectedItem.Equals(0);
            HabilitarCampos();
        }

        //public bool RegistrarSuscripcion()
        //{
        //    Suscriptor suscriptor = suscriptorBLL.BuscarSuscriptor(cboTipoDoc.SelectedValue, txtDocumento.Text);
        //    Suscripcion suscripcion = new Suscripcion();
        //    SuscripcionBLL suscripcionBLL = new SuscripcionBLL();
        //    suscripcion.IdSuscriptor = suscriptor.IdSuscriptor;
        //    return suscripcionBLL.RegistrarSuscripcion(sus);
        //}

        protected void btnRegistrarSuscripcion_Click(object sender, EventArgs e)
        {
            //RegistrarSuscripcion();
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Suscripcion realizada con exito!')", true);
            
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