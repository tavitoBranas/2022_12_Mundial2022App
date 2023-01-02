using System;

namespace PrimerObligatorio
{
    class Program
    {
        static void Main(string[] args)
        {
            //patron singleton
            Sistema s = Sistema.GetSistema();

            int op = -1;

            while (op != 0)
            {
                Console.Clear();
                Console.WriteLine("***MENU MUNDIAL 2022***");
                Console.WriteLine("     Seleccione opción para continuar");
                Console.WriteLine("          1 - Ingresar un periodista");
                Console.WriteLine("          2 - Asignar valor de referencia para categoria financiera de jugadores");
                Console.WriteLine("          3 - Partidos que ha participado un determinado jugador");
                Console.WriteLine("          4 - Jugadores expulsados ordenados por valor de mercado descendente / nombre completo ascendente");
                Console.WriteLine("          5 - Partido con mayor cantidad de goles de una seleccion (no se consideran los goles obtenidos en una definición por penales)");
                Console.WriteLine("          6 - Jugadores que convirtieron al menos un gol");
                Console.WriteLine("          0 - Salir del sistema");
                Console.WriteLine("");

                //mensaje si se ingresa valor no numerico
                bool bandera = true;
                try
                {
                    string _op = Console.ReadLine();
                    if (_op == "") { _op = "0"; }

                    op = Int32.Parse(_op);
                }
                catch
                {
                    Console.WriteLine("Ingrese valor numerico segun lo que se indica en el menu");
                    bandera = false;
                }

                //mensaje si se ingresa valor numerico diferente al permitido
                if ((op < 0 || op > 6) && bandera)
                {
                    Console.WriteLine("Ingrese valor numerico segun lo que se indica en el menu");
                }

                switch (op)
                {
                    case 1:
                        Console.WriteLine("");
                        Console.WriteLine("     Ingrese nombre del periodista");
                        string nombrePeriodista = Console.ReadLine();
                        Console.WriteLine("");
                        Console.WriteLine("     Ingrese apellido del periodista");
                        string apellidoPeriodista = Console.ReadLine();
                        Console.WriteLine("");
                        Console.WriteLine("     Ingrese email asociado al periodista");
                        string email = Console.ReadLine();
                        Console.WriteLine("");
                        Console.WriteLine("     Ingrese password. Debe de contar al menos con 8 caracteres");
                        string password = Console.ReadLine();
                        Console.WriteLine("");
                        try
                        {
                            s.GeneracionPeriodista(nombrePeriodista, apellidoPeriodista, email, password);
                            Console.WriteLine("El periodista fue dado de alta");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case 2:
                        Console.WriteLine("");
                        Console.WriteLine("Ingrese valor de referencia mayor o igual a cero");
                        try
                        {
                            double valorRef = Double.Parse(Console.ReadLine());
                            if (valorRef >= 0)
                            {
                                s.AsignarValorReferencia(valorRef);
                                Console.WriteLine("");
                                Console.WriteLine("Se ha actualizado correctamente el valor.");
                            }
                            else
                            {
                                Console.WriteLine("Ingrese valor mayor o igual a cero.");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Ingrese valor numérico segun lo que se indica en el menu.");
                        }

                        break;

                    case 3:
                        Console.WriteLine("");
                        Console.WriteLine("Ingrese Id de jugador");
                        try
                        {
                            int idJugador = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("");
                            if (idJugador > 0 && idJugador < 872)
                            {
                                if (s.GetPartidosDejugador(idJugador).Count != 0)
                                {
                                    Console.WriteLine($"El jugador {s.GetJugadorSegunId(idJugador).NombreCompJugador} de la seleccion de " +
                                        $"{s.GetJugadorSegunId(idJugador).PaisJugador.NombrePais} ha participado en los siguientes partidos:");

                                    foreach (Partido item in s.GetPartidosDejugador(idJugador))
                                    {
                                        Console.WriteLine($"Id Partido {item.IdPartido} Fecha {item.FechaPartido.ToString("dd/MM/yyyy")} Hora {item.FechaPartido.ToString("HH:mm")}" +
                                            $" contra la seleccion de {s.GetSeleccionQueJugoContra(item, s.GetPaisDeJugador(idJugador)).Pais.NombrePais}" +
                                            $" y el total de incidencias registrado fue de {item.GetIncidenciasPartido().Count}.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("El jugador con Id ingresado no ha jugado ningun partido.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("El jugador con Id ingresado no existe en la base de datos. Corrobore su ingreso");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Ingrese valor numerico segun lo que se indica en el menu");
                        }
                        break;

                    case 4:
                        Console.WriteLine("");
                        if(s.GetJugadoresExpulsados().Count != 0)
                        {
                            foreach (Jugador item in s.GetJugadoresExpulsados())
                            {
                                Console.WriteLine("Id jugador  " + item.IdJugador + "-----" + item.NombreCompJugador + " ----- Valor de mercado: " + item.ValorMercado);
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("No existen datos registrados");
                        }
                        break;

                    case 5:
                        Console.WriteLine("");
                        Console.WriteLine("Ingrese seleccion considerando que su primera letra debe de ser mayúscula");

                        string seleccion = Console.ReadLine();
                        Console.WriteLine("");

                        if (s.GetSelecciones().Contains(s.GetSeleccionParaPartido(seleccion)))
                        {
                            if (s.GetPartidoConMasGoles(seleccion).Count != 0)
                            {
                                Console.WriteLine($"La seleccion {seleccion} realizo la mayor cantidad de goles en los siguientes partidos:");

                                foreach (Partido item in s.GetPartidoConMasGoles(seleccion))
                                {
                                    Console.WriteLine($"Id del partido {item.IdPartido} con fecha {item.FechaPartido.ToString("dd/MM/yyyy")} y hora {item.FechaPartido.ToString("HH:mm")}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("La seleccion no realizo ningun gol.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("La seleccion no se encuentra registrada.");
                        }
                        break;

                    case 6:
                        Console.WriteLine("");
                        if (s.GetJugadoresRealizaronGol().Count != 0)
                        {
                            foreach (Jugador item in s.GetJugadoresRealizaronGol())
                            {
                                Console.WriteLine($"Id jugador {item.IdJugador} -- Nombre jugador {item.NombreCompJugador} -- Valor en Euros {item.ValorMercado}" +
                                    $" -- Categoria financiera {item.CategoriaJugador()}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No existen registros");
                        }
                        
                        break;
                }
                Console.WriteLine("");
                Console.WriteLine("Presione una letra para continuar");
                Console.ReadKey();
            }
        }
    }
}
