document.querySelector("#logout").addEventListener('click', LogOut);

function LogOut(evt) {
    evt.preventDefault();


    if (confirm("Seguro que desea salir del sistema?")) {
        window.location = event.currentTarget.href;
    }

}