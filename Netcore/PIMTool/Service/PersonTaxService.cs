/**
 * The service to provide personal tax utilities.
 */
using TW.TestTool.Dom;
using System;
namespace TW.TestTool.Service
{


    /**
     * @author qng
     *
     */
    public interface IPersonalTaxService
    {

        /**
         * Calculating annual tax base on monthly salary.
         * 
         * @param person
         * @return annual tax
         */
        double CalculateAnnualTax(Person person);
        Double CalculateAnnualTax1(Person person);

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

        void VoidMethod();
    }
}
