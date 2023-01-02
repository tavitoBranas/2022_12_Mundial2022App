using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace PrimerObligatorio
{
    public abstract class Partido : IValidacion, IComparable<Partido>
    {
        private static int AutoIdPartido { get; set; } = 1;
        public int IdPartido { get; set; }
        private List<Seleccion> SeleccionesPartido { get; set; }
        public DateTime FechaPartido { get; set; }
        public bool PartidoFinalizado { get; set; }
        private List<Incidencia> IncidenciasPartido { get; set; }
        public string ResultadoFinal { get; set; }


        //CONSTRUCTOR
        protected Partido(DateTime fechaPartido)
        {
            IdPartido = AutoIdPartido;
            AutoIdPartido++;
            SeleccionesPartido = new List<Seleccion>();
            IncidenciasPartido = new List<Incidencia>();
            ResultadoFinal = "Pendiente";
            PartidoFinalizado = false;
            FechaPartido = fechaPartido;
        }

        //METODOS

        //  --> agregar seleccion al partido
        public void AgregarSeleccionesPartido(Seleccion seleccion, Seleccion seleccion2)
        {
            SeleccionesPartido.Add(seleccion);
            SeleccionesPartido.Add(seleccion2);
        }


        //  --> get selecciones del partido
        public List<Seleccion> GetSeleccionesPartido()
        //no virtual no abstract para no modificar
        {
            return SeleccionesPartido;
        }


        //  --> validar partido
        public void EsValido()
        {
            if (SeleccionesPartido.Count != 2 || SeleccionesPartido[0].Pais == SeleccionesPartido[1].Pais || FechaPartido > new DateTime(2022, 12, 18) || FechaPartido < new DateTime(2022, 11, 20))
            {
                throw new Exception("El partido ingresado no es valido");
            }
        }


        //  --> verificar que el jugador exista en la seleccion y agregar la incidencia a la lista de incidencias del partido
        public void ValidarYagregarIncidencia(Incidencia incidencia)
        {
            if (!PartidoFinalizado)
            {
                foreach (Seleccion item in GetSeleccionesPartido())
                {
                    foreach (Jugador item2 in item.GetJugadoresSeleccion())
                    {
                        if (item2.IdJugador == incidencia.JugadorId)
                        {
                            IncidenciasPartido.Add(incidencia);
                            break;
                        }
                    }
                }

            }
        }


        //  --> get Incidencias 
        public List<Incidencia> GetIncidenciasPartido()
        {
            //no virtual ni abstract para no modificar
            IncidenciasPartido.Sort();
            return IncidenciasPartido;
        }


        //  --> finalizacion partido
        public virtual void FinalizacionPartido()
        {
            PartidoFinalizado = true;
            ResultadoFinal = MensajeFinalPartido();
        }


        //  --> Determinacion del ganador
        protected string DeterminacionDelGanador()
        {
            string ganador = "El partido no ha finalizado";

            if (PartidoFinalizado)
            {
                string pais1 = SeleccionesPartido[0].Pais.CodigoPais;
                int golesSeleccion1 = 0;
                int golesSeleccion2 = 0;

                foreach (Incidencia incidencia in GetIncidenciasPartido())
                {
                    foreach (Seleccion seleccion in GetSeleccionesPartido())
                    {
                        foreach (Jugador jugador in seleccion.GetJugadoresSeleccion())
                        {
                            if (incidencia.Hecho == TipoIncidencia.Gol && incidencia.JugadorId == jugador.IdJugador && seleccion.Pais.CodigoPais == pais1)
                            {
                                golesSeleccion1 += 1;
                            }
                            else if (incidencia.Hecho == TipoIncidencia.Gol && incidencia.JugadorId == jugador.IdJugador && seleccion.Pais.CodigoPais != pais1)
                            {
                                golesSeleccion2 += 1;
                            }
                        }
                    }
                }

                if (golesSeleccion1 > golesSeleccion2) { ganador = SeleccionesPartido[0].Pais.NombrePais; }
                else if (golesSeleccion1 < golesSeleccion2) { ganador = SeleccionesPartido[1].Pais.NombrePais; }
                else { ganador = "Empate"; }
            }
            return ganador;
        }


        //  --> Mensaje final del partido
        public abstract string MensajeFinalPartido();


        //  --> comparacion de partidos ordenados por fecha
        public int CompareTo([AllowNull] Partido other)
        {
            if (FechaPartido.CompareTo(other.FechaPartido) > 0)
            {
                return 1;
            }
            else if (FechaPartido.CompareTo(other.FechaPartido) < 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }


        //  --> Cantidad de Incidencias tipo (roja, amarilla, gol) y seleccion
        public string GetIncidenciasTipo(string tipo, int numSeleccion)  
            //numero de seleccion es la posicion 0 y 1
        {
            int count = 0;
            int countPenales = 0;
            Seleccion s = SeleccionesPartido[numSeleccion];
            
            if (PartidoFinalizado && tipo != "Gol")
            {
                foreach (Incidencia i in IncidenciasPartido)
                {
                    foreach(Jugador j in s.GetJugadoresSeleccion())
                    if (i.JugadorId == j.IdJugador && i.Hecho.ToString().Equals(tipo))
                    {
                        count++;
                    }
                }
            }
            else if (PartidoFinalizado && tipo == "Gol")
            {
                foreach (Incidencia i in IncidenciasPartido)
                {
                    foreach (Jugador j in s.GetJugadoresSeleccion())
                        if (i.JugadorId == j.IdJugador && i.Hecho.ToString().Equals(tipo) && !i.Minuto.Equals(-1))
                        {
                            count++;
                        }else if(i.JugadorId == j.IdJugador && i.Hecho.ToString().Equals(tipo) && i.Minuto.Equals(-1))
                        {
                            countPenales++;
                        }
                }
                if (countPenales != 0)
                {
                    return count.ToString() + "  (" + countPenales.ToString() + ")";
                }
            }
            return count.ToString();
        }

        public List<Incidencia> GetIncidenciaGol(Seleccion s)
        {
            List<Incidencia> _ret = new List<Incidencia>();

            foreach(Incidencia i in GetIncidenciasPartido())
            {
                foreach(Jugador j in s.GetJugadoresSeleccion())
                {
                    if (i.Hecho.ToString().Equals("Gol") && !i.Minuto.Equals(-1)
                        && j.IdJugador.Equals(i.JugadorId))
                    {
                        _ret.Add(i);
                    }
                }
            }
            return _ret;
        }

        public List<Incidencia> GetIncidenciaPenal(Seleccion s)
        {
            List<Incidencia> _ret = new List<Incidencia>();

            foreach (Incidencia i in GetIncidenciasPartido())
            {
                foreach (Jugador j in s.GetJugadoresSeleccion())
                {
                    if (i.Hecho.ToString().Equals("Gol") && i.Minuto.Equals(-1)
                         && j.IdJugador.Equals(i.JugadorId))
                    {
                        _ret.Add(i);
                    }
                }
            }
            return _ret;
        }

        public List<Incidencia> GetIncidenciaAmarilla(Seleccion s)
        {
            List<Incidencia> _ret = new List<Incidencia>();

            foreach (Incidencia i in GetIncidenciasPartido())
            {
                foreach (Jugador j in s.GetJugadoresSeleccion())
                {
                    if (i.Hecho.ToString().Equals("TarjetaAmarilla") 
                        && j.IdJugador.Equals(i.JugadorId))
                    {
                        _ret.Add(i);
                    }
                }
            }
            return _ret;
        }

        public List<Incidencia> GetIncidenciaRoja(Seleccion s)
        {
            List<Incidencia> _ret = new List<Incidencia>();

            foreach (Incidencia i in GetIncidenciasPartido())
            {
                foreach (Jugador j in s.GetJugadoresSeleccion())
                {
                    if (i.Hecho.ToString().Equals("TarjetaRoja")
                         && j.IdJugador.Equals(i.JugadorId))
                    {
                        _ret.Add(i);
                    }
                }
            }
            return _ret;
        }
    }

}
