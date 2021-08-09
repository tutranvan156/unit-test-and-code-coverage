using TW.TestTool.Dom;
using TW.TestTool.Service.Impl;
using NUnit.Framework;
using System.Diagnostics;
using TW.TestTool.Service;
using System;
using NSubstitute;
using NSubstitute.Extensions;

namespace NUnitTest.Service {
    [TestFixture]
    public class TaxServiceTest {

        private IBankService m_bankService = null;
        private TaxService m_taxService = null;

        [SetUp]
        public void FixtureSetup() {
            m_taxService = new TaxServiceImpl();
        }

        /// <summary>
        /// This method will be invoked when this test is instantiated
        /// </summary>

        [SetUp]
        public void MethodSetUp() {
        }

        [TearDown]
        public void MethodTearDown() {
        }


        /// <summary>
        /// Test method {@link SimpleServiceImpl#updateDefaultUserInformation(String, String, Date, double)} 
        /// successfully.
        /// </summary>
        [Test, Category("TestWithoutMock")]
        public void TestUpdateDefaultUserInformation() {
            // 1. Build input data.
            String firstName = "Nam";
            String lastName = "Vu";
            DateTime dateOfBirth = new DateTime(1985, 10, 10);
            double monthlySalary = 800;

            // 2. Execute main test method.
            Person updatedPerson =
                m_taxService.UpdateDefaultUserInformation(firstName,
                        lastName, dateOfBirth, monthlySalary);
            
            // 3. Check the result. 
            Assert.AreEqual(monthlySalary, updatedPerson.GetMonthlySalary(), "Salary is not correct");
            Assert.IsNotNull(updatedPerson.GetFirstName(), "First name is not updated");
        }


        /// <summary>
        /// Tests the method to update annual tax.
        /// </summary>
        [Test, Category("Medium")]
        public void TestUpdateAnnualTax() {
            // 1. Arrange. 
            Person person = new Person(1, "Hung", "Nguyen", new DateTime(1984, 9, 10), 1000);
            person.SetInheritTax(400);
            double mockAnnualTax = 660;
            double expectedTotalTax = 1060;

            // 1.1 Create the mock object. 
            // Build the behaviour for the fake service personalTaxService 
            // If any call to the fake service personalTaxService
            // to calculate tax for the given person, just return dummy 'annualTax'
            // Note: The interface PersonalTaxService has no implementation.

            var perTaxServMock = Substitute.For<IPersonalTaxService>();
            
            // 1.2 Record mock object behavior
            // a. Expect behaviour of method CalculateAnnualTax of 
            // specified person to return value of variable annualTax

            perTaxServMock.CalculateAnnualTax(person).Returns(mockAnnualTax);

            // b. Expect behaviour of method ConsolidateTax of
            // specified person to behave as below.
            perTaxServMock.When(x => x.ConsolidateTax(person)).Do(x => {
                double annualTax = person.GetAnnualTax();
                double inheritTax = person.GetInheritTax();
                person.SetTotalTax(inheritTax + annualTax);
            });
            // 2. Act
            m_taxService.PersonalTaxService = perTaxServMock;
            Person updatedPerson = m_taxService.UpdateAnnualTax(person);

            // 3. Assert. 

            perTaxServMock.Received().ConsolidateTax(person);
            Assert.AreEqual(mockAnnualTax, updatedPerson.GetAnnualTax(), "Incorrect Annual Tax");
            Assert.AreEqual(expectedTotalTax, updatedPerson.GetTotalTax(), "Incorrect Total Tax");
            
        }

        ///// <summary>
        ///// Consolidates the tax.
        ///// </summary>
        ///// <param name="person">The person.</param>
        //private void ConsolidateTax(Person person) {
        //    double annualTax = person.GetAnnualTax();
        //    double inheritTax = person.GetInheritTax();
        //    person.SetTotalTax(inheritTax + annualTax);
        //}


        ///// <summary>
        ///// Tests the method to update annual tax default user.
        ///// </summary>
        //[Test, Category("Fast")]
        //public void TestUpdateAnnualTaxDefaultUser() {
        //    // 1. Arrange
        //    var personalTaxServiceMock = MockRepository.GenerateStrictMock<IPersonalTaxService>();

        //    // Build input data.
        //    Person person = new Person(1, "Nam", "Vu", new DateTime(1984, 7, 14), 1000);

        //    // Build output data.
        //    double annualTax = 660;

        //    // Add mock objects behavior.
        //    personalTaxServiceMock.Expect(srv => srv.CalculateAnnualTax(person))
        //        .Constraints(Rhino.Mocks.Constraints.Is.Matching<Person>(
        //            delegate(Person actualPerson) {
        //                return IsSamePerson(person, actualPerson);
        //            }
        //         ))
        //        .Return(annualTax);

