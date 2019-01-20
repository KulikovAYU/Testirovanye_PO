using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestingGraph;
using Moq;

namespace TestingGraph.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1_2_7()
        {
            algorhytm algo = new algorhytm();
            int[,] Arr = new int[1, 1];
            Arr[0, 0] = 0;
            algo.m_VertexCnt = 0;
            int j = 0;
          

            Assert.AreEqual(algo.CountUnits(Arr, j, ETypeControls.eEdgeListInput, algo.m_VertexCnt), 0);
        }

        [TestMethod]
        public void TestMethod1_2_3_7()
        {
            algorhytm algo = new algorhytm();
            int[,] Arr = new int[1, 1];
            Arr[0, 0] = 0; 
            algo.m_VertexCnt = 0;
            int j = 0;
           

            Assert.AreEqual(algo.CountUnits(Arr, j, ETypeControls.eAdjacencyMatrixInput, algo.m_VertexCnt), 0);
        }

        [TestMethod]
        public void TestMethod1_2_3_4_3_7()
        {
            algorhytm algo = new algorhytm();
            int[,] Arr = new int[2, 2];
            Arr[0, 0] = 0;
            Arr[0, 1] = 0;
            Arr[1, 0] = 1;
            Arr[1, 1] = 0;
            algo.m_VertexCnt = 2;
            int j = 1;
           
            Assert.AreEqual(algo.CountUnits(Arr, j, ETypeControls.eAdjacencyMatrixInput, algo.m_VertexCnt), 1);
        }

        [TestMethod]
        public void TestMethod1_2_3_4_5_6_3_7()
        {
            algorhytm algo = new algorhytm();
            int[,] Arr = new int[2, 2];
            Arr[0, 0] = 1;
            Arr[0, 1] = 1;
            Arr[1, 0] = 1;
            Arr[1, 1] = 0;
            algo.m_VertexCnt = 2;
            int j = 1;

            Assert.AreEqual(algo.CountUnits(Arr, j, ETypeControls.eAdjacencyMatrixInput, algo.m_VertexCnt), 1);
        }

       
        [TestMethod]
        public void IntegratedTest21()
        {

            int[,] exp = new int[2, 1];
            exp[0, 0] = 1;
            exp[1, 0] = 1;

            int[,] mass = new int[1, 2];
            mass[0, 1] = 1;
            mass[0, 0] = 1;

            var mock = new Mock<algorhytm>();
            mock.Setup(a => a.CountUnits(mass, 0, ETypeControls.eIncidenceMatrixInput, mass.Length)).Returns(2);
            algorhytm algo = new algorhytm();

            bool actual = algo.Check(exp, 2);

            Assert.AreEqual(actual, true);
        }

        [TestMethod]
        public void IntegratedTest22()
        {
            int[,] exp = new int[2, 2];
            exp[0, 0] = 1;
            exp[1, 0] = 1;
            exp[0, 1] = 1;
            exp[1, 1] = 1;

            int[,] mass = new int[1, 2];
            mass[0, 1] = 1;
            mass[0, 0] = 1;

            var mock = new Mock<algorhytm>();
            mock.Setup(a => a.CountUnits(mass, 0, ETypeControls.eIncidenceMatrixInput, mass.Length)).Returns(2);
            algorhytm algo = new algorhytm();

            bool actual = algo.Check(exp, 4);

            Assert.AreEqual(actual, true);
        }

        [TestMethod]
        public void IntegratedTest23()
        {
            int[,] exp = new int[2, 2];
            exp[0, 0] = 1;
            exp[1, 0] = 1;
            exp[0, 1] = 1;
            exp[1, 1] = 1;

            int[,] mass = new int[1, 2];
            mass[0, 1] = 1;
            mass[0, 0] = 1;

            var mock = new Mock<algorhytm>();
            mock.Setup(a => a.CountUnits(mass, 0, ETypeControls.eAdjacencyMatrixInput, mass.Length)).Returns(2);
            algorhytm algo = new algorhytm();

            bool actual = algo.Check(exp, 3);

            Assert.AreEqual(actual, false);
        }

        [TestMethod]
        public void IntegratedTest24()
        {
            int[,] expression = new int[2, 2];
            expression[0, 0] = 1;

            expression[0, 1] = 1;

            expression[1, 0] = 1;

            expression[1, 1] = 1;

            algorhytm algo = new algorhytm();

            bool actual = algo.Check(expression, 4);

            Assert.AreEqual(actual, true);
        }

        [TestMethod]
        public void IntegratedTest25()
        {
            int[,] expression = new int[2, 2];
            expression[0, 0] = 1;

            expression[0, 1] = 0;

            expression[1, 0] = 1;

            expression[1, 1] = 0;

            algorhytm algo = new algorhytm();

            bool actual = algo.Check(expression, 2);

            Assert.AreEqual(actual, true);
        }

        [TestMethod]
        public void IntegratedTest26()
        {
            int[,] expression = new int[2, 2];
            expression[0, 0] = 1;

            expression[0, 1] = 1;

            expression[1, 0] = 0;

            expression[1, 1] = 0;

            algorhytm algo = new algorhytm();

            bool actual = algo.Check(expression, 2);

            Assert.AreEqual(actual, false);
        }



    }
}
