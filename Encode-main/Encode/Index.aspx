<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Encode.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css" integrity="sha384-B0vP5xmATw1+K9KRQjQERJvTumQW0nPEzvF6L/Z6nronJ3oUOFUFpCjEUQouq2+l" crossorigin="anonymous"/>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <script src="js/JavaScript.js"></script>     
    <link href="css/StyleSheet1.css" rel="stylesheet"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.19.1/jquery.validate.min.js"></script>
    <title></title>
</head>
<body>
    <form class="container" id="formulario" runat="server">
        <h1>Suscripcion</h1>
        <h6>Para realizar la suscripcion complete los siguientes datos</h6>
        <h3>Buscar Suscriptor</h3>
        <%-----------------------BUSCAR-------------------------------------%>
        <div class="row" <%--class="form-row align-items-center"--%>>
            <div class="col-5">
                <label for="">Tipo Documento</label>
                <asp:DropDownList ID="cboTipoDoc" runat="server" CssClass="form-control">
                          <asp:ListItem Text="Seleccione un tipo de documento..."/>
                          <asp:ListItem Text="DNI"/>
                          <asp:ListItem Text="LC"/>
                          <asp:ListItem Text="PASAPORTE"/>
                </asp:DropDownList>
            </div>
            <div class="col-5">
                <label for="">Numero de Documento</label>                            
                  <asp:TextBox runat="server" CssClass="form-control" ID="txtDocumento" placeholder="Numero documento"/>                                  
            </div>
            <div class="col-2">
                <%--<button type="submit" class="btn btn-success mt-4 btn-lg">Buscar</button>--%>
                <asp:Button runat="server" ID="btnBuscar" CssClass="btn btn-success mt-4 btn-lg" Text="Buscar" OnClick="btnBuscar_Click" UseSubmitBehavior="False"/>
            </div>
        </div>
        <%-------------------------NUEVO-----------------------------------%>
        <h3>Datos del Suscriptor</h3>
        <div class="row" <%--form-row align-items-center"--%>>
            <div class="col-5">
                <label for="">Nombre</label>                
                <asp:TextBox runat="server" CssClass="form-control mb-2" ID="txtNombre" placeholder="Nombre" Font-Names=""/>
               </div>
            <div class="col-5">
                <label for="">Apellido</label>                                 
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido" placeholder="Apellido"/>              
            </div>
            <div class="col-2">                
                <asp:Button runat="server" ID="btnNuevo" CssClass="btn btn-success mt-4 btn-lg" Text="Nuevo" OnClick="btnNuevo_Click"/>
            </div>
        </div>
        <%--------------------------MODIFICAR----------------------------------%>
        
        <div class="row" <%--form-row align-items-center"--%>>
            <div class="col-5">              
                <label for="">Direccion</label>                              
                <asp:TextBox runat="server" CssClass="form-control mb-2" ID="txtDireccion" placeholder="Direccion"/>
            </div>
            <div class="col-5">
                <label for="">Email</label>                                 
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" placeholder="@encodesa.com.ar"/>
                </div>            
            <div class="col-2">                
                <asp:Button runat="server" ID="btnModificar" CssClass="btn btn-primary mt-4 btn-lg" Text="Modificar" OnClick="btnModificar_Click" UseSubmitBehavior="False"/>
            </div>
        </div>
       
        <%---------------------------GUARDAR---------------------------------%>
        
        <div class="row" <%--form-row align-items-center"--%>>
            <div class="col-5">
                <label for="">Telefono</label>                
                
                <asp:TextBox runat="server" CssClass="form-control mb-2" ID="txtTelefono" placeholder="Telefono"/>
            </div>
            <div class="col-5">
                <label for="">Estado</label>                                  
                    <asp:TextBox runat="server" CssClass="form-control mb-2" ID="txtEstado" placeholder="-"/>
                </div>            
            <div class="col-2">                
                <asp:Button runat="server" ID="btnGuardar" CssClass="btn btn-success mt-4 btn-lg" Text="Guardar" OnClick="btnGuardar_Click" UseSubmitBehavior="False"/>
            </div>
        </div>
        <%----------------------------CANCELAR--------------------------------%>

           <div class="row" <%--form-row align-items-center"--%>>
            <div class="col-5">
                <label for="">Nombre de usuario</label>                             
                <asp:TextBox runat="server" CssClass="form-control mb-2" ID="txtNombreUsuario" placeholder="Usuario"/>
            </div>
            <div class="col-5">
                <label for="">Contraseña</label>                   
                    <asp:TextBox runat="server" CssClass="form-control mb-2" ID="txtContrasenia" placeholder="********" type="password"/>
                </div>            
            <div class="col-2">               
                <asp:Button runat="server" ID="btnCancelar" CssClass="btn btn-warning mt-4 btn-lg" Text="Cancelar" OnClick="btnCancelar_Click" UseSubmitBehavior="False"/>
            </div>
        </div>        
        <%------------------------REGISTRAR SUSCRIPCION------------------------------------%>        
        <asp:Button runat="server" ID="btnRegistrarSuscripcion" CssClass="btn btn-success mt-4 btn-lg" Text="Registrar Suscripcion" OnClick="btnRegistrarSuscripcion_Click" UseSubmitBehavior="False"/>
        <asp:Button runat="server" ID="btnBajaSuscripcion" CssClass="btn btn-danger mt-4 btn-lg" Text="Baja Suscripcion" OnClick="btnBajaSuscripcion_Click" UseSubmitBehavior="False"/>
    </form>    
