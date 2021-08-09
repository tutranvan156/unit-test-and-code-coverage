/**
 * The service to provide banking utilities. 
 */
using TW.TestTool.Dom;
namespace TW.TestTool.Service
{

    /**
     * @author qng
     *
     */
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