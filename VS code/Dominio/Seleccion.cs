using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace PrimerObligatorio
{
    public class Seleccion : IValidacion, IComparable<Seleccion>
    {
        //PROPERTIES
        private static int AutoIdSeleccion { get; set; } = 1;
        public int IdSeleccion { get; set; }
        public Pais Pais { get; set; }
        private List <Jugador> JugadoresSeleccion { get; set; }

        //CONSTRUCTOR
        public Seleccion(Pais pais)
        {
            IdSeleccion = AutoIdSeleccion;
            AutoIdSeleccion++;
            Pais = pais;
            JugadoresSeleccion = new List<Jugador>();
        }

        //METODOS

        //  --> agregar jugador a la lista 
        public void AgregarJugadorAseleccion(Jugador jugador)
        {
            JugadoresSeleccion.Add(jugador);
        }

        //  --> getJugadores de la selccion
        public List<Jugador> GetJugadoresSeleccion()
        {
            JugadoresSeleccion.Sort();
            return JugadoresSeleccion;
        }

        //  --> validacion 
        public void EsValido()
        {
            if(Pais == null || JugadoresSeleccion.Count < 11)
            {
                throw new Exception("La saleccion no posee pais asociado o cantidad de jugadores menor a 11");
            }
        }

        public int CompareTo([AllowNull] Seleccion other)
        {
            if (Pais.NombrePais.CompareTo(other.Pais.NombrePais) > 0)
            {
                return +1;
            }
            else if (Pais.NombrePais.CompareTo(other.Pais.NombrePais) < 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
