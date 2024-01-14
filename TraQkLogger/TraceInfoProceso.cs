using System.Collections.Generic;

namespace TraQkLogger
{
    public class TraceInfoProceso
    {
        public string Proceso { get; set; }
        public Tipo Tipo { get; set; } //PS, WS, BD, INFO
        public int Nivel { get; internal set; }

        public TraceInfo TraceInfoIni { get; }
        public List<TraceInfo> TraceInfoList { get; } 
        public TraceInfo TraceInfoFin { get; }

        //Constructor con Preceso, Tipo y Nivel
        public TraceInfoProceso(string proceso, Tipo tipo, int Nivel)
        {
            TraceInfoList = new List<TraceInfo>();
        }
        
    }
}
