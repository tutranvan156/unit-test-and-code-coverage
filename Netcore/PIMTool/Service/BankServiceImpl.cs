/**
 * The implementation of {@link BankService}.
 */
using TW.TestTool.Dom;
namespace TW.TestTool.Service.Impl
{
    /**
     * @author qng
     *
     */
    public class BankServiceImpl : IBankService
    {

        private const double INTEREST_RATIO_PER_YEAR = 0.14;

        private const double LEVEL_1 = 2000;
        private const double LEVEL_2 = 4000;
        private const double LEVEL_3 = 6000;
        private const double LEVEL_4 = 8000;
        private const double LEVEL_5 = 10000;

        //Interest ratio for level 1
        private const double INTEREST_LEVEL_1 = 0.12;
        //Interest ratio for level 2
        private const double INTEREST_LEVEL_2 = 0.14;
        //Interest ratio for level 3
        private const double INTEREST_LEVEL_3 = 0.16;
        //Interest ratio for level 4
        private const double INTEREST_LEVEL_4 = 0.18;
        //Interest ratio for level 5
        private const double INTEREST_LEVEL_5 = 0.2;
        //Interest ratio for level 6
        private const double INTEREST_LEVEL_6 = 0.24;

        
        public double CalculateInterestRevenue(Person person)
        {
            double savingAccount = person.GetSavingAccount();
            double result = savingAccount * INTEREST_RATIO_PER_YEAR;
            return result;
        }

        /**
         * Method to calculate interest revenue by level.<br/>
         *   (LEVEL_1)2000  (LEVEL_2)4000 (LEVEL_3)6000	(LEVEL_4)8000 (LEVEL_5)10000            <br/>
         * -------------|-------------|-------------|-------------|-------------|-------------> <br/>
         * --- 0.12 ----><-- 0.14 ----><-- 0.16 ----><-- 0.18 ----><-- 0.2 ----><-- 0.24 ---->  <br/>
         * @param person Person object to calculate.
         * @return interest revenue
         */
        public double CalculateInterestRevenueByLevel(Person person)
        {

            double savingAccount = person.GetSavingAccount();
            double interestRatio = INTEREST_LEVEL_1;

            if (LEVEL_1 < savingAccount && savingAccount <= LEVEL_2)
            {
                interestRatio = INTEREST_LEVEL_2;

            }
            else if (LEVEL_2 < savingAccount && savingAccount <= LEVEL_3)
            {
                interestRatio = INTEREST_LEVEL_3;

            }
            else if (LEVEL_3 < savingAccount && savingAccount <= LEVEL_4)
            {
                interestRatio = INTEREST_LEVEL_4;

            }
            else if (LEVEL_4 < savingAccount && savingAccount <= LEVEL_5)
            {
                interestRatio = INTEREST_LEVEL_5;

            }
            else if (savingAccount > LEVEL_5)
            {
                interestRatio = INTEREST_LEVEL_6;

            }

            return interestRatio * savingAccount;
        }
    }
}