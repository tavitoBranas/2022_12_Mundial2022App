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
                Console.WriteLine("          5 - Partido con mayor cantidad de goles de una seleccion (no se consideran penales)");
                Console.WriteLine("          6 - Jugadores que convirtieron al menos un gol");
                Console.WriteLine("          0 - Salir del sistema");
                Console.WriteLine("");

                //mensaje si se ingresa valor no numerico
                try
                {
                    string _op = Console.ReadLine();
                    if (_op == "") { _op = "0"; }

                    op = Int32.Parse(_op);
                }
                catch
                {
                    throw new Exception("Ingrese valor numerico segun lo que se indica en el menu");
                }

                //mensaje si se ingresa valor numerico diferente al permitido
                if (op < 0 || op > 6)
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
                        Periodista Periodista = new Periodista(nombrePeriodista, apellidoPeriodista, email, password);
                        s.AltaPeriodista(Periodista);
                        break;

                    case 2:
                        Console.WriteLine("");
                        Console.WriteLine("Ingrese valor de referencia");
                        try
                        {
                            int valorRef = Int32.Parse(Console.ReadLine());
                            Jugador.ValorReferencia = valorRef;
                        }
                        catch
                        {
                            throw new Exception("Ingrese valor numerico segun lo que se indica en el menu");
                        }
                        Console.WriteLine("");
                        Console.WriteLine("Se ha actualizado correctamente el valor. Presione una letra para continuar");
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.WriteLine("");
                        Console.WriteLine("Ingrese numero de jugador");
                        try
                        {
                            int idJugador = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("");
                            if (s.GetPartidosDejugador(idJugador).Count != 0)
                            {
                                Console.WriteLine($"El jugador {s.GetJugadorSegunId(idJugador).NombreCompJugador} de la seleccion de " +
                                    $"{s.GetJugadorSegunId(idJugador).PaisJugador.NombrePais} ha participado en los siguientes partidos:");
                                foreach (Partido item in s.GetPartidosDejugador(idJugador))
                                {
                                    Console.WriteLine($"Fecha {item.FechaPartido.ToString("dd/MM/yyyy")} Hora {item.FechaPartido.ToString("HH:mm")}" +
                                        $" contra la seleccion de {s.GetSeleccionQueJugoContra(item, s.GetPaisDeJugador(idJugador)).Pais.NombrePais}" +
                                        $" y el total de incidencias registrado fue de {item.GetIncidenciasPartido().Count}.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("El jugador con Id ingresado no ha jugado ningun partido.");
                            }
                            Console.WriteLine("");
                            Console.WriteLine("Presione una letra para continuar");
                            Console.ReadKey();
                        }
                        catch
                        {
                            throw new Exception("Ingrese valor numerico segun lo que se indica en el menu");
                        }
                        break;

                    case 4:
                        Console.WriteLine("");
                        foreach (Jugador item in s.GetJugadoresExpulsados())
                        {
                            Console.WriteLine(item.NombreCompJugador + " ----- Valor de mercado: " + item.ValorMercado);
                        }
                        Console.WriteLine("");
                        Console.WriteLine("Presione una letra para continuar");
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.WriteLine("");
                        Console.WriteLine("Ingrese seleccion considerando que su primera letra debe de ser mayuscula");
                        try
                        {
                            string seleccion = Console.ReadLine();
                            Console.WriteLine("");

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
                            Console.WriteLine("");
                            Console.WriteLine("Presione una letra para continuar");
                            Console.ReadKey();
                        }
                        catch
                        {
                            throw new Exception("Ingrese valor numerico segun lo que se indica en el menu");
                        }
                        break;

                    case 6:
                        Console.WriteLine("");
                        foreach (Jugador item in s.GetJugadoresRealizaronGol())
                        {
                            Console.WriteLine($"Nombre jugador {item.NombreCompJugador} -- Valor en Euros {item.ValorMercado}" +
                                $" -- Categoria financiera {item.CategoriaJugador()}");
                        }
                        Console.WriteLine("");
                        Console.WriteLine("Presione una letra para continuar");
                        Console.ReadKey();
                        break;
                }
                /*  prueba de finalizacion de los partidos
                 foreach (Partido item in s.GetPartidos())
                {
                    Console.WriteLine(item.IdPartido + item.MensajeFinalPartido());
                }*/
            }
        }
    }
}