</body>      
<script>  
    $(document).ready(function () {
        $("#formulario").validate({
            rules: {
                /*cboTipoDoc: { required: true, minlength: 3, },*/
                txtDocumento: { required: true, minlength: 7, maxlength: 8, digits: true},
                txtNombre: { required: true, minlength: 3, maxlength: 30},
                txtApellido: { required: true, minlength: 3, maxlength: 30 },
                txtDireccion: { required: true, minlength: 4, maxlength: 30 },
                txtEmail: { required: true, email: true },
                txtTelefono: { required: true, minlength: 9, maxlength: 20 },
                /*txtEstado: { required: true, minlength: 4 },*/
                txtNombreUsuario: { required: true, minlength: 4, maxlength: 30 },
                txtContrasenia: { required: true, minlength: 4, maxlength: 15 },
            },
            messages: {
                //cboTipoDoc: {
                //    required: 'Por favor ingrese su nombre',
                //    minlength: 'Debe ingresar un minimo de 3 caracteres'
                //},
                txtDocumento: {
                    required: 'Ingrese numero de documento',
                    minlength: 'Debe ingresar un minimo de 7 caracteres',
                    maxlength: 'Debe ingresar un maximo de 8 caracteres',
                    digits: 'Debe Ingresar solo numeros'
                },
                txtNombre: {
                    required: 'Ingrese Nombre',
                    minlength: 'Debe ingresar un minimo de 3 caracteres',
                    maxlength: 'Debe ingresar un maximo de 30 caracteres'
                },
                txtApellido: {
                    required: 'Ingrese Apellido',
                    minlength: 'Debe ingresar un minimo de 3 caracteres',
                    maxlength: 'Debe ingresar un maximo de 30 caracteres'
                },
                txtDireccion: {
                    required: 'Ingrese una dirección',
                    minlength: 'Debe ingresar un minimo de 4 caracteres',
                    maxlength: 'Debe ingresar un maximo de 30 caracteres'
                },
                txtEmail: {
                    required: 'Ingresar una direccion de email',
                    email: 'Debe ingresar un email valido'
                },
                txtTelefono: {
                    required: 'Ingrese numero de telefono',
                    minlength: 'Debe ingresar un minimo de 9 caracteres',
                    maxlength: 'Debe ingresar un maximo de 20 caracteres',
                },
                //txtEstado: {
                //    required: 'Ingrese una contraseña',
                //    minlength: 'Debe ingresar un minimo de 4 caracteres'
                //},
                txtNombreUsuario: {
                    required: 'Ingrese nombre de usuario',
                    minlength: 'Debe ingresar un minimo de 4 caracteres',
                    maxlength: 'Debe ingresar un maximo de 30 caracteres',
                },
                txtContrasenia: {
                    required: 'Ingrese una contraseña',
                    minlength: 'Debe ingresar un minimo de 4 caracteres',
                    maxlength: 'Debe ingresar un maximo de 15 caracteres',
                }
            }
        });
    });
</script>
</html>




