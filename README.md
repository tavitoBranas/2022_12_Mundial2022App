# Aplicacion para Gestion del mundial 2022

Esta aplicacion se desarrolló en .NET empleando el patron MVC y permite la gestion de los partidos del mundial de Qatar.
Dicha aplicación se deployo en Somee.

La aplicacion cuenta con una clase Sistema comom singleton que permite administrar el backend.

La aplicacion almacena informacion de partidos realizados. 
Existen dos usuarios:
  Operadores: 
    - generan los partidos 
    - cargan las incidencias
    - finalizan el partido: el resultado (ganador o empate) se define automaticamente por el sistema
    - listar todos los partidos de un jugador con su estadistica
    - listar jugadores expulsados de manera ordernada
    - dado una seleccion, obtener el partido con mayor cantidad de goles
    - listar jugadores que hayan convertido al menos un gol
    - visulizar los partidos jugados entre dos fechas
  Periodistas: 
    - se registran
    - realizan reseñas de partidos finalizados
    - desplegar todas las reseñas realizadas por el
    - pueden desloguearse

-----------------------------------------------------------------------------------------------------------------------------

# Second assignment for Programacion 2 (Second semester at ORT University)
I created a web page where two different user's profiles (Admin and Customer) can log in and out. To do so, I used .NET to create a MVC. The users have different features: 
for instance, Admin can sign in while customer can not. I attached the UML model where the different classes can be seen by SISTEMA. This class manages the comunication 
with the console and allows to validate the entries. I have also performed some valiation before reaching the SISTEMA through JavaScript. 
