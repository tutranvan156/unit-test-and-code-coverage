/**
 * The service to provide user utilities.
 */
using TW.TestTool.Dom;
using System;
namespace TW.TestTool.Service{

    /**
     * @author qng
     *
     */
    public interface TaxService {

	    /**
	     * Update annual tax for input user.
	     * 
	     * @param person
	     * @return user having updated annual tax
	     */
	    Person UpdateAnnualTax(Person person);
    	
	    /**
	     * Update annual tax for default user.
	     * 
	     * @return the default user having updated annual tax.
	     */
	    Person UpdateAnnualTaxDefaultUser();
    	
	    /**
	     * Update inherit tax for input user.
	     * 
	     * @param person
	     * @return user having updated inherit tax
	     */
	    Person UpdateInheritTax(Person person);
    	
	    /**
	     * Update annual tax percentage for input user.
	     * 
	     * @param person
	     * @return user having updated annual tax percentage
	     */
	    Person UpdateAnnualTaxPercentage(Person person);
    	
	    /**
	     * Update annual interest cash for input user.
	     * 
	     * @param person
	     * @return user having updated annual interest cash.
	     */
         Person UpdateInterestAvenue(Person person);
    	
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

        IPersonalTaxService PersonalTaxService{get; set;}
        
        IBankService BankService{get; set;}
    }
}
