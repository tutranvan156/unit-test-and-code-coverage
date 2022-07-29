package vn.elca.training.unittesting.service.impl;

import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.MethodSource;
import vn.elca.training.unittesting.dom.TriangleType;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class MyServiceTest {

    public static Object[][] createValidData() {
        return new Object[][] {
                {TriangleType.EQUILATERAL, 3, 3, 3} ,
                {TriangleType.EQUILATERAL, 3.5, 3.5, 3.5} ,
                {TriangleType.ISOSCELES, 3, 3, 6} ,
                {TriangleType.ISOSCELES, 13, 13, 20} ,
                {TriangleType.RIGHT_ANGLE, 3, 4, 5},
                {TriangleType.ERROR, 7, 8, 9}
        };
    }
    @MethodSource("createValidData")
    @ParameterizedTest
    void testValidTriangle(TriangleType triangleType, double a, double b, double c) {
//        assertEquals(MyService.checkTriangle(a, b, c), triangleType);
        assertEquals(triangleType, MyService.checkTriangle(a, b, c));
    }
}
