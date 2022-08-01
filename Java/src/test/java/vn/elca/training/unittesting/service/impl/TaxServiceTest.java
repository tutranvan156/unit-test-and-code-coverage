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

import org.junit.jupiter.api.*;
import org.mockito.Mockito;
import vn.elca.training.unittesting.dom.Person;
import vn.elca.training.unittesting.service.IPersonTaxService;

import java.util.Date;

import static org.junit.jupiter.api.Assertions.assertThrows;

/**
 * @author qvr
 */
@TestInstance(TestInstance.Lifecycle.PER_CLASS)
class TaxServiceTest {

    private TaxService taxService = null;
    private static final double MIN_INHERIT_TAX = -100;


    @BeforeAll
    void setup() {
        taxService = new TaxService();
    }

    @BeforeEach
    void setupEach() {


    }

    @Test
    @Tag("fast")
    void testUpdateAnnualTax() {
        // 1. Arrange.
        Person person = new Person(1, "Hung", "Nguyen", new Date(), 1000);
        person.setInheritTax(400);
        double mockAnnualTax = 660;

        // 1.1 Create the mock object.
        // Build the behaviour for the fake service personalTaxService
        // If any call to the fake service personalTaxService
        // to calculate tax for the given person, just return dummy 'annualTax'
        // Note: The interface IPersonTaxService has no implementation.
        IPersonTaxService personTaxServiceMock = Mockito.mock(IPersonTaxService.class);

        // 1.2 Record mock object behavior
        // a. Expect behaviour of method calculateAnnualTax of specified person to return value of variable annualTax
        Mockito.when(personTaxServiceMock.calculateAnnualTax(person)).thenReturn(mockAnnualTax);

        // b. Expect behaviour of method consolidateTax of specified person to behave as below.
        Mockito.doNothing().when(personTaxServiceMock).consolidateTax(person);

        // 2. Act
        taxService.setPersonTaxService(personTaxServiceMock);
        Person updatedPerson = taxService.updateAnnualTax(person);

        // 3. Assert.
        //Mockito.verify(personTaxServiceMock);
        Assertions.assertEquals(mockAnnualTax, updatedPerson.getAnnualTax(), "Incorrect Annual Tax");
    }

    //note MIN_INHERIT_TAX = -100
    @Test
    void testUpdateInheritTax() {
        Person person = new Person(1, "Hung", "Nguyen", new Date(), 1000);
        double mockInheritTax = 360;
        IPersonTaxService personTaxServiceMock = Mockito.mock(IPersonTaxService.class);
        Mockito.when(personTaxServiceMock.calculateInheritTax(person)).thenReturn(mockInheritTax);
        Mockito.doNothing().when(personTaxServiceMock).consolidateTax(person);
        taxService.setPersonTaxService(personTaxServiceMock);
        Person personUpdateInheriteTax = taxService.updateInheritTax(person);
        Assertions.assertEquals(mockInheritTax, personUpdateInheriteTax.getInheritTax(), "Incorrect Inherited tax");
    }

    @Test
    void testUpdateInheritTaxWithException() {
        Person person = new Person(1, "Hung", "Nguyen", new Date(), 1000);
        double mockInheritTax = -200;
        IPersonTaxService personTaxServiceMock = Mockito.mock(IPersonTaxService.class);
        Mockito.when(personTaxServiceMock.calculateInheritTax(person)).thenReturn(mockInheritTax);
        Mockito.doNothing().when(personTaxServiceMock).consolidateTax(person);
        taxService.setPersonTaxService(personTaxServiceMock);

        Throwable exception = assertThrows(IllegalArgumentException.class, () -> {
            Person personUpdateInheriteTax = taxService.updateInheritTax(person);
        });
        Assertions.assertEquals("inheriteTax must larger than equal " + MIN_INHERIT_TAX, exception.getMessage());
    }

    @Test
    void testUpdateAnnualTaxPercentage() {
        Person person = new Person(1, "Hung", "Nguyen", new Date(), 1000);
        double mockAnnualTaxPercentage = 20;
        double mockAnnualTax = 300;
        IPersonTaxService personTaxServiceMock = Mockito.mock(IPersonTaxService.class);

        Mockito.when(personTaxServiceMock.calculateAnnualTax(person)).thenReturn(mockAnnualTax);
        Mockito.when(personTaxServiceMock.calculateAnnualTaxPercentage(person)).thenReturn(mockAnnualTaxPercentage);

        Mockito.doNothing().when(personTaxServiceMock).consolidateTax(person);

        taxService.setPersonTaxService(personTaxServiceMock);


        person = taxService.updateAnnualTaxPercentage(person);
        Assertions.assertEquals(person, taxService.updateAnnualTaxPercentage(person));
    }
}
