using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace TraQkLogger
{
    public class TraQkLogger
    {
        private Stopwatch stopwatch;
        private Dictionary<string, TraceInfoMaster> tracesIndex;
        private List<TraceInfo> traces;
        private int nivel;
        private double toma;

        public IEnumerable<TraceInfo> Traces { get => traces; }

        public TraQkLogger()
        {
            tracesIndex = new Dictionary<string, TraceInfoMaster>();
            traces = new List<TraceInfo>();
            nivel = 0;
        }

        public void Iniciar(string proceso, Tipo tipo, string mensaje)
        {
            stopwatch = Stopwatch.StartNew();
            toma = stopwatch.Elapsed.TotalMilliseconds;
            AddTrace(proceso, tipo, Fase.Ini, mensaje);
        }

        public void Finalizar(string proceso, Tipo tipo, string mensaje)
        {
            AddTrace(proceso, tipo, Fase.Fin, mensaje);
            stopwatch.Stop();

            Flush();

        }

        private void Flush()
        {
            string GenerarIndentacion(int nivel)
            {
                return "".PadLeft(nivel, ' ').Replace(" ", "        ") + "".PadLeft(nivel, '1').Replace("1", "1.");
            }


            StringBuilder s = new StringBuilder();
            foreach (TraceInfo trace in traces)
            {
                switch (trace.Fase)
                {
                    case Fase.Ini:
                        s.Append($"{GenerarIndentacion(trace.TraceInfoMaster.Nivel)} [{trace.Toma - toma:000000} ms] Tipo: {trace.TraceInfoMaster.Tipo} - (Ini) - {trace.Mensaje}" + Environment.NewLine);
                        break;
                    case Fase.Info:
                        s.Append($"{GenerarIndentacion(trace.TraceInfoMaster.Nivel)} [------ ms] Tipo: {trace.TraceInfoMaster.Tipo} - (Inf) - {trace.Mensaje}" + Environment.NewLine);
                        break;
                    case Fase.Fin:
                        s.Append($"{GenerarIndentacion(trace.TraceInfoMaster.Nivel)} [{trace.Toma - trace.TraceInfoMaster.Toma:000000} ms] Tipo: {trace.TraceInfoMaster.Tipo} - (Fin) - {trace.Mensaje}" + Environment.NewLine);
                        toma =  trace.Toma;
                        break;

                }
            }
            Console.WriteLine(s);
        }

        public void AddTrace(string proceso, Tipo tipo, Fase fase, string mensaje)
        {
            double tiempo = stopwatch.Elapsed.TotalMilliseconds;

            switch (fase)
            {
                case Fase.Ini:
                    nivel++;
                    tracesIndex.Add(proceso, new TraceInfoMaster(proceso, tipo, nivel, tiempo));
                    traces.Add(new TraceInfo(fase, mensaje, tiempo, tracesIndex[proceso]));
                    break;
                case Fase.Info:
                    traces.Add(new TraceInfo(fase, mensaje, tiempo, tracesIndex[proceso]));
                    break;
                case Fase.Fin:
                    traces.Add(new TraceInfo(fase, mensaje, tiempo, tracesIndex[proceso]));
                    nivel--;
                    break;
                default:
                    throw new Exception("Invalid Phase");
            }

        }
    }
}