        //    personalTaxServiceMock.Expect(srv => srv.ConsolidateTax(person))
        //        .Constraints(Rhino.Mocks.Constraints.Is.Matching<Person>(
        //            delegate(Person actualPerson) {
        //                return IsSamePerson(person, actualPerson);
        //            }
        //         ));


        //    // 2. Act
        //    m_taxService.PersonalTaxService = personalTaxServiceMock;
        //    Person updatedPerson = m_taxService.UpdateAnnualTaxDefaultUser();

        //    // 3. Assert.
        //    Assert.AreEqual(updatedPerson.GetAnnualTax(), annualTax);

        //    personalTaxServiceMock.VerifyAllExpectations();
        //}


        ///// <summary>
        ///// Determines whether person A & person B is the same.
        ///// </summary>
        ///// <param name="personA">The person A.</param>
        ///// <param name="personB">The person B.</param>
        ///// <returns>
        ///// 	<c>true</c> if person A & B is the same person.
        ///// </returns>
        //private bool IsSamePerson(Person personA, Person personB) {
        //    return personA.GetId() == personB.GetId();
        //}

        
        ///// <summary>
        ///// Tests the method to update inherit tax throws format exception.
        ///// </summary>
        ////[Test, Category("Fast"), ExpectedException(typeof(FormatException))]
        //public void TestUpdateInheritTaxThrowsFormatException() {
        //    // 1. Arrange.
        //    var perTaxServiceMock = MockRepository.GenerateStrictMock<IPersonalTaxService>();

        //    // Build input data.
        //    Person person = new Person(1, "Nam", "Vu", new DateTime(1984, 7, 14), 1000);

        //    // Build output data.
        //    FormatException numberFormatException = new FormatException();

        //    // Add mock objects behavior.
        //    perTaxServiceMock.Expect(srv => srv.CalculateInheritTax(person)).Throw(numberFormatException);

        //    // 2. Act
        //    m_taxService.PersonalTaxService = perTaxServiceMock;
        //    try {
        //        m_taxService.UpdateInheritTax(person);
        //    } finally {
        //        perTaxServiceMock.VerifyAllExpectations();
        //    }
        //} 

        ///// <summary>
        ///// Tests the method to update inherit tax throws format exception.
        ///// </summary>
        //[Test, Category("Fast")]
        //public void TestUpdateInheritTax() {

        //    // 1. Arrange
        //    IPersonalTaxService perTaxServiceMock = MockRepository.GenerateStrictMock<IPersonalTaxService>();

        //    // Build input data.
        //    Person person = new Person(1, "Nam", "Vu", new DateTime(1984, 7, 14), 1000);

        //    // Build output data.
        //    FormatException numberFormatException = new FormatException();

        //    // Add mock objects behavior.
        //    perTaxServiceMock.Expect(srv => srv.CalculateInheritTax(person)).Return(-110);
        //    perTaxServiceMock.Expect(srv => srv.CalculateInheritTax(person)).Return(-100);

        //    // 2. Act
        //    m_taxService.PersonalTaxService = perTaxServiceMock;
        //    m_taxService.UpdateInheritTax(person);

        //    // 3. Assert
        //    perTaxServiceMock.VerifyAllExpectations();
        //}

        //#region ForTraining
        
        ///// <summary>
        ///// Tests the method to update annual tax.
        ///// </summary>
        //// [Test, Category("Medium")]

        ////public void TestUpdateAnnualTax() {
        ////    // 1. Arrange

        ////    // Build output data.
        ////    double mockAnnualTax = 660;

        ////    // ...

        ////    // Add mock object's behavior.
        ////    perTaxServMock.Expect(srv => srv.CalculateAnnualTax(person)).Return(mockAnnualTax);

        ////    // ...


        ////    // 2. Act 
        ////    m_taxService.PersonalTaxService = perTaxServMock;
        ////    Person updatedPerson = m_taxService.UpdateAnnualTax(person);

        ////    // 3. Assert. 
        ////    Assert.AreEqual(mockAnnualTax, updatedPerson.GetAnnualTax(), "Incorrect Annual Tax");
        ////    Assert.AreEqual(expectedTotalTax, updatedPerson.GetTotalTax(), "Incorrect Total Tax");
         
        ////    perTaxServMock.VerifyAllExpectations();
        ////}

        ////public void TestUpdateAnnualTaxDefaultUser() {
        ////    // ...

        ////    // Add mock objects behavior.
        ////    personalTaxServiceMock.Expect(srv => srv.CalculateAnnualTax(person))
        ////        .Constraints(Rhino.Mocks.Constraints.Is.Matching<Person>(
        ////            delegate(Person actualPerson) {
        ////                return IsSamePerson(person, actualPerson);
        ////            }
        ////         ))
        ////        .Return(annualTax);

        ////    //...
        ////}

        ////private bool IsSamePerson(Person personA, Person personB) {
        ////    return personA.GetId() == personB.GetId();
        ////}
        
        //#endregion ForTraining
    }

}

