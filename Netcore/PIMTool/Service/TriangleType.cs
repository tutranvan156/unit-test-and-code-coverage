namespace TW.TestTool.Service.Impl
{

    public enum TriangleType
    {
        /** Equilateral: all the sides have equal lengths */
        EQUILATERAL,
        /** two sides have equal length, but not all three*/
        ISOSCELES,
        /** one angle is a right angle, excluding isosceles*/
        RIGHT_ANGLED,
        /** One angle is a right angle, and 2 sides are equals*/
        ISOSCELES_RIGHT_ANGLED,
        /** All the lengths are unequal, excluding right-angled*/
        SCALENE,
        /** the three lengths cannot be used to form a triangle, 
         *  or form only a flat line, Invalid the number of lengths is wrong, 
         *  a length is not numeric, or a length is out of range*/
        IMPOSSIBLE
    }
}
