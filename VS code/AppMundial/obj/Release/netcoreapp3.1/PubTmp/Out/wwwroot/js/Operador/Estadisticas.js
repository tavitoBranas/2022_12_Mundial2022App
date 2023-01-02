document.querySelector("#busqueda").addEventListener("submit", validarBusqueda);

function validarBusqueda(evt) {
    evt.preventDefault();

    if (eliminarEspacios(dqs("mail").value) == "") {
        return document.querySelector("#error").innerHTML = "Complete campo email";
    } else if (arrobaPrincipioFinal(dqs("mail").value) || !contienearroba(dqs("mail").value)){
        return document.querySelector("#error").innerHTML = "El email ingresado es incorrecto";
    }else {
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

function arrobaPrincipioFinal(texto) {
    let _ret = false;
    if (texto[0] == '@' || texto[texto.length - 1] == '@') {
       _ret = true
    }
    return _ret
}

function contienearroba(texto) {
    let _ret = true;
    let count = 0;
    for (i = 0; i <= texto.length - 1; i++) {
        if (texto[i] == '@') {
            count =+ 1;
        }
    }
    if (count != 1) {
        _ret = false
    }
    return _ret;
}