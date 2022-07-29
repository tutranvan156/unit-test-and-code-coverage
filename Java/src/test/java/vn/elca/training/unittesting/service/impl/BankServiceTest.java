/*
 * BankServiceTest
 *
 * Project: Hiccup Framework
 *
 * Copyright 2019 by ELCA Informatik AG
 * Steinstrasse 21, CH-8036 Zurich
 * All rights reserved.
 *
 * This software is the confidential and proprietary information
 * of ELCA Informatik AG ("Confidential Information"). You
 * shall not disclose such "Confidential Information" and shall
 * use it only in accordance with the terms of the license
 * agreement you entered into with ELCA.
 */

package vn.elca.training.unittesting.service.impl;

import org.junit.jupiter.api.Test;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.MethodSource;
import vn.elca.training.unittesting.dom.Person;
import vn.elca.training.unittesting.service.IBankService;

import java.util.Date;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;

/**
 * @author qvr
 *
 */
class BankServiceTest {

    /**
     * Method BankServiceImpl.calculateInterestRevenue computes the interest revenue based on the saving account of
     * person. This test case is used to test the correctness of the method.
     */
    @Test
    void testCalculateInterestRevenueWithDifferenceSavingAccountsShouldCorrectly() {
        // 1. Build input data.
        Person person = new Person(1, "Man", "Nguyen", new Date(), 3000, 2000);

        // 2. Build output data.
        double interestRevenueExpected = 280;

        // 3. Execute main test method.
        IBankService bankService = new BankService();
        double interestRevenue = bankService.calculateInterestRevenue(person);

        // 4. Check the result.
        assertEquals(interestRevenueExpected, interestRevenue, "Interest revenue is wrongly calculated");
    }

    @Test
    void testCalculateInterestRevenueWithException() {
        Person person = new Person(1, "Man", "Nguyen", new Date(), 3000, 5);
        Throwable exception = assertThrows(IllegalArgumentException.class, () -> {
            IBankService bankService = new BankService();
            double interestRevenue = bankService.calculateInterestRevenue(person);
        });
        assertEquals("The saving account must be large or equal 10 USD in order to calculate interest revenue by level", exception.getMessage());
    }

    public static Object[][] createTestDataForAllLevel() {
        return new Object[][] {
                {280, new Person(1, "Hoang", "Thi Hau", new Date(), 3000, 2000)},
                {560, new Person(1, "Hoang", "Thi Hau", new Date(), 3000, 4000)},
                {960, new Person(1, "Hoang", "Thi Hau", new Date(), 3000, 6000)},
                {1440, new Person(1, "Hoang", "Thi Hau", new Date(), 3000, 8000)},
                {2000, new Person(1, "Hoang", "Thi Hau", new Date(), 3000, 10000)},
                {2880, new Person(1, "Hoang", "Thi Hau", new Date(), 3000, 12000)},
        };
    }
    @ParameterizedTest
    @MethodSource("createTestDataForAllLevel")
    void testCalculateInterestRevenueForAllLevel(int expect, Person person) {

        IBankService bankService = new BankService();
        double interestRevenue = bankService.calculateInterestRevenue(person);
        assertEquals(expect, interestRevenue);

    }

}
