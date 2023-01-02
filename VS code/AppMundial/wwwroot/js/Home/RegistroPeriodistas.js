document.querySelector("#registroPeriodistas").addEventListener("submit", validarPeriodista);

function validarPeriodista(evt) {
    evt.preventDefault();

    if (eliminarEspacios(dqs("Nombre").value) == "") {
        return document.querySelector("#error").innerHTML = "Complete campo Nombre";
    } else if (eliminarEspacios(dqs("Apellido").value) == "") {
        return document.querySelector("#error").innerHTML = "Complete campo Apelido";
    } else if (eliminarEspacios(dqs("Email").value) == "") {
        return document.querySelector("#error").innerHTML = "Complete campo Email";
    } else if (eliminarEspacios(dqs("Password").value) == "") {
        return document.querySelector("#error").innerHTML = "Complete campo Contrasena";
    } else {
        this.submit()
    }
}

function dqs(id) {
    return document.querySelector("#" + id);
}

function eliminarEspacios(texto) {
    let _ret = "";
    for (i = 0; i <= texto.length - 1; i++) {

        if (texto[i] != " ") {
            _ret += texto[i];
        }
    }
    return _ret;
}