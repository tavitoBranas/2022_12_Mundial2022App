using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace PrimerObligatorio
{
    public class Reseña : IComparable<Reseña>, IValidacion
    {
        //PROPERTIES
        private static int AutoIdReseña { get; set; } = 1;
        public int IdReseña { get; set; }
        public Periodista Periodista { get; set; }
        public DateTime FechaReseña { get; set; }
        public Partido Partido { get; set; }
        public string TituloReseña { get; set; }
        public string ContenidoReseña { get; set; }

        //CONSTRUCTOR
        public Reseña(Periodista periodista, Partido partido, string tituloReseña, string contenidoReseña)
        {
            IdReseña = AutoIdReseña;
            AutoIdReseña++;
            FechaReseña = DateTime.Today;
            Periodista = periodista;
            Partido = partido;
            TituloReseña = tituloReseña;
            ContenidoReseña = contenidoReseña;
        }

        public Reseña(Periodista periodista, Partido partido, string tituloReseña, string contenidoReseña, DateTime fecha)
        {
            IdReseña = AutoIdReseña;
            AutoIdReseña++;
            FechaReseña = fecha;
            Periodista = periodista;
            Partido = partido;
            TituloReseña = tituloReseña;
            ContenidoReseña = contenidoReseña;
        }

        public Reseña()
        {
            IdReseña = AutoIdReseña;
            AutoIdReseña++;
            FechaReseña = DateTime.Today;
        }

        public int CompareTo([AllowNull] Reseña other)
        {
            if (FechaReseña.DayOfYear.CompareTo(other.FechaReseña.DayOfYear) > 0)
            {
                return -1;
            }
            else if (FechaReseña.DayOfYear.CompareTo(other.FechaReseña.DayOfYear) < 0)
            {
                return 1;
            }
            else
            {
                if (FechaReseña.Hour.CompareTo(other.FechaReseña.Hour) > 0)
                {
                    return -1;
                }
                else if (FechaReseña.Hour.CompareTo(other.FechaReseña.Hour) < 0)
                {
                    return +1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public void EsValido()
        {
            if (TituloReseña == null || ContenidoReseña == null)
            {
                throw new Exception("Existen campos vacios. Por favor completelos para realizar la resena");
            }
        }

        public string GrupoPartido()
        {
            string mensaje = null;

            if (Partido is FaseGrupo)
            {
                FaseGrupo _ret = Partido as FaseGrupo;
                mensaje = _ret.Fase.ToString();
            }
            else if (Partido is FaseEliminatoria)
            {
                FaseEliminatoria _ret = Partido as FaseEliminatoria;
                mensaje = _ret.Fase.ToString();
            }
            return mensaje;
        }
    }
}

