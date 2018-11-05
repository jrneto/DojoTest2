using System;
using Banco;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace testeContaBancaria
{
    [TestClass]
    public class testeConta
    {
        [TestMethod]
        public void TesteDebito()
        {
            ContaBancaria ba = new ContaBancaria("GEVO SA.", 1000);

            ba.Debito(100);

            Assert.AreEqual(ba.Saldo, 900);

        }
        [TestMethod]
        public void TesteCredito()
        {
            ContaBancaria ba = new ContaBancaria("GEVO SA.", 1000);

            ba.Credito(20);

            Assert.AreEqual(ba.Saldo, 1020);

        }
        [TestMethod]
        public void TesteContaBloqueada()
        {
            ContaBancaria ba = new ContaBancaria("GEVO SA.", 1000, true);
                        
            Assert.IsTrue(ba.Bloqueada);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Conta bloqueada")]
        public void TesteCreditoBloqueada()
        {
            ContaBancaria ba = new ContaBancaria("GEVO SA.", 1000, true);

            ba.Credito(20);

        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Conta bloqueada")]
        public void TesteDebitoBloqueada()
        {
            ContaBancaria ba = new ContaBancaria("GEVO SA.", 1000, false);

            ba.ContaBloqueada();

            ba.Debito(20);
                        
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "valor maior que o saldo")]
        public void TesteDebitoSaldoInsuficiente()
        {
            ContaBancaria ba = new ContaBancaria("GEVO SA.", 100, false);

            ba.Debito(200);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "valor menor que zero")]
        public void TesteDebitoValorMenorZero()
        {
            ContaBancaria ba = new ContaBancaria("GEVO SA.", 100, false);

            ba.Debito(-1);

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "valor menor que zero")]
        public void TesteDebitoValorMenorSaldo()
        {
            ContaBancaria ba = new ContaBancaria("GEVO SA.", 100, false);

            ba.Debito(-1);

        }
    }
}
