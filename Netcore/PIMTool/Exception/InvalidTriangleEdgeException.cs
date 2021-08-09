using System;
namespace TW.TestTool.Exceptions
{
    public class InvalidTriangleEdgeException : Exception
    {


        public InvalidTriangleEdgeException(double a, double b, double c): base("Invalid edges to form a triangle (" + a + ", " + b + ", " + c + ")")
        {
            
        }
    }
}
