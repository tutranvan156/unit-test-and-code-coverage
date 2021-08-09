/**
 * The implementation of {@link SimpleService}.
 */
using TW.TestTool.Dom;
using System;
namespace TW.TestTool.Service.Impl {
    public class TaxServiceImpl : TaxService {

        private const double MIN_INHERIT_TAX = -100;
        private IPersonalTaxService m_personalTaxService = null;
        private IBankService m_bankService = null;
        private Person m_defaultUser = null;

        /**
         * Default constructor.
         */
        public TaxServiceImpl() {
            m_defaultUser = new Person(1);
        }


        public Person UpdateAnnualTax(Person person) {
            if (person != null) {
                double annualTax = m_personalTaxService.CalculateAnnualTax(person);
                person.SetAnnualTax(annualTax);
                m_personalTaxService.ConsolidateTax(person);
            }

            return person;
        }



        public Person UpdateAnnualTaxDefaultUser() {
            Person person = UpdateAnnualTax(m_defaultUser);
            return person;
        }


        public Person UpdateInheritTax(Person person) {
            if (person != null) {
                double inheriteTax = m_personalTaxService.CalculateInheritTax(person);
                if (inheriteTax < MIN_INHERIT_TAX) {
                    person.SetInheritTax(inheriteTax / 2);
                    inheriteTax = m_personalTaxService.CalculateInheritTax(person);
                }

                if (inheriteTax < MIN_INHERIT_TAX) {
                    person.SetInheritTax(inheriteTax);
                    inheriteTax = m_personalTaxService.CalculateInheritTax(person);
                }

                person.SetInheritTax(inheriteTax);
            }

            return person;
        }


        public Person UpdateAnnualTaxPercentage(Person person) {
            if (person != null) {
                double annualTax = m_personalTaxService.CalculateAnnualTax(person);
                person.SetAnnualTax(annualTax);

                double annualTaxPercentage = m_personalTaxService.CalculateAnnualTaxPercentage(person);
                person.SetAnnualTaxPercentage(annualTaxPercentage);
            }

            return person;
        }


        public Person UpdateInterestAvenue(Person person) {
            if (person != null) {
                double interestAvenue = m_bankService.CalculateInterestRevenue(person);
                person.SetInterestAvenue(interestAvenue);
            }

            return person;
        }


        public Person UpdateDefaultUserInformation(String firstName, String lastName,
                DateTime dateOfBirth, double monthlySalary) {

            m_defaultUser.SetFirstName(firstName);
            m_defaultUser.SetLastName(lastName);
            m_defaultUser.SetDateOfBirth(dateOfBirth);
            m_defaultUser.SetMonthlySalary(monthlySalary);

            return m_defaultUser;
        }


        public Person UpdateAnnualIncome(Person person) {
            if (person != null) {
                // Calculate income.
                double interestAvenue = m_bankService.CalculateInterestRevenue(person);

                // Calculate outcome.
                double annualTax = m_personalTaxService.CalculateAnnualTax(person);

                double annualIncome = person.GetMonthlySalary() * 12 + interestAvenue - annualTax;

                person.SetAnnualIncome(annualIncome);
            }

            return person;
        }

        public IPersonalTaxService PersonalTaxService {
            get {
                return m_personalTaxService;
            }

            set {
                m_personalTaxService = value;
            }
        }

        public IBankService BankService {
            get {
                return m_bankService;
            }

            set {
                m_bankService = value;
            }
        }
    }
}