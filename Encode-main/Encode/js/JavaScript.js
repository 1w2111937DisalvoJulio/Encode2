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
                document.getElementById("btnCancelar").disabled = "disabled";
                document.getElementById("btnRegistrarSuscripcion").disabled = "disabled";

            } else {
                document.getElementById("btnNuevo").disabled = "disabled";
                document.getElementById("btnCancelar").disabled = "disabled";
                document.getElementById("btnRegistrarSuscripcion").disabled = "disabled";
            }
        });
}

function alerta(titulo, mensaje) {
    Swal.Fire({
        title: titulo,
        text: mensaje,
        icon: "warning"
    })
}
