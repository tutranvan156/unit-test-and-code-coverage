using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using NUnitTest.Service;

namespace NUnitTest.Suite {
    /// <summary>
    /// This suite test all critical services.
    /// </summary>
    public class CriticalServiceSuite {
        /// <summary>
        /// Define critical services to be tested.
        /// </summary>
        
        public static IEnumerable Suite {
            get {
                ArrayList suite = new ArrayList();
                suite.Add(typeof(BankServiceTest));
                suite.Add(typeof(TaxServiceTest));
                return suite;
            }
        }
    }
}

