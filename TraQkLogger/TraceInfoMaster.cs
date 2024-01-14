using System.Collections.Generic;

namespace TraQkLogger
{
    public class TraceInfoMaster
    {
        public string Proceso { get; private set; } //Nombre del proceso
        public Tipo Tipo { get; private set; } //PS, WS, BD, INFO
        public int Nivel { get; private set; } //Nivel de identación

        public double Toma { get; private set; }

        //Constructor con Proceso, Tipo y Nivel
        public TraceInfoMaster(string proceso, Tipo tipo, int nivel, double toma)
        {
            Proceso = proceso;
            Tipo = tipo;
            Nivel = nivel;
            Toma = toma;
        }

    }
}
