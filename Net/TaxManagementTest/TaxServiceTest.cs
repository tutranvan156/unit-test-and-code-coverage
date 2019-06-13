using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using TaxManagement.Dto;
using TaxManagement.External;
using TaxManagement.Interface;
using TaxManagement.Service;

namespace TaxManagementTest
{
    public class TaxServiceTest
    {

        private IBankService m_bankService = null;
        private ITaxService m_taxService = null;

        [SetUp]
        public void FixtureSetup()
        {
            m_taxService = new TaxServiceImpl();
        }

        [Test, Category("Medium")]
        public void TestUpdateAnnualTax()
        {
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
    }
}
