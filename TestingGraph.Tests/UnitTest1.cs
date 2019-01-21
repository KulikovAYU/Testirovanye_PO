using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestingGraph.Tests
{
    [TestClass]
    public class UnitTest
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
    }

    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public void IntegratedTest1()
        {
            int[,] expression = new int[2, 2];
            expression[0, 0] = 1;

            expression[0, 1] = 1;

            expression[1, 0] = 1;

            expression[1, 1] = 1;
             int[,] mass = new int[1, 2];
             mass[0, 1] = 1;
             mass[0, 0] = 1;
            var mock = new Mock<ICounter>();
       
            mock.Setup(a => a.CountUnits(mass, 0, ETypeControls.eIncidenceMatrixInput, mass.Length)).Returns(2);
            
            algorhytm algo = new algorhytm(mock.Object);
           
            var res = algo.Check(expression, 2);

            //mock.Verify(p=>p.CountUnits(mass, 0, ETypeControls.eIncidenceMatrixInput, mass.Length),Times.Exactly(2));
            mock.VerifyAll();

            Assert.AreEqual(res, true);
        }

      
        /// <summary>
        /// Снятие заглушки
        /// </summary>
        [TestMethod]
        public void IntegratedTest1_removingThePlug()
        {
            int[,] expression = new int[2, 2];
            expression[0, 0] = 1;

            expression[0, 1] = 1;

            expression[1, 0] = 1;

            expression[1, 1] = 1;

            algorhytm algo = new algorhytm();

            bool actual = algo.Check(expression, 2);

            Assert.AreEqual(actual, true);
        }
    }

}
