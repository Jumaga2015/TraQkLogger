using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TraQkLogger
{
    public class TraQkLogger
    {
        private Stopwatch stopwatch;
        private List<TraceInfo> traces;
        private int nivel;

        public List<TraceInfo> Traces { get => traces; }

        public TraQkLogger()
        {
            traces = new List<TraceInfo>();
            nivel = 0;
        }

        public void Iniciar(string proceso, Tipo tipo)
        {
            stopwatch = Stopwatch.StartNew();
            AddTrace(proceso, tipo, Fase.Ini);
        }

        public void Finalizar(string proceso, Tipo tipo)
        {
            stopwatch.Stop();
            AddTrace(proceso, tipo, Fase.Fin);

            Console.WriteLine("Lista de trazas:");
            foreach (TraceInfo trace in traces)
            {
                Console.WriteLine(trace.ToString());
            }
        }

        public void AddTrace(string proceso, Tipo tipo, Fase fase)
        {
            double tiempo = stopwatch.Elapsed.TotalSeconds;
            if (fase == Fase.Ini)
            {
                nivel++;
            }
            else if (fase == Fase.Fin)
            {
                nivel--;
            }
            TraceInfo trace = new TraceInfo { Proceso = proceso, Tipo = tipo, Fase = fase, Tiempo = tiempo, Nivel = nivel };
            traces.Add(trace);
        }
    }
}
