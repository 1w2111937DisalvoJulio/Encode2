function funcionModal() {
    swal({
        title: "Suscriptor no encontrado",
        text: "¿Desea registrar un nuevo suscriptor?",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                swal("Boton nuevo habilitado", {
                    icon: "success",
                });
                document.getElementById("btnNuevo").disabled = "";
                document.getElementById("btnBuscar").disabled = "";
                document.getElementById("btnCancelar").disabled = "";
                document.getElementById("btnRegistrarSuscripcion").disabled = "disabled";

            } else {
                document.getElementById("btnNuevo").disabled = "disabled";
                document.getElementById("btnCancelar").disabled = "";
                document.getElementById("btnRegistrarSuscripcion").disabled = "disabled";
            }
        });
}



//$(document).ready(function () {
//        $("#formulario").validate({
//            rules: {
//                /*cboTipoDoc: { required: true, minlength: 3, },*/
//                txtDocumento: { required: true, minlength: 3, },
//                txtNombre: { required: true, minlength: 3, },
//                txtApellido: { required: true, minlength: 3 },
//                txtDireccion: { required: true, minlength: 4 },
//                txtEmail: { required: true, email: true },
//                txtTelefono: { required: true, minlength: 4 },
//                /*txtEstado: { required: true, minlength: 4 },*/
//                txtNombreUsuario: { required: true, minlength: 4 },
//                txtContrasenia: { required: true, minlength: 4 },
//            },
//            messages: {
//                //cboTipoDoc: {
//                //    required: 'Por favor ingrese su nombre',
//                //    minlength: 'Debe ingresar un minimo de 3 caracteres'
//                //},
//                txtDocumento: {
//                    required: 'Por favor ingrese su nombre',
//                    minlength: 'Debe ingresar un minimo de 3 caracteres'
//                },
//                txtNombre: {
//                    required: 'Por favor ingrese su nombre',
//                    minlength: 'Debe ingresar un minimo de 3 caracteres'
//                },
//                txtApellido: {
//                    required: 'Por favor ingrese su apellido',
//                    minlength: 'Debe ingresar un minimo de 3 caracteres'
//                },
//                txtDireccion: {
//                    required: 'Ingrese su dirección',
//                    minlength: 'Debe ingresar un minimo de 4 caracteres'
//                },
//                txtEmail: {
//                    required: 'Debe ingresar una direccion de email',
//                    email: 'Debe ingresar un email valido'
//                },
//                txtTelefono: {
//                    required: 'Ingrese numero de telefono',
//                    minlength: 'Debe ingresar un minimo de 4 caracteres'
//                },
//                //txtEstado: {
//                //    required: 'Ingrese una contraseña',
//                //    minlength: 'Debe ingresar un minimo de 4 caracteres'
//                //},
//                txtNombreUsuario: {
//                    required: 'Ingrese nombre de usuario',
//                    minlength: 'Debe ingresar un minimo de 4 caracteres'
//                },
//                txtContrasenia: {
//                    required: 'Ingrese una contraseña',
//                    minlength: 'Debe ingresar un minimo de 4 caracteres'
//                }
//            }
//        });
//    });