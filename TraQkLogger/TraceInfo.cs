namespace TraQkLogger
{


    public class TraceInfo
    {
        public Fase Fase {  get; private set; }
        public string Mensaje { get; private set; }
        public double Toma { get; private set; }

        public TraceInfoMaster TraceInfoMaster { get; private set; }

        public TraceInfo(Fase fase, string mensaje, double toma, TraceInfoMaster traceInfoMaster)
        {
            Fase = fase;
            Mensaje = mensaje;
            Toma = toma;
            TraceInfoMaster = traceInfoMaster;
        }

        //Quiero el toString
        public override string ToString()
        {
            return Mensaje;

        }

    }
}
