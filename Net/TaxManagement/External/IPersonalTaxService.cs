using System;
using TaxManagement.Dto;

namespace TaxManagement.External
{
    public interface IPersonalTaxService
    {
        /**
        * Calculating annual tax base on monthly salary.
        * 
        * @param person
        * @return annual tax
        */
        double CalculateAnnualTax(Person person);

        /**
         * Calculating annual tax percentage base on annual salary and tax.
         * 
         * @param person
         * @return annual tax percentage (ranging from 0 to 100)
         */
        double CalculateAnnualTaxPercentage(Person person);

        /**
         * Calculating inherit tax base on the amount of inherited money.
         * 
         * @param person
         * @return inherit tax
         * @throws NumberFormatException
         */
        double CalculateInheritTax(Person person);

        /**
         * Consolidate all tax and set to total tax property of person.  
         * 
         * @param person
         */
        void ConsolidateTax(Person person);
    }
}
