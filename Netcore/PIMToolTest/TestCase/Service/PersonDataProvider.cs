namespace NUnitTest.TestCase.Service {
    using System;

    using TW.TestTool.Dom;

    public class PersonDataProvider {
	    //return array of Person objects and expected interest revenues corresponding.
	    //format: {Person p, double corresponding interest revenue}.
	    public static Object[] PersonArrayProvider() {
    		
		    //The last parameter in Person constructor is the saving account.
		    //interest rate level 1
		    Person p1 = new Person (1, "Hung", "Nguyen", new DateTime(1980, 1, 1), 1234, 1500);	
		    //interest rate level 2
		    Person p2 = new Person (2, "Bao", "Ho", new DateTime(1981, 1, 1), 2345, 2100);
		    //interest rate level 3
		    Person p3 = new Person (3, "Minh", "Nguyen", new DateTime(1984, 1, 1), 4567, 4100);
		    //interest rate level 4
		    Person p4 = new Person (4, "Can", "Ho", new DateTime(1985, 1, 1), 5678, 6100);
		    //interest rate level 5
		    Person p5 = new Person (5, "Viet", "Vo", new DateTime(1982, 1, 1), 6789, 8100);
		    //interest rate level 6
		    Person p6 = new Person (6, "Tri", "Doan", new DateTime(1985, 1, 1), 7890, 10100);		
    		
		    return new Object[]{
				    new object[] {p1, 180},
				    new object[] {p2, 294},
				    new object[] {p3, 656},
				    new object[] {p4, 1098},
				    new object[] {p5, 1620},
				    new object[] {p6, 2424}
		    };
	    }
    }
}
