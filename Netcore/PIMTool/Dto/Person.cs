/**
 * Class contains personal information like name, salary, tax, bank account.
 */
using System;
namespace TW.TestTool.Dom
{
    public class Person
    {

        private int id;
        private String firstName;
        private String lastName;
        private DateTime dateOfBirth;
        private double monthlySalary;
        private double annualTax;
        private double inheritTax;
        private double annualTaxPercentage;
        private double savingAccount;
        private double interestAvenue;
        private double annualIncome;
        private double totalTax;

        /**
         * Constructor.
         * 
         * @param id
         */
        public Person(int id)
        {
            this.id = id;
        }

        /**
         * Constructor.
         * 
         * @param id
         * @param firstName
         * @param lastName
         * @param dateOfBirth
         * @param monthlySalary
         */
        public Person(int id, String firstName, String lastName, DateTime dateOfBirth,
                double monthlySalary)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.monthlySalary = monthlySalary;
        }

        /**
         * Constructor.
         * 
         * @param id
         * @param firstName
         * @param lastName
         * @param dateOfBirth
         * @param monthlySalary
         */
        public Person(int id, String firstName, String lastName, DateTime dateOfBirth,
                double monthlySalary, double savingAccount)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.monthlySalary = monthlySalary;
            this.savingAccount = savingAccount;
        }

        public String GetFirstName()
        {
            return firstName;
        }
        public void SetFirstName(String firstName)
        {
            this.firstName = firstName;
        }
        public String GetLastName()
        {
            return lastName;
        }
        public void SetLastName(String lastName)
        {
            this.lastName = lastName;
        }
        public DateTime GetDateOfBirth()
        {
            return dateOfBirth;
        }
        public void SetDateOfBirth(DateTime dateOfBirth)
        {
            this.dateOfBirth = dateOfBirth;
        }
        public double GetMonthlySalary()
        {
            return monthlySalary;
        }
        public void SetMonthlySalary(double monthlySalary)
        {
            this.monthlySalary = monthlySalary;
        }

        public double GetAnnualTax()
        {
            return annualTax;
        }

        public void SetAnnualTax(double annualTax)
        {
            this.annualTax = annualTax;
        }

        public double GetInheritTax()
        {
            return inheritTax;
        }

        public void SetInheritTax(double inheritTax)
        {
            this.inheritTax = inheritTax;
        }

        public double GetAnnualTaxPercentage()
        {
            return annualTaxPercentage;
        }

        public void SetAnnualTaxPercentage(double annualTaxPercentage)
        {
            this.annualTaxPercentage = annualTaxPercentage;
        }

        public double GetSavingAccount()
        {
            return savingAccount;
        }

        public void SetSavingAccount(double savingAccount)
        {
            this.savingAccount = savingAccount;
        }

        public double GetInterestAvenue()
        {
            return interestAvenue;
        }

        public void SetInterestAvenue(double interestAvenue)
        {
            this.interestAvenue = interestAvenue;
        }

        public int GetId()
        {
            return id;
        }

        public void SetId(int id)
        {
            this.id = id;
        }

        public double GetAnnualIncome()
        {
            return annualIncome;
        }

        public void SetAnnualIncome(double annualIncome)
        {
            this.annualIncome = annualIncome;
        }

        public double GetTotalTax()
        {
            return totalTax;
        }

        public void SetTotalTax(double totalTax)
        {
            this.totalTax = totalTax;
        }
    }
}