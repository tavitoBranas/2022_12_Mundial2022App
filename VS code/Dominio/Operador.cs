using PrimerObligatorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Operador : Usuario
    {
        //PROPERTIES
        public DateTime FechaInicio { get; set; }

        //CONTRUCTOR
        public Operador() : base() { }

        public Operador(string nombre, string apellido, string email, string password, DateTime inicio) : base(nombre, apellido, email, password) 
        {
            FechaInicio = inicio;
        }

    }
}
