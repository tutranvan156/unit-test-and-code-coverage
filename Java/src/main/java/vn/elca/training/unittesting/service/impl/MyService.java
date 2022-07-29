package vn.elca.training.unittesting.service.impl;

import vn.elca.training.unittesting.dom.TriangleType;

public class MyService {
    public static TriangleType checkTriangle(double a, double b, double c) {
        if(a==b && b==c)
            return TriangleType.EQUILATERAL;
        else if(((a*a)+(b*b))==(c*c) || ((a*a)+(c*c))==(b*b) || ((c*c)+(b*b))==(a*a))
            return TriangleType.RIGHT_ANGLE;
        else if(a==b || c==a || c==b)
            return TriangleType.ISOSCELES;
        else return TriangleType.ERROR;
    }

}
