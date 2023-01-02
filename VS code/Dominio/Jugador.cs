using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace PrimerObligatorio
{
    public class Jugador: IValidacion, IComparable<Jugador>
    {
        //PROPERTIES
        public static double ValorReferencia { get; set; }
        public int IdJugador { get; set; }
        public string NombreCompJugador { get; set; }
        public Pais PaisJugador { get; set; }
        public string NumeroCamisetaJugador { get; set; }
        public DateTime FechaNacJugador { get; set; }
        public double AlturaJugador { get; set; }
        public string PieHabil { get; set; }
        public string PosicionJugador { get; set; }
        public int ValorMercado { get; set; }
        public string MonedaValorMercado { get; set; }

        //CONSTRUCTOR
        public Jugador(int idJugador, string numeroCamisetaJugador, string nombreCompJugador, DateTime fechaNacJugador, double alturaJugador, string pieHabil, int valorMercado, string moneda ,Pais paisJugador, string posicionJugador)
        {
            IdJugador = idJugador;
            ValorMercado = valorMercado;
            NombreCompJugador = nombreCompJugador;
            PaisJugador = paisJugador;
            NumeroCamisetaJugador = numeroCamisetaJugador;
            FechaNacJugador = fechaNacJugador;
            AlturaJugador = alturaJugador;
            PieHabil = pieHabil;
            PosicionJugador = posicionJugador;
            MonedaValorMercado = moneda;
        }

        //METODOS

        //  --> categoriaJugador
        public string CategoriaJugador()
        {
            string categoria = "Estandar";
            if (ValorMercado >= ValorReferencia)
            {
                categoria = "VIP";
            }
            return categoria;
        }


        //  --> validacionJugador
        public void EsValido()
        {
            if (NombreCompJugador == "" || PaisJugador == null || NumeroCamisetaJugador == "" || FechaNacJugador == null
                || AlturaJugador < 0 || PieHabil == "" || PosicionJugador == "" || ValorMercado < 0)
            {
                throw new Exception("Los datos ingresados para juagdores no son validos");
            }
        }

       

        //  --> ordenamiento jugadores
        public int CompareTo([AllowNull] Jugador other)  
        {
            //ordeno por valor de mercado descendente
            if (ValorMercado.CompareTo(other.ValorMercado) > 0)   
            {
                return -1;
            }
            else if (ValorMercado.CompareTo(other.ValorMercado) < 0)
            {
                return 1;
            } else
            {
                //si valor de mercado igual entonces se ordenan por nombre ascendente
                if (NombreCompJugador.CompareTo(other.NombreCompJugador) > 0)
                {
                    return 1;
                }
                else if (NombreCompJugador.CompareTo(other.NombreCompJugador) < 0)
                {
                    return -1;
                }
                else { 
                    //si coincide tambien la primer letra? entonces queda como esta en la posicion
                    return 0; }
            }
        }
    }
}
