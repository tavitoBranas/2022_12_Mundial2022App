using System;

namespace PrimerObligatorio
{
    public class FaseEliminatoria : Partido
    {
        //PROPERTIES
        private bool HuboAlagrue { get; set; }
        public ClasificacionFaseEliminatoria Fase { get; set; }

        //COSNTRUCTOR
        public FaseEliminatoria(DateTime fechaPartido, bool alargue, ClasificacionFaseEliminatoria fase) : base(fechaPartido)
        {
            HuboAlagrue = alargue;
            Fase = fase;
        }

        //METODOS

        //  --> definicion por penales
        public bool DefinidoPorPenales()
        {
            bool huboPenales = false;
            foreach (Incidencia item in GetIncidenciasPartido())
            {
                if (item.Minuto.Equals(-1))  //si existio incidencia en min -1 entonces hubo penales
                {
                    huboPenales = true;
                    break;
                }
            }
            return huboPenales;
        }

        //  --> mensaje de ganador
        public override string MensajeFinalPartido()
        {
            string mensaje = $"Ganador: {DeterminacionDelGanador()}";

            if (DefinidoPorPenales())
            //el metodo determinacion del ganador ya considera que el partido este terminado
            {
                mensaje = $"Empate en tiempo de juego. Ganador {DeterminacionDelGanador()} en tanda de penales";
            }
            return mensaje;
        }

        public bool HuboALargue()
        {
            return HuboAlagrue;
        }


        //  --> finalizacion partido
        public override void FinalizacionPartido()
        {
            PartidoFinalizado = true;
            ResultadoFinal = MensajeFinalPartido();

            foreach (Incidencia i in GetIncidenciasPartido())
            {
                if(i.Minuto > 90  || i.Minuto.Equals(-1))
                {
                    HuboAlagrue = true;
                    break;
                }
            }
        }
    }
}
