<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Encode.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css" integrity="sha384-B0vP5xmATw1+K9KRQjQERJvTumQW0nPEzvF6L/Z6nronJ3oUOFUFpCjEUQouq2+l" crossorigin="anonymous"/>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <title></title>
</head>
<body>
    <form class="container-fluid" id="form1" runat="server">
        <h1>Suscripcion</h1>
        <h6>Para realizar la suscripcion complete los siguientes datos</h6>
        <h3>Buscar Suscriptor</h3>
        <%-----------------------BUSCAR-------------------------------------%>
        <div class="form-row align-items-center">
            <div class="col">
                <label for="validationCustom01">Tipo Documento</label>
                <asp:DropDownList ID="cboTipoDoc" runat="server" CssClass="form-control">
                          <asp:ListItem Text="Seleccione un tipo de documento..."/>
                          <asp:ListItem Text="DNI"/>
                          <asp:ListItem Text="LC"/>
                          <asp:ListItem Text="PASAPORTE"/>
                </asp:DropDownList>
            </div>
            <div class="col">
                <label for="validationCustom01">Numero de Documento</label>
                <label class="sr-only" for="inlineFormInputGroup">Username</label>
                <div class="input-group">
                    <%--<input type="text" class="form-control" id="inlineFormInputGroup" placeholder="123456">--%>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtDocumento" placeholder="Numero documento"/>                    
                </div>
            </div>
            <div class="col">
                <%--<button type="submit" class="btn btn-success mt-4 btn-lg">Buscar</button>--%>
                <asp:Button runat="server" ID="btnBuscar" CssClass="btn btn-success mt-4 btn-lg" Text="Buscar" OnClick="btnBuscar_Click"/>
            </div>
        </div>
        <%-------------------------NUEVO-----------------------------------%>
        <h3>Datos del Suscriptor</h3>
        <div class="form-row align-items-center">
            <div class="col">
                <label for="validationCustom01">Nombre</label>
                <label class="sr-only" for="inlineFormInput">Name</label>
                <%--<input type="text" class="form-control mb-2" id="inlineFormInput" placeholder="Juan">--%>
                <asp:TextBox runat="server" CssClass="form-control mb-2" ID="txtNombre" placeholder="Nombre"/>
            </div>
            <div class="col">
                <label for="validationCustom01">Apellido</label>
                <label class="sr-only" for="inlineFormInputGroup">Username</label>
                <div class="input-group mb-2">
                    <%--<input type="text" class="form-control" id="inlineFormInputGroup" placeholder="Perez">--%>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido" placeholder="Apellido"/>
                </div>
            </div>
            <div class="col">
                <%--<button type="submit" class="btn btn-info mt-4 btn-lg">Nuevo</button>--%>
                <asp:Button runat="server" ID="btnNuevo" CssClass="btn btn-success mt-4 btn-lg" Text="Nuevo" OnClick="btnNuevo_Click"/>
            </div>
        </div>
        <%--------------------------MODIFICAR----------------------------------%>
        
        <div class="form-row align-items-center">
            <div class="col">
                <script>

                </script>
                <label for="validationCustom01">Direccion</label>
                <label class="sr-only" for="inlineFormInput">Name</label>
                <%--<input type="text" class="form-control mb-2" id="inlineFormInput" placeholder="Bolivar 123">--%>
                <asp:TextBox runat="server" CssClass="form-control mb-2" ID="txtDireccion" placeholder="Direccion"/>
            </div>
            <div class="col">
                <label for="validationCustom01">Email</label>
                <label class="sr-only" for="inlineFormInputGroup">Username</label>
                <div class="input-group mb-2">
                    <%--<input type="text" class="form-control" id="inlineFormInputGroup" placeholder="jperez@encodesa.com.ar">--%>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" placeholder="@encodesa.com.ar"/>
                </div>
            </div>
            <div class="col">
                <%--<button type="submit" class="btn btn-primary mt-4 btn-lg">Modificar</button>--%>
                <asp:Button runat="server" ID="btnModificar" CssClass="btn btn-primary mt-4 btn-lg" Text="Modificar" OnClick="btnModificar_Click"/>
            </div>
        </div>
        <%---------------------------GUARDAR---------------------------------%>
        
        <div class="form-row align-items-center">
            <div class="col">
                <label for="validationCustom01">Telefono</label>
                <label class="sr-only" for="inlineFormInput">Name</label>
                <%--<input type="text" class="form-control mb-2" id="inlineFormInput" placeholder="156321564">--%>
                <asp:TextBox runat="server" CssClass="form-control mb-2" ID="txtTelefono" placeholder="Telefono"/>
            </div>
            <div class="col">
                <label for="validationCustom01">Estado</label>
                <label class="sr-only" for="inlineFormInputGroup">Username</label>
                <div class="input-group mb-2">
                    <%--<input type="text" class="form-control" id="inlineFormInputGroup" placeholder="No Suscripto">--%>
                    <asp:TextBox runat="server" CssClass="form-control mb-2" ID="txtEstado" placeholder="-"/>
                </div>
            </div>
            <div class="col">
                <%--<button type="submit" class="btn btn-success mt-4 btn-lg">Guardar</button>--%>
                <asp:Button runat="server" ID="btnGuardar" CssClass="btn btn-success mt-4 btn-lg" Text="Guardar" OnClick="btnGuardar_Click"/>
            </div>
        </div>
        <%----------------------------CANCELAR--------------------------------%>
        
        <div class="form-row align-items-center">
            <div class="col">
                <label for="validationCustom01">Nombre de usuario</label>
                <label class="sr-only" for="inlineFormInput">Name</label>
                <%--<input type="text" class="form-control mb-2" id="inlineFormInput" placeholder="jperez">--%>
                <asp:TextBox runat="server" CssClass="form-control mb-2" ID="txtNombreUsuario" placeholder="Usuario"/>
            </div>
            <div class="col">
                <label for="validationCustom01">Contraseña</label>
                <label class="sr-only" for="inlineFormInputGroup">Username</label>
                <div class="input-group mb-2">
                    <%--<input type="text" class="form-control" id="inlineFormInputGroup" placeholder="*******">--%>
                    <asp:TextBox runat="server" CssClass="form-control mb-2" ID="txtContrasenia" placeholder="********" type="password"/>
                </div>
            </div>
            <div class="col">
                <%--<button type="submit" class="btn btn-warning mt-4 btn-lg">Cancelar</button>--%>
                <asp:Button runat="server" ID="btnCancelar" CssClass="btn btn-warning mt-4 btn-lg" Text="Cancelar" OnClick="btnCancelar_Click"/>
            </div>
        </div>
        <%------------------------REGISTRAR SUSCRIPCION------------------------------------%>
        <%--<button type="button" class="btn btn-success mt-5 btn-lg">Registrar Suscripcion</button>--%>
        <asp:Button runat="server" ID="btnRegistrarSuscripcion" CssClass="btn btn-success mt-4 btn-lg" Text="Registrar Suscripcion" OnClick="btnRegistrarSuscripcion_Click"/>

    </form>
</body>
</html>
