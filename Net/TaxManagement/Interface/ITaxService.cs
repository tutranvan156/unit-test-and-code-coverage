using System;
using TaxManagement.Dto;
using TaxManagement.External;
using TaxManagement.Service;

namespace TaxManagement.Interface
{
    public interface ITaxService
    {
        /**
        * Update annual tax for input user.
        * 
        * @param person
        * @return user having updated annual tax
        */
        Person UpdateAnnualTax(Person person);

        /**
	     * Update inherit tax for input user.
	     * 
	     * @param person
	     * @return user having updated inherit tax
	     */
        Person UpdateInheritTax(Person person);

        /**
	     * Update default user information with input data.
	     * 
	     * @param firstName
	     * @param lastName
	     * @param dateOfBirth
	     * @param monthlySalary
	     * @return the default user with updated data.
	     * @throws NullPointerException
	     */
        Person UpdateDefaultUserInformation(String firstName, String lastName,
            DateTime dateOfBirth, double monthlySalary);

        /**
	     * Calculate and update annual income for input user.s 
	     * @param person
	     * @return user having updated annual income.
	     */
        Person UpdateAnnualIncome(Person person);

        IPersonalTaxService PersonalTaxService { get; set; }

        IBankService BankService { get; set; }

    }
}
