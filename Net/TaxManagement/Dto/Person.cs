using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxManagement.Dto
{
    public class Person
    {

        private int _id;
        private String _firstName;
        private String _lastName;
        private DateTime _dateOfBirth;
        private double _monthlySalary;
        private double _annualTax;
        private double _inheritTax;
        private double _annualTaxPercentage;
        private double _savingAccount;
        private double _interestAvenue;
        private double _annualIncome;
        private double _totalTax;

        /**
         * Constructor.
         * 
         * @param id
         */
        public Person(int id)
        {
            this._id = id;
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
            this._id = id;
            this._firstName = firstName;
            this._lastName = lastName;
            this._dateOfBirth = dateOfBirth;
            this._monthlySalary = monthlySalary;
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
            this._id = id;
            this._firstName = firstName;
            this._lastName = lastName;
            this._dateOfBirth = dateOfBirth;
            this._monthlySalary = monthlySalary;
            this._savingAccount = savingAccount;
        }

        public String GetFirstName()
        {
            return _firstName;
        }
        public void SetFirstName(String firstName)
        {
            this._firstName = firstName;
        }
        public String GetLastName()
        {
            return _lastName;
        }
        public void SetLastName(String lastName)
        {
            this._lastName = lastName;
        }
        public DateTime GetDateOfBirth()
        {
            return _dateOfBirth;
        }
        public void SetDateOfBirth(DateTime dateOfBirth)
        {
            this._dateOfBirth = dateOfBirth;
        }
        public double GetMonthlySalary()
        {
            return _monthlySalary;
        }
        public void SetMonthlySalary(double monthlySalary)
        {
            this._monthlySalary = monthlySalary;
        }

        public double GetAnnualTax()
        {
            return _annualTax;
        }

        public void SetAnnualTax(double annualTax)
        {
            this._annualTax = annualTax;
        }

        public double GetInheritTax()
        {
            return _inheritTax;
        }

        public void SetInheritTax(double inheritTax)
        {
            this._inheritTax = inheritTax;
        }

        public double GetAnnualTaxPercentage()
        {
            return _annualTaxPercentage;
        }

        public void SetAnnualTaxPercentage(double annualTaxPercentage)
        {
            this._annualTaxPercentage = annualTaxPercentage;
        }

        public double GetSavingAccount()
        {
            return _savingAccount;
        }

        public void SetSavingAccount(double savingAccount)
        {
            this._savingAccount = savingAccount;
        }

        public double GetInterestAvenue()
        {
            return _interestAvenue;
        }

        public void SetInterestAvenue(double interestAvenue)
        {
            this._interestAvenue = interestAvenue;
        }

        public int GetId()
        {
            return _id;
        }

        public void SetId(int id)
        {
            this._id = id;
        }

        public double GetAnnualIncome()
        {
            return _annualIncome;
        }

        public void SetAnnualIncome(double annualIncome)
        {
            this._annualIncome = annualIncome;
        }

        public double GetTotalTax()
        {
            return _totalTax;
        }

        public void SetTotalTax(double totalTax)
        {
            this._totalTax = totalTax;
        }
    }
}
