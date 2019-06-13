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

import java.util.Date;

import org.testng.Assert;
import org.testng.annotations.Test;

import vn.elca.training.unittesting.dom.Person;
import vn.elca.training.unittesting.service.IBankService;

/**
 * @author mmn
 *
 */
public class BankServiceTest {

    /**
     * Method BankServiceImpl.calculateInterestRevenue computes the interest revenue based on the saving account of
     * person. This test case is used to test the correctness of the method.
     */
    @Test
    public void calculateInterestRevenueWithDifferenceSavingAccountsShouldCorrectly() {
        // 1. Build input data.
        Person person = new Person(1, "Man", "Nguyen", new Date(), 3000, 2000);

        // 2. Build output data.
        double interestRevenueExpected = 280;

        // 3. Execute main test method.
        IBankService bankService = new BankService();
        double interestRevenue = bankService.calculateInterestRevenue(person);

        // 4. Check the result.
        Assert.assertEquals(interestRevenueExpected, interestRevenue, "Interest revenue is wrongly calculated");
    }
}
