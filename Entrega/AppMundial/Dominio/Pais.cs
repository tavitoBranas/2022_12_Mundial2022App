using System;
using System.Collections.Generic;
using System.Text;

namespace PrimerObligatorio
{
    public class Pais:IValidacion
    {
        //PROPERTIES
        private static int AutoIdPais { get; set; } = 1;
        public int IdPais { get; set; }
        public string NombrePais { get; set; }
        public string CodigoPais { get; set; }

        //CONSTRUCTOR
        public Pais(string nombrePais, string codigoPais)
        {
            IdPais = AutoIdPais;
            AutoIdPais++;
            NombrePais = nombrePais;
            CodigoPais = codigoPais;
        }

        //METODOS

        //  --> validacion
        public void EsValido()
        {
            if(NombrePais == "")
            {
                throw new Exception("No se ingresó nombre de pais pais");
            } 
            else
            {
                int cantidadLetras = 0;
                // no puedo usar count ya que contaria caracteres e interesa saber letras
                foreach (char item in CodigoPais.ToLower())
                {
                    if ((int)item >= 97 && (int)item <= 122)
                    {
                        cantidadLetras += 1;
                    }
                }
                if (cantidadLetras != 3)
                {
                    throw new Exception("El codigo del país es incorrecto");
                }
            }
        }
    }
}
