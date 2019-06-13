using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TaxManagement.Dto;
using TaxManagement.Service;

namespace TaxManagementTest
{
    public class BankServiceTest
    {
        /// <summary>
        /// Method BankServiceImpl.CalculateInterestRevenue computes the interest revenue 
        /// based on the saving account of person.
        /// This test case is used to test the correctness of the method.
        /// </summary>
        [Test]
        public void CalculateInterestRevenue_WithDifferenceSavingAccounts_ShouldCorrectly()
        {
            // 1. Build input data.
            Person person = new Person(1, "Nam", "Vu",
                new DateTime(2006, 1, 20), 3000);
            person.SetSavingAccount(2000);

            // 2. Build output data.
            double interestRevenueExpected = 240;

            // 3. Execute main test method.
            BankServiceImpl bankService = new BankServiceImpl();
            double interestRevenue = bankService.CalculateInterestRevenue(person);

            // 4. Check the result. 
            Assert.AreEqual(interestRevenueExpected, interestRevenue,
                "Interest revenue is wrongly calculated");
        }

    }
}
