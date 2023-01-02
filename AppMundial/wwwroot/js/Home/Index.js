document.querySelector("#login").addEventListener("submit", login);

function login(evt) {
    evt.preventDefault();

    if (eliminarEspacios(dqs("usuario").value) == "") {
        return document.querySelector("#error").innerHTML = "Complete campo Usuario";
    } else if (eliminarEspacios(dqs("contraseña").value) == "") {
        return document.querySelector("#error").innerHTML = "Complete campo Contraseña";
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