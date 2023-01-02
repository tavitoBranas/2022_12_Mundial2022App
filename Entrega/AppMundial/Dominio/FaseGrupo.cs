using System;
using System.Collections.Generic;
using System.Text;

namespace PrimerObligatorio
{
    public class FaseGrupo : Partido
    {
        //PROPERTIES
        public ClasificacionFaseGrupo Fase { get; set; }

        //CONSTRUCTOR
        public FaseGrupo (DateTime fechaPartido, ClasificacionFaseGrupo fase) : base(fechaPartido)
        {
            Fase = fase;
        }

        //METODO

        //  --> mensaje de ganador
        public override string MensajeFinalPartido()
        {
            string mensaje = "Empate";
            if (DeterminacionDelGanador() != "Empate")  
                //metodo determinacion del ganador ya implica que el partido este finalizado
            {
                mensaje = $"Ganador: {DeterminacionDelGanador()}";
            }
            return mensaje;
        }
    }
}
