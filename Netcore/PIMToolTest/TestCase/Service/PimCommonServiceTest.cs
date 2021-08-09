using TW.TestTool.Dom;
using TW.TestTool.Service.Impl;
using NUnit.Framework;
using System;
using TW.TestTool.Exceptions;
using System.Threading;
#pragma warning disable 1591
#pragma warning disable 1591

namespace NUnitTest.Service {
    [TestFixture]
    public class PimCommonServiceTest {
        private PimCommonService m_service;

        [SetUp]
        public void SetUp() {
            m_service = new PimCommonService();
        }


        
        [Test]
        [Culture("en")]
        public void MethodSetUp() {
            Thread.Sleep(3000);
        }


        /// <summary>
        /// Tests the fund correlated.
        /// </summary>
        /// <param name="f1">The fund 1.</param>
        /// <param name="f2">The fund 2.</param>
        /// <param name="result">if set to <c>true</c> [result].</param>
        [Test, TestCaseSource("GetTestFundCorrelatedData")]
        public void TestFundCorrelated(Fund f1, Fund f2, bool result) {
            Assert.AreEqual(result, m_service.IsFundCorrelated(f1, f2), "Fund correlation test");
        }

        protected Object[] GetTestFundCorrelatedData() {
            return new Object[] {
                    new object[] {new Fund(2, 1, 1, 2), new Fund(2, 1.1, 1, 1.2), false},
                    new object[] {new Fund(2, 1, 1.3, 2), new Fund(2, 1.1, 1.31, 1.9), true},
                    new object[] {new Fund(1, 0.5, 4, 1), new Fund(1, 0.5, 3.9, 2), false},
                    new object[] {new Fund(1, 0.5, 3.89, 1.9), new Fund(1, 0.5, 3.9, 2), true}
            };
        }



        [Test, TestCaseSource(nameof(CreateValidTriangleTestData))]
        public void TestValidTriangle(TriangleType type, 
                double a, double b, double c){
            Assert.AreEqual(type, m_service.ClassifyTriangle(a, b, c));   
        }
        /// <summary>
        /// Create valid triangleTestData
        /// </summary>
        /// <returns></returns>
        public static object[] CreateValidTriangleTestData() {
            return new object[] {
                    new object[] {TriangleType.EQUILATERAL, 3, 3, 3},
                    new object[] {TriangleType.EQUILATERAL, 7.5, 7.5, 7.5},
                    new object[] {TriangleType.ISOSCELES, 3, 3, 2},
                    new object[] {TriangleType.ISOSCELES, 13, 13, 20},
                    new object[] {TriangleType.RIGHT_ANGLED, 3, 4, 5},
                    new object[] {TriangleType.RIGHT_ANGLED, 10, 8, 6},
                    new object[] {TriangleType.RIGHT_ANGLED, 12, 9, 15},
                    new object[] {TriangleType.ISOSCELES_RIGHT_ANGLED, Math.Sqrt(7*7+7*7), 7, 7},
                    new object[] {TriangleType.SCALENE, 2, 3, 4},
                    new object[] {TriangleType.SCALENE, 5, 8, 9}
                };
        }
        
        [Test, Category("Fast")]
        [TestCaseSource(nameof(CreateInvalidTriangleTest))]
        public void TestInvalidTriangle(double a, double b, double c) {
            var exception = Assert.Catch(() => m_service.ClassifyTriangle(a, b, c));
            Assert.That(exception,
                Is.TypeOf<InvalidTriangleEdgeException>());
        }

        public static Object[] CreateInvalidTriangleTest() {
            return new Object[] {
               new object[] {1, 2, 3}, 
               new object[] {0, 2, 2}, 
               new object[] {-3, -4, -5}, 
               new object[] {-1, 7, 5}, 
               new object[] {4, 5, 10}, 
               new object[] {999, 0.5, 998.5}}; 
        }

        ////--------------- A pure example of testing expected exception without 
        //// --- using parameter

        [Test]
        public void TestInvalidTriangle(){
            var exception = Assert.Catch(() => m_service.ClassifyTriangle(1, 2, 3));
            Assert.That(exception,
                Is.TypeOf<InvalidTriangleEdgeException>());
        }

        [Test]
        public void TestInvalidTriangleOldStyle() {
            try {
                m_service.ClassifyTriangle(1, 2, 3);
                Assert.Fail(@"Input invalid edges but ClassifyTriangle 
                    does not throw any exception");
            } catch (InvalidTriangleEdgeException) {
                // pass here --> mean successul.
            }
        }
    }
}