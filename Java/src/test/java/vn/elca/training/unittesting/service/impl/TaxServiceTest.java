/*
 * TaxServiceTest
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

import static org.easymock.EasyMock.createMock;
import static org.easymock.EasyMock.expect;
import static org.easymock.EasyMock.expectLastCall;
import static org.easymock.EasyMock.replay;
import static org.easymock.EasyMock.verify;

import java.util.Date;

import org.testng.Assert;
import org.testng.annotations.BeforeClass;
import org.testng.annotations.Test;

import vn.elca.training.unittesting.dom.Person;
import vn.elca.training.unittesting.service.IBankService;
import vn.elca.training.unittesting.service.IPersonTaxService;

/**
 * @author mmn
 *
 */
public class TaxServiceTest {

    private IBankService bankService = null;
    private TaxService taxService = null;

    @BeforeClass
    public void setup() {
        taxService = new TaxService();
    }

    @Test
    public void testUpdateAnnualTax() {
        // 1. Arrange.
        Person person = new Person(1, "Hung", "Nguyen", new Date(), 1000);
        person.setInheritTax(400);
        double mockAnnualTax = 660;

        // 1.1 Create the mock object.
        // Build the behaviour for the fake service personalTaxService
        // If any call to the fake service personalTaxService
        // to calculate tax for the given person, just return dummy 'annualTax'
        // Note: The interface IPersonTaxService has no implementation.
        IPersonTaxService personTaxServiceMock = createMock(IPersonTaxService.class);


        // 1.2 Record mock object behavior
        // a. Expect behaviour of method calculateAnnualTax of specified person to return value of variable annualTax
        expect(personTaxServiceMock.calculateAnnualTax(person)).andReturn(mockAnnualTax);

        // b. Expect behaviour of method consolidateTax of specified person to behave as below.
        personTaxServiceMock.consolidateTax(person);
        expectLastCall().once();

        // 2. Act
        replay(personTaxServiceMock);
        taxService.setPersonTaxService(personTaxServiceMock);
        Person updatedPerson = taxService.updateAnnualTax(person);

        // 3. Assert.
        verify(personTaxServiceMock);
        Assert.assertEquals(mockAnnualTax, updatedPerson.getAnnualTax(), "Incorrect Annual Tax");
    }
}
