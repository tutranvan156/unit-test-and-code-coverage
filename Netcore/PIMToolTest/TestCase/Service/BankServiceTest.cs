using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TW.TestTool.Dom;
using TW.TestTool.Service.Impl;
using NUnit.Framework;
using System.Diagnostics;

namespace NUnitTest.Service {
    using NUnitTest.TestCase.Service;

    public class BankServiceTest {

        /// <summary>
        /// Method BankServiceImpl.CalculateInterestRevenue computes the interest revenue 
        /// based on the saving account of person.
        /// This test case is used to test the correctness of the method.
        /// </summary>
        [Test]
        public void TestCalculateInterestRevenue() {
            // 1. Build input data.
            Person person = new Person(1, "Nam", "Vu",
                                       new DateTime(2006, 1, 20), 1000);
            person.SetSavingAccount(2000);

            // 2. Build output data.
            double interestRevenueExpected = 280;

            // 3. Execute main test method.
            BankServiceImpl bankService = new BankServiceImpl();
            double interestRevenue = bankService.CalculateInterestRevenue(person);

            // 4. Check the result. 
            Assert.AreEqual(interestRevenueExpected, interestRevenue,
                             "Interest revenue is wrongly calculated");
        }
        
        [SetUp]
        public void Init() {
            // init before any test cases 
        }


        [Test]
        public void TestCalculateInterestRevenue1() {
            // 1. Build input data.
            Person person = new Person(1);
            person.SetSavingAccount(2000);

            // 3. Execute main test method.
            BankServiceImpl bankService = new BankServiceImpl();
            double interestRevenue = bankService.CalculateInterestRevenue(person);

            // 4. Check the result. 
            Assert.AreEqual(280, interestRevenue,
                    "Interest revenue is wrongly calculated");
        }


        /// <summary>
        /// Test method BankServiceImpl.CalculateInterestRevenue(Person)} 
        /// with parameters provided from the attribute.
        /// </summary>
        /// <remarks>Parameter must be primitive type</remarks>
        [Test]
        [Category("Slow")]
        [TestCase(1, "Hung", "Nguyen", /*DateTime type can't be used here*/ null, 8000, 2000, 280)]
        [TestCase(2, "Nam", "Vu", /*DateTime type can't be used here*/ null , 8000, 2340, 327.6)]
        public void TestCalculateInterestRevenueParameters(int id, String firstName, String lastName,
                int dateOfBirth, double monthlySalary, double savingAccount, double interestRevenueExpected) {
            // 1. Build input data.
            Person person = new Person(id, firstName, lastName, new DateTime(dateOfBirth), monthlySalary, savingAccount);

            // 2. Execute main test method.
            BankServiceImpl bankService = new BankServiceImpl();
            double interestRevenue = bankService.CalculateInterestRevenue(person);

            // 3. Check the result. 
            Assert.AreEqual(interestRevenueExpected, interestRevenue);
        }


        /// <summary>
        /// Test method BankServiceImpl.CalculateInterestRevenue(Person)} 
        /// with parameters provided from a member of current class .
        /// </summary>
        [Test, Category("TestWithMock")]
        [TestCaseSource("CreatePersonData")]
        public void TestCalculateInterestRevenueDataProvider(Person person,
                double interestRevenueExpected) {

            BankServiceImpl bankService = new BankServiceImpl();

            // 1. Execute main test method.		
            double interestRevenueActual = bankService.CalculateInterestRevenue(person);

            // 2. Check the result. 
            Assert.AreEqual(interestRevenueExpected, interestRevenueActual);
        }


        /// <summary>
        /// Provide person information and saving account.
        /// </summary>
        /// <returns>array of {person information, saving account}</returns>
        public static object[] CreatePersonData() {
            object[] result = new object[] {
                new object[] {new Person(1, "Hung", "Nguyen", new DateTime(1984, 1, 1), 1000, 2340), 327.6},
                new object[] {new Person(2, "Nam", "Vu", new DateTime(1985, 1, 1), 1000, 2000), 280}
            };

            return result;
        }


        /// <summary>
        /// Test method BankServiceImpl.CalculateInterestRevenue(Person)} 
        /// with dataProvided by member named PersonArrayProvider declared in class PersonDataProvider.
        /// </summary>
        [Test]
        [Category("Medium")]
        [TestCaseSource(typeof(PersonDataProvider), "PersonArrayProvider")]
        public void TestCalculateInterestRevenueByLevel(Person person,
                double interestRevenueExpected) {

            BankServiceImpl bankService = new BankServiceImpl();

            // 1. Execute main test method.		
            double interestRevenueActual = bankService.CalculateInterestRevenueByLevel(person);
            // 2. Check the result. 
            Assert.AreEqual(interestRevenueExpected, interestRevenueActual);
        }
    }
}