using Microsoft.VisualStudio.TestTools.UnitTesting;
using TraQkLogger;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
            logger.Iniciar("proceso", Tipo.PS);
            logger.Finalizar("proceso", Tipo.PS);

            var trace = logger.Traces.First();
            Assert.AreEqual("proceso", trace.Proceso);
            Assert.AreEqual(Tipo.PS, trace.Tipo);
            Assert.AreEqual(Fase.Ini, trace.Fase);
            Assert.AreEqual(1, trace.Nivel);

            trace = logger.Traces.Last();
            Assert.AreEqual("proceso", trace.Proceso);
            Assert.AreEqual(Tipo.PS, trace.Tipo);
            Assert.AreEqual(Fase.Fin, trace.Fase);
            Assert.AreEqual(0, trace.Nivel);
        }
    }
}