using PrimerObligatorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public abstract class Usuario
    {
        //PROPERTIES
        private static int AutoId { get; set; } = 1;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //CONSTRUCTOR
        protected Usuario()
        {
            Id = AutoId;
            AutoId++;
        }

        protected Usuario(string nombre, string apellido, string email, string password)
        {
            Id = AutoId;
            AutoId++;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Password = password;
        }
    }
}
