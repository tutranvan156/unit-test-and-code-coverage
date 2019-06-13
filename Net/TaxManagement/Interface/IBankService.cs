using TaxManagement.Dto;

namespace TaxManagement.Interface
{
    public interface IBankService
    {
        /**
        * Calculating annual interest base on saving account.
        * 
        * @param person
        * @return annual interest cash
        */
        double CalculateInterestRevenue(Person person);
    }
}
