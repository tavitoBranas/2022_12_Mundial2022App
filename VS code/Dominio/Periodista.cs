using Dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace PrimerObligatorio
{
    public class Periodista : Usuario, IValidacion, IComparable<Periodista>
    {

        //CONTRUCTOR
        public Periodista() : base() { }

        public Periodista(string nombre, string apellido, string email, string password) : base(nombre, apellido, email, password) { }

        //METODOS

        //  --> validacionPeriodista
        public void EsValido()
        {
            if (Nombre == null || Apellido == null || Password == null || Email == null)
            {
                throw new Exception("Alguno de los datos requeridos se encuentra vacío");
            }
            else if (Password.Length < 8)
            {
                throw new Exception("La contraseña debe poseer una longitud mayor a 8 caracteres");
            }
            else if (Email[0] == '@' || Email[Email.Length - 1] == '@')
            {
                throw new Exception("Error: El mail comienza o termina con '@'");
            }
            else
            {
                int cantidadArroba = 0;
                foreach (char item in Email)
                {
                    if (item == '@')
                    {
                        cantidadArroba += 1;
                    }
                }
                if (cantidadArroba != 1)
                {
                    throw new Exception("El mail ingresado no es valido: no posee o posee mas de 1 sola @");
                }
            }
        }

        //  --> equals para periodista (para control de creación)
        public override bool Equals(object obj)
        {
            return obj is Periodista periodista && Email == periodista.Email;
        }

        //  --> comparacion de periodistas ordenados ascendentemente 
        public int CompareTo([AllowNull] Periodista other)
        {
            if (Apellido.CompareTo(other.Apellido) > 0)
            {
                return +1;
            }
            else if (Apellido.CompareTo(other.Apellido) < 0)
            {
                return -1;
            }
            else
            {
                if (Nombre.CompareTo(other.Nombre) > 0)
                {
                    return +1;
                }
                else if (Nombre.CompareTo(other.Nombre) < 0)
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
}
