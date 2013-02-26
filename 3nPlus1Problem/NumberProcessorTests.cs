using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _3nPlus1Problem
{
    [TestClass]
    public class NumberProcessorTests
    {
        private readonly NumberProcessor _numberProcessor = new NumberProcessor();                

        [TestMethod]
        public void TestSet1_10()
        {
            Assert.AreEqual(20, _numberProcessor.CalculateCycleLength(1, 10));
        }

        [TestMethod]
        public void TestSet100_200()
        {
            Assert.AreEqual(125, _numberProcessor.CalculateCycleLength(100, 200));
        }

        [TestMethod]
        public void TestSet201_210()
        {
            Assert.AreEqual(89, _numberProcessor.CalculateCycleLength(201, 210));
        }

        [TestMethod]
        public void TestSet900_1000()
        {
            Assert.AreEqual(174, _numberProcessor.CalculateCycleLength(900, 1000));
        }

        [TestMethod]
        public void TestSet9000_10000()
        {
            Assert.AreEqual(260, _numberProcessor.CalculateCycleLength(9000, 10000));
        }

        [TestMethod]
        public void TestSet90000_100000()
        {
            Assert.AreEqual(333, _numberProcessor.CalculateCycleLength(90000, 100000));
        }

        [TestMethod]
        public void TestSet999900_1000000()
        {
            Assert.AreEqual(259, _numberProcessor.CalculateCycleLength(999900, 1000000));
        }
    }
}
