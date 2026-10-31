function mostrarCartel(mensaje, tipo) {
    var alertaDiv = document.getElementById("miAlerta");
    var textoDiv = document.getElementById("textoAlerta");
    var contenedor = document.getElementById("contenedorAlerta");

    if (!alertaDiv || !textoDiv) return;

    // Seteamos el texto
    textoDiv.innerText = mensaje;

    // Cambiamos el color según si es éxito (verde) o error (rojo/oscuro)
    alertaDiv.className = "toast align-items-center text-white border-0 shadow-lg " + (tipo === "success" ? "bg-success" : "bg-danger");

    // Mostramos el contenedor
    contenedor.style.display = "block";

    // Inicializamos y mostramos el componente Toast de Bootstrap
    var toast = new bootstrap.Toast(alertaDiv, { delay: 2500 }); // Se oculta solo a los 4 segundos
    toast.show();
}