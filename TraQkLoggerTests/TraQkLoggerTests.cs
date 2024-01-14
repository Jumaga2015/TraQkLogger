using Microsoft.VisualStudio.TestTools.UnitTesting;
using TraQkLogger;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace TraQkLogger.Tests
{
    [TestClass]
    public class TraQkLoggerTests
    {
        private TraQkLogger logger;

        [TestInitialize]
        public void Setup()
        {
            logger = new TraQkLogger();
        }

        [TestMethod]
        public void TestIniciarYFinalizar()
        {
            logger.Iniciar("procesoPS", Tipo.PS, "mensaje");
                logger.AddTrace("procesoBDD", Tipo.BD, Fase.Ini, "mensaje BDD Ini");
                Task.Delay(1000).Wait();
                logger.AddTrace("procesoBDD", Tipo.BD, Fase.Info, "4 recuperados");
                Task.Delay(1000).Wait();
                    logger.AddTrace("procesoWS", Tipo.WS, Fase.Ini, "4 llamadas");
                    logger.AddTrace("procesoWS", Tipo.WS, Fase.Fin, "4 llamadas");
                    Task.Delay(500).Wait();
                logger.AddTrace("procesoBDD", Tipo.BD, Fase.Fin, "mensaje BDD Fin");
            logger.Finalizar("procesoPS", Tipo.PS, "mensaje");

            List<TraceInfo> traces = logger.Traces.ToList();

            var trace = traces.First();
            Assert.AreEqual("proceso", trace.TraceInfoMaster.Proceso);
            Assert.AreEqual(Tipo.PS, trace.TraceInfoMaster.Tipo);
            Assert.AreEqual(Fase.Ini, trace.Fase);
            Assert.AreEqual(1, trace.TraceInfoMaster.Nivel);

            trace = traces.Last();
            Assert.AreEqual("proceso", trace.TraceInfoMaster.Proceso);
            Assert.AreEqual(Tipo.PS, trace.TraceInfoMaster.Tipo);
            Assert.AreEqual(Fase.Fin, trace.Fase);
            Assert.AreEqual(1, trace.TraceInfoMaster.Nivel);
        }
    }
}