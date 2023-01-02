using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace PrimerObligatorio
{
    public class Incidencia : IValidacion, IComparable<Incidencia>
    {
        //PROPERTIES
        private static int AutoIdIncidencia { get; set; } = 1;
        public int IdIncidencia { get; set; }
        public TipoIncidencia Hecho { get; set; }
        public int Minuto { get; set; }
        public int JugadorId { get; set; }

        //CONSTRUCTOR
        public Incidencia(int jugador, TipoIncidencia hecho, int minuto)
        {
            IdIncidencia = AutoIdIncidencia;
            AutoIdIncidencia++;
            JugadorId = jugador;
            Hecho = hecho;
            Minuto = minuto;
        }

        //METODO

        //  --> validacion de incidencia
        public void EsValido()
        {
            if (JugadorId <= 0 || JugadorId > 871 || Minuto < -1)
            {
                throw new Exception("La incidencia no es valida");
            }
        }

        //  --> compare to
        public int CompareTo([AllowNull] Incidencia other)
        {
            if (Minuto.CompareTo(other.Minuto) > 0)
            {
                return +1;
            }
            else if (Minuto.CompareTo(other.Minuto) < 0)
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
